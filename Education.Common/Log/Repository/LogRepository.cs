using Education.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Common
{
    public class LogRepository : ILogRepository
    {
        //实例化DB工厂
        DBFactory dbFactory = new DBFactory();

        //实现增删改方法
        public int Execute(string sql, object param = null)
        {
            return dbFactory.CRUD().Execute(sql, param);
        }
        //实现查询显示
        public List<Log> ListLog(string sql, object param = null)
        {
            return dbFactory.CRUD().GetClassLists<Log>(sql, param);
        }
    }
}
