using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Common;
using Education.Model;

namespace Education.Repository
{
    public interface IClassRepository
    {
        //获取课程信息
        List<ClassList> GetClassLists(string courseName = "", int state = 0, int check = 0, string free = "", string checkStat = "");

        //修改上下架状态
        int EditClassStat(int id = 0, int stat = 0);

        //修改课程信息
        int EditCourse(ClassList list);

        //修改课程状态
        int EditCourseStat(int id = 0, int classStat = 0);

        //修改课程审核状态
        int EditCheckStat(ClassList list);

        //获取直播课程信息
        List<Video> GetVideo(int class_ClassType = 0);

        //获取录播课程信息
        List<ClassList> GetLVideoClassList(int class_ClassType = 0);

        //获取秒杀课程信息
        List<ClassList> GetSVideoClassList();

        //收藏我的录播+秒杀课程
        int Upt(int Class_Id=0);

        //收藏我的直播课程
        int Vupt(int VideoId = 0);

    }
}
