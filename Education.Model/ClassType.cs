using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Model
{
    public class ClassType
    {
        public int Type_Id { get; set; }         // 类型序号 

        public string Type_Name { get; set; }     // 分类名称

        public int Type_State { get; set; }         // 类型的状态(0禁用 1正常)

        public int Type_Sort { get; set; }     // 排序

        public string Type_Remark { get; set; }         // 类型备注

        public int Type_IsDelete { get; set; }             // 逻辑删除标识符

        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Updateor { get; set; }
        public DateTime UpdateTime { get; set; }


        public int Id { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public DateTime ReleaseTime { get; set; }
        public int UserId { get; set; }
        public string UserPhone { get; set; }
        public int ArticleTypeId { get; set; }

    }
}
