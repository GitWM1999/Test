using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ServiceStack.Redis;
using System.Reflection;
using Education.Common;

namespace Education.Common
{
    /// <summary>
    /// 缓存拦截器
    /// </summary>
    public class RedisCacheInterceptor : IInterceptor
    {
        //实例化Redis帮助类
        RedisClient redis = new RedisClient("127.0.0.1", 6379, null, 1);

        //拦截方法
        public void Intercept(IInvocation invocation)
        {
            //获取方法调用的目标
            MethodInfo methodInfo = invocation.MethodInvocationTarget;
            if (methodInfo == null)
            {
                //赋值为当前的方法
                methodInfo = invocation.Method;
            }
            //获取缓存拦截器
            RedisCacheAttribute attribute = methodInfo.GetCustomAttributes<RedisCacheAttribute>(true).FirstOrDefault();
            //判断是否为缓存拦截器
            if (attribute != null)
            {
                //RedisKey值
                string strKey = invocation.TargetType.FullName.ToString();
                //RedisValue值
                string value = redis.Get<string>(strKey);
                if (value != null)
                {
                    invocation.ReturnValue = "Intercept" + value;
                }
                AopHelper.ExecuteCondition(invocation);
                //方法执行完存入Redis
                redis.Set(strKey, invocation.ReturnValue.ToString());
            }
            else
            {
                AopHelper.ExecuteCondition(invocation);
            }
        }
    }
}
