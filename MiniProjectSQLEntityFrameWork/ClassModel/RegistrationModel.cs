using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectSQLEntityFrameWork.ClassModel
{
    public class RegistrationModel
    {
        public int Id { get; set; }
        public int Project_Id { get; set; }
        public string Project_Name { get; set; } // I cant print without taking projectname. That is why i need to take another prop. 
        public int Person_Id { get; set; }
        public string Person_Name { get; set; } // I cant print without taking Personname. That is why i need to take another prop.
        public int Hours { get; set; }

        // all properties should be together. Prop should be like ProjectName instead of Project_Name. _ used is a bad practise.

    }
}
