using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Transactions;

namespace Education.Common
{
    /// <summary>
    /// 事务拦截器
    /// </summary>
    public class TransactionInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            //获取方法调用的目标
            MethodInfo methodInfo = invocation.MethodInvocationTarget;
            if (methodInfo == null)
            {
                //赋值为当前的方法
                methodInfo = invocation.Method;
            }
            //获取事务拦截器
            TransactionAttribute attribute = methodInfo.GetCustomAttributes<TransactionAttribute>(true).FirstOrDefault();
            if (attribute != null)
            {
                TransactionOptions transactionOptions = new TransactionOptions();
                //设置事务隔离级别
                transactionOptions.IsolationLevel = attribute.IsolationLevel;
                //设置事务超时时间为60秒
                transactionOptions.Timeout = new TimeSpan(0, 0, attribute.Timeout);
                using (TransactionScope scope = new TransactionScope(attribute.ScopeOption, transactionOptions))
                {
                    try
                    {
                        //实现事务性工作
                        AopHelper.ExecuteCondition(invocation);
                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        //记录异常
                        throw ex;
                    }
                }
            }
            else
            {
                AopHelper.ExecuteCondition(invocation);
            }
        }
    }
}
