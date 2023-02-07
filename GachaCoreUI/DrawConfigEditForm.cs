using GachaCore.Model;

namespace GachaCoreUI
{
    public partial class DrawConfigEditForm : Form
    {
        public DrawConfigEditForm()
        {
            InitializeComponent();
        }

        public PoolDrawConfig DrawConfig { get; set; }
        public bool SaveFlag { get; set; }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveFlag = MessageBox.Show("确实要保存吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            Close();
        }

        private void DefaultBtn_Click(object sender, EventArgs e)
        {
            DrawConfig = MainForm.Instance.CurrentPool.DrawConfig;
            LoadPoolProperty();
        }

        private void DrawConfigEditForm_Load(object sender, EventArgs e)
        {
            CurrentPoolDisplay.Text = $"当前卡池：{MainForm.Instance.CurrentPool.Name}";
            DrawConfig = MainForm.Instance.CurrentPool.DrawConfig;
            LoadPoolProperty();
        }

        private void LoadPoolProperty()
        {
            var configType = DrawConfig.GetType().GetProperties();

            foreach (var item in configType)
            {
                string name = $"{item.Name}Value";
                var control = Controls.Find(name, true);
                if (control != null && control.Length == 1 && control[0] is TextBox)
                {
                    control[0].Text = item.GetValue(DrawConfig).ToString();
                }
                else if (name.StartsWith("OrderOptional"))
                {
                    (control[0] as ComboBox).SelectedIndex = Convert.ToInt32(Enum.Parse(typeof(OrderOptional), item.GetValue(DrawConfig).ToString()));
                }
            }
        }

        private void DrawConfigPropertyChanged(object sender, EventArgs e)
        {
            TextBox textBox = (sender as TextBox);
            string name = textBox.Name.Replace("Value", "");

            var poolType = DrawConfig.GetType().GetProperty(name);
            try
            {
                switch (poolType.PropertyType.Name)
                {
                    case "Int32":
                        poolType.SetValue(DrawConfig, int.Parse(textBox.Text));
                        break;
                    case "String":
                        poolType.SetValue(DrawConfig, textBox.Text);
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                ShowError($"数值转换失败：{poolType.Name}");
                textBox.Text = poolType.GetValue(DrawConfig).ToString();
                textBox.Focus();
            }
        }

        private void OrderOptionalValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawConfig.OrderOptional = (OrderOptional)OrderOptionalValue.SelectedIndex;
        }

        private void ShowError(string msg)
        {
            MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
