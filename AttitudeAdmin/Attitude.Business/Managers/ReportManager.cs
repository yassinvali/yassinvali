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
                var order = (int)item;
                var sortOrder = order > 100 ? order - 100 : order > 1 ? order + 6 : order;
                foreach (var item2 in Enum.GetValues(typeof(Gender)))
                {
                    selectListItesm.Add(new VM_AttituteViewReport()
                    {
                        RowTitle = ((QuestionType)item).ToDescriptionEnum(),
                        ColTitle = ((Gender)item2).ToDescriptionEnum(),
                        Value = attitudeViewReports.Any(q => q.questionType == order && q.Id == (int)item2) ? attitudeViewReports.Single(q => q.questionType == order && q.Id == (int)item2).average : 0,
                        SortOrder = sortOrder
                    });
                }
            }

            return selectListItesm.OrderBy(q=>q.SortOrder).ToList();
        }

        public List<VM_AttituteViewReport> GetReport15(string userId)
        {
            var attitudeViewReports = _reportDal.GetReportAttitude(StoreProcedureName.Rpt_Table15, userId);
            var selectListItesm = new List<VM_AttituteViewReport>();
            var result = attitudeViewReports.GroupBy(q => q.questionType);
            foreach (var item in Enum.GetValues(typeof(QuestionType)))
            {
                var order = (int)item;
                var sortOrder = order > 100 ? order - 100 : order > 1 ? order + 6 : order;

                foreach (var item2 in Enum.GetValues(typeof(Age)))
                {
                    selectListItesm.Add(new VM_AttituteViewReport()
                    {
                        RowTitle = ((QuestionType)item).ToDescriptionEnum(),
                        ColTitle = ((Age)item2).ToDescriptionEnum(),
                        Value = attitudeViewReports.Any(q => q.questionType == (int)item && q.Id == (int)item2) ? attitudeViewReports.Single(q => q.questionType == (int)item && q.Id == (int)item2).average : 0,
                        SortOrder = sortOrder
                        
                    });
                }
            }

            return selectListItesm.OrderBy(q => q.SortOrder).ToList();
        }

        public List<VM_AttituteViewReport> GetReport16(string userId)
        {
            var attitudeViewReports = _reportDal.GetReportAttitude(StoreProcedureName.Rpt_Table16, userId);
            var selectListItesm = new List<VM_AttituteViewReport>();
            var result = attitudeViewReports.GroupBy(q => q.questionType);
            foreach (var item in Enum.GetValues(typeof(QuestionType)))
            {
                var order = (int)item;
                var sortOrder = order > 100 ? order - 100 : order > 1 ? order + 6 : order;
              foreach (var item2 in Enum.GetValues(typeof(WorkExperience)))
                {
                    selectListItesm.Add(new VM_AttituteViewReport()
                    {
                        RowTitle = ((QuestionType)item).ToDescriptionEnum(),
                        ColTitle = ((WorkExperience)item2).ToDescriptionEnum(),
                        Value = attitudeViewReports.Any(q => q.questionType == (int)item && q.Id == (int)item2) ? attitudeViewReports.Single(q => q.questionType == (int)item && q.Id == (int)item2).average : 0,
                        SortOrder = sortOrder

                    });
                }
            }

            return selectListItesm.OrderBy(q=>q.SortOrder).ToList();
        }

        public List<VM_AttituteViewReport> GetReport17(string userId)
        {
            var attitudeViewReports = _reportDal.GetReportAttitude(StoreProcedureName.Rpt_Table17, userId);
            var selectListItesm = new List<VM_AttituteViewReport>();
            var result = attitudeViewReports.GroupBy(q => q.questionType);
            foreach (var item in Enum.GetValues(typeof(QuestionType)))
            {
                var order = (int)item;
                var sortOrder = order > 100 ? order - 100 : order > 1 ? order + 6 : order;

                foreach (var item2 in Enum.GetValues(typeof(CurrentWorkExperience)))
                {
                    selectListItesm.Add(new VM_AttituteViewReport()
                    {
                        RowTitle = ((QuestionType)item).ToDescriptionEnum(),
                        ColTitle = ((CurrentWorkExperience)item2).ToDescriptionEnum(),
                        Value = attitudeViewReports.Any(q => q.questionType == (int)item && q.Id == (int)item2) ? attitudeViewReports.Single(q => q.questionType == (int)item && q.Id == (int)item2).average : 0,
                        SortOrder = sortOrder

                    });
                }
            }

            return selectListItesm.OrderBy(q=>q.SortOrder).ToList();
        }

        public List<VM_AttituteViewReport> GetReport18(string userId)
        {
            var attitudeViewReports = _reportDal.GetReportAttitude(StoreProcedureName.Rpt_Table18, userId);
            var selectListItesm = new List<VM_AttituteViewReport>();
            var result = attitudeViewReports.GroupBy(q => q.questionType);
            foreach (var item in Enum.GetValues(typeof(QuestionType)))
            {
                var order = (int)item;
                var sortOrder = order > 100 ? order - 100 : order > 1 ? order + 6 : order;

                foreach (var item2 in Enum.GetValues(typeof(Education)))
                {
                    selectListItesm.Add(new VM_AttituteViewReport()
                    {
                        RowTitle = ((QuestionType)item).ToDescriptionEnum(),
                        ColTitle = ((Education)item2).ToDescriptionEnum(),
                        Value = attitudeViewReports.Any(q => q.questionType == (int)item && q.Id == (int)item2) ? attitudeViewReports.Single(q => q.questionType == (int)item && q.Id == (int)item2).average : 0,
                        SortOrder = sortOrder

                    });
                }
            }

            return selectListItesm.OrderBy(q=>q.SortOrder).ToList();
        }

        public List<VM_AttituteViewReport> GetReport19(string userId)
        {
            var attitudeViewReports = _reportDal.GetReportAttitude(StoreProcedureName.Rpt_Table19, userId);
            var selectListItesm = new List<VM_AttituteViewReport>();
            var result = attitudeViewReports.GroupBy(q => q.questionType);
            foreach (var item in Enum.GetValues(typeof(QuestionType)))
            {
                var order = (int)item;
                var sortOrder = order > 100 ? order - 100 : order > 1 ? order + 6 : order;

                foreach (var item2 in Enum.GetValues(typeof(Position)))
                {
                    selectListItesm.Add(new VM_AttituteViewReport()
                    {
                        RowTitle = ((QuestionType)item).ToDescriptionEnum(),
                        ColTitle = ((Position)item2).ToDescriptionEnum(),
                        Value = attitudeViewReports.Any(q => q.questionType == (int)item && q.Id == (int)item2) ? attitudeViewReports.Single(q => q.questionType == (int)item && q.Id == (int)item2).average : 0,
                        SortOrder = sortOrder

                    });
                }
            }

            return selectListItesm.OrderBy(q=>q.SortOrder).ToList();
        }

        public List<VM_AttituteViewReportMain> GetReport21(string userId)
        {
            var attitudeViewReports = _reportDal.GetReport21(StoreProcedureName.Rpt_Table21, userId);
            var selectListItesm = new List<VM_AttituteViewReportMain>();
            return attitudeViewReports;
        }

        public List<string[]> GetAllSurvay(string userId)
        {
            var attitudeViewReports = _reportDal.GetAllSheetDetail(StoreProcedureName.GetAllSheetDetail, userId);
            var level1 = attitudeViewReports.GroupBy(q => q.masId);


            var result = new List<string[]>();
            foreach (var item1 in level1)
            {
                var baseInfo = new string[119];

                baseInfo[0] = item1.First().UserId;
                baseInfo[1] = item1.First().ATitle;
                baseInfo[2]=item1.First().GTitle;
                baseInfo[3]=item1.First().xpTitle;
                baseInfo[4]=item1.First().CxpTitle;
                baseInfo[5]=item1.First().EduTitle;
                baseInfo[6]=item1.First().PTitle;
               
                var i = 7;
                foreach (var reportExcel in item1)
                {
                    baseInfo[i] = reportExcel.SelectOptionId.ToString();
                    i++;
                }
                result.Add(baseInfo);
            }

            return result;
        }
       
    }

}
