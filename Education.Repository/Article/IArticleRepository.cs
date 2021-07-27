using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Model;

namespace Education.Repository
{
    public interface IArticleRepository
    {
        //获取文章信息
        List<CustomerArticle> GetArticles(string title="");

        //获取分类
        List<ClassType> GetClassTypes(int id=0);

    }
}
