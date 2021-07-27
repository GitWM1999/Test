using Education.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Education.Repository
{
    public class BaseRepository<T>: IBaseRepository<T> where T :class,new()
    {
        private DBFactory _dBFactory;
        private DBContextHelper _dBContext;

        public BaseRepository(DBFactory dBFactory, DBContextHelper dBContext)
        {
            _dBFactory = dBFactory;
            _dBContext = dBContext;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(T t)
        {
            _dBContext.Set<T>().Add(t);
            return _dBContext.SaveChanges();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            T t = _dBContext.Set<T>().Find(Id);
            _dBContext.Set<T>().Remove(t);
            return _dBContext.SaveChanges();
        }

        /// <summary>
        /// 查询（返回单个对象）
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T Get(int Id)
        {
            return _dBContext.Set<T>().Find(Id);
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<T> GetList()
        {
            return _dBContext.Set<T>().ToList();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(T t)
        {
            _dBContext.Entry<T>(t).State = EntityState.Modified;
            return _dBContext.SaveChanges();
        }
    }
}
