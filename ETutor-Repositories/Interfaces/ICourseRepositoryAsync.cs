using ETutor_Repositories.Models.Courses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Interfaces
{
    public interface ICourseRepositoryAsync
    {
        Task<ICollection<ICourses>> Select_Courses_All();

        Task<int> Insert(string name, string description, string duration);

        Task<int> Delete_Course(int id);

        Task<int> Update_Course(int id, string name, string duration, string description);
    }
}
