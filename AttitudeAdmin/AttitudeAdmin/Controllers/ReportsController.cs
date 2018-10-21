using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Attitude.Business;
using Attitude.Shared.Entities;
using Attitude.Shared.Extensions;
using AttitudeAdmin.Extensions;

namespace AttitudeAdmin.Controllers
{
    public class ReportsController : BaseController
    {
        private ReportManager reportManager = new ReportManager();

        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report6()
        {
            try
            {
                ViewBag.ReportId = 6;
                ViewBag.ReportTitle = "فراوانی پاسخگویان به تفکیک جنسیت";
                var model = reportManager.GetReport6(UserId);
                return View("FrequencyReport", model);
            }
            catch (Exception e)
            {
                LogHelper.Error(this, e);
                return View("Error");
            }
        }
        public ActionResult Report7()
        {
            try
            {
                ViewBag.ReportId = 7;
                ViewBag.ReportTitle = "فراوانی پاسخگویان به تفکیک سن";
                var model = reportManager.GetReport7(UserId);
                return View("FrequencyReport", model);
            }
            catch (Exception e)
            {
                LogHelper.Error(this, e);
                return View("Error");
            }
        }
        public ActionResult Report8()
        {

            try
            {
                ViewBag.ReportId = 8;
                ViewBag.ReportTitle = "فراوانی پاسخگویان به تفکیک سنوات خدمت";
                var model = reportManager.GetReport8(UserId);
                return View("FrequencyReport", model);
            }
            catch (Exception e)
            {
                LogHelper.Error(this, e);
                return View("Error");
            }
        }
        public ActionResult Report9()
        {
            try
            {
                ViewBag.ReportId = 9;
                ViewBag.ReportTitle = "فراوانی پاسخگویان به تفکیک سنوات خدمت فعلی";
                var model = reportManager.GetReport9(UserId);
                return View("FrequencyReport", model);
            }
            catch (Exception e)
            {
                LogHelper.Error(this, e);
                return View("Error");
            }
        }
        public ActionResult Report10()
        {
            try
            {
                ViewBag.ReportId = 10;
                ViewBag.ReportTitle = "فراوانی پاسخگویان به تفکیک تحصیلات";
                var model = reportManager.GetReport10(UserId);
                return View("FrequencyReport", model);
            }
            catch (Exception e)
            {
                LogHelper.Error(this, e);
                return View("Error");
            }
        }
        public ActionResult Report11()
        {
            try
            {
                ViewBag.ReportId = 11;
                ViewBag.ReportTitle = "فراوانی پاسخگویان به تفکیک پست سازمانی";
                var model = reportManager.GetReport11(UserId);
                return View("FrequencyReport", model);
            }
            catch (Exception e)
            {
                LogHelper.Error(this, e);
                return View("Error");
            }
        }

