using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attitude.DAL.Repository;
using Attitude.Shared.Entities;
using AttitudeMeasurement.DAL.Entities;
using AttitudeMeasurement.DAL.Enums;
using Dapper;

namespace Attitude.DAL.DALRepository
{
    public class ReportDal : BaseSqlConnection, IReportDal
    {
        public List<FrequencyBaseViewReport> GetReport(StoreProcedureName spName, string userId)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var result = connection.Query<FrequencyBaseViewReport>(spName.ToString(), new { UserId = userId }, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<AttitudeViewReport> GetReportAttitude(StoreProcedureName spName, string userId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<AttitudeViewReport>(spName.ToString(), new { UserId = userId }, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public List<VM_AttituteViewReportMain> GetReport21(StoreProcedureName spName, string userId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<VM_AttituteViewReportMain>(spName.ToString(), new { UserId = userId }, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public List<ReportExcel> GetAllSheetDetail(StoreProcedureName spName, string userId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<ReportExcel>(spName.ToString(), new { UserId = userId }, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
