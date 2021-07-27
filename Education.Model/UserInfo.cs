using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Model
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string UserNumber { get; set; }
        public string UserAccount { get; set; }
        public string UserPass { get; set; }
        public string UserNike { get; set; }
        public string UserName { get; set; }
        public int UserAge { get; set; }
        public int UserSex { get; set; }
        public string UserPhone { get; set; }
        public string UserComment { get; set; }
        public string UserFace { get; set; }
        public DateTime CreatePersonTime { get; set; }
        public int IsDelete { get; set; }
        


    }
}
