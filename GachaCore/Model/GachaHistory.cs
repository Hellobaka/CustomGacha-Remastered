using SqlSugar;
using System;
using System.Collections.Generic;

namespace GachaCore.Model
{
    public class GachaHistory
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        public long QQ { get; set; }
        public string ItemID { get; set; }
        public string PoolID { get; set; }
        public string ItemName { get; set; }
        public bool IsBaodi { get; set; }
        public int Count { get; set; }
        public DateTime CreateTime { get; set; }
        public static int GetLastBaodiCount(long QQ, string poolID)
        {
            using var db = SQLHelper.GetInstance();
            int id = db.Queryable<GachaHistory>().OrderBy(x => x.ID, OrderByType.Desc)
                .First(x => x.IsBaodi && x.QQ == QQ && poolID == x.PoolID).ID;
            return db.Queryable<GachaHistory>().OrderBy(x => x.ID, OrderByType.Desc)
                .First(x => x.QQ == QQ && x.PoolID == poolID).ID - id;
        }

        public static GachaHistory AddGachaHistory(GachaHistory gachaHistory)
        {
            using var db = SQLHelper.GetInstance();
            if (Cache.GachaItemsCache[gachaHistory.ItemID].CanBeFolded)
            {
                var item = db.Queryable<GachaHistory>().Where(x => x.ItemID == gachaHistory.ItemID && gachaHistory.QQ == x.QQ).First();
                if (item != null)
                {
                    item.Count += gachaHistory.Count;
                    db.Updateable(item).ExecuteCommand();
                    return item;
                }
                else
                {
                    return db.Insertable(item).ExecuteReturnEntity();
                }
            }
            else
            {
                return db.Insertable(gachaHistory).ExecuteReturnEntity();
            }
        }
    }
}
