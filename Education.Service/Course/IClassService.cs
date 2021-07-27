using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Common;
using Education.Model;
using Education.DTO;

namespace Education.Service
{
    public interface IClassService
    {
        //获取课程信息
        List<ClassListOutPut> GetClassLists(string courseName = "", int state = 0, int check = 0, string free = "", string checkStat = "");

        //修改上下架状态
        int EditClassStat(int id = 0, int stat = 0);

        //修改课程信息
        int EditCourse(ClassListInPut listInPut);

        //修改课程状态
        int EditCourseStat(int id = 0, int classStat = 0);

        //修改课程审核状态
        int EditCheckStat(ClassListInPut list);

        /// <summary>
        /// 显示+查询
        /// </summary>
        /// <param name="State"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        List<ClassTypeOutput> GetClassType(int State = -1, string Name = "");

        /// <summary>
        /// 添加一级分类
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        int AddClassTypeInput(ClassTypeInput input);

        /// <summary>
        /// 添加二级分类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        int AddClassSecondTypeInput(ClassSecondTypeInput input);

        /// <summary>
        /// 删除一级分类
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int DeleteClassType(int Id);

        /// <summary>
        /// 修改类型
        /// </summary>
        /// <returns></returns>
        int UptClassType(int Id = 0, string Name = "");

        /// <summary>
        /// 显示二级类型
        /// </summary>
        /// <returns></returns>
        List<ClassSecondType> ShowSedEntity(int State = 0, string Name = "", int Id = -1);

        /// <summary>
        /// 删除二级分类
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int DeleteSedClassType(int Id);

        //获取直播课程信息
        List<VideoOutPut> GetVideo(int class_ClassType=0);

        //获取录播课程信息
        List<ClassListOutPut> GetLVideoClassList(int class_ClassType = 0);

        //获取秒杀课程信息
        List<ClassListOutPut> GetSVideoClassList();

        //收藏我的录播+秒杀课程
        int Upt(int Class_Id=0);

        //收藏我的直播课程
        int Vupt(int VideoId = 0);

    }
}
