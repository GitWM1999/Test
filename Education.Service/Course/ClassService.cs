using AutoMapper;
using Education.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Model;
using Education.DTO;
using Education.Repository.Class;

namespace Education.Service
{
    public class ClassService: BaseService,IClassService
    {
        public IClassRepository _classRepository;
        public IMapper _mapper;
        public IClassTypesRepository _classTypeRepository;

        public ClassService(IMapper mapper,IClassRepository classRepository, IClassTypesRepository classTypeRepository)
        {
            _classRepository = classRepository;
            _classTypeRepository = classTypeRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// 显示与查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<ClassListOutPut> GetClassLists(string courseName = "", int state = 0, int check = 0, string free = "", string checkStat = "")
        {
            //调用方法
            List<ClassList> classLists = _classRepository.GetClassLists(courseName,state,check,free,checkStat);
            //映射
            var  classListOutPuts = Mapper.Map<List<ClassListOutPut>>(classLists);
            return classListOutPuts;
        }


        /// <summary>
        /// 修改上下架状态
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int EditClassStat(int id = 0, int stat = 0)
        {
            int i = _classRepository.EditClassStat(id,stat);
            return i;
        }


        /// <summary>
        /// 修改课程信息
        /// </summary>
        /// <param name="listInPut"></param>
        /// <returns></returns>
        public int EditCourse(ClassListInPut listInPut)
        {
            var list = _mapper.Map<ClassList>(listInPut);
            int i = _classRepository.EditCourse(list);
            return i;
        }

        /// <summary>
        /// 修改课程状态
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int EditCourseStat(int id = 0, int classStat = 0)
        {
            int i = _classRepository.EditCourseStat(id,classStat);
            return i;
        }


        /// <summary>
        /// 修改课程审核状态
        /// </summary>
        /// <param name="listInPut"></param>
        /// <returns></returns>
        public int EditCheckStat(ClassListInPut listInPut)
        {
            var list = _mapper.Map<ClassList>(listInPut);
            int i = _classRepository.EditCheckStat(list);
            return i;
        }


        /// <summary>
        /// 添加二级分类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int AddClassSecondTypeInput(ClassSecondTypeInput input)
        {
            ClassSecondType classSecondTypeEntity = _mapper.Map<ClassSecondType>(input);
            
            int i = _classTypeRepository.AddSedStairData(classSecondTypeEntity);

            return i;
        }

        /// <summary>
        /// 添加一级分类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int AddClassTypeInput(ClassTypeInput input)
        {
            ClassType classTypeEntity = _mapper.Map<ClassType>(input);

            int i = _classTypeRepository.AddStairData(classTypeEntity);

            return i;

        }

        /// <summary>
        /// 类型的显示
        /// </summary>
        /// <param name="State"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<ClassTypeOutput> GetClassType(int State = -1, string Name = "")
        {
            //找到仓储层的实体
            List<ClassType> classListEntities = _classTypeRepository.GetClassType(State, Name);
            //转换成映射
            List<ClassTypeOutput> classTypeOutputs = _mapper.Map<List<ClassTypeOutput>>(classListEntities);
            //返回数据
            return classTypeOutputs;
        }

        /// <summary>
        /// 删除一级分类
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteClassType(int Id)
        {
            int i = _classTypeRepository.DeleteClassType(Id);

            return i;
        }

        /// <summary>
        /// 修改一级分类
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public int UptClassType(int Id = 0, string Name = "")
        {
            int i = _classTypeRepository.UptStairData(Id, Name);

            return i;
        }

        /// <summary>
        /// 显示二级的分类
        /// </summary>
        /// <param name="State"></param>
        /// <param name="Name"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<ClassSecondType> ShowSedEntity(int State = 0, string Name = "", int Id = -1)
        {
            List<ClassSecondType> classSecondTypeEntities = _classTypeRepository.GetSedData(State, Name, Id);

            return classSecondTypeEntities;
        }

        /// <summary>
        /// 删除二级的节点
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteSedClassType(int Id)
        {
            int i = _classTypeRepository.DeleteSedType(Id);

            return i;
        }

        /// <summary>
        /// 查询直播课程
        /// </summary>
        /// <param name="class_ClassType"></param>
        /// <returns></returns>
        public List<VideoOutPut> GetVideo(int class_ClassType = 0)
        {
            List<Video> videoOutPuts = _classRepository.GetVideo(class_ClassType);

            //映射
            var videoOutPut = _mapper.Map<List<VideoOutPut>>(videoOutPuts);

            return videoOutPut;

        }

        /// <summary>
        /// 查询录播课程
        /// </summary>
        /// <param name="class_ClassType"></param>
        /// <returns></returns>
        public List<ClassListOutPut> GetLVideoClassList(int class_ClassType = 0)
        {
            List<ClassList> classOutPuts = _classRepository.GetLVideoClassList(class_ClassType);

            //映射
            var classOutPut = Mapper.Map<List<ClassListOutPut>>(classOutPuts);

            return classOutPut;
        }

        /// <summary>
        /// 查询秒杀课程
        /// </summary>
        /// <returns></returns>
        public List<ClassListOutPut> GetSVideoClassList()
        {
            List<ClassList> classOutPuts = _classRepository.GetSVideoClassList();

            //映射
            var classOutPut = Mapper.Map<List<ClassListOutPut>>(classOutPuts);

            return classOutPut;
        }

        /// <summary>
        /// 我的收藏
        /// </summary>
        /// <param name="Class_Id"></param>
        /// <returns></returns>
        public int Upt(int Class_Id = 0)
        {
            int i = _classRepository.Upt(Class_Id);

            return i;
        }

        /// <summary>
        /// 直播收藏
        /// </summary>
        /// <param name="VideoId"></param>
        /// <returns></returns>
        public int Vupt(int VideoId = 0)
        {
            int i = _classRepository.Vupt(VideoId);

            return i;
        }
    }
}
