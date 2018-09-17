using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attitude.Shared.Entities;
using AttitudeMeasurement.DAL.Entities;
using AttitudeMeasurement.DAL.Enums;

namespace Attitude.DAL.DALRepository
{
    public interface IReportDal
    {
        List<FrequencyBaseViewReport> GetReport(StoreProcedureName spName,string userId);
        List<AttitudeViewReport> GetReportAttitude(StoreProcedureName spName, string userId);
        List<VM_AttituteViewReportMain> GetReport21(StoreProcedureName spName, string userId);
    }
}
