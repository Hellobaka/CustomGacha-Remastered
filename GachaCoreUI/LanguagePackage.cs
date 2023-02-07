namespace GachaCoreUI
{
    public class LanguagePackage
    {
        public static Dictionary<string, string> CurrentLanguage { get; set; } = new();

        public static Dictionary<string, string> LoadLanguagePackage(string name = "zh-CN")
        {
            Directory.CreateDirectory("langs");
            Dictionary<string, string> langs = new();
            if (!File.Exists($"langs\\{name}.pak"))
            {
                MessageBox.Show("文件缺失", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            foreach (var item in File.ReadAllLines($"langs\\{name}.pak"))
            {
                var langItem = item.Split('=');
                if (langItem.Length != 2)
                {
                    continue;
                }
                if (langs.ContainsKey(langItem[0]) is false)
                {
                    langs.Add(langItem[0], langItem[1]);
                }
            }
            CurrentLanguage = langs;
            return langs;
        }

        public static void ApplyLanguagePackage(Form form, Dictionary<string, string> langs)
        {
            if (langs == null)
            {
                return;
            }
            foreach (Control item in form.Controls)
            {
                var controlProperty = item.GetType().GetProperty("Controls");
                if (controlProperty != null && (controlProperty.GetValue(item) as Control.ControlCollection).Count > 0)
                {
                    ApplyLanguagePackage(item, langs);
                }
                if (langs.ContainsKey(item.Text))
                {
                    item.Text = langs[item.Text];
                }
            }
        }

        public static void ApplyLanguagePackage(Control control, Dictionary<string, string> langs)
        {
            if(langs == null)
            {
                return;
            }
            foreach (Control item in control.Controls)
            {
                var controlProperty = item.GetType().GetProperty("Controls");
                if (controlProperty != null && (controlProperty.GetValue(item) as Control.ControlCollection).Count > 0)
                {
                    ApplyLanguagePackage(item, langs);
                }
                if (langs.ContainsKey(item.Text))
                {
                    item.Text = langs[item.Text];
                }
            }
        }
    }
}
