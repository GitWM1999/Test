
using Education.Common;
using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.Class
{
    public class ClassRepository : IClassTypesRepository
    {
        //实例化工厂类
        DBFactory factory = new DBFactory();

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="State"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<ClassType> GetClassType(int State = 0, string Name = "")
        {
            //sql语句
            string sql = "select * from ClassType where 1=1 and Type_IsDelete=0";
            if (State != 0)
            {
                sql += $" and Type_State={State}";
            }
            if (!string.IsNullOrEmpty(Name))
            {
                sql += $" and Type_Name like '%{Name}%'";
            }
            //调用方法
            List<ClassType> typeModels = factory.CRUD().GetClassLists<ClassType>(sql);
            //返回
            return typeModels;
        }

        /// <summary>
        /// 添加一级分类
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public int AddStairData(ClassType enitytype)
        {
            //sql语句
            string sql = "insert into ClassType VALUES(null,@Type_Name,@Type_State,@Type_Sort,@Type_Remark,@Type_IsDelete,@Creator,@CreateTime,@Updateor,@UpdateTime)";
            //调用方法
            int i = factory.CRUD().Execute(sql,
            new
            {
                @Type_Id = "null",
                @Type_Name = enitytype.Type_Name,
                @Type_State = 1,
                @Type_Sort = 6,
                @Type_Remark = "课程好的没法说！！",
                @Type_IsDelete = 0,
                @Creator="俊杰",
                @CreateTime="2021-3-4",
                @Updateor="万淼",
                @UpdateTime= "2021-3-10"
            });
            //返回
            return i;
        }

        /// <summary>
        /// 添加二级分类
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int AddSedStairData(ClassSecondType classSecondTypeEntity)
        {
            //sql语句
            string sql = "insert into ClassSecondType VALUES(null,@SecondType_Name,@SecondType_State,@SecondType_Sort,@SecondType_Remark,@Class_ClassType,@Type_IsDelete,@Creator,@CreateTime,@Updateor,@UpdateTime)";
            //调用方法
            int i = factory.CRUD().Execute(sql, new
            {
                @SecondType_Id = "null",
                @SecondType_Name = classSecondTypeEntity.SecondType_Name,
                @SecondType_State = 1,
                @SecondType_Sort = 6,
                @SecondType_Remark = "专业好的没法说！！",
                @Class_ClassType = classSecondTypeEntity.Class_ClassType,
                @Type_IsDelete = 0,
                @Creator = "小黑",
                @CreateTime = "2021-3-4",
                @Updateor = "李淼",
                @UpdateTime = "2021-3-10"
            });
            //返回
            return i;
        }

        /// <summary>
        /// 删除一级分类
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteClassType(int Id = 0)
        {
            //sql语句
            string sql = $"select *from ClassSecondType where Class_ClassType={Id}";
            //获取数据
            List<ClassType> sedlist = factory.CRUD().GetClassLists<ClassType>(sql);
            //获取二级的分类个数
            int Num = sedlist.Count();
            //判断一级下面是否有二级分类
            if (Num != 0)
            {
                return 0;
            }
            string sqlserve = "delete from ClassType where Type_Id=@Type_Id";
            //删除一级
            int i =  factory.CRUD().Execute(sqlserve, new
            {
                @Type_Id = Id
            });
            //返回
            return i;
        }

        /// <summary>
        /// 编辑一级分类
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public int UptStairData(int Id = 0, string Name = "")
        {
            //sql语句
            string sql = "UPDATE ClassType SET Type_Name=@Type_Name,Type_State=@Type_State,Type_Sort=@Type_Sort,Type_Remark=@Type_Remark,Type_IsDelete=@Type_IsDelete Where Type_Id=@Type_Id";
            //调用方法
            int i = factory.CRUD().Execute(sql, new
            {
                @Type_Id = Id,
                @Type_Name = Name,
                @Type_State = 1,
                @Type_Sort = 6,
                @Type_Remark = "课程好的没法说！！",
                @Type_IsDelete = 0
            });
            //返回
            return i;
        }

        /// <summary>
        /// 得到二级的菜单列表数据
        /// </summary>
        /// <param name="State"></param>
        /// <param name="Name"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<ClassSecondType> GetSedData(int State = 0, string Name = "", int Id = -1)
        {
            //sql语句
            string sql = $"select * from ClassSecondType where 1=1 and Type_IsDelete=0 and Class_ClassType={Id}";
            if (State != 0)
            {
                sql += $" and SecondType_State={State}";
            }
            if (!string.IsNullOrEmpty(Name))
            {
                sql += $" and SecondType_Name like '%{Name}%'";
            }
            //调用方法
            List<ClassSecondType> typeModels = factory.CRUD().GetClassLists<ClassSecondType>(sql);
            //返回
            return typeModels;
        }

        /// <summary>
        /// 删除二级
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteSedType(int Id = 0)
        {
            string sqlserve = "delete from ClassSecondType where SecondType_Id=@SecondType_Id";
            //删除一级
            int i = factory.CRUD().Execute(sqlserve, new
            {
                @SecondType_Id = Id
            });
            //返回
            return i;
        }


    }
}
