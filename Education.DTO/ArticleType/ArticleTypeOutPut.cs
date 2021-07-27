using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.DTO
{
    public class ArticleTypeOutPut
    {

        public int Type_Id { get; set; }
        public string Type_Name { get; set; }
        public int Type_State { get; set; }
        public int Type_Sort { get; set; }
        public string Type_Remark { get; set; }

        public int Id { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public DateTime ReleaseTime { get; set; }
        public int UserId { get; set; }
        public string UserPhone { get; set; }
    }
}
