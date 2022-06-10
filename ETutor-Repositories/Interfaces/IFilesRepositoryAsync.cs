using ETutor_Repositories.Models.Files;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Interfaces
{
    public interface IFilesRepositoryAsync
    {
        Task<int> Insert(string name, int moduleId, int userId);
        Task<int> Delete_File(int fileId);
        Task<ICollection<IFiles>> Select_Lecture(int lectureId);
    }
}
