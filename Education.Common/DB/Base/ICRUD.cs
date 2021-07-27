using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Common
{
    public interface ICRUD
    {
        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        int Execute(string sql, object param = null);

        /// <summary>
        /// 查询 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        List<T> GetClassLists<T>(string sql, object param = null) where T : class, new();

        /// <summary>
        /// 事务增删改方法一
        /// </summary>
        /// <param name="sqlarr"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        int ExecuteTransaction(string[] sqlarr, object[] param);

        /// <summary>
        /// 事务增删改方法二
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        int ExecuteTransaction(Dictionary<string, object> dic);
    }
}
