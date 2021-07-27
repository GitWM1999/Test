using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Common;


namespace Education.Common
{
    public interface ILogRepository
    {
        //增删改  
        int Execute(string sql, object param = null);
        //显示查询
        List<Log> ListLog(string sql, object param = null);
    }
}
