using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Education.Common;
using Education.Service;
using Education.DTO;

namespace Education.API.Controllers
{
    
    [ApiController]
    public class VideoController : ControllerBase
    {
        IVideoService _videoService;
        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }


        /// <summary>
        /// 获取直播信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetVideo")]
        public ResultData GetVideo(string name="",int stat=0,int videofree=0)
        {
            var videos = _videoService.GetVideos(name,stat,videofree);
            return APIResultHelper.Success(videos);
        }


        /// <summary>
        /// 删除直播
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("/api/DelVideo")]
        public ResultData DelVideo(int id)
        {
            int i = _videoService.DelVideo(id);
            return APIResultHelper.Success(i);
        }


        /// <summary>
        /// 修改直播状态
        /// </summary>
        /// <param name="inPut"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("/api/EditVideoStat")]
        public ResultData EditVideoStat(VideoInPut inPut)
        {
            int i = _videoService.EditVideoStat(inPut);
            return APIResultHelper.Success(i);
        }



    }
}
