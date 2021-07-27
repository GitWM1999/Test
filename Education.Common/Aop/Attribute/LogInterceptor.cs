using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Education.Common;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace Education.Common
{
    /// <summary>
    /// 日志拦截器
    /// </summary>
    public class LogInterceptor : IInterceptor
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
            //获取日志拦截器
            LogAttribute attribute = methodInfo.GetCustomAttributes<LogAttribute>(true).FirstOrDefault();
            //判断是否为日志拦截器
            if (attribute != null)
            {
                //方法执行开始前写入日志
                NLogHelperReopsitory.AddAOPLog(invocation, "执行开始", true);
                AopHelper.ExecuteCondition(invocation);
                //方法执行开始后写入日志
                NLogHelperReopsitory.AddAOPLog(invocation, "执行结束", false);
            }
            else
            {
                AopHelper.ExecuteCondition(invocation);
            }
        }
    }
}
