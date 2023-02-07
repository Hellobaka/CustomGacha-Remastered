﻿using SqlSugar;
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
            return db.Queryable<Category>().Where(x => x.ID == id).First();
        }
       
        public GachaItem RandomGetGachaItem()
        {
            double totalProbablity = 0, currentProbablity = 0, targertProbablity = Common.Random.NextDouble() * 100;
            var gachaItems = CreateGachaItemList();
            gachaItems.ForEach(x => totalProbablity += x.Probablity);
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

        private List<GachaItem> CreateGachaItemList()
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
            foreach (var item in ItemList)
            {
                if (Cache.GachaItemsCache.ContainsKey(item))
                {
                    continue;
                }
                else
                {
                    Cache.GachaItemsCache.Add(item, GachaItem.GetItemByID(item));
                }
            }
        }

        public Category AddCategory()
        {
            ID = Guid.NewGuid().ToString();
            CreateTime = DateTime.Now;
            using var db = SQLHelper.GetInstance();
            return db.Insertable(this).ExecuteReturnEntity();
        }

        public void UpdateCategory()
        {
            using var db = SQLHelper.GetInstance();
            db.Updateable(this).ExecuteCommand();
        }

        public void DeleteCategory()
        {
            using var db = SQLHelper.GetInstance();
            db.Deleteable(this).ExecuteCommand();
            var pool = Pool.GetPoolByID(PoolID);
            pool.CategoryList.Remove(ID);
            pool.UpdatePool();
        }
    }
}
