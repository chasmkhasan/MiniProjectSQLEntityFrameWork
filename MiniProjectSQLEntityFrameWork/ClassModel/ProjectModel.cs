using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectSQLEntityFrameWork.ClassModel
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Project_Name { get; set; }

        // all properties should be together. Prop should be like ProjectName instead of Project_Name. _ used is a bad practise.
    }
}
