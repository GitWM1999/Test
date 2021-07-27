
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Model;
using Education.Common;

namespace Education.Repository
{
    public class ClassRepository : IClassRepository
    {
      

        DBFactory db = new DBFactory();


        /// <summary>
        /// 修改课程审核状态
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int EditCheckStat(ClassList list)
        {
            var stat = "";
            if (list.Class_CheckState == "1")
            {
                stat = "审核通过";
            }
            if (list.Class_CheckState == "2")
            {
                stat = "审核未通过";
            }
            string sql = $"update ClassList set Class_CheckState=@stat,Class_CheckRemark=@remark where Class_Id=@id";
            return db.CRUD().Execute(sql, new { @stat = stat, @remark = list.Class_CheckRemark, @id = list.Class_Id });

        }

        /// <summary>
        /// 修改上下架状态
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int EditClassStat(int id = 0, int stat = 0)
        {
            var state = 0;
            if (stat == 1)
            {
                state = 2;
            }
            else
            {
                state = 1;
            }
            string sql = $"update ClassList set Class_Added=@stat where Class_Id=@id";
            return db.CRUD().Execute(sql, new { @stat = state, @id = id });
        }

        /// <summary>
        /// 修改课程
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int EditCourse(ClassList list)
        {
            string sql = $"update ClassList set Class_Name=@name,Class_Price=@price,Class_ArticleDescription=@desc where Class_Id=@id";

            return db.CRUD().Execute(sql, new { @name = list.Class_Name, @price = list.Class_Price, @desc = list.Class_ArticleDescription, @id = list.Class_Id });
        }

        /// <summary>
        /// 修改课程状态
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int EditCourseStat(int id = 0, int classStat = 0)
        {
            var class_State = 0;
            if (classStat == 1)
            {
                class_State = 2;
            }
            if (classStat == 2)
            {
                class_State = 1;
            }
            string sql = $"update ClassList set Class_State=@stat where Class_Id=@id";
            int i = db.CRUD().Execute(sql, new { @stat = class_State, @id = id });
            return i;
        }

        /// <summary>
        /// 获取课程信息
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<ClassList> GetClassLists(string courseName = "", int state = 0, int check = 0, string free = "", string checkstat = "")
        {
            var freemoney = "免费";
            var audit = "";

            if (checkstat == "1")
            {
                audit = "审核通过";
            }
            if (checkstat == "2")
            {
                audit = "审核未通过";
            }
            string sql = $"select * from ClassList a join ClassType b on a.Class_ClassType=b.Type_Id join ClassSecondType c on a.Class_Second=c.SecondType_Id where 1=1";
            if (!string.IsNullOrEmpty(courseName))
            {
                sql += $" and a.Class_Name like concat('%',@cname,'%')";
            }
            if (state != 0)
            {
                sql += $" and a.Class_State=@stat";
            }
            if (check != 0)
            {
                sql += $" and a.Class_Added=@check";
            }
            if (!string.IsNullOrEmpty(free))
            {
                if (free == "是")
                {
                    sql += $" and a.Class_Price=@free";
                }
                if (free == "否")
                {
                    sql += $" and a.Class_Price!=@free";
                }
            }
            if (!string.IsNullOrEmpty(checkstat))
            {
                sql += $" and a.Class_CheckState=@checkstat";
            }

            List<ClassList> lists = db.CRUD().GetClassLists<ClassList>(sql, new { @cname = courseName, @stat = state, @check = check, @free = freemoney, @checkstat = audit });
            return lists;
        }

        /// <summary>
        /// 查询录播课程
        /// </summary>
        /// <param name="class_ClassType"></param>
        /// <returns></returns>
        public List<ClassList> GetLVideoClassList(int class_ClassType = 0)
        {
            string sql = $"select Class_Id,Class_Name,Class_Price,Class_Img,Class_Collect from classlist where 1=1";

            if (class_ClassType != 0)
            {
                sql += $" and Class_ClassType=@class_ClassType";
            }

            sql += " limit 6";

            List<ClassList> lists = db.CRUD().GetClassLists<ClassList>(sql, new { @class_ClassType = class_ClassType });
            return lists;
        }

        /// <summary>
        /// 查询秒杀课程
        /// </summary>
        /// <returns></returns>
        public List<ClassList> GetSVideoClassList()
        {
            string sql = $"select Class_Id,Class_Name,Class_SalePrice,Class_Img,Class_Collect from classlist where Class_SaleState=1";

            sql += " limit 6";

            List<ClassList> lists = db.CRUD().GetClassLists<ClassList>(sql);

            return lists;
        }

        /// <summary>
        /// 查询直播课程
        /// </summary>
        /// <param name="class_ClassType"></param>
        /// <returns></returns>
        public List<Video> GetVideo(int class_ClassType = 0)
        {
            string sql = $"select VideoId,CourseDescription,CoursePrice,VideoImg,VideoCollect from video where 1=1";

            if (class_ClassType != 0)
            {
                sql += $" and Type_Id=@class_ClassType";
            }

            sql += " limit 6";

            List<Video> lists = db.CRUD().GetClassLists<Video>(sql, new { @class_ClassType = class_ClassType});

            return lists;
        }

        /// <summary>
        /// 我的录播+秒杀收藏
        /// </summary>
        /// <param name="Class_Id"></param>
        /// <returns></returns>
        public int Upt(int Class_Id = 0)
        {
            string sql = $"update classlist set Class_Collect=1 where Class_Id=@class_Id";
            int i = db.CRUD().Execute(sql, new {@class_Id=Class_Id });
            return i;

        }

        //直播收藏
        public int Vupt(int VideoId = 0)
        {
            string sql = $"update video set VideoCollect=1 where VideoId=@video_Id";
            int i = db.CRUD().Execute(sql, new { @video_Id = VideoId });
            return i;
        }

    }
}
