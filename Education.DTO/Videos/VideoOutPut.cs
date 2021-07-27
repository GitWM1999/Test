using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.DTO
{
    public class VideoOutPut
    {
        public int OutPutVideoId { get; set; }                         //直播id
        public string OutPutCourseTitle { get; set; }                 //课程标题
        public string OutPutCourseDescription { get; set; }          //课程介绍
        public decimal OutPutCoursePrice { get; set; }                //课程价格
        public DateTime OutPutBeginTime { get; set; }                 //直播预约开始时间
        public DateTime OutPutEndTime { get; set; }                   //直播预约结束时间
        public int OutPutType_Id { get; set; }                        //课程分类
        public int OutPutVideoState { get; set; }                     //直播状态
        public string OutPutVideoImg { get; set; }                    //封面图片
        public int OutPutTeachers_Id { get; set; }                     //讲师id
        public string OutPutBeginTimes { get; set; }
        public int OutPutTeacher_Id { get; set; }                     //讲师id
        public int OutPutVideoCollect { get; set; }

        public string OutPutTeacher_Name { get; set; }                  //讲师姓名


    }
}
