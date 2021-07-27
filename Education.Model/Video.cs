using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Model
{
    public class Video
    {
        public int VideoId { get; set; }                         //直播id
        public string CourseTitle { get; set; }                 //课程标题
        public string CourseDescription { get; set; }          //课程介绍
        public decimal CoursePrice { get; set; }                //课程价格
        public DateTime BeginTime { get; set; }                 //直播预约开始时间
        public DateTime EndTime { get; set; }                   //直播预约结束时间
        public int Type_Id { get; set; }                        //课程分类
        public int VideoState { get; set; }                     //直播状态
        public DateTime VideoTrueBeginTime { get; set; }        //真实开始时间
        public DateTime VideoTrueEndTime { get; set; }          //真实结束时间
        public string VideoImg { get; set; }                    //封面图片
        public int VideoShowModel { get; set; }                 //直播显示模式
        public int Teachers_Id { get; set; }                     //讲师id
        public string Creator { get; set; }                     //创建人
        public DateTime CreateTime { get; set; }                //创建时间
        public int Updateor { get; set; }                       //修改人
        public int VideoCollect { get; set; }

        public DateTime UpdateTime { get; set; }                //修改时间
        public string BeginTimes { get; set; }

        public int Teacher_Id { get; set; }                     //讲师id
        public string Teacher_Name { get; set; }                  //讲师姓名

    }
}
