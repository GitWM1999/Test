using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Education.Service;
using Education.Common;
using Education.DTO;
using Education.Model;

namespace Education.API.Controllers
{
    
    [ApiController]
    public class CourseController : ControllerBase
    {
        IClassService _classService;

        public CourseController(IClassService classService)
        {
            _classService = classService;
        }
        


        /// <summary>
        /// 获取课程
        /// </summary>
        /// <param name="courseName"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [Route("/api/GetCourse")]
        [HttpGet]
        [Log]
        public ResultData GetCourse(string courseName = "", int state = 0, int check = 0, string free = "", string checkStat = "")
        {

            List<ClassListOutPut> outputs = _classService.GetClassLists(courseName,state,check,free,checkStat); 
            return APIResultHelper.Success(outputs);
        }


        /// <summary>
        /// 修改课程上下架状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stat"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("/api/EditClassStat")]
        public ResultData EditClassStat(int id=0, int stat=0)
        {
            int i = _classService.EditClassStat(id,stat);
            return APIResultHelper.Success(i);
        }


        /// <summary>
        /// 修改课程
        /// </summary>
        /// <param name="classList"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("/api/EditCourse")]
        public ResultData EditCourse(ClassListInPut listInPut)
        {
            int i = _classService.EditCourse(listInPut);
            return APIResultHelper.Success(i);
        }


        /// <summary>
        /// 修改课程状态
        /// </summary>
        [HttpPut]
        [Route("/api/EditCourseStat")]
        public ResultData EditCourseStat(int id=0, int classStat=0)
        {
            int i = _classService.EditCourseStat(id, classStat);
            return APIResultHelper.Success(i);
        }


        /// <summary>
        /// 修改审核状态
        /// </summary>
        /// <param name="classList"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("/api/EditCheckStat")]
        public ResultData EditCheckStat(ClassListInPut classList)
        {
            int i = _classService.EditCheckStat(classList);
            return APIResultHelper.Success(i);
            
        }


        /// <summary>
        /// 获取类型一级数据方法
        /// </summary>
        /// <returns></returns>
        [Route("GetStairData")]
        [HttpGet]
        public ResultData GetStairData(int State = 0, string Name = "")
        {
            //调用方法
            List<ClassTypeOutput> outputs = _classService.GetClassType(State, Name);
            //返回
            return APIResultHelper.Success(outputs);
        }


        /// <summary>
        /// 添加类型一级数据方法
        /// </summary>
        /// <returns></returns>
        [Route("AddStairData")]
        [HttpPost]
        public ResultData AddStairData(ClassTypeInput input)
        {
            int i = _classService.AddClassTypeInput(input);

            return APIResultHelper.Success(i);
        }


        /// <summary>
        /// 删除一级的分类
        /// </summary>
        /// <returns></returns>
        [Route("DeleteClassType")]
        [HttpDelete]
        public ResultData DeleteClassType(int Id = 0)
        {
            int i = _classService.DeleteClassType(Id);

            return APIResultHelper.Success(i);
        }


        /// <summary>
        /// 添加二级类型
        /// </summary>
        /// <returns></returns>
        [Route("AddSedStairData")]
        [HttpPost]
        public ResultData AddSedStairData(ClassSecondTypeInput classSecondTypeInput)
        {
            //添加二级 
            int i = _classService.AddClassSecondTypeInput(classSecondTypeInput);
            //返回
            return APIResultHelper.Success(i);
        }


        /// <summary>
        /// 修改类型
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        [Route("UptStairData")]
        [HttpPut]
        public ResultData UptStairData(int Id = 0, string Name = "")
        {
            int i = _classService.UptClassType(Id, Name);
            //返回
            return APIResultHelper.Success(i);
        }


        /// <summary>
        /// 获取商品类型一级数据方法
        /// </summary>
        /// <returns></returns>
        [Route("GetSedData")]
        [HttpGet]
        public ResultData GetSedData(int State = 0, string Name = "", int Id = -1)
        {
            List<ClassSecondType> typeModels = _classService.ShowSedEntity(State, Name, Id);
            //返回
            return APIResultHelper.Success(typeModels);
        }


        /// <summary>
        /// 删除一级的分类
        /// </summary>
        /// <returns></returns>
        [Route("DeleteSedType")]
        [HttpGet]
        public ResultData DeleteSedType(int Id = 0)
        {
            int i = _classService.DeleteSedClassType(Id);
            //返回
            return APIResultHelper.Success(i);
        }


        /// <summary>
        /// 查询直播
        /// </summary>
        /// <param name="State"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        [Route("GetVideo")]
        [HttpGet]
        public ResultData GetVideo(int class_ClassType=0)
        {
            //调用方法
            List<VideoOutPut> outputs = _classService.GetVideo(class_ClassType);
            //返回
            return APIResultHelper.Success(outputs);
        }



        /// <summary>
        /// 查询录播
        /// </summary>
        /// <param name="class_ClassType"></param>
        /// <returns></returns>
        [Route("GetLVideo")]
        [HttpGet]
        public ResultData GetLVideo(int class_ClassType=0)
        {
            //调用方法
            List<ClassListOutPut> outputs = _classService.GetLVideoClassList(class_ClassType);
            //返回
            return APIResultHelper.Success(outputs);
        }

        
        /// <summary>
        /// 查询秒杀
        /// </summary>
        /// <param name="class_ClassType"></param>
        /// <returns></returns>
        [Route("GetSVideo")]
        [HttpGet]
        public ResultData GetSVideo()
        {
            //调用方法
            List<ClassListOutPut> outputs = _classService.GetSVideoClassList();
            //返回
            return APIResultHelper.Success(outputs);
        }

        /// <summary>
        /// 我的收藏
        /// </summary>
        /// <param name="Class_Id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("GetCollect")]
        public ResultData GetCollect(int Class_Id)
        {
            int i = _classService.Upt(Class_Id);

            return APIResultHelper.Success(i);
        }

        /// <summary>
        /// 我的收藏
        /// </summary>
        /// <param name="Class_Id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("GetVideoCollect")]
        public ResultData GetVideoCollect(int VideoId)
        {
            int i = _classService.Vupt(VideoId);

            return APIResultHelper.Success(i);
        }

    }
}
