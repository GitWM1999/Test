using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Common;

namespace Education.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        DBFactory db = new DBFactory();

        /// <summary>
        /// 获取文章信息
        /// </summary>
        /// <returns></returns>
        public List<CustomerArticle> GetArticles(string title="")
        {
            string sql = $"select * from CustomerArticle where 1=1";
            if (!string.IsNullOrEmpty(title))
            {
                sql += $" and ArticleTitle like concat('%',@title,'%')";
            }
            return db.CRUD().GetClassLists<CustomerArticle>(sql,new { @title=title});
        }

        /// <summary>
        /// 获取分类的信息
        /// </summary>
        /// <returns></returns>
        public List<ClassType> GetClassTypes(int id=0)
        {
            string sql = $"select * from CustomerArticle join ClassType on CustomerArticle.ArticleTypeId=ClassType.Type_Id where 1=1";
            if (id != 0)
            {
                 sql += $" and ClassType.Type_Id=@id";
            }
            
            return db.CRUD().GetClassLists<ClassType>(sql,new { @id=id});
        }



    }
}
