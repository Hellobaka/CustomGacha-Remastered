using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace GachaCore.Model
{
    public class GachaItem
    {
        public override string ToString()
        {
            return $"Name={Name}, Count={Count}";
        }

        [SugarColumn(IsPrimaryKey = true)]
        public string ID { get; set; }
        public string Name { get; set; } = "";
        public double Probablity { get; set; }
        public double UpProbablity { get; set; }
        public string MainImagePath { get; set; } = "";
        public string BackgroundImagePath { get; set; } = "";
        public bool CanBeFolded { get; set; }
        public int Count { get; set; }
        public int MinCount { get; set; }
        public int MaxCount { get; set; }
        public bool IsUP { get; set; }
        public int Value { get; set; }
        public string Remark { get; set; }
        [SugarColumn(IsJson = true, ColumnDataType = "Text")]
        public ItemDrawConfig DrawConfig { get; set; } = new ItemDrawConfig();
        public DateTime CreateTime { get; set; }

        public static GachaItem GetItemByID(string id)
        {
            using var db = SQLHelper.GetInstance();
            return db.Queryable<GachaItem>().Where(x => x.ID == id).First();
        }
        public static void SaveItems(List<GachaItem> items)
        {
            using var db = SQLHelper.GetInstance();
            db.Insertable(items).ExecuteCommandAsync();
        }
    }
}
