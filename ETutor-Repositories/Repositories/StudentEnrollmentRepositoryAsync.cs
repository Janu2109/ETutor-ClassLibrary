using ETutor_Repositories.Interfaces;
using ETutor_Repositories.Models.StudentEnrollment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Repositories
{
    public class StudentEnrollmentRepositoryAsync : RepositoryBase<IStudentEnrollment>, IStudentEnrollmentRepositoryAsync
    {
        public StudentEnrollmentRepositoryAsync() { }

        public StudentEnrollmentRepositoryAsync(IDatabase database) : base(database) { }

        public override IStudentEnrollment Adapt(IDataReader dataReader)
        {
            return new StudentEnrollment
            {
                Id = (int)dataReader["Id"],
                UserId = (int)dataReader["UserId"],
                CourseId = (int)dataReader["CourseId"]
            };
        }

        public async Task<int> Insert(int userId, int courseId)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_INSERT_Enrollment]", Database.SqlConnection as SqlConnection))
            {
                //Set command type I want to fire
                command.CommandType = CommandType.StoredProcedure;

                //Parameters Stored Proc will be expecting 
                command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = userId
                });
                command.Parameters.Add(new SqlParameter("@courseId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = courseId
                });

                return await command.ExecuteNonQueryAsync();
            }
        }
    }
}
