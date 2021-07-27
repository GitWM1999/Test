using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.DTO
{
    public class ClassSecondTypeOutput
    {
        public int SecondType_Id { get; set; }  // 二级类型序号

        public string SecondType_Name { get; set; }  // 二级分类名称

        public int SecondType_State { get; set; }      // 二级类型的状态(0禁用

        public int SecondType_Sort { get; set; }  // 二级排序

        public string SecondType_Remark { get; set; }   // 二级类型备注

        public int Class_ClassType { get; set; }      // 课程分类

        public int Type_IsDelete { get; set; }      // 逻辑删除标识符
    }
}
