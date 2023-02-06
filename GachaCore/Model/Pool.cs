using SqlSugar;
using System;
using System.Collections.Generic;
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
       
        [SugarColumn(IsJson = true, ColumnDataType = "Text")]
        public List<string> CategoryList { get; set; } = new List<string>();
       
        [SugarColumn(IsJson = true, ColumnDataType = "Text")]
        public PoolDrawConfig DrawConfig { get; set; } = new PoolDrawConfig();
       
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
                if (Cache.CategoriesCache.ContainsKey(item))
                {
                    continue;
                }
                else
                {
                    Cache.CategoriesCache.Add(item, Category.GetCategoryByID(item));
                }
            }
        }
       
        public List<Category> CreateCategoryList()
        {
            CreateCache();
            List<Category> ls = new List<Category>();
            foreach (var item in CategoryList)
            {
                ls.Add(Cache.CategoriesCache[item]);
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
            double totalProbablity = 0, currentProbablity = 0, targertProbablity = Common.Random.NextDouble() * 100;
            var categories = CreateCategoryList();
            if(isBaodi)
            {
                categories = categories.Where(x => x.IsBaodi).ToList();
            }
            categories.ForEach(x => totalProbablity += x.Probablity);
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

        public void UpdatePool()
        {
            using var db = SQLHelper.GetInstance();
            db.Updateable(this).ExecuteCommand();
        }
    }
}
