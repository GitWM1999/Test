using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.DTO
{
    public class ClassListOutput
    {
        public int Class_Id { get; set; }          	    //课程序号

        public string Class_Img { get; set; }          	//课程封面

        public string Class_Name { get; set; }          	//课程名称

        public string Class_Price { get; set; }          	//课程价格

        public int Class_Added { get; set; }          	//上下架(0下架 1上架)

        public int Class_State { get; set; }          	//状态(0正常 1禁止)

        public int Class_Collect { get; set; }          	//是否收藏(0不收藏 1收藏)

        public int Class_Sort { get; set; }          	//排序

        public int Teacher_Id { get; set; }          	//讲师Id

        public string Class_CheckState { get; set; }          	    //审核的状态

        public string Class_CheckRemark { get; set; }          	    //审核描述

        public string Class_ArticleDescription { get; set; }     	//文章描述

        public int Class_ClassType { get; set; }          	//课程分类

        public int Class_IsDelete { get; set; }               // 逻辑删除标识符
    }
}
