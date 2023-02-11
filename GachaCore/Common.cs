using System;

namespace GachaCore
{
    public static class Common
    {
        public static string DBPath { get; set; } = "data.db";
        public static DateTime SignRefreshTime { get; set; }
        public static int MinSignMoney { get; set; }
        public static Action<string, string, bool> InfoMethod { get; set; } = null;
        public static int MaxSignMoney { get; set; }
        public static int RegistryMoney { get; set; }
        public static Random Random { get; set; } = new Random();
      
        public static void Init()
        {
            SignRefreshTime = ConfigHelper.GetConfig("SignRefreshTime", new DateTime(1970, 1, 1, 4, 0, 0));
            MinSignMoney = ConfigHelper.GetConfig("MinSignMoney", 0);
            MaxSignMoney = ConfigHelper.GetConfig("MaxSignMoney", 1000);
            RegistryMoney = ConfigHelper.GetConfig("RegistryMoney", 5000);
        }
      
        public static void Info(string type, string message, bool status = true)
        {
            if (InfoMethod == null)
            {
                Console.WriteLine($"{(status ? "[+]" : "[-]")}[{DateTime.Now:G}][{type}]{message}");
            }
            else
            {
                InfoMethod.Invoke(type, message, status);
            }
        }
    }
}
