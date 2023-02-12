using GachaCore;
using GachaCore.Model;
using System.Diagnostics;

namespace GachaCoreUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public List<Pool> PoolList { get; set; } = new();
        public List<Category> CategoryList { get; set; } = new();
        public List<GachaItem> GachaItemList { get; set; } = new();
        public Pool CurrentPool { get; set; } = new();
        public Category CurrentCategory { get; set; } = new();
        public GachaItem CurrentGachaItem { get; set; } = new();
        public static MainForm Instance { get; set; } = null;
        public bool EditPoolFlag { get; set; }
        public bool EditCategoryFlag { get; set; }
        public bool EditGachaItemFlag { get; set; }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Instance = this;
            EditPoolFlag = false;
            SQLHelper.CreateDatabase();
            ReloadPool();
            PoolListBox.SelectedIndex = PoolListBox.Items.Count > 0 ? 0 : -1;
            LanguagePackage.LoadLanguagePackage("zh-CN");
            LanguagePackage.ApplyLanguagePackage(this, LanguagePackage.CurrentLanguage);
        }

        private void LoadPoolList()
        {
            PoolListBox.Items.Clear();
            PoolList.ForEach(x => PoolListBox.Items.Add(x.Name));
        }

        private void LoadCategoryList()
        {
            CategoryListBox.Items.Clear();
            CategoryList.ForEach(x => CategoryListBox.Items.Add($"{(x.IsBaodi ? "[Up] " : "")}{x.Name}"));
        }

        private void LoadPoolProperty()
        {
            var poolType = CurrentPool.GetType().GetProperties();

            foreach (var item in poolType)
            {
                string name = $"Pool_{item.Name}Value";
                var textbox = Controls.Find(name, true);
                if (textbox == null || textbox.Length != 1 || textbox[0] is not TextBox) continue;
                textbox[0].Text = item.GetValue(CurrentPool).ToString();
            }
        }

        private void LoadCategoryProperty()
        {
            var categoryType = CurrentCategory.GetType().GetProperties();

            foreach (var item in categoryType)
            {
                string name = $"Category_{item.Name}Value";
                var control = Controls.Find(name, true);
                if (control != null && control.Length == 1 && control[0] is TextBox)
                {
                    control[0].Text = item.GetValue(CurrentCategory).ToString();
                }
                else if (name.StartsWith("Category_IsBaodi"))
                {
                    (control[0] as CheckBox).Checked = bool.Parse(item.GetValue(CurrentCategory).ToString());
                }
            }
        }

        private void PoolListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PoolListBox.SelectedIndex == -1)
            {
                return;
            }
            if (EditPoolFlag && !ShowConfirm("当前存在未保存的更改，确认切换卡池吗？"))
            {
                EditPoolFlag = false;
                PoolListBox.SelectedIndex = PoolList.IndexOf(CurrentPool);
                EditPoolFlag = true;
                return;
            }
            EditPoolFlag = false;
            CurrentPool = PoolList[PoolListBox.SelectedIndex];
            LoadPoolProperty();
        }

        private void PoolAddBtn_Click(object sender, EventArgs e)
        {
            if (PoolList.Any(x => x.Name == CurrentPool.Name))
            {
                if (ShowConfirm("存在同名卡池，确认要重复添加吗？") is false)
                {
                    return;
                }
            }
            CurrentPool = CurrentPool.AddPool();
            EditPoolFlag = false;
            ReloadPool();
            ShowInfo("ok");
        }

        private void PoolEditBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentPool.ID))
            {
                ShowError("当前项目请先点新建或添加");
                return;
            }
            CurrentPool.UpdatePool();
            EditPoolFlag = false;
            ReloadPool();
            ShowInfo("ok");
        }

        private void PoolDeleteBtn_Click(object sender, EventArgs e)
        {
            if (ShowConfirm("确认要删除此卡池吗？") is false)
            {
                return;
            }
            CurrentPool.DeletePool();
            PoolListBox.SelectedIndex = -1;
            ShowInfo("ok");
        }

        private void ReloadPool()
        {
            PoolList = Pool.GetAllPools();
            LoadPoolList();
            LoadPoolProperty();
        }

        private void ReloadGachaItems()
        {
            GachaItemList = CurrentCategory.CreateGachaItemList();
            LoadGachaItemList();
            LoadGachaItemProperty();
        }

        private void LoadGachaItemList()
        {
            GachaItemListBox.Items.Clear();
            GachaItemList.ForEach(x => GachaItemListBox.Items.Add($"{(x.IsUP ? "[Up] " : "")}{x.Name}"));
        }

        private void ReloadCategory()
        {
            EditCategoryFlag = false;
            CategoryList = CurrentPool.CreateCategoryList();
            LoadCategoryList();
            LoadCategoryProperty();
        }

        private void ShowError(string msg)
        {
            MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowInfo(string msg)
        {
            MessageBox.Show(msg, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ShowConfirm(string msg)
        {
            return MessageBox.Show(msg, "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
        }

        private void Pool_Property_Changed(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string name = textBox.Name.Replace("Pool_", "");

            var poolType = CurrentPool.GetType().GetProperty(name.Substring(0, name.Length - "Value".Length));
            if (!EditPoolFlag)
            {
                EditPoolFlag = poolType.GetValue(CurrentPool).ToString() != textBox.Text;
            }
            try
            {
                switch (poolType.PropertyType.Name)
                {
                    case "Int32":
                        poolType.SetValue(CurrentPool, int.Parse(textBox.Text));
                        break;
                    case "String":
                        poolType.SetValue(CurrentPool, textBox.Text);
                        break;
                    case "DateTime":
                        poolType.SetValue(CurrentPool, DateTime.Parse(textBox.Text));
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                ShowError($"数值转换失败：{poolType.Name}");
                textBox.Text = poolType.GetValue(CurrentPool).ToString();
                textBox.Focus();
            }
        }

        private void Category_PropertyChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string name = textBox.Name.Replace("Category_", "");

            var categoryType = CurrentCategory.GetType().GetProperty(name[..^"Value".Length]);
            if (!EditCategoryFlag)
            {
                EditCategoryFlag = categoryType.GetValue(CurrentCategory).ToString() != textBox.Text;
            }
            try
            {
                switch (categoryType.PropertyType.Name)
                {
                    case "Double":
                        categoryType.SetValue(CurrentCategory, double.Parse(textBox.Text));
                        break;
                    case "String":
                        categoryType.SetValue(CurrentCategory, textBox.Text);
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                ShowError($"数值转换失败：{categoryType.Name}");
                textBox.Text = categoryType.GetValue(CurrentCategory).ToString();
                textBox.Focus();
            }
        }

        private void GachaItem_MainImgBtn_Click(object sender, EventArgs e)
        {
            ShowFileDialog(GachaItem_MainImagePathValue);
        }

        private void GachaItem_BackgroundImgBtn_Click(object sender, EventArgs e)
        {
            ShowFileDialog(GachaItem_BackgroundImagePathValue);
        }

        private void Pool_NewPicImgBtn_Click(object sender, EventArgs e)
        {
            ShowFileDialog(Pool_NewPicPathValue);
        }

        private void Pool_RelativePathBtn_Click(object sender, EventArgs e)
        {
            Pool_RelativePathValue.Focus();
            if (DirectoryDialog.ShowDialog(this) == DialogResult.OK)
            {
                Pool_RelativePathValue.Text = DirectoryDialog.SelectedPath;
                FileDialog.InitialDirectory = DirectoryDialog.SelectedPath;
            }
        }

        private void Pool_BackPicImgBtn_Click(object sender, EventArgs e)
        {
            ShowFileDialog(Pool_BackgroundImagePathValue);
        }

        private void Pool_PluginPathBtn_Click(object sender, EventArgs e)
        {
            FileDialog.Filter = "插件文件|*.dll|所有文件|*.*";
            ShowFileDialog(Pool_PluginPathValue);
            FileDialog.Filter = "PNG 图片|*.png|JPG 图片|*.jpg|所有文件|*.*";
        }

        private void ShowFileDialog(TextBox targetTextBox)
        {
            targetTextBox.Focus();
            if (FileDialog.ShowDialog(this) == DialogResult.OK)
            {
                targetTextBox.Text = FileDialog.FileName.Replace(FileDialog.InitialDirectory + "\\", "");
                FileDialog.FileName = "";
                targetTextBox.Focus();
            }
        }

        private void Pool_DrawConfigBtn_Click(object sender, EventArgs e)
        {
            PoolDrawConfigEditForm form = new();
            form.ShowDialog(this);
            if (form.SaveFlag)
            {
                CurrentPool.PoolDrawConfig = form.DrawConfig;
            }
        }

        private void PoolNewBtn_Click(object sender, EventArgs e)
        {
            if (EditPoolFlag && !ShowConfirm("当前存在未保存的更改，确认新建吗？"))
            {
                return;
            }
            EditPoolFlag = false;
            PoolListBox.SelectedIndex = -1;
            CurrentPool = new();
            LoadPoolProperty();
        }

        private void PoolReloadBtn_Click(object sender, EventArgs e)
        {
            int index = PoolList.IndexOf(CurrentPool);
            ReloadPool();
            PoolListBox.SelectedIndex = index;
        }

        private void PoolCategoryBtn_Click(object sender, EventArgs e)
        {
            ModeSelector.SelectedIndex = 1;
        }

        private void PoolSingleTestBtn_Click(object sender, EventArgs e)
        {
            var r = CurrentPool.CallGacha(1);
            var img = CurrentPool.DrawGachaImage(r);
            img.Save("1.png");
            ShowInfo("保存完成");
        }

        private void PoolMultiTestBtn_Click(object sender, EventArgs e)
        {
            var r = CurrentPool.CallGacha(CurrentPool.MultiGachaNumber);
            var img = CurrentPool.DrawGachaImage(r);
            img.Save("1.png");
            ShowInfo("保存完成");
        }

        private void Pool_BackgroundImagePathValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                Pool_BackPicImgBtn.PerformClick();
            }
        }

        private void Pool_NewPicPathValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                Pool_NewPicImgBtn.PerformClick();
            }
        }

        private void ModeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ModeSelector.SelectedIndex)
            {
                case 1:
                    CategoryStatusDisplay.Text = $"当前卡池：{CurrentPool.Name}";
                    ReloadCategory();
                    CategoryListBox.SelectedIndex = CategoryListBox.Items.Count > 0 ? 0 : -1;
                    break;
                case 2:
                    if(CategoryListBox.SelectedIndex == -1)
                    {
                        ShowInfo("请先选择一个目录");
                        return;
                    }
                    GachaItemStatusDisplay.Text = $"当前卡池：{CurrentPool.Name} - {CurrentCategory.Name}";
                    ReloadGachaItems();
                    GachaItemListBox.SelectedIndex = GachaItemListBox.Items.Count > 0 ? 0 : -1;
                    break;
            }
        }

        private void PoolListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                PoolDeleteBtn.PerformClick();
            }
            else if (e.KeyCode == Keys.C && e.Control)
            {
                PoolCopyBtn.PerformClick();
            }
        }

        private void PoolCopyBtn_Click(object sender, EventArgs e)
        {
            if (EditPoolFlag && !ShowConfirm("当前存在未保存的更改，确认复制吗？"))
            {
                return;
            }
            EditPoolFlag = false;
            PoolListBox.SelectedIndex = -1;
            CurrentPool = new()
            {
                Name = CurrentPool.Name,
                RelativePath = CurrentPool.RelativePath,
                PluginPath = CurrentPool.PluginPath,
                BackgroundImagePath = CurrentPool.BackgroundImagePath,
                NewPicPath = CurrentPool.NewPicPath,
                NewPicWidth = CurrentPool.NewPicWidth,
                NewPicHeight = CurrentPool.NewPicHeight,
                NewPicX = CurrentPool.NewPicX,
                NewPicY = CurrentPool.NewPicY,
                SingleGachaText = CurrentPool.SingleGachaText,
                MultiGachaText = CurrentPool.MultiGachaText,
                Remark = CurrentPool.Remark,
                SingleGachaOrder = CurrentPool.SingleGachaOrder,
                MultiOrder = CurrentPool.MultiOrder,
                MultiGachaNumber = CurrentPool.MultiGachaNumber,
                PerGachaCost = CurrentPool.PerGachaCost,
                BaodiCount = CurrentPool.BaodiCount,
                CategoryList = CurrentPool.CategoryList,
                PoolDrawConfig = CurrentPool.PoolDrawConfig.Clone(),
                ItemDrawConfig = CurrentPool.ItemDrawConfig.Clone(),
            };
            LoadPoolProperty();
        }

        private void CategoryNewBtn_Click(object sender, EventArgs e)
        {
            if (EditCategoryFlag && !ShowConfirm("当前存在未保存的更改，确认新建吗？"))
            {
                return;
            }
            EditCategoryFlag = false;
            CategoryListBox.SelectedIndex = -1;
            CurrentCategory = new();
            CurrentCategory.PoolID = CurrentPool.ID;
            LoadCategoryProperty();
        }

        private void CategoryAddBtn_Click(object sender, EventArgs e)
        {
            if (CategoryList.Any(x => x.Name == CurrentCategory.Name))
            {
                if (ShowConfirm("存在同名目录，确认要重复添加吗？") is false)
                {
                    return;
                }
            }
            CurrentCategory.PoolID = CurrentPool.ID;
            CurrentCategory = CurrentCategory.AddCategory();
            ReloadCategory();
            ShowInfo("ok");
        }

        private void CategoryEditBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentCategory.ID))
            {
                ShowError("当前项目请先点新建或添加");
                return;
            }
            CurrentCategory.PoolID = CurrentPool.ID;
            CurrentCategory.UpdateCategory();
            EditCategoryFlag = false;
            ReloadCategory();
            ShowInfo("ok");
        }

        private void CategoryDeleteBtn_Click(object sender, EventArgs e)
        {
            if (ShowConfirm("确认要删除此目录吗？") is false)
            {
                return;
            }
            CurrentCategory.PoolID = CurrentPool.ID;
            CurrentCategory.DeleteCategory();
            CategoryListBox.SelectedIndex = -1;
            ShowInfo("ok");
        }

        private void CategoryRefreshBtn_Click(object sender, EventArgs e)
        {
            int index = CategoryList.IndexOf(CurrentCategory);
            ReloadCategory();
            CategoryListBox.SelectedIndex = index;
        }

        private void CategoryItemsBtn_Click(object sender, EventArgs e)
        {
            ModeSelector.SelectedIndex = 2;
        }

        private void CategoryCopyBtn_Click(object sender, EventArgs e)
        {
            if (EditCategoryFlag && !ShowConfirm("当前存在未保存的更改，确认复制吗？"))
            {
                return;
            }
            EditCategoryFlag = false;
            CategoryListBox.SelectedIndex = -1;
            CurrentCategory = new()
            {
                PoolID = CurrentCategory.PoolID,
                Name = CurrentCategory.Name,
                Probablity = CurrentCategory.Probablity,
                IsBaodi = CurrentCategory.IsBaodi,
                ItemList = CurrentCategory.ItemList,
            };
            LoadCategoryProperty();
        }

        private void Category_IsBaodiValue_CheckedChanged(object sender, EventArgs e)
        {
            CurrentCategory.IsBaodi = Category_IsBaodiValue.Checked;
        }

        private void CategoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryListBox.SelectedIndex == -1)
            {
                return;
            }
            if (EditCategoryFlag && !ShowConfirm("当前存在未保存的更改，确认切换目录吗？"))
            {
                EditCategoryFlag = false;
                CategoryListBox.SelectedIndex = CategoryList.IndexOf(CurrentCategory);
                EditCategoryFlag = true;
                return;
            }
            EditCategoryFlag = false;
            CurrentCategory = CategoryList[CategoryListBox.SelectedIndex];
            LoadCategoryProperty();
        }

        private void GachaItem_PropertyChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string name = textBox.Name.Replace("GachaItem_", "");

            var gachaItemType = CurrentGachaItem.GetType().GetProperty(name[..^"Value".Length]);
            if (!EditGachaItemFlag)
            {
                EditGachaItemFlag = gachaItemType.GetValue(CurrentGachaItem).ToString() != textBox.Text;
            }
            try
            {
                switch (gachaItemType.PropertyType.Name)
                {
                    case "Int32":
                        gachaItemType.SetValue(CurrentGachaItem, int.Parse(textBox.Text));
                        break;
                    case "Double":
                        gachaItemType.SetValue(CurrentGachaItem, double.Parse(textBox.Text));
                        break;
                    case "String":
                        gachaItemType.SetValue(CurrentGachaItem, textBox.Text);
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                ShowError($"数值转换失败：{gachaItemType.Name}");
                textBox.Text = gachaItemType.GetValue(CurrentGachaItem).ToString();
                textBox.Focus();
            }
        }

        private void GachaItem_CanBeFoldedValue_CheckedChanged(object sender, EventArgs e)
        {
            CurrentGachaItem.CanBeFolded = GachaItem_CanBeFoldedValue.Checked;
        }

        private void GachaItem_IsUpValue_CheckedChanged(object sender, EventArgs e)
        {
            CurrentGachaItem.IsUP = GachaItem_IsUpValue.Checked;
        }

        private void GachaItem_DrawConfigBtn_Click(object sender, EventArgs e)
        {
            ItemDrawConfigEditForm form = new();
            form.ShowDialog(this);
            if (form.SaveFlag)
            {
                CurrentPool.ItemDrawConfig = form.DrawConfig;
            }
        }

        private void GachaItemListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GachaItemListBox.SelectedIndex == -1)
            {
                return;
            }
            if (EditGachaItemFlag && !ShowConfirm("当前存在未保存的更改，确认切换卡池吗？"))
            {
                EditGachaItemFlag = false;
                GachaItemListBox.SelectedIndex = GachaItemList.IndexOf(CurrentGachaItem);
                EditGachaItemFlag = true;
                return;
            }
            EditGachaItemFlag = false;
            CurrentGachaItem = GachaItemList[GachaItemListBox.SelectedIndex];
            LoadGachaItemProperty();
        }

        private void LoadGachaItemProperty()
        {
            var gachaItemType = CurrentGachaItem.GetType().GetProperties();

            foreach (var item in gachaItemType)
            {
                string name = $"GachaItem_{item.Name}Value";
                var control = Controls.Find(name, true);
                if (control == null || control.Length != 1) continue;
                if (control[0] is TextBox)
                {
                    control[0].Text = item.GetValue(CurrentGachaItem).ToString();
                }
                else if (control[0] is ComboBox)
                {
                    (control[0] as CheckBox).Checked = bool.Parse(item.GetValue(CurrentGachaItem).ToString());
                }
            }
        }

        private void GachaItem_NewBtn_Click(object sender, EventArgs e)
        {
            if (EditGachaItemFlag && !ShowConfirm("当前存在未保存的更改，确认新建吗？"))
            {
                return;
            }
            EditGachaItemFlag = false;
            GachaItemListBox.SelectedIndex = -1;
            CurrentGachaItem = new();
            LoadGachaItemProperty();
        }

        private void GachaItem_AddBtn_Click(object sender, EventArgs e)
        {
            if (GachaItemList.Any(x => x.Name == CurrentGachaItem.Name))
            {
                if (ShowConfirm("存在同名单例，确认要重复添加吗？") is false)
                {
                    return;
                }
            }
            CurrentGachaItem = CurrentGachaItem.AddItem();
            CurrentCategory.AddGachaItem(CurrentGachaItem);
            EditGachaItemFlag = false;
            ReloadGachaItems();
            ShowInfo("ok");
        }

        private void GachaItem_EditBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentGachaItem.ID))
            {
                ShowError("当前项目请先点新建或添加");
                return;
            }
            CurrentGachaItem.UpdateItem();
            EditGachaItemFlag = false;
            ReloadGachaItems();
            ShowInfo("ok");
        }

        private void GachaItem_DeleteBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentGachaItem.ID))
            {
                ShowError("当前项目请先点新建或添加");
                return;
            }
            CurrentCategory.RemoveGachaItem(CurrentGachaItem);
            EditGachaItemFlag = false;
            ReloadGachaItems();
            ShowInfo("ok");
        }

        private void GachaItem_CopyBtn_Click(object sender, EventArgs e)
        {
            if (EditCategoryFlag && !ShowConfirm("当前存在未保存的更改，确认复制吗？"))
            {
                return;
            }
            EditGachaItemFlag = false;
            GachaItemListBox.SelectedIndex = -1;
            CurrentGachaItem = new()
            {
                Name = CurrentGachaItem.Name,
                Probablity = CurrentGachaItem.Probablity,
                UpProbablity = CurrentGachaItem.UpProbablity,
                MainImagePath = CurrentGachaItem.MainImagePath,
                BackgroundImagePath = CurrentGachaItem.BackgroundImagePath,
                CanBeFolded = CurrentGachaItem.CanBeFolded,
                Count = CurrentGachaItem.Count,
                MinCount = CurrentGachaItem.MinCount,
                MaxCount = CurrentGachaItem.MaxCount,
                IsUP = CurrentGachaItem.IsUP,
                Value = CurrentGachaItem.Value,
                Remark = CurrentGachaItem.Remark,
            };
            LoadGachaItemProperty();
        }

        private void GachaItem_RefreshBtn_Click(object sender, EventArgs e)
        {
            int index = GachaItemList.IndexOf(CurrentGachaItem);
            ReloadGachaItems();
            GachaItemListBox.SelectedIndex = index;
            LoadGachaItemProperty();
        }

        private void GachaItem_QueryBtn_Click(object sender, EventArgs e)
        {

        }
    }
}