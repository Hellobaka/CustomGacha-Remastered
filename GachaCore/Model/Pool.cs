using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GachaCore.Model
{
    public class Pool
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string ID { get; set; } = "";
        public string Name { get; set; } = "";
        public string BackgroundImagePath { get; set; } = "";
        /// <summary>
        /// New 图片相对路径
        /// </summary>
        public string NewPicPath { get; set; } = "";
        /// <summary>
        /// New 图片绘制宽度
        /// </summary>
        public int NewPicWidth { get; set; } = 0;
        /// <summary>
        /// New 图片绘制高度
        /// </summary>
        public int NewPicHeight { get; set; } = 0;
        /// <summary>
        /// New 图片绘制坐标 X
        /// </summary>
        public int NewPicX { get; set; } = 0;
        /// <summary>
        /// New 图片绘制坐标 Y
        /// </summary>
        public int NewPicY { get; set; } = 0;
        public string SingleGachaText { get; set; } = "";
        public string MultiGachaText { get; set; } = "";
        public string Remark { get; set; } = "";
        /// <summary>
        /// 单抽指令
        /// </summary>
        public string SingleGachaOrder { get; set; } = "#单抽指令";
        /// <summary>
        /// 多抽指令
        /// </summary>
        public string MultiOrder { get; set; } = "#多抽指令";
        /// <summary>
        /// 多抽抽取次数
        /// </summary>

        public int MultiGachaNumber { get; set; } = 10;

        public int PerGachaCost { get; set; }

        public int BaodiCount { get; set; }

        [SugarColumn(IsIgnore = true)]
        public List<Category> CategoryList { get; set; } = new List<Category>();

        [SugarColumn(IsJson = true, ColumnDataType = "Text")]
        public PoolDrawConfig PoolDrawConfig { get; set; } = new PoolDrawConfig();

        [SugarColumn(IsJson = true, ColumnDataType = "Text")]
        public ItemDrawConfig ItemDrawConfig { get; set; } = new ItemDrawConfig();

        /// <summary>
        /// 相对路径
        /// </summary>
        public string RelativePath { get; set; } = "";
        
        /// <summary>
        /// 插件路径
        /// </summary>
        public string PluginPath { get; set; } = "";

        public DateTime CreateTime { get; set; }

        public static List<Pool> GetAllPools()
        {
            using var db = SQLHelper.GetInstance();
            return db.Queryable<Pool>().ToList();
        }

        public void CreateCache()
        {
            foreach (var item in CategoryList)
            {
                if (Cache.CategoriesCache.ContainsKey(item.ID))
                {
                    continue;
                }
                else
                {
                    Cache.CategoriesCache.Add(item.ID, item);
                }
            }
        }

        public List<Category> CreateCategoryList()
        {
            CategoryList.Clear();
            using var db = SQLHelper.GetInstance();
            var ls = db.Queryable<Category>().Where(x => x.PoolID == ID).ToList();
            CreateCache();
            foreach (var item in ls)
            {
                CategoryList.Add(item);
            }
            return ls;
        }

        public (GachaItem, bool) GetItem()
        {
            var category = RandomGetCategory(false);
            return (category.RandomGetGachaItem(), category.IsBaodi);
        }

        public (GachaItem, bool) GetBaodiItem()
        {
            var category = RandomGetCategory(true);
            return (category.RandomGetGachaItem(), category.IsBaodi);
        }

        public Category RandomGetCategory(bool isBaodi = false)
        {
            double totalProbablity = 0, currentProbablity = 0, targertProbablity = 0;
            var categories = CreateCategoryList();
            if (isBaodi)
            {
                categories = categories.Where(x => x.IsBaodi).ToList();
            }
            categories.ForEach(x => totalProbablity += x.Probablity);
            targertProbablity = Common.Random.NextDouble() * 100 * (totalProbablity / 100);
            Category targetCategory = null;
            foreach (var item in categories)
            {
                currentProbablity += item.Probablity;
                if (currentProbablity >= targertProbablity)
                {
                    targetCategory = item;
                    break;
                }
            }
            return targetCategory;
        }

        public Pool AddPool()
        {
            ID = Guid.NewGuid().ToString();
            CreateTime = DateTime.Now;
            using var db = SQLHelper.GetInstance();
            return db.Insertable(this).ExecuteReturnEntity();
        }

        public void DeletePool()
        {
            using var db = SQLHelper.GetInstance();
            db.Deleteable(this).ExecuteCommand();
        }

        public void UpdatePool()
        {
            using var db = SQLHelper.GetInstance();
            db.Updateable(this).ExecuteCommand();
        }

        public static Pool GetPoolByID(string poolID)
        {
            using var db = SQLHelper.GetInstance();
            return db.Queryable<Pool>().Where(x => x.ID == poolID).First();
        }

        public void InitPlugin()
        {
            string pluginPath = Path.Combine(RelativePath, PluginPath);
            if (Gacha.PluginExectors.ContainsKey(ID))
            {
                Gacha.PluginExectors[ID] = new PluginExecutor(pluginPath);
            }
            else
            {
                Gacha.PluginExectors.Add(ID, new PluginExecutor(pluginPath));
            }
            Gacha.PluginExectors[ID].LoadPlugin();
            Gacha.PluginExectors[ID].CreateInterfaceInstance();
        }
    }
}
