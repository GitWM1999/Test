using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Common
{
    public class DBFactory
    {
        //选择数据库
        public static string conDb = DbConfig.UseDB;

        //通用增删改查的接口
        ICRUD _crud;

        /// <summary>
        /// 选择数据库
        /// </summary>
        /// <returns></returns>
        public ICRUD CRUD()
        {
            switch (conDb)
            {
                case "SqlServer":
                    _crud = new SqlServerDapperHelper();
                    break;
                case "MySql":
                    _crud = new MySqlDapperHelper();
                    break;
                default:
                    break;
            }
            return _crud;
        }
    }
}
