using SqlSugar;

namespace GachaCore
{
    public class SQLHelper
    {
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
