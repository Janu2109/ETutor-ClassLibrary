using ETutor_Repositories.Interfaces;
using ETutor_Repositories.Models.StudentsEnrolled;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Repositories
{
    public class StudentsEnrolledRepositoryAsync : RepositoryBase<IStudentsEnrolled>, IStudentsEnrolledRepositoryAsync
    {
        public StudentsEnrolledRepositoryAsync() { }

        public StudentsEnrolledRepositoryAsync(IDatabase database) : base(database) { }

        public override IStudentsEnrolled Adapt(IDataReader dataReader)
        {
            return new StudentsEnrolled
            {
                FirstName = (string)dataReader["FirstName"].ToString(),
                LastName = (string)dataReader["LastName"].ToString(),
                Email = (string)dataReader["Email"].ToString(),
                Name = (string)dataReader["Name"].ToString()
            };
        }

        #region SELECT

        public async Task<ICollection<IStudentsEnrolled>> Select()
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_SELECT_Enrolled]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (var courses = await command.ExecuteReaderAsync())
                {
                    return await ReadCollectionAsync(courses, this);
                }
            }
        }

        #endregion

    }
}
