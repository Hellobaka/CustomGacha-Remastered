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
                ShowError("当前项目请先点新建");
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

        }

        private void ReloadCategory()
        {
            EditCategoryFlag = false;
            CategoryList.Clear();
            foreach (var item in CurrentPool.CategoryList)
            {
                CategoryList.Add(Category.GetCategoryByID(item));
            }
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
                        categoryType.SetValue(CurrentPool, double.Parse(textBox.Text));
                        break;
                    case "String":
                        categoryType.SetValue(CurrentPool, textBox.Text);
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

        private void Pool_BackPicImgBtn_Click(object sender, EventArgs e)
        {
            if (FileDialog.ShowDialog(this) == DialogResult.OK)
            {
                Pool_BackgroundImagePathValue.Text = FileDialog.FileName;
                FileDialog.FileName = "";
                Pool_BackgroundImagePathValue.Focus();
            }
        }

        private void Pool_NewPicImgBtn_Click(object sender, EventArgs e)
        {
            if (FileDialog.ShowDialog(this) == DialogResult.OK)
            {
                Pool_NewPicPathValue.Text = FileDialog.FileName;
                FileDialog.FileName = "";
                Pool_NewPicPathValue.Focus();
            }
        }

        private void Pool_DrawConfigBtn_Click(object sender, EventArgs e)
        {
            DrawConfigEditForm form = new();
            form.ShowDialog(this);
            if (form.SaveFlag)
            {
                CurrentPool.DrawConfig = form.DrawConfig;
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
            r.ForEach(x => Debug.WriteLine(x.ToString()));
        }

        private void PoolMultiTestBtn_Click(object sender, EventArgs e)
        {
            var r = CurrentPool.CallGacha(CurrentPool.MultiGachaNumber);
            r.ForEach(x => Debug.WriteLine(x.ToString()));
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
                    CategoryStatusDisplay.Text = $"当前卡池：{CurrentPool.Name} - {CurrentCategory.Name}";
                    ReloadGachaItems();
                    CategoryListBox.SelectedIndex = CategoryListBox.Items.Count > 0 ? 0 : -1;
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
                DrawConfig = CurrentPool.DrawConfig,
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
                ShowError("当前项目请先点新建");
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
                ID = CurrentCategory.ID,
                PoolID = CurrentCategory.PoolID,
                Name = CurrentCategory.Name,
                Probablity = CurrentCategory.Probablity,
                IsBaodi = CurrentCategory.IsBaodi,
                ItemList = CurrentCategory.ItemList,
                CreateTime = CurrentCategory.CreateTime,
            };
            LoadCategoryProperty();
        }

        private void Category_IsBaodiValue_CheckedChanged(object sender, EventArgs e)
        {
            CurrentCategory.IsBaodi = Category_IsBaodiValue.Checked;
        }
    }
}