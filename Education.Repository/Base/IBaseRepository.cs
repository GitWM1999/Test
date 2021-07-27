using System;
using System.Collections.Generic;

namespace Education.Repository
{
    public interface IBaseRepository<T> where T:class,new()
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Add(T t);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int Delete(int Id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Update(T t);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T Get(int Id);

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        List<T> GetList();
    }
}
