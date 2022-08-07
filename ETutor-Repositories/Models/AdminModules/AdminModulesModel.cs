using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.AdminModules
{
    public class AdminModulesModel : IAdminModulesModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Course { get; set; }
        public string LectureFirstName { get; set; }
        public string LectureLastName { get; set; }
    }
}
