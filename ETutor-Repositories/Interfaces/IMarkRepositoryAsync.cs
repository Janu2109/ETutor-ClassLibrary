using ETutor_Repositories.Models.Marks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Interfaces
{
    public interface IMarkRepositoryAsync
    {
        Task<int> Insert(int mark, int moduleId, int userId);
        Task<ICollection<IMarks>> Select_Marks(int studentId);
    }
}
