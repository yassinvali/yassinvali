using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attitude.Shared.Entities;
using AttitudeAdmin.Entitess;
using AttitudeMeasurement.DAL.Entities;
using Dapper;
using DapperParameters;

namespace Attitude.DAL.DALRepository
{
    public class QuestionDal : IQuestionDal
    {

        public List<Question> GetQuestions()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                var result = connection.Query<Question>("GetQuestions", commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
        public void Insert(QuestionSheet questionSheet)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserId", questionSheet.UserId,DbType.String);
                dynamicParameters.Add("@Gender", questionSheet.Gendar,DbType.Int32);
                dynamicParameters.Add("@Age", (int)questionSheet.Age, DbType.Int32);
                dynamicParameters.Add("@WorkExperience", questionSheet.WorkExperience, DbType.Int32);
                dynamicParameters.Add("@CurrentWorkExperience", questionSheet.CurrentWorkExperience, DbType.Int32);
                dynamicParameters.Add("@Education", questionSheet.Education, DbType.Int32);
                dynamicParameters.Add("@Position", questionSheet.Position, DbType.Int32);
                dynamicParameters.AddTable("@questionAnswer", "QuestionAnswer", questionSheet.AnswerList);

                connection.Execute("InsertQuestionSheet", dynamicParameters, commandType: CommandType.StoredProcedure);
                connection.Close();
            }
        }

        public DataTable ToDataTable(List<AnswerModel> values)
        {
            var dt = new DataTable();
            dt.Columns.Add("QuestionId", typeof(int));
            dt.Columns.Add("AnswerId", typeof(int));
            foreach (var pair in values)
            {
                var row = dt.NewRow();
                row["QuestionId"] = pair.QuestionId;
                row["AnswerId"] = pair.AnswerId;
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}
