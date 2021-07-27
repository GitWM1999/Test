using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.Common
{
    public class JwtResultData
    {
        public int code { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
    }
}
