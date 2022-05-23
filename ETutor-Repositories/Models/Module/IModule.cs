using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.Module
{
    public interface IModule
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int LectureId { get; set; }
        int CourseId { get; set; }
    }
}
