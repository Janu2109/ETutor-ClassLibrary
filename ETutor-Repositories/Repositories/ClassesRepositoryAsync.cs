using ETutor_Repositories.Interfaces;
using ETutor_Repositories.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Repositories
{
    public class ClassesRepositoryAsync : RepositoryBase<IClasses>, IClassesRepositoryAsync
    {
        public ClassesRepositoryAsync() { }

        public ClassesRepositoryAsync(IDatabase database) : base(database) { }

        public override IClasses Adapt(IDataReader dataReader)
        {
            return new Classes
            {
                Id = (int)dataReader["Id"],
                LectureId = (int)dataReader["LectureId"],
                ModuleId = (int)dataReader["ModuleId"],
                Day = (string)dataReader["Day"].ToString(),
                TimeStart = (string)dataReader["TimeStart"].ToString(),
                TimeEnd = (string)dataReader["TimeEnd"].ToString()
            };
        }

        #region INSERT

        public async Task<int> Insert(int lectureId, int moduleId, string day, string startTime, string endTime)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_INSERT_Classes]", Database.SqlConnection as SqlConnection))
            {
                //Set command type I want to fire
                command.CommandType = CommandType.StoredProcedure;

                //Parameters Stored Proc will be expecting 
                command.Parameters.Add(new SqlParameter("@lectureId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = lectureId
                });
                command.Parameters.Add(new SqlParameter("@moduleId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = moduleId

                });
                command.Parameters.Add(new SqlParameter("@day", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = day

                });
                command.Parameters.Add(new SqlParameter("@timeStart", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = startTime

                });
                command.Parameters.Add(new SqlParameter("@timeEnd", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = endTime

                });

                return await command.ExecuteNonQueryAsync();
            }
        }

        #endregion

        #region SELECT

        public async Task<ICollection<IClasses>> Select_Classes_LectureId(int lectureId)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_SELECT_Classes_LectureId]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@lectureId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = lectureId
                });

                using (var classes = await command.ExecuteReaderAsync())
                {
                    return await ReadCollectionAsync(classes, this);
                }
            }
        }

        public async Task<ICollection<IClasses>> Select_Classes_ModuleId(int moduleId)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_GET_Classes_ModuleId]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@moduleId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = moduleId
                });

                using (var classes = await command.ExecuteReaderAsync())
                {
                    return await ReadCollectionAsync(classes, this);
                }
            }
        }

        public async Task<ICollection<IClasses>> Select()
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_SELECT_Classes]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (var classes = await command.ExecuteReaderAsync())
                {
                    return await ReadCollectionAsync(classes, this);
                }
            }
        }

        #endregion

        #region DELETE

        public async Task<int> Delete(int classId)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_DELETE_Class]", Database.SqlConnection as SqlConnection))
            {
                //Set command type I want to fire
                command.CommandType = CommandType.StoredProcedure;

                //Parameters Stored Proc will be expecting 
                command.Parameters.Add(new SqlParameter("@classId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = classId
                });

                return await command.ExecuteNonQueryAsync();
            }
        }

        #endregion
    }
}
