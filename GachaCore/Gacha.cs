using GachaCore.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GachaCore
{
    public static class Gacha
    {
        public static Dictionary<string, PluginExecutor> PluginExectors { get; set; } = new Dictionary<string, PluginExecutor>();

        public static List<GachaItem> CallGacha(this Pool pool, User user, int count)
        {
            List<GachaItem> ls = new List<GachaItem>();
            int lastBaodi = GachaHistory.GetLastBaodiCount(user.QQ, pool.ID);
            for (int i = 0; i < count; i++)
            {
                var item = pool.GetItem();
                if (lastBaodi >= pool.BaodiCount)
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

        public static Bitmap DrawGachaImage(this Pool pool, List<GachaItem> items, long QQ = 0)
        {
            Bitmap background = (Bitmap)Image.FromFile(Path.Combine(pool.RelativePath, pool.BackgroundImagePath));
            switch (pool.PoolDrawConfig.OrderOptional)
            {
                case OrderOptional.Increasing:
                    items = items.OrderBy(x => x.Value).ToList();
                    break;
                case OrderOptional.Descending:
                    items = items.OrderByDescending(x => x.Value).ToList();
                    break;
                case OrderOptional.None:
                default:
                    break;
            }
            PluginExecutor pluginExecutor;
            if (PluginExectors.ContainsKey(pool.ID))
            {
                pluginExecutor= PluginExectors[pool.ID];
            }
            else
            {
                pluginExecutor = new PluginExecutor(pool.PluginPath);
                pluginExecutor.LoadPlugin();
                pluginExecutor.CreateInterfaceInstance();
                PluginExectors[pool.ID] = pluginExecutor;
            }
            Point[] drawPoints = (Point[])pluginExecutor.DrawPoints.GetType().GetMethod("GetDrawPoints")
                .Invoke(pluginExecutor.DrawPoints, new object[] { pool, pool.MultiGachaNumber });

            List<Image> images2Draw = new List<Image>();
            items.ForEach(x =>
            {
                Image destImg = Image.FromFile(Path.Combine(pool.RelativePath, x.MainImagePath));
                if (pluginExecutor.DrawMainImage != null)
                {
                    destImg = (Bitmap)pluginExecutor.DrawMainImage.GetType().GetMethod("RedrawMainImage")
                        .Invoke(pluginExecutor.DrawMainImage, new object[] { destImg, pool, x });
                }

                destImg = (Bitmap)pluginExecutor.DrawItem.GetType().GetMethod("DrawPicItem")
                    .Invoke(pluginExecutor.DrawItem, new object[] { x, pool, destImg });
                images2Draw.Add(destImg);
            });

            background = (Bitmap)pluginExecutor.DrawAllItems.GetType().GetMethod("DrawAllItems")
                .Invoke(pluginExecutor.DrawAllItems, new object[] { images2Draw, items, drawPoints, background, pool });

            if (pluginExecutor.FinallyDraw != null)
            {
                User user = User.GetUserByID(QQ);
                if (user == null)
                {
                    Random rd = new Random();
                    user = new User
                    {
                        Money = rd.Next(0, 10000),
                        TotalGachaCount = rd.Next(0, 10),
                        LastSignTime = DateTime.Now.AddSeconds(-1 * rd.Next(360, rd.Next(0, 72) * 3600)),
                        TotalMoneyCount = rd.Next(pool.PerGachaCost * rd.Next(0, 500)),
                        QQ = QQ,
                        TotalSignTime = rd.Next(1000),
                        RegistryTime = DateTime.Now.AddDays(-1 * rd.Next(0, 1000))
                    };
                }
                background = (Bitmap)pluginExecutor.FinallyDraw.GetType().GetMethod("DrawAllItems")
                    .Invoke(pluginExecutor.FinallyDraw, new object[] { background, drawPoints, items, user, pool });
            }
            return background;
        }
    }
}
