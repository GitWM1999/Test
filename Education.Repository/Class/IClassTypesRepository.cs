
using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.Class
{
    public interface IClassTypesRepository
    {
        /// <summary>
        /// 显示一级分类
        /// </summary>
        /// <param name="State"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        List<ClassType> GetClassType(int State = -1, string Name = "");

        /// <summary>
        /// 添加一级分类
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        int AddStairData(ClassType enitytype);

        /// <summary>
        /// 添加二级类型
        /// </summary>
        /// <returns></returns>
        int AddSedStairData(ClassSecondType classSecondTypeEntity);

        /// <summary>
        /// 删除一级的分类
        /// </summary>
        /// <returns></returns>
        int DeleteClassType(int Id = 0);

        /// <summary>
        /// 修改类型
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        int UptStairData(int Id = 0, string Name = "");

        /// <summary>
        /// 显示二级的分类
        /// </summary>
        /// <returns></returns>
        List<ClassSecondType> GetSedData(int State = 0, string Name = "", int Id = -1);

        /// <summary>
        /// 删除二级的分类
        /// </summary>
        /// <returns></returns>
        int DeleteSedType(int Id = 0);
       
    }
}
