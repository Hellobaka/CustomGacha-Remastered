using GachaCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GachaCore
{
    public static class Common
    {
        public static string DBPath { get; set; } = "data.db";
        public static DateTime SignRefreshTime { get; set; }
        public static int MinSignMoney { get; set; }
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
    }
}
