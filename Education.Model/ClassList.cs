using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Model
{
    public class ClassList
    {
        public int Class_Id { get; set; }
        public string Class_Img { get; set; }
        public string Class_Name { get; set; }
        public decimal Class_Price { get; set; }
        public decimal Class_SalePrice { get; set; }
        public int Class_Added { get; set; }
        public int Class_State { get; set; }
        public int Class_Sort { get; set; }
        public int Teacher_Id { get; set; }
        public string Class_CheckState { get; set; }
        public string Class_CheckRemark { get; set; }
        public string Class_ArticleDescription { get; set; }
        public int Class_ClassType { get; set; }
        public int Class_Second { get; set; }
        public int Class_IsDelete { get; set; }
        public int Class_Collect { get; set; }
        public int Class_SaleState { get; set; }


        public int SecondType_Id { get; set; }
        public string SecondType_Name { get; set; }


        public int Type_Id { get; set; }
        public string Type_Name { get; set; }

        public string TypeName{ get { return  Type_Name+"-"+SecondType_Name; } }
    }
}
