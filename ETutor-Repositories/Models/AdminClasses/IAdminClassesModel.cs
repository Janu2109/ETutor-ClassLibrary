using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.AdminClasses
{
    public interface IAdminClassesModel
    {
        string Day { get; set; }
        string TimeStart { get; set; }
        string TimeEnd { get; set; }
        string LectureFirstName { get; set; }
        string LectureLastName { get; set; }
        string Module { get; set; }
    }
}
