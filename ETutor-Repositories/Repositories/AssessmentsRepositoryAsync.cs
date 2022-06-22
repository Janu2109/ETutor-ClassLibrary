using ETutor_Repositories.Interfaces;
using ETutor_Repositories.Models.Assessments;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Repositories
{
    public class AssessmentsRepositoryAsync : RepositoryBase<IAssessments>, IAssessmentsRepositoryAsync
    {
        public AssessmentsRepositoryAsync() { }
        public AssessmentsRepositoryAsync(IDatabase database) : base(database) { }

        public override IAssessments Adapt(IDataReader dataReader)
        {
            return new Assessments
            {
                Id = (int)dataReader["Id"],
                ModuleId = (int)dataReader["ModuleId"],
                Title = (string)dataReader["Title"].ToString(),
                QuestionOneQ = (string)dataReader["QuestionOneQ"].ToString(),
                QuestionOneA = (string)dataReader["QuestionOneA"].ToString(),
                QuestionOneO = (string)dataReader["QuestionOneO"].ToString(),
                QuestionTwoQ = (string)dataReader["QuestionTwoQ"].ToString(),
                QuestionTwoA = (string)dataReader["QuestionTwoA"].ToString(),
                QuestionTwoO = (string)dataReader["QuestionTwoO"].ToString(),
                QuestionThreeQ = (string)dataReader["QuestionThreeQ"].ToString(),
                QuestionThreeA = (string)dataReader["QuestionThreeA"].ToString(),
                QuestionThreeO = (string)dataReader["QuestionThreeO"].ToString(),
                QuestionFourQ = (string)dataReader["QuestionFourQ"].ToString(),
                QuestionFourA = (string)dataReader["QuestionFourA"].ToString(),
                QuestionFourO = (string)dataReader["QuestionFourO"].ToString(),
                QuestionFiveQ = (string)dataReader["QuestionFiveQ"].ToString(),
                QuestionFiveA = (string)dataReader["QuestionFiveA"].ToString(),
                QuestionFiveO = (string)dataReader["QuestionFiveO"].ToString(),
            };
        }

        #region INSERT

        public async Task<int> Insert(int moduleId, string title, string questionOneQ, string questionOneA, string questionOneO, string questionTwoQ, string questionTwoA, string questionTwoO, string questionThreeQ, string questionThreeA, string questionThreeO, string questionFourQ, string questionFourA, string questionFourO, string questionFiveQ, string questionFiveA, string questionFiveO)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_INSERT_Assessment]", Database.SqlConnection as SqlConnection))
            {
                //Set command type I want to fire
                command.CommandType = CommandType.StoredProcedure;

                //Parameters Stored Proc will be expecting 
                command.Parameters.Add(new SqlParameter("@moduleId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = moduleId
                });
                command.Parameters.Add(new SqlParameter("@title", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = title

                });
                command.Parameters.Add(new SqlParameter("@questionOneQ", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = questionOneQ

                });
                command.Parameters.Add(new SqlParameter("@questionOneA", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = questionOneA

                });
                command.Parameters.Add(new SqlParameter("@questionOneO", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = questionOneO

                });
                command.Parameters.Add(new SqlParameter("@questionTwoQ", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = questionTwoQ

                });
                command.Parameters.Add(new SqlParameter("@questionTwoA", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = questionTwoA

                });
                command.Parameters.Add(new SqlParameter("@questionTwoO", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = questionTwoO

                });
                command.Parameters.Add(new SqlParameter("@questionThreeQ", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = questionThreeQ

                });
                command.Parameters.Add(new SqlParameter("@questionThreeA", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = questionThreeA

                });
                command.Parameters.Add(new SqlParameter("@questionThreeO", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = questionThreeO

                });
                command.Parameters.Add(new SqlParameter("@questionFourQ", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = questionFourQ

                });
                command.Parameters.Add(new SqlParameter("@questionFourA", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = questionFourA

                });
                command.Parameters.Add(new SqlParameter("@questionFourO", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = questionFourO

                });
                command.Parameters.Add(new SqlParameter("@questionFiveQ", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = questionFiveQ

                });
                command.Parameters.Add(new SqlParameter("@questionFiveA", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = questionFiveA

                });
                command.Parameters.Add(new SqlParameter("@questionFiveO", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = questionFiveO

                });

                return await command.ExecuteNonQueryAsync();
            }
        }

        #endregion

        #region SELECT

        public async Task<ICollection<IAssessments>> Select_Assessments()
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_GET_Assessments]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (var assessments = await command.ExecuteReaderAsync())
                {
                    return await ReadCollectionAsync(assessments, this);
                }
            }
        }

        #endregion
    }
}