        public ActionResult Report14()
        {

            try
            {
                ViewBag.ReportId = 14;
                ViewBag.ReportTitle = "شاخص نگرش کارکنان به تفکیک جنسیت";

                var model = reportManager.GetReport14(UserId);
                return View("AttitudeReport", model);
            }
            catch (Exception e)
            {
                LogHelper.Error(this, e);
                return View("Error");
            }

        }
        public ActionResult Report15()
        {

            try
            {
                ViewBag.ReportId = 15;
                ViewBag.ReportTitle = "شاخص نگرش کارکنان به تفکیک سن";
                var model = reportManager.GetReport15(UserId);
                return View("AttitudeReport", model);
            }
            catch (Exception e)
            {
                LogHelper.Error(this, e);
                return View("Error");
            }
        }
        public ActionResult Report16()
        {

            try
            {
                ViewBag.ReportId = 16;
                ViewBag.ReportTitle = "شاخص نگرش کارکنان  به تفکیک سنوات خدمت";
                var model = reportManager.GetReport16(UserId);
                return View("AttitudeReport", model);
            }
            catch (Exception e)
            {
                LogHelper.Error(this, e);
                return View("Error");
            }
        }
        public ActionResult Report17()
        {

            try
            {
                ViewBag.ReportId = 17;
                ViewBag.ReportTitle = "شاخص نگرش کارکنان  به تفکیک سنوات خدمت فعلی";
                var model = reportManager.GetReport17(UserId);
                return View("AttitudeReport", model);
            }
            catch (Exception e)
            {
                LogHelper.Error(this, e);
                return View("Error");
            }
        }
        public ActionResult Report18()
        {

            try
            {
                ViewBag.ReportId = 18;
                ViewBag.ReportTitle = "شاخص نگرش کارکنان  به تفکیک تحصیلات";
                var model = reportManager.GetReport18(UserId);
                return View("AttitudeReport", model);
            }
            catch (Exception e)
            {
                LogHelper.Error(this, e);
                return View("Error");
            }
        }
        public ActionResult Report19()
        {
            try
            {
                ViewBag.ReportId = 19;
                ViewBag.ReportTitle = "شاخص نگرش کارکنان به تفکیک پست سازمانی";
                var model = reportManager.GetReport19(UserId);
                return View("AttitudeReport", model);
            }
            catch (Exception e)
            {
                LogHelper.Error(this, e);
                return View("Error");
            }
        }

        public ActionResult Report21()
        {
            try
            {
                ViewBag.ReportId = 21;
                ViewBag.ReportTitle = "شاخص نگرش کارکنان ";
                var model = reportManager.GetReport21(UserId);
                return View("ViewReport21", model);
            }
            catch (Exception e)
            {
                LogHelper.Error(this, e);
                return View("Error");
            }
        }

