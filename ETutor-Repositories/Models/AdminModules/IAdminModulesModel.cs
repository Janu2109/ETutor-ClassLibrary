using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.AdminModules
{
    public interface IAdminModulesModel
    {
        string Name { get; set; }
        string Description { get; set; }
        string Course { get; set; }
        string LectureFirstName { get; set; }
        string LectureLastName { get; set; }
    }
}
