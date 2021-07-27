using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Common
{
    public class ResultData
    {
        /// <summary>
        /// 状态
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }
    }
}
