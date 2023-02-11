using GachaCore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GachaCoreUI
{
    public partial class ItemDrawConfigEditForm : Form
    {
        public ItemDrawConfig DrawConfig { get; set; }
        public bool SaveFlag { get; set; }

        public ItemDrawConfigEditForm()
        {
            InitializeComponent();
        }

        private void DrawConfig_PropertyChanged(object sender, EventArgs e)
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

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveFlag = MessageBox.Show("确实要保存吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            Close();
        }

        private void DefaultBtn_Click(object sender, EventArgs e)
        {
            DrawConfig = MainForm.Instance.CurrentPool.ItemDrawConfig;
            LoadDrawConfigProperty();
        }

        private void DrawOptionalValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawConfig.DrawOrder = (DrawOrder)DrawOrderValue.SelectedIndex;
        }

        private void GachaItemDrawConfigEditForm_Load(object sender, EventArgs e)
        {
            CurrentGachaItemDisplay.Text = $"当前卡池：{MainForm.Instance.CurrentPool.Name}";
            DrawConfig = MainForm.Instance.CurrentPool.ItemDrawConfig;
            LoadDrawConfigProperty();
            LanguagePackage.ApplyLanguagePackage(this, LanguagePackage.CurrentLanguage);
        }

        private void LoadDrawConfigProperty()
        {
            var configType = DrawConfig.GetType().GetProperties();

            foreach (var item in configType)
            {
                string name = $"{item.Name}Value";
                var control = Controls.Find(name, true);
                if(control.Length == 0 || control == null)
                {
                    return;
                }
                if (control[0] is TextBox)
                {
                    control[0].Text = item.GetValue(DrawConfig).ToString();
                }
                else if (name.StartsWith("DrawOrder"))
                {
                    (control[0] as ComboBox).SelectedIndex = Convert.ToInt32(Enum.Parse(typeof(DrawOrder), item.GetValue(DrawConfig).ToString()));
                }
            }
        }

        private void ShowError(string msg)
        {
            MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
