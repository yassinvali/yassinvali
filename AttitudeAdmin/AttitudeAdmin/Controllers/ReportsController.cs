using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Attitude.Business;
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
                mytable.Columns.Add("survayId", typeof(string));
                mytable.Columns.Add("questionNumner", typeof(string));
                mytable.Columns.Add("answer", typeof(string));

                mytable.Rows.Add(
                    "شماره پرسشنامه",
                    "شماره سوال",
                    "گزینه انتخاب شده"
                );

                foreach (var transactionDetail in result)
                {
                    mytable.Rows.Add(
                        transactionDetail.survayId,
                        transactionDetail.questionNumner,
                        transactionDetail.answer);
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
                return PartialView("_Error", "در ایجاد فایل اکسل خطایی رخ داده است");
            }
        }
    }
}