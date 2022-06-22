using ETutor_Repositories.Models.Module;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETutor_Repositories.Interfaces
{
    public interface IModuleRepositoryAsync
    {
        Task<ICollection<IModule>> Select_Module_LectureId(int lectureId);
        Task<ICollection<IModule>> Select_Modules_Student_Enrolled(int userId);
        Task<ICollection<IModule>> Select_Modules();
        Task<int> Insert(string name, string description, int courseId, int lectureId);
        Task<int> Delete(int moduleId);
        Task<int> Update(int moduleId, string name, string description, int lectureId, int courseId);
    }
}
