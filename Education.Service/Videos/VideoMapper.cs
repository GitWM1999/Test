using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Education.Model;
using Education.DTO;

namespace Education.Service
{
    public class VideoMapper:Profile
    {
        public VideoMapper()
        {
            //查询，显示
            CreateMap<Video, VideoOutPut>()
                 .ForMember(d => d.OutPutVideoId, m => m.MapFrom(m => m.VideoId))
                 .ForMember(d => d.OutPutCourseTitle, m => m.MapFrom(m => m.CourseTitle))
                 .ForMember(d => d.OutPutCoursePrice, m => m.MapFrom(m => m.CoursePrice))
                 .ForMember(d => d.OutPutVideoState, m => m.MapFrom(m => m.VideoState))
                  .ForMember(d => d.OutPutTeacher_Name, m => m.MapFrom(m => m.Teacher_Name))
                  .ForMember(d => d.OutPutVideoImg, m => m.MapFrom(m => m.VideoImg))
                   .ForMember(d => d.OutPutCourseDescription, m => m.MapFrom(m => m.CourseDescription))
                   .ForMember(d => d.OutPutCoursePrice, m => m.MapFrom(m => m.CoursePrice))
                   .ForMember(d => d.OutPutVideoCollect, m => m.MapFrom(m => m.VideoCollect));

            //修改
            CreateMap<VideoInPut, Video>()
                 .ForMember(d => d.VideoId, m => m.MapFrom(m => m.InPutVideoId))
                 .ForMember(d => d.VideoState, m => m.MapFrom(m => m.InPutVideoState))
                 .ForMember(d => d.VideoCollect, m => m.MapFrom(m => m.InPutVideoCollect))
                 .ForMember(d => d.EndTime, m => m.MapFrom(m => m.InPutEndTime));


        }
    }
}