        public ActionResult ExportToExcel()
        {
            try
            {
                var result = new ReportManager().GetAllSurvay(UserId);

                var myExcell = new ExcellMaker();
                var fileName = $"Surveys-{DateTime.Now.ToPersianDateTime()}.xls";
                var mytable = new DataTable();
                mytable.Columns.Add("UserId", typeof(string));
                mytable.Columns.Add("atitle", typeof(string));
                mytable.Columns.Add("GTitle", typeof(string));
                mytable.Columns.Add("xpTitle", typeof(string));
                mytable.Columns.Add("CxpTitle", typeof(string));
                mytable.Columns.Add("EduTitle", typeof(string));
                mytable.Columns.Add("PTitle", typeof(string));
                mytable.Columns.Add("QuestionId1", typeof(string));
                mytable.Columns.Add("QuestionId2", typeof(string));
                mytable.Columns.Add("QuestionId3", typeof(string));
                mytable.Columns.Add("QuestionId4", typeof(string));
                mytable.Columns.Add("QuestionId5", typeof(string));
                mytable.Columns.Add("QuestionId6", typeof(string));
                mytable.Columns.Add("QuestionId7", typeof(string));
                mytable.Columns.Add("QuestionId8", typeof(string));
                mytable.Columns.Add("QuestionId9", typeof(string));
                mytable.Columns.Add("QuestionId10", typeof(string));
                mytable.Columns.Add("QuestionId11", typeof(string));
                mytable.Columns.Add("QuestionId12", typeof(string));
                mytable.Columns.Add("QuestionId13", typeof(string));
                mytable.Columns.Add("QuestionId14", typeof(string));
                mytable.Columns.Add("QuestionId15", typeof(string));
                mytable.Columns.Add("QuestionId16", typeof(string));
                mytable.Columns.Add("QuestionId17", typeof(string));
                mytable.Columns.Add("QuestionId18", typeof(string));
                mytable.Columns.Add("QuestionId19", typeof(string));
                mytable.Columns.Add("QuestionId20", typeof(string));
                mytable.Columns.Add("QuestionId21", typeof(string));
                mytable.Columns.Add("QuestionId22", typeof(string));
                mytable.Columns.Add("QuestionId23", typeof(string));
                mytable.Columns.Add("QuestionId24", typeof(string));
                mytable.Columns.Add("QuestionId25", typeof(string));
                mytable.Columns.Add("QuestionId26", typeof(string));
                mytable.Columns.Add("QuestionId27", typeof(string));
                mytable.Columns.Add("QuestionId28", typeof(string));
                mytable.Columns.Add("QuestionId29", typeof(string));
                mytable.Columns.Add("QuestionId30", typeof(string));
                mytable.Columns.Add("QuestionId31", typeof(string));
                mytable.Columns.Add("QuestionId32", typeof(string));
                mytable.Columns.Add("QuestionId33", typeof(string));
                mytable.Columns.Add("QuestionId34", typeof(string));
                mytable.Columns.Add("QuestionId35", typeof(string));
                mytable.Columns.Add("QuestionId36", typeof(string));
                mytable.Columns.Add("QuestionId37", typeof(string));
                mytable.Columns.Add("QuestionId38", typeof(string));
                mytable.Columns.Add("QuestionId39", typeof(string));
                mytable.Columns.Add("QuestionId40", typeof(string));
                mytable.Columns.Add("QuestionId41", typeof(string));
                mytable.Columns.Add("QuestionId42", typeof(string));
                mytable.Columns.Add("QuestionId43", typeof(string));
                mytable.Columns.Add("QuestionId44", typeof(string));
                mytable.Columns.Add("QuestionId45", typeof(string));
                mytable.Columns.Add("QuestionId46", typeof(string));
                mytable.Columns.Add("QuestionId47", typeof(string));
                mytable.Columns.Add("QuestionId48", typeof(string));
                mytable.Columns.Add("QuestionId49", typeof(string));
                mytable.Columns.Add("QuestionId50", typeof(string));
                mytable.Columns.Add("QuestionId51", typeof(string));
                mytable.Columns.Add("QuestionId52", typeof(string));
                mytable.Columns.Add("QuestionId53", typeof(string));
                mytable.Columns.Add("QuestionId54", typeof(string));
                mytable.Columns.Add("QuestionId55", typeof(string));
                mytable.Columns.Add("QuestionId56", typeof(string));
                mytable.Columns.Add("QuestionId57", typeof(string));
                mytable.Columns.Add("QuestionId58", typeof(string));
                mytable.Columns.Add("QuestionId59", typeof(string));
                mytable.Columns.Add("QuestionId60", typeof(string));
                mytable.Columns.Add("QuestionId61", typeof(string));
                mytable.Columns.Add("QuestionId62", typeof(string));
                mytable.Columns.Add("QuestionId63", typeof(string));
                mytable.Columns.Add("QuestionId64", typeof(string));
                mytable.Columns.Add("QuestionId65", typeof(string));
                mytable.Columns.Add("QuestionId66", typeof(string));
                mytable.Columns.Add("QuestionId67", typeof(string));
                mytable.Columns.Add("QuestionId68", typeof(string));
                mytable.Columns.Add("QuestionId69", typeof(string));
                mytable.Columns.Add("QuestionId70", typeof(string));
                mytable.Columns.Add("QuestionId71", typeof(string));
                mytable.Columns.Add("QuestionId72", typeof(string));
                mytable.Columns.Add("QuestionId73", typeof(string));
                mytable.Columns.Add("QuestionId74", typeof(string));
                mytable.Columns.Add("QuestionId75", typeof(string));
                mytable.Columns.Add("QuestionId76", typeof(string));
                mytable.Columns.Add("QuestionId77", typeof(string));
                mytable.Columns.Add("QuestionId78", typeof(string));
                mytable.Columns.Add("QuestionId79", typeof(string));
                mytable.Columns.Add("QuestionId80", typeof(string));
                mytable.Columns.Add("QuestionId81", typeof(string));
                mytable.Columns.Add("QuestionId82", typeof(string));
                mytable.Columns.Add("QuestionId83", typeof(string));
                mytable.Columns.Add("QuestionId84", typeof(string));
                mytable.Columns.Add("QuestionId85", typeof(string));
                mytable.Columns.Add("QuestionId86", typeof(string));
                mytable.Columns.Add("QuestionId87", typeof(string));
                mytable.Columns.Add("QuestionId88", typeof(string));
                mytable.Columns.Add("QuestionId89", typeof(string));
                mytable.Columns.Add("QuestionId90", typeof(string));
                mytable.Columns.Add("QuestionId91", typeof(string));
                mytable.Columns.Add("QuestionId92", typeof(string));
                mytable.Columns.Add("QuestionId93", typeof(string));
                mytable.Columns.Add("QuestionId94", typeof(string));
                mytable.Columns.Add("QuestionId95", typeof(string));
                mytable.Columns.Add("QuestionId96", typeof(string));
                mytable.Columns.Add("QuestionId97", typeof(string));
                mytable.Columns.Add("QuestionId98", typeof(string));
                mytable.Columns.Add("QuestionId99", typeof(string));
                mytable.Columns.Add("QuestionId100", typeof(string));
                mytable.Columns.Add("QuestionId101", typeof(string));
                mytable.Columns.Add("QuestionId102", typeof(string));
                mytable.Columns.Add("QuestionId103", typeof(string));
                mytable.Columns.Add("QuestionId104", typeof(string));
                mytable.Columns.Add("QuestionId105", typeof(string));
                mytable.Columns.Add("QuestionId106", typeof(string));
                mytable.Columns.Add("QuestionId107", typeof(string));
                mytable.Columns.Add("QuestionId108", typeof(string));
                mytable.Columns.Add("QuestionId109", typeof(string));
                mytable.Columns.Add("QuestionId110", typeof(string));
                mytable.Columns.Add("QuestionId111", typeof(string));
                mytable.Columns.Add("QuestionId112", typeof(string));
                mytable.Rows.Add(
                    "نام کاربری",
                    "سن",
                    "جنسیت",
                    "سابقه",
                    "سابقه فعلی",
                    "تحصیلات",
                    "پست",
                    "سوال 1",
                    "سوال 2",
                    "سوال 3",
                    "سوال 4",
                    "سوال 5",
                    "سوال 6",
                    "سوال 7",
                    "سوال 8",
                    "سوال 9",
                    "سوال 10",
                    "سوال 11",
                    "سوال 12",
                    "سوال 13",
                    "سوال 14",
                    "سوال 15",
                    "سوال 16",
                    "سوال 17",
                    "سوال 18",
                    "سوال 19",
                    "سوال 20"
                 , " سوال 21"
               , " سوال 22 "
               , " سوال 23 "
               , " سوال 24 "
               , " سوال 25 "
               , " سوال 26 "
               , " سوال 27 "
               , " سوال 28 "
               , " سوال 29 "
               , " سوال 30 "
               , " سوال 31 "
               , " سوال 32 "
               , " سوال 33 "
               , " سوال 34 "
               , " سوال 35 "
               , " سوال 36 "
               , " سوال 37 "
               , " سوال 38 "
               , " سوال 39 "
               , " سوال 40 "
               , " سوال 41 "
               , " سوال 42 "
               , " سوال 43 "
               , " سوال 44 "
               , " سوال 45 "
               , " سوال 46 "
               , " سوال 47 "
               , " سوال 48 "
               , " سوال 49 "
               , " سوال 50 "
               , " سوال 51 "
               , " سوال 52 "
               , " سوال 53 "
               , " سوال 54 "
               , " سوال 55 "
               , " سوال 56 "
               , " سوال 57 "
               , " سوال 58 "
               , " سوال 59 "
               , " سوال 60 "
               , " سوال 61 "
               , " سوال 62 "
               , " سوال 63 "
               , " سوال 64 "
               , " سوال 65 "
               , " سوال 66 "
               , " سوال 67 "
               , " سوال 68 "
               , " سوال 69 "
               , " سوال 70 "
               , " سوال 71 "
               , " سوال 72 "
               , " سوال 73 "
               , " سوال 74 "
               , " سوال 75 "
               , " سوال 76 "
               , " سوال 77 "
               , " سوال 78 "
               , " سوال 79 "
               , " سوال 80 "
               , " سوال 81 "
               , " سوال 82 "
               , " سوال 83 "
               , " سوال 84 "
               , " سوال 85 "
               , " سوال 86 "
               , " سوال 87 "
               , " سوال 88 "
               , " سوال 89 "
               , " سوال 90 "
               , " سوال 91 "
               , " سوال 92 "
               , " سوال 93 "
               , " سوال 94 "
               , " سوال 95 "
               , " سوال 96 "
               , " سوال 97 "
               , " سوال 98 "
               , " سوال 99 "
               , " سوال 100"
               , " سوال 101"
               , " سوال 102"
               , " سوال 103"
               , " سوال 104"
               , " سوال 105"
               , " سوال 106"
               , " سوال 107"
               , " سوال 108"
               , " سوال 109"
               , " سوال 110"
               , " سوال 111"
               , " سوال 112"
                );

                DataRow dr = mytable.NewRow();

                foreach (var transactionDetail in result)
                {
                    mytable.Rows.Add(
                        transactionDetail[0],
                        transactionDetail[1],
                        transactionDetail[2],
                        transactionDetail[3],
                        transactionDetail[4],
                        transactionDetail[5],
                        transactionDetail[6],
                        transactionDetail[7],
                        transactionDetail[8],
                        transactionDetail[9],
                        transactionDetail[10],
                        transactionDetail[11],
                        transactionDetail[12],
                        transactionDetail[13],
                        transactionDetail[14],
                        transactionDetail[15],
                        transactionDetail[16],
                        transactionDetail[17],
                        transactionDetail[18],
                        transactionDetail[19],
                        transactionDetail[20],
                        transactionDetail[21],
                        transactionDetail[22],
                        transactionDetail[23],
                        transactionDetail[24],
                        transactionDetail[25],
                        transactionDetail[26],
                        transactionDetail[27],
                        transactionDetail[28],
                        transactionDetail[29],
                        transactionDetail[30],
                        transactionDetail[31],
                        transactionDetail[32],
                        transactionDetail[33],
                        transactionDetail[34],
                        transactionDetail[35],
                        transactionDetail[36],
                        transactionDetail[37],
                        transactionDetail[38],
                        transactionDetail[39],
                        transactionDetail[40],
                        transactionDetail[41],
                        transactionDetail[42],
                        transactionDetail[43],
                        transactionDetail[44],
                        transactionDetail[45],
                        transactionDetail[46],
                        transactionDetail[47],
                        transactionDetail[48],
                        transactionDetail[49],
                        transactionDetail[50],
                        transactionDetail[51],
                        transactionDetail[52],
                        transactionDetail[53],
                        transactionDetail[54],
                        transactionDetail[55],
                        transactionDetail[56],
                        transactionDetail[57],
                        transactionDetail[58],
                        transactionDetail[59],
                        transactionDetail[60],
                        transactionDetail[61],
                        transactionDetail[62],
                        transactionDetail[63],
                        transactionDetail[64],
                        transactionDetail[65],
                        transactionDetail[66],
                        transactionDetail[67],
                        transactionDetail[68],
                        transactionDetail[69],
                        transactionDetail[70],
                        transactionDetail[71],
                        transactionDetail[72],
                        transactionDetail[73],
                        transactionDetail[74],
                        transactionDetail[75],
                        transactionDetail[76],
                        transactionDetail[77],
                        transactionDetail[78],
                        transactionDetail[79],
                        transactionDetail[80],
                        transactionDetail[81],
                        transactionDetail[82],
                        transactionDetail[83],
                        transactionDetail[84],
                        transactionDetail[85],
                        transactionDetail[86],
                        transactionDetail[87],
                        transactionDetail[88],
                        transactionDetail[89],
                        transactionDetail[90],
                        transactionDetail[91],
                        transactionDetail[92],
                        transactionDetail[93],
                        transactionDetail[94],
                        transactionDetail[95],
                        transactionDetail[96],
                        transactionDetail[97],
                        transactionDetail[98],
                        transactionDetail[99],
                        transactionDetail[100],
                        transactionDetail[101],
                        transactionDetail[102],
                        transactionDetail[103],
                        transactionDetail[104],
                        transactionDetail[105],
                        transactionDetail[106],
                        transactionDetail[107],
                        transactionDetail[108],
                        transactionDetail[109],
                        transactionDetail[110],
                        transactionDetail[111],
                        transactionDetail[112],
                        transactionDetail[113],
                        transactionDetail[114],
                        transactionDetail[115],
                        transactionDetail[116],
                        transactionDetail[117],
                        transactionDetail[118]
                        );
                }

                var excellText = new StringBuilder(myExcell.Create(mytable, ""));
                Response.ClearContent();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.AddHeader("Content-Type", "application/vnd.ms-excel");
                Response.Write(excellText.ToString());
                Response.Flush();
                Response.End();

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return PartialView("Error", "در ایجاد فایل اکسل خطایی رخ داده است");
            }
        }

