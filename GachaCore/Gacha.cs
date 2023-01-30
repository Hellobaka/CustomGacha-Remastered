using GachaCore.Model;
using System;
using System.Collections.Generic;

namespace GachaCore
{
    public static class Gacha
    {
        public static List<GachaItem> CallGacha(Pool pool, User user, int count)
        {
            List<GachaItem> ls = new List<GachaItem>();
            int lastBaodi = GachaHistory.GetLastBaodiCount(user.QQ, pool.ID);
            for (int i = 0; i < count; i++)
            {
                var item = pool.GetItem();
                if(lastBaodi >= pool.BaodiCount)
                {
                    item = pool.GetBaodiItem();
                }
                GachaHistory.AddGachaHistory(new GachaHistory
                {
                    Count = item.Count,
                    CreateTime = DateTime.Now,
                    IsBaodi = item.IsBaodi,
                    ItemName = item.Name,
                    PoolID = pool.ID,
                    QQ = user.QQ
                });
            }
            user.TotalGachaCount += count;
            user.UpdateUser();
            return ls;
        }
    }
}
