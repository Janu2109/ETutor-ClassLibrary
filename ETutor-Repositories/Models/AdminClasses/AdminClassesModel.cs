using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.AdminClasses
{
    public class AdminClassesModel : IAdminClassesModel
    {
        public string Day { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public string  LectureFirstName { get; set; }
        public string LectureLastName { get; set; }
        public string Module { get; set; }
    }
}
