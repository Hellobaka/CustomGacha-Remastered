using SqlSugar;
using System;

namespace GachaCore.Model
{
    public class User
    {
        [SugarColumn(IsPrimaryKey = true)]
        public long QQ { get; set; }
        public long Money { get; set; }
        public long TotalMoneyCount { get; set; }
        public int TotalGachaCount { get; set; }
        public int TotalSignTime { get; set; }
        public DateTime RegistryTime { get; set; }
        public DateTime LastSignTime { get; set; }

        public bool CanSign()
        {
            DateTime dt = DateTime.Now;
            DateTime sign = new DateTime(dt.Year, dt.Month, dt.Day
                , Common.SignRefreshTime.Hour, Common.SignRefreshTime.Minute, Common.SignRefreshTime.Second);
            return LastSignTime <= sign;
        }

        public int Sign()
        {
            if (!CanSign()) return 0;
            int sign = Common.Random.Next(Common.MinSignMoney, Common.MaxSignMoney + 1);
            Money += sign;
            TotalSignTime++;
            LastSignTime = DateTime.Now;
            UpdateUser();
            return sign;
        }

        public static User Registry(long qq)
        {
            var user = new User
            {
                QQ = qq,
                Money = Common.Random.Next(Common.RegistryMoney),
                RegistryTime = DateTime.Now,
            };
            using var db = SQLHelper.GetInstance();
            db.Insertable(user).ExecuteCommand();
            return user;
        }

        public void UpdateUser()
        {
            using var db = SQLHelper.GetInstance();
            db.Updateable(this).ExecuteCommand();
        }

        public static User GetUserByID(long id)
        {
            using var db = SQLHelper.GetInstance();
            return db.Queryable<User>().Where(x => x.QQ == id).First();
        }
    }
}
