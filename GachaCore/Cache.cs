using GachaCore.Model;
using System.Collections.Generic;

namespace GachaCore
{
    public class Cache
    {
        public static Dictionary<string, Category> CategoriesCache { get; set; } = new Dictionary<string, Category>();
        public static Dictionary<string, GachaItem> GachaItemsCache { get; set; } = new Dictionary<string, GachaItem>();
        public static Dictionary<string, Pool> PoolsCache { get; set; } = new Dictionary<string, Pool>();
    }
}
