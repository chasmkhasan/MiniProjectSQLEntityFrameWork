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
        public int Person_Id { get; set; }
        public int Hours { get; set; }

    }
}
