using ETutor_Repositories.Interfaces;
using ETutor_Repositories.Models.Files;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Repositories
{
    public class FilesRepositoryAsync : RepositoryBase<IFiles>, IFilesRepositoryAsync
    {
        public FilesRepositoryAsync() { }
        public FilesRepositoryAsync(IDatabase database) : base(database) { }

        public override IFiles Adapt(IDataReader dataReader)
        {
            return new Files
            {
                Id = (int)dataReader["Id"],
                Name = (string)dataReader["Name"].ToString(),
                ModuleId = (int)dataReader["ModuleId"],
                UserId = (int)dataReader["UserId"],
            };
        }

        #region INSERT

        public async Task<int> Insert(string name, int moduleId, int userId)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_INSERT_File]", Database.SqlConnection as SqlConnection))
            {
                //Set command type I want to fire
                command.CommandType = CommandType.StoredProcedure;

                //Parameters Stored Proc will be expecting 
                command.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = name
                });
                command.Parameters.Add(new SqlParameter("@moduleId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = moduleId

                });
                command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = userId

                });

                return await command.ExecuteNonQueryAsync();
            }
        }

        #endregion

        #region DELETE

        public async Task<int> Delete_File(int fileId)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_DELETE_File]", Database.SqlConnection as SqlConnection))
            {
                //Set command type I want to fire
                command.CommandType = CommandType.StoredProcedure;

                //Parameters Stored Proc will be expecting 
                command.Parameters.Add(new SqlParameter("@fileId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = fileId
                });

                return await command.ExecuteNonQueryAsync();
            }
        }


        #endregion

        #region SELECT

        public async Task<ICollection<IFiles>> Select_Lecture(int lectureId)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_GET_Files_LectureId]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@lectureId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = lectureId
                });

                using (var user = await command.ExecuteReaderAsync())
                {
                    return await ReadCollectionAsync(user, this);
                }
            }
        }

        public async Task<ICollection<IFiles>> Select_Module(int moduleId)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_GET_Files_ModuleId]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@moduleId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = moduleId
                });

                using (var user = await command.ExecuteReaderAsync())
                {
                    return await ReadCollectionAsync(user, this);
                }
            }
        }

        #endregion
    }
}
