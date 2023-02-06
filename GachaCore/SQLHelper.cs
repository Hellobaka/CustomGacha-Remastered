using GachaCore.Model;
using SqlSugar;
using System;

namespace GachaCore
{
    public class SQLHelper
    {
        public static void CreateDatabase()
        {
            using var db = GetInstance();
            db.DbMaintenance.CreateDatabase(Common.DBPath);
            db.CodeFirst.InitTables(typeof(Pool));
            db.CodeFirst.InitTables(typeof(GachaItem));
            db.CodeFirst.InitTables(typeof(Category));
            db.CodeFirst.InitTables(typeof(Repository));
            db.CodeFirst.InitTables(typeof(User));
            db.CodeFirst.InitTables(typeof(GachaHistory));
        }

        public static SqlSugarClient GetInstance()
        {
            return new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = $"data source={Common.DBPath}",
                DbType = DbType.Sqlite,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute,
            });
        }
    }
}
