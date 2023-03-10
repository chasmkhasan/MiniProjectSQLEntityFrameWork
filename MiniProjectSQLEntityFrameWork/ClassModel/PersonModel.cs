using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectSQLEntityFrameWork.ClassModel
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Person_Name { get; set; }

        // all properties should be together. Prop should be like PersonName instead of Person_Name. _ used is a bad practise.
    }
}
