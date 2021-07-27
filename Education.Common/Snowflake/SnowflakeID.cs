using Snowflake.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Common
{
    public static class SnowflakeID
    {
        //生成雪花ID
        public static long GenerateSnowflakeID()
        {
            //IdWorker 应该以单实例模式运行，否则会出现重复Id。
            //理论上两个参数：
            //在同一workid，datacenterid下，1ms 能产生2^12 – 1(4095)个id。
            //不同workid，datacenterid，1ms能产生2 ^ 22 – 1(近420w)个id， 1秒钟产生42亿个id
            IdWorker idWorker = new IdWorker(1,1);
            //生成雪花ID
            long snowflakeID = idWorker.NextId();
            //返回值
            return snowflakeID;
        }
    }
}
