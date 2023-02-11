using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GachaCore.Model
{
    public class Category
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string ID { get; set; } = "";
        public string PoolID { get; set; } = "";
        public string Name { get; set; } = "";
        public double Probablity { get; set; }
        public bool IsBaodi { get; set; }
        [SugarColumn(IsJson = true, ColumnDataType = "Text")]
        public List<string> ItemList { get; set; } = new List<string>();
        public DateTime CreateTime { get; set; }

        public static Category GetCategoryByID(string id)
        {
            using var db = SQLHelper.GetInstance();
            var category = db.Queryable<Category>().Where(x => x.ID == id).First();
            if (Cache.CategoriesCache.ContainsKey(category.ID))
            {
                Cache.CategoriesCache[category.ID] = category;
            }
            else
            {
                Cache.CategoriesCache.Add(category.ID, category);
            }
            return category;
        }

        public GachaItem RandomGetGachaItem()
        {
            double totalProbablity = 0, currentProbablity = 0, targertProbablity = 0;
            var gachaItems = CreateGachaItemList();
            gachaItems.ForEach(x => totalProbablity += x.Probablity);
            targertProbablity = Common.Random.NextDouble() * 100 * (totalProbablity / 100);
            GachaItem targetGachaItem = null;
            foreach (var item in gachaItems)
            {
                currentProbablity += item.Probablity;
                if (currentProbablity >= targertProbablity)
                {
                    targetGachaItem = item;
                    break;
                }
            }
            return targetGachaItem;
        }

        public List<GachaItem> CreateGachaItemList()
        {
            CreateCache();
            List<GachaItem> ls = new List<GachaItem>();
            foreach (var item in ItemList)
            {
                ls.Add(Cache.GachaItemsCache[item]);
            }
            return ls;
        }

        public void CreateCache()
        {
            List<string> errorList = new List<string>();
            foreach (var item in ItemList)
            {
                if (Cache.GachaItemsCache.ContainsKey(item))
                {
                    continue;
                }
                else
                {
                    var gachaItem = GachaItem.GetItemByID(item);
                    if(gachaItem != null)
                    {
                        Cache.GachaItemsCache.Add(item, gachaItem);
                    }
                    else
                    {
                        errorList.Add(item);
                    }
                }
            }
            errorList.ForEach(item => ItemList.Remove(item));
            UpdateCategory();
        }

        public Category AddCategory()
        {
            ID = Guid.NewGuid().ToString();
            CreateTime = DateTime.Now;
            using var db = SQLHelper.GetInstance();
            var category = db.Insertable(this).ExecuteReturnEntity();
            if (Cache.CategoriesCache.ContainsKey(category.ID))
            {
                Cache.CategoriesCache[category.ID] = category;
            }
            else
            {
                Cache.CategoriesCache.Add(category.ID, category);
            }
            return category;
        }

        public void UpdateCategory()
        {
            using var db = SQLHelper.GetInstance();
            db.Updateable(this).ExecuteCommand();
            if (Cache.CategoriesCache.ContainsKey(ID))
            {
                Cache.CategoriesCache[ID] = this;
            }
            else
            {
                Cache.CategoriesCache.Add(ID, this);
            }
        }

        public void DeleteCategory()
        {
            using var db = SQLHelper.GetInstance();
            db.Deleteable(this).ExecuteCommand();
            if (Cache.CategoriesCache.ContainsKey(ID))
            {
                Cache.CategoriesCache.Remove(ID);
            }
        }

        public void AddGachaItem(GachaItem currentGachaItem)
        {
            if(ItemList.Any(x=>x == currentGachaItem.ID))
            {
                return;
            }
            ItemList.Add(currentGachaItem.ID);
            UpdateCategory();
        }

        public void RemoveGachaItem(GachaItem currentGachaItem)
        {
            if (!ItemList.Any(x => x == currentGachaItem.ID))
            {
                return;
            }
            ItemList.Remove(currentGachaItem.ID);
            UpdateCategory();
        }
    }
}
