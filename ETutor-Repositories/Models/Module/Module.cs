using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.Module
{
    public class Module : IModule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LectureId { get; set; }
        public int CourseId { get; set; }
    }
}
