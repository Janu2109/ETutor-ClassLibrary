 using ETutor_Repositories.Interfaces;
using ETutor_Repositories.Models.Courses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Repositories
{
    public class CourseRepositoryAsync : RepositoryBase<ICourses>, ICourseRepositoryAsync
    {
        public CourseRepositoryAsync() { }

        public CourseRepositoryAsync(IDatabase database) : base(database) { }

        public override ICourses Adapt(IDataReader dataReader)
        {
            return new Courses
            {
                Id = (int)dataReader["Id"],
                Name = (string)dataReader["Name"].ToString(),
                Description = (string)dataReader["Description"].ToString(),
                Duration = (string)dataReader["Duration"].ToString()
            };
        }

        #region SELECT

        public async Task<ICollection<ICourses>> Select_Courses_All()
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_GET_Courses_All]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (var courses = await command.ExecuteReaderAsync())
                {
                    return await ReadCollectionAsync(courses, this);
                }
            }
        }

        #endregion

        #region INSERT

        public async Task<int> Insert(string name, string description, string duration)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_INSERT_Course]", Database.SqlConnection as SqlConnection))
            {
                //Set command type I want to fire
                command.CommandType = CommandType.StoredProcedure;

                //Parameters Stored Proc will be expecting 
                command.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = name
                });
                command.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = description

                });
                command.Parameters.Add(new SqlParameter("@duration", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = duration

                });

                return await command.ExecuteNonQueryAsync();
            }
        }

        #endregion

        #region DELETE

        public async Task<int> Delete_Course(int id)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_DELETE_Course]", Database.SqlConnection as SqlConnection))
            {
                //Set command type I want to fire
                command.CommandType = CommandType.StoredProcedure;

                //Parameters Stored Proc will be expecting 
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = id
                });

                return await command.ExecuteNonQueryAsync();
            }
        }

        #endregion

        #region UPDATE

        public async Task<int> Update_Course(int id, string name, string duration, string description)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_UPDATE_Course]", Database.SqlConnection as SqlConnection))
            {
                //Set command type I want to fire
                command.CommandType = CommandType.StoredProcedure;

                //Parameters Stored Proc will be expecting 
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = id
                });
                command.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = name
                });
                command.Parameters.Add(new SqlParameter("@duration", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = duration
                });
                command.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = description
                });

                return await command.ExecuteNonQueryAsync();
            }
        }

        #endregion
    }
}
