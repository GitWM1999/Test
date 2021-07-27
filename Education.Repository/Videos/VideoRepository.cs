using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Common;

namespace Education.Repository
{
    public class VideoRepository : IVideoRepository
    {
        DBFactory db = new DBFactory();

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelVideo(int id)
        {
            string sql = $"delete from Video where VideoId=@id";
            return db.CRUD().Execute(sql, new { @id = id });
        }

        /// <summary>
        /// 修改直播状态
        /// </summary>
        /// <param name="time"></param>
        /// <param name="id"></param>
        /// <param name="stat"></param>
        /// <returns></returns>
        public int EditVideoStat(Video video)
        {
            DateTime time = DateTime.Now;
            var stat = 0;
            if (video.VideoState == 1)
            {
                stat = 2;
            }
            string sql = $"update Video set VideoState=@stat,BeginTime=@time where VideoId=@id";
            return db.CRUD().Execute(sql, new { @stat =stat, @time = time, @id =video.VideoId });

        }


        /// <summary>
        /// 获取直播信息
        /// </summary>
        /// <returns></returns>
        public List<Video> GetVideos(string name="",int stat=0,int videofree=0)
        {
            string sql = $"select * from Video a join TeachersInfor b on a.Teachers_Id=b.Teacher_Id where 1=1";
            if (!string.IsNullOrEmpty(name))
            {
                sql += $" and a.CourseTitle like concat('%',@name,'%')";
            }
            if (stat != 0)
            {
                sql += $" and a.VideoState=@stat";
            }
            if (videofree != 0)
            {
                if (videofree == 1)
                {
                    sql += $" and a.CoursePrice=0";
                }
                else
                {
                    sql += $" and a.CoursePrice!=0";
                }
            }
            return db.CRUD().GetClassLists<Video>(sql,new { @name=name,@stat=stat});
        }



    }
}