        public ActionResult ReportToExcel(int id)
        {
            try
            {
                var result =new List<FrequencyBaseViewReport>();
                var reportName = string.Empty;
                switch (id)
                {
                    case 6:
                        result = reportManager.GetReport6(UserId);
                        reportName = "جنسیت";
                        return CreateFrequencyReport(reportName, result);
                    case 7:
                        result = reportManager.GetReport7(UserId);
                        reportName = "سن"; 
                        return CreateFrequencyReport(reportName, result);
                    case 8:
                        result = reportManager.GetReport8(UserId);
                        reportName = "سنوات خدمت"; 
                        return CreateFrequencyReport(reportName, result);
                    case 9:
                        result = reportManager.GetReport9(UserId);
                        reportName = " سنوات خدمت فعلی"; 
                        return CreateFrequencyReport(reportName, result);
                    case 10:
                        result = reportManager.GetReport10(UserId);
                        reportName = "تحصیلات"; 
                        return CreateFrequencyReport(reportName, result);
                    case 11:
                        result = reportManager.GetReport11(UserId);
                        reportName = "پست سازمانی";
                        return CreateFrequencyReport(reportName, result);
                }

                return View("Index");

            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return PartialView("Error", "در ایجاد فایل اکسل خطایی رخ داده است");
            }
        }

        private ActionResult CreateFrequencyReport(string reportName, List<FrequencyBaseViewReport> result)
        {
            var title = $"گزارش فراوانی به تفکیک {reportName}-{User.Identity.Name}-{DateTime.Now}.xls";

            var myExcell = new ExcellMaker();
            var fileName = title;
            var mytable = new DataTable();
            mytable.Columns.Add("title", typeof(string));
            mytable.Columns.Add("Count", typeof(string));
            mytable.Columns.Add("FrequencyPercent", typeof(string));
            mytable.Rows.Add(
                "شرح",
                "فراوانی",
                " درصد فراوانی"
            );

            DataRow dr = mytable.NewRow();

            foreach (var frequencyBaseViewReport in result)
            {
                mytable.Rows.Add(
                    frequencyBaseViewReport.Title,
                    frequencyBaseViewReport.Count,
                    frequencyBaseViewReport.FrequencyPercent);
            }

            var excellText = new StringBuilder(myExcell.Create(mytable, ""));
            Response.ClearContent();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.AddHeader("Content-Type", "application/vnd.ms-excel");
            Response.Write(excellText.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("Index");
        }
    }
}