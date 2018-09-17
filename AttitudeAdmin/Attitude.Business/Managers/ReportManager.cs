using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attitude.DAL.DALRepository;
using Attitude.Shared.Entities;
using AttitudeAdmin.Extensions;
using AttitudeMeasurement.DAL.Enums;

namespace Attitude.Business
{
    public class ReportManager
    {
        private IReportDal _reportDal = new ReportDal();

        public List<FrequencyBaseViewReport> GetReport6(string userId)
        {
            return _reportDal.GetReport(StoreProcedureName.Rpt_Table6, userId);
        }

        public List<FrequencyBaseViewReport> GetReport7(string userId)
        {
            return _reportDal.GetReport(StoreProcedureName.Rpt_Table7, userId);
        }

        public List<FrequencyBaseViewReport> GetReport8(string userId)
        {

            return _reportDal.GetReport(StoreProcedureName.Rpt_Table8, userId);
        }

        public List<FrequencyBaseViewReport> GetReport9(string userId)
        {
            return _reportDal.GetReport(StoreProcedureName.Rpt_Table9, userId);
        }

        public List<FrequencyBaseViewReport> GetReport10(string userId)
        {
            return _reportDal.GetReport(StoreProcedureName.Rpt_Table10, userId);
        }

        public List<FrequencyBaseViewReport> GetReport11(string userId)
        {
            return _reportDal.GetReport(StoreProcedureName.Rpt_Table11, userId);
        }


        public List<VM_AttituteViewReport> GetReport14(string userId)
        {
            var attitudeViewReports = _reportDal.GetReportAttitude(StoreProcedureName.Rpt_Table14, userId);
            var selectListItesm = new List<VM_AttituteViewReport>();
            var result = attitudeViewReports.GroupBy(q => q.questionType);
            foreach (var item in Enum.GetValues(typeof(QuestionType)))
            {
                foreach (var item2 in Enum.GetValues(typeof(Gender)))
                {
                    selectListItesm.Add(new VM_AttituteViewReport()
                    {
                        RowTitle = ((QuestionType)item).ToDescriptionEnum(),
                        ColTitle = ((Gender)item2).ToDescriptionEnum(),
                        Value = attitudeViewReports.Any(q => q.questionType == (int)item && q.Title.Contains(((Gender)item2).ToDescriptionEnum())) ? attitudeViewReports.Where(q => q.questionType == (int)item).Sum(p => p.Sum) : 0

                    });
                }
            }

            return selectListItesm;
        }

        public List<VM_AttituteViewReport> GetReport15(string userId)
        {
            var attitudeViewReports = _reportDal.GetReportAttitude(StoreProcedureName.Rpt_Table15, userId);
            var selectListItesm = new List<VM_AttituteViewReport>();
            var result = attitudeViewReports.GroupBy(q => q.questionType);
            foreach (var item in Enum.GetValues(typeof(QuestionType)))
            {
                foreach (var item2 in Enum.GetValues(typeof(Age)))
                {
                    selectListItesm.Add(new VM_AttituteViewReport()
                    {
                        RowTitle = ((QuestionType)item).ToDescriptionEnum(),
                        ColTitle = ((Age)item2).ToDescriptionEnum(),
                        Value = attitudeViewReports.Any(q => q.questionType == (int)item && q.Title.Contains(((Age)item2).ToDescriptionEnum())) ? attitudeViewReports.Where(q => q.questionType == (int)item).Sum(p => p.Sum) : 0

                    });
                }
            }

            return selectListItesm;
        }

