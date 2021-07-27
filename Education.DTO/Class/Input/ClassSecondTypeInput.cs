using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.DTO
{
    /// <summary>
    /// 添加二级分类
    /// </summary>
    public class ClassSecondTypeInput
    {
        public int   Class_ClassType { get; set; }      // 课程分类

        public string SecondType_Name { get; set; }  // 二级分类名称
    } 
}
