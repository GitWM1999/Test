using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Education.Service;
using Education.DTO;
using Education.Common;

namespace Education.API.Controllers
{
    
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }


        /// <summary>
        /// 获取文章信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetArticle")]
        public ResultData GetArticle(string title="")
        {
            List<ArticleOutPut> outputArticle = _articleService.GetArticles(title);
            return APIResultHelper.Success(outputArticle);
        }


        /// <summary>
        /// 获取分类的信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetClassType")]
        public ResultData GetClassType(int id=0)
        {
            List<ArticleTypeOutPut> typeOutputs = _articleService.GetClassTypes(id);
            return APIResultHelper.Success(typeOutputs);
        }



    }
}
