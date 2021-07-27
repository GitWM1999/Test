using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Model;
using Education.DTO;

namespace Education.Service
{
    public class ClassMapper: Profile
    {
        public ClassMapper()
        {
            //显示，查询
            CreateMap<ClassList, ClassListOutPut>()
                .ForMember(d => d.Class_Name, m => m.MapFrom(m => m.Class_Name))
                .ForMember(d => d.Class_Id, m => m.MapFrom(m => m.Class_Id))
                .ForMember(d => d.Class_Collect, m => m.MapFrom(m => m.Class_Collect))
                .ForMember(d => d.Class_Img, m => m.MapFrom(m => m.Class_Img));

            //修改
            CreateMap<ClassListInPut, ClassList>();

            //类型显示映射
            CreateMap<ClassType, ClassTypeOutput>();
            //一级分类的添加
            CreateMap<ClassTypeInput, ClassType>();
            //二级分类的添加
            CreateMap<ClassSecondTypeInput, ClassSecondType>();

            //CreateMap<Video, VideoOutPut>();
            

        }
    }
}
