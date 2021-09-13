using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCHOOL_MANAGEMENT.Data.DataModel.Teacher
{
    public class TeacherModel :BaseDataModel
    {
        public string Name { get; set; }
        public string Ph_Number { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
    }
}
