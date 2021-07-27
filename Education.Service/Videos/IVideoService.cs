using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.DTO;

namespace Education.Service
{
    public interface IVideoService
    {
        /// <summary>
        /// 获取直播信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="stat"></param>
        /// <param name="videofree"></param>
        /// <returns></returns>
        List<VideoOutPut> GetVideos(string name="",int stat=0,int videofree=0);


        /// <summary>
        /// 删除直播
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DelVideo(int id);

        /// <summary>
        /// 修改直播的状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stat"></param>
        /// <returns></returns>
        int EditVideoStat(VideoInPut inPut);

    }
}
