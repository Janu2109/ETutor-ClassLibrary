using ETutor_Repositories.Interfaces;
using ETutor_Repositories.Models.Module;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Repositories
{
    public class ModuleRepositoryAsync : RepositoryBase<IModule>, IModuleRepositoryAsync
    {
        public ModuleRepositoryAsync() { }

        public ModuleRepositoryAsync(IDatabase database) : base(database) { }

        public override IModule Adapt(IDataReader dataReader)
        {
            return new Module
            {
                Id = (int)dataReader["Id"],
                Name = (string)dataReader["Name"].ToString(),
                Description = (string)dataReader["Description"].ToString(),
                LectureId = (int)dataReader["LectureId"],
                CourseId = (int)dataReader["CourseId"]
            };
        }

        #region SELECT

        public async Task<ICollection<IModule>> Select_Module_LectureId(int lectureId)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_GET_Modules_LectureId]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@lectureId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = lectureId
                });

                using (var module = await command.ExecuteReaderAsync())
                {
                    return await ReadCollectionAsync(module, this);
                }
            }
        }

        public async Task<ICollection<IModule>> Select_Modules_Student_Enrolled(int userId)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_GET_Student_Modules]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = userId
                });

                using (var module = await command.ExecuteReaderAsync())
                {
                    return await ReadCollectionAsync(module, this);
                }
            }
        }

        public async Task<ICollection<IModule>> Select_Modules()
        {
            Database.Validate();
            
            using(var command = new SqlCommand("[dbo].[USP_GET_Modules]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                using(var modules = await command.ExecuteReaderAsync())
                {
                    return await ReadCollectionAsync(modules, this);
                }
            }
        }

        #endregion

        #region INSERT

        public async Task<int> Insert(string name, string description, int courseId, int lectureId)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_INSERT_Module]", Database.SqlConnection as SqlConnection))
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
                command.Parameters.Add(new SqlParameter("@courseId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = courseId

                });
                command.Parameters.Add(new SqlParameter("@lectureId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = lectureId

                });

                return await command.ExecuteNonQueryAsync();
            }

        }

        #endregion

        #region DELETE

        public async Task<int> Delete(int moduleId)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_DELETE_Module]", Database.SqlConnection as SqlConnection))
            {
                //Set command type I want to fire
                command.CommandType = CommandType.StoredProcedure;

                //Parameters Stored Proc will be expecting 
                command.Parameters.Add(new SqlParameter("@moduleId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = moduleId
                });

                return await command.ExecuteNonQueryAsync();
            }
        }

        #endregion


        #region UPDATE

        public async Task<int> Update(int moduleId, string name, string description, int lectureId, int courseId)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_UPDATE_Module]", Database.SqlConnection as SqlConnection))
            {
                //Set command type I want to fire
                command.CommandType = CommandType.StoredProcedure;

                //Parameters Stored Proc will be expecting 
                command.Parameters.Add(new SqlParameter("@moduleId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = moduleId
                });
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
                command.Parameters.Add(new SqlParameter("@lectureId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = lectureId
                });
                command.Parameters.Add(new SqlParameter("@courseId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = courseId
                });
                return await command.ExecuteNonQueryAsync();
            }
        }

        #endregion
    }
}
