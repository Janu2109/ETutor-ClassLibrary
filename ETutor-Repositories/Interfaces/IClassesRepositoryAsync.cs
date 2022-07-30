using ETutor_Repositories.Models.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Interfaces
{
    public interface IClassesRepositoryAsync
    {
        Task<int> Insert(int lectureId, int moduleId, string day, string startTime, string endTime);
        Task<ICollection<IClasses>> Select_Classes_LectureId(int lectureId);
        Task<ICollection<IClasses>> Select_Classes_ModuleId(int moduleId);
        Task<ICollection<IClasses>> Select();
        Task<int> Delete(int classId);
    }
}
