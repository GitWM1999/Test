using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Education.Common
{
    /// <summary>
    /// 使用属性，属性范围.方法，继承
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class TransactionAttribute : Attribute
    {
        /// <summary>
        /// 超时时间
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// 事务范围
        /// </summary>
        public TransactionScopeOption ScopeOption { get; set; }

        /// <summary>
        /// 事务隔离级别
        /// </summary>
        public IsolationLevel IsolationLevel { get; set; }
          
        public TransactionAttribute()
        {
            Timeout = 60;
            //事务范围:必须
            ScopeOption = TransactionScopeOption.Required;
            //事务隔离级别:读取命令
            IsolationLevel = IsolationLevel.ReadCommitted;
        }
    }
}
