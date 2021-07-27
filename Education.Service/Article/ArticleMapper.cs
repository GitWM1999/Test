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
    public class ArticleMapper:Profile
    {
        public ArticleMapper()
        {
            CreateMap<CustomerArticle, ArticleOutPut>()
                .ForMember(d => d.OutPutId, m => m.MapFrom(m => m.Id))
                .ForMember(d => d.OutPutArticleTitle, m => m.MapFrom(m => m.ArticleTitle))
                .ForMember(d => d.OutPutArticleContent, m => m.MapFrom(m => m.ArticleContent))
                .ForMember(d => d.OutPutReleaseTime, m => m.MapFrom(m => m.ReleaseTime))
                .ForMember(d => d.OutPutUserPhone, m => m.MapFrom(m => m.UserPhone))
                ;

            CreateMap<ClassType,ArticleTypeOutPut>();

        }

    }
}