        public List<VM_AttituteViewReport> GetReport16(string userId)
        {
            var attitudeViewReports = _reportDal.GetReportAttitude(StoreProcedureName.Rpt_Table16, userId);
            var selectListItesm = new List<VM_AttituteViewReport>();
            var result = attitudeViewReports.GroupBy(q => q.questionType);
            foreach (var item in Enum.GetValues(typeof(QuestionType)))
            {
                foreach (var item2 in Enum.GetValues(typeof(WorkExperience)))
                {
                    selectListItesm.Add(new VM_AttituteViewReport()
                    {
                        RowTitle = ((QuestionType)item).ToDescriptionEnum(),
                        ColTitle = ((WorkExperience)item2).ToDescriptionEnum(),
                        Value = attitudeViewReports.Any(q => q.questionType == (int)item && q.Title.Contains(((WorkExperience)item2).ToDescriptionEnum())) ? attitudeViewReports.Where(q => q.questionType == (int)item).Sum(p => p.Sum) : 0

                    });
                }
            }

            return selectListItesm;
        }

        public List<VM_AttituteViewReport> GetReport17(string userId)
        {
            var attitudeViewReports = _reportDal.GetReportAttitude(StoreProcedureName.Rpt_Table17, userId);
            var selectListItesm = new List<VM_AttituteViewReport>();
            var result = attitudeViewReports.GroupBy(q => q.questionType);
            foreach (var item in Enum.GetValues(typeof(QuestionType)))
            {
                foreach (var item2 in Enum.GetValues(typeof(CurrentWorkExperience)))
                {
                    selectListItesm.Add(new VM_AttituteViewReport()
                    {
                        RowTitle = ((QuestionType)item).ToDescriptionEnum(),
                        ColTitle = ((CurrentWorkExperience)item2).ToDescriptionEnum(),
                        Value = attitudeViewReports.Any(q => q.questionType == (int)item && q.Title.Contains(((CurrentWorkExperience)item2).ToDescriptionEnum())) ? attitudeViewReports.Where(q => q.questionType == (int)item).Sum(p => p.Sum) : 0

                    });
                }
            }

            return selectListItesm;
        }

        public List<VM_AttituteViewReport> GetReport18(string userId)
        {
            var attitudeViewReports = _reportDal.GetReportAttitude(StoreProcedureName.Rpt_Table18, userId);
            var selectListItesm = new List<VM_AttituteViewReport>();
            var result = attitudeViewReports.GroupBy(q => q.questionType);
            foreach (var item in Enum.GetValues(typeof(QuestionType)))
            {
                foreach (var item2 in Enum.GetValues(typeof(Education)))
                {
                    selectListItesm.Add(new VM_AttituteViewReport()
                    {
                        RowTitle = ((QuestionType)item).ToDescriptionEnum(),
                        ColTitle = ((Education)item2).ToDescriptionEnum(),
                        Value = attitudeViewReports.Any(q => q.questionType == (int)item && q.Title.Contains(((Education)item2).ToDescriptionEnum())) ? attitudeViewReports.Where(q => q.questionType == (int)item).Sum(p => p.Sum) : 0

                    });
                }
            }

            return selectListItesm;
        }

        public List<VM_AttituteViewReport> GetReport19(string userId)
        {
            var attitudeViewReports = _reportDal.GetReportAttitude(StoreProcedureName.Rpt_Table19, userId);
            var selectListItesm = new List<VM_AttituteViewReport>();
            var result = attitudeViewReports.GroupBy(q => q.questionType);
            foreach (var item in Enum.GetValues(typeof(QuestionType)))
            {
                foreach (var item2 in Enum.GetValues(typeof(Position)))
                {
                    selectListItesm.Add(new VM_AttituteViewReport()
                    {
                        RowTitle = ((QuestionType)item).ToDescriptionEnum(),
                        ColTitle = ((Position)item2).ToDescriptionEnum(),
                        Value = attitudeViewReports.Any(q => q.questionType == (int)item && q.Title.Contains(((Position)item2).ToDescriptionEnum())) ? attitudeViewReports.Where(q => q.questionType == (int)item).Sum(p => p.Sum) : 0

                    });
                }
            }

            return selectListItesm;
        }

        public List<VM_AttituteViewReportMain> GetReport21(string userId)
        {
            var attitudeViewReports = _reportDal.GetReport21(StoreProcedureName.Rpt_Table21, userId);
            var selectListItesm = new List<VM_AttituteViewReportMain>();
            return attitudeViewReports;
        }
    }
}
