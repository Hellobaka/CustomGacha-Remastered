using GachaCore.Model;
using System;
using System.Collections.Generic;

namespace GachaCore
{
    public static class Gacha
    {
        public static List<GachaItem> CallGacha(this Pool pool, User user, int count)
        {
            List<GachaItem> ls = new List<GachaItem>();
            int lastBaodi = GachaHistory.GetLastBaodiCount(user.QQ, pool.ID);
            for (int i = 0; i < count; i++)
            {
                var item = pool.GetItem();
                if(lastBaodi >= pool.BaodiCount)
                {
                    lastBaodi = 0;
                    item = pool.GetBaodiItem();
                }
                lastBaodi++;
                GachaHistory.AddGachaHistory(new GachaHistory
                {
                    Count = item.Item1.Count,
                    CreateTime = DateTime.Now,
                    IsBaodi = item.Item2,
                    ItemName = item.Item1.Name,
                    PoolID = pool.ID,
                    QQ = user.QQ
                });
                ls.Add(item.Item1);
            }
            user.TotalGachaCount += count;
            user.UpdateUser();
            GachaItem.SaveItems(ls);
            return ls;
        }

        public static List<GachaItem> CallGacha(this Pool pool, int count)
        {
            List<GachaItem> ls = new List<GachaItem>();
            int lastBaodi = 0;
            for (int i = 0; i < count; i++)
            {
                var item = pool.GetItem();
                if (lastBaodi >= pool.BaodiCount)
                {
                    lastBaodi = 0;
                    item = pool.GetBaodiItem();
                }
                lastBaodi++;
                ls.Add(item.Item1);
            }
            return ls;
        }
    }
}
