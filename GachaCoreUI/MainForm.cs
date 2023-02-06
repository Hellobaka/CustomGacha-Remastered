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

        private void MainForm_Load(object sender, EventArgs e)
        {
            SQLHelper.CreateDatabase();
            ReloadPool();
        }

        private void LoadPoolList()
        {
            PoolListBox.Items.Clear();
            PoolList.ForEach(x => PoolListBox.Items.Add(x.Name));
        }

        private void LoadPoolProperty(Pool currentPool)
        {
            var poolType = currentPool.GetType().GetProperties();

            foreach (var item in poolType)
            {
                string name = $"Pool_{item.Name}Value";
                var textbox = Controls.Find(name, true);
                if (textbox == null || textbox.Length != 1 || textbox[0] is not TextBox) continue;
                textbox[0].Text = item.GetValue(currentPool).ToString();
            }
        }

        private void PoolListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PoolListBox.SelectedIndex == -1) return;
            CurrentPool = PoolList[PoolListBox.SelectedIndex];
            LoadPoolProperty(CurrentPool);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (PoolList.Any(x => x.Name == CurrentPool.Name))
            {
                if (ShowConfirm("存在同名卡池，确认要重复添加吗？") == DialogResult.No) return;
            }
            CurrentPool = CurrentPool.AddPool();
            ReloadPool();
            ShowInfo("ok");
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentPool.ID))
            {
                ShowError("空选择");
                return;
            }
            CurrentPool.UpdatePool();
            ReloadPool();
            ShowInfo("ok");
        }

        private void ReloadPool()
        {
            PoolList = Pool.GetAllPools();
            LoadPoolList();
            LoadPoolProperty(CurrentPool);
        }

        private void ShowError(string msg)
        {
            MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowInfo(string msg)
        {
            MessageBox.Show(msg, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private DialogResult ShowConfirm(string msg)
        {
            return MessageBox.Show(msg, "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

        private void Pool_Property_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (sender as TextBox);
            string name = textBox.Name.Replace("Pool_", "");

            var poolType = CurrentPool.GetType().GetProperty(name.Substring(0, name.Length - "Value".Length));
            Debug.WriteLine(poolType.PropertyType.Name);
            switch (poolType.PropertyType.Name)
            {
                case "Int32":
                    poolType.SetValue(CurrentPool, int.TryParse(textBox.Text, out int intValue) ? intValue : 0);
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

        private void Pool_BackPicImgBtn_Click(object sender, EventArgs e)
        {

        }

        private void Pool_NewPicImgBtn_Click(object sender, EventArgs e)
        {

        }
    }
}