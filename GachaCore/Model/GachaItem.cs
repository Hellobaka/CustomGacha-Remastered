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
        public string ID { get; set; } = "";
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
        public string Remark { get; set; } = "";
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

        public GachaItem AddItem()
        {
            ID = Guid.NewGuid().ToString();
            using var db = SQLHelper.GetInstance();
            var item = db.Insertable(this).ExecuteReturnEntity();
            if(Cache.GachaItemsCache.ContainsKey(ID))
            {
                Cache.GachaItemsCache[ID] = item;
            }
            else
            {
                Cache.GachaItemsCache.Add(ID, item);
            }
            return item;
        }

        public void UpdateItem()
        {
            using var db = SQLHelper.GetInstance();
            db.Updateable(this).ExecuteCommandAsync();
            if (Cache.GachaItemsCache.ContainsKey(ID))
            {
                Cache.GachaItemsCache[ID] = this;
            }
            else
            {
                Cache.GachaItemsCache.Add(ID, this);
            }
        }
    }
}
