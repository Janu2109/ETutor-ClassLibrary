using ETutor_Repositories.Interfaces;
using ETutor_Repositories.Models.Marks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Repositories
{
    public class MarkRepositoryAsync : RepositoryBase<IMarks>, IMarkRepositoryAsync
    {
        public MarkRepositoryAsync() { }
        public MarkRepositoryAsync(IDatabase database) : base(database) { }

        public override IMarks Adapt(IDataReader dataReader)
        {
            return new Marks
            {
                Id = (int)dataReader["Id"],
                Mark = (int)dataReader["Mark"],
                ModuleId= (int)dataReader["ModuleId"],
                UserId = (int)dataReader["UserId"],
            };
        }

        #region INSERT

        public async Task<int> Insert(int mark, int moduleId, int userId)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_INSERT_Mark]", Database.SqlConnection as SqlConnection))
            {
                //Set command type I want to fire
                command.CommandType = CommandType.StoredProcedure;

                //Parameters Stored Proc will be expecting 
                command.Parameters.Add(new SqlParameter("@mark", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = mark
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

        public async Task<ICollection<IMarks>> Select_Marks(int studentId)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_GET_Marks_StudentId]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@studentId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = studentId
                });

                using (var module = await command.ExecuteReaderAsync())
                {
                    return await ReadCollectionAsync(module, this);
                }
            }
        }

        #endregion
    }
}
