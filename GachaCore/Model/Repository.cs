using SqlSugar;
using System;
using System.Collections.Generic;

namespace GachaCore.Model
{
    public class Repository
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        public string ItemID { get; set; } = "";
        public long Count { get; set; }
        public long QQ { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
