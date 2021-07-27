using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Common
{
    public static class AopHelper
    {
        public static void ExecuteCondition(IInvocation invocation)
        {
            //判断是否已经执行完毕方法
            if (invocation.ReturnValue == null)
            {
                //执行方法
                invocation.Proceed();
            }
        }
    }
}
