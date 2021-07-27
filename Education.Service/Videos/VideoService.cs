using Education.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Repository;
using Education.Model;
using AutoMapper;
using Education.Common;

namespace Education.Service.Videos
{
    public class VideoService :IVideoService
    {
        IVideoRepository _videoRepository;
        private IMapper _mapper;
        public VideoService(IVideoRepository videoRepository,IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 删除直播
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelVideo(int id)
        {
            int i = _videoRepository.DelVideo(id);
            return i;
        }

        /// <summary>
        /// 修改直播状态
        /// </summary>
        /// <param name="inPut"></param>
        /// <returns></returns>
        public int EditVideoStat(VideoInPut inPut)
        {
            var overstat = _mapper.Map<Video>(inPut);
            var videostat = _videoRepository.EditVideoStat(overstat);
            return videostat;
        }


        /// <summary>
        /// 获取直播的信息
        /// </summary>
        /// <returns></returns>
        //[Log]
       // [RedisCache]
       // [Transaction]
        public List<VideoOutPut> GetVideos(string name="",int stat=0,int videofree=0)
        {
            List<Video> videos = _videoRepository.GetVideos(name,stat,videofree);
            List<VideoOutPut> outPuts = _mapper.Map<List<VideoOutPut>>(videos);
            return outPuts;
        }


    }
}
