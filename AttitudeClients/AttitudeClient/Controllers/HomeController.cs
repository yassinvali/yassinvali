using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Attitude.Business;
using Attitude.Shared.Entities;
using Attitude.Shared.Extensions;
using AttitudeAdmin.Entitess;
using AttitudeClient.Extensions;
using AttitudeMeasurement.DAL.Entities;
using AttitudeMeasurement.DAL.Enums;
using log4net;
using Microsoft.AspNet.Identity.Owin;

namespace AttitudeAdmin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        QuestionManager manager = new QuestionManager();
        static string AnswerKey = "AnswerKey";
        static string userInfoKey = "userInfoKey";


        public ActionResult Index()
        {
            try
            {
                var model = PrepaideData;
                return View(model);
            }
            catch (Exception e)
            {
                LogHelper.Error(this, e);
                return View("Error");
            }
        }

        public ActionResult NotFound()
        {
            return View("404");
        }

        [HttpGet]
        public PartialViewResult Forward(int questionId, int answerId)
        {
            try
            {
                var allQuestions = GetTotalQuestion();
                var nextQuestion = questionId + 1;

                if (questionId != 0)
                {
                    QuestionListManage(questionId, answerId);

                    var question = allQuestions.Single(q => q.Number == nextQuestion);

                    return PartialView("QuestionPartial", question);
                }

                var questionFirst = allQuestions.Single(q => q.Number == 1);
                return PartialView("QuestionPartial", questionFirst);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return PartialView("Error");
            }
        }

        private void QuestionListManage(int questionId, int answerId)
        {
            var answerModels = (List<AnswerModel>)TempData.Peek(AnswerKey);
            var oldAnswer = answerModels.Find(q => q.QuestionId == questionId);
            if (oldAnswer != null)
            {
                answerModels.Remove(oldAnswer);
            }

            answerModels.Add(new AnswerModel()
            {
                QuestionId = questionId,
                AnswerId = answerId
            });
        }

        [HttpGet]
        public PartialViewResult Backward(int questionId)
        {
            try
            {
                var allQuestions = GetTotalQuestion();
                var nextQustion = questionId - 1;
                var questionSheet = new List<AnswerModel>(); 
                if (nextQustion != 0)
                {
                    var question = allQuestions.Single(q => q.Number == nextQustion);
                     questionSheet = (List<AnswerModel>)TempData.Peek(AnswerKey);
                    if (questionSheet.Any(q => q.QuestionId == nextQustion))
                    {
                        question.SelectedOption = questionSheet.Single(q => q.QuestionId==nextQustion).AnswerId;
                    }
                    return PartialView("QuestionPartial", question);
                }
                if (nextQustion == 0)
                {
                    GetUserInfoData();
                    return PartialView("_UserInformation");
                }

                var questionFirst = allQuestions.Single(q => q.Number == 1);
                questionSheet = (List<AnswerModel>)TempData.Peek(AnswerKey);
                if (questionSheet.Any(q => q.QuestionId == nextQustion))
                {
                    questionFirst.SelectedOption = questionSheet.Single(q => q.QuestionId == nextQustion).AnswerId;
                }
                return PartialView("QuestionPartial", questionFirst);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return PartialView("Error");
            }
        }

        public int GetSelectedOption(int questionNumber)
        {
            try
            {
                var answerModels = (List<AnswerModel>)TempData.Peek(AnswerKey);
                var oldAnswer = answerModels.Find(q => q.QuestionId == questionNumber);
                if (oldAnswer != null)
                {
                    return oldAnswer.AnswerId;
                }

                return -1;
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return -1;
            }
        }

        public ActionResult RegisterUserInfo(QuestionSheet question)
        {
            try
            {
                var allQuestions = GetTotalQuestion();

                var applicationUser = UserManager.FindByNameAsync(User.Identity.Name).Result;
                var questionSheet = new QuestionSheet()
                {
                    Position = question.Position,
                    UserId =applicationUser.Id,
                    Education = question.Education,
                    Age = question.Age,
                    CurrentWorkExperience = question.CurrentWorkExperience,
                    WorkExperience = question.WorkExperience,
                    Gendar = question.Gendar,
                };
                TempData[userInfoKey] = questionSheet;
                var questions = manager.GetAllQuestions();
                var model = questions.First();
                return PartialView("QuestionPartial", model);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return PartialView("Error");
            }
        }

        [HttpPost]
        public ActionResult Process(QuestionSheet question)
        {
            try
            {
                var questionSheet = (List<AnswerModel>)TempData.Peek(AnswerKey);
                var userInfo = (QuestionSheet)TempData.Peek(userInfoKey);
                manager.Insert(new QuestionSheet()
                {
                    Position = userInfo.Position,
                    UserId = userInfo.UserId,
                    Education = userInfo.Education,
                    Age = userInfo.Age,
                    CurrentWorkExperience = userInfo.CurrentWorkExperience,
                    WorkExperience = userInfo.WorkExperience,
                    Gendar = userInfo.Gendar,
                    AnswerList = questionSheet
                });
                return PartialView("_SuccesResult");
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return View("Error");
            }
        }

        private void GetUserInfoData()
        {
            ViewBag.Education = GetEducation();
            ViewBag.Ages = GetAge();
            ViewBag.Gendar = GetGender();
            ViewBag.Position = GetPosition();
            ViewBag.WorkExperience = GetWorkExperience();
            ViewBag.CurrentWorkExperience = GetCurrentWorkExperience();
        }

        private List<Question> GetTotalQuestion()
        {
            var allQuestions = manager.GetAllQuestions();
            var allQuestionsCount = allQuestions.Count;
            ViewBag.QuestionCount = allQuestionsCount;
            return allQuestions;
        }

        private Question PrepaideData
        {
            get
            {
                if (TempData.ContainsKey(AnswerKey))
                {
                    TempData.Remove(AnswerKey);
                }
                TempData.Add(AnswerKey, new List<AnswerModel>());

                if (TempData.ContainsKey(userInfoKey))
                {
                    TempData.Remove(userInfoKey);
                }
                TempData.Add(userInfoKey, new QuestionSheet());

                var questions = manager.GetAllQuestions();
                var model = questions.First();
                GetUserInfoData();
                return model;
            }
        }
        private static List<SelectListItem> GetEducation()
        {
            var selectListItesm = new List<SelectListItem>();
            selectListItesm.Add(new SelectListItem()
            {
                Value = "-1",
                Text = "تحصیلات را انتخاب نمایید"
            });
            foreach (var education in Enum.GetValues(typeof(Education)))
            {
                selectListItesm.Add(new SelectListItem()
                {
                    Text = ((Education)education).ToDescriptionEnum(),
                    Value = ((int)education).ToString()
                });
            }

            return selectListItesm;
        }
        private static List<SelectListItem> GetAge()
        {
            var selectListItesm = new List<SelectListItem>();
            selectListItesm.Add(new SelectListItem()
            {
                Value = "-1",
                Text = "سن را انتخاب نمایید"
            }); foreach (var education in Enum.GetValues(typeof(Age)))
            {
                selectListItesm.Add(new SelectListItem()
                {
                    Text = ((Age)education).ToDescriptionEnum(),
                    Value = ((int)education).ToString()
                });
            }

            return selectListItesm;
        }
        private static List<SelectListItem> GetPosition()
        {
            var selectListItesm = new List<SelectListItem>();
            selectListItesm.Add(new SelectListItem()
            {
                Value = "-1",
                Text = "پست سازمانی را انتخاب نمایید"
            });
            foreach (var education in Enum.GetValues(typeof(Position)))
            {
                selectListItesm.Add(new SelectListItem()
                {
                    Text = ((Position)education).ToDescriptionEnum(),
                    Value = ((int)education).ToString()
                });
            }

            return selectListItesm;
        }
        private static List<SelectListItem> GetWorkExperience()
        {
            var selectListItesm = new List<SelectListItem>();
            selectListItesm.Add(new SelectListItem()
            {
                Value = "-1",
                Text = "سنوات خدمت را انتخاب نمایید"
            }); foreach (var education in Enum.GetValues(typeof(WorkExperience)))
            {
                selectListItesm.Add(new SelectListItem()
                {
                    Text = ((WorkExperience)education).ToDescriptionEnum(),
                    Value = ((int)education).ToString()
                });
            }

            return selectListItesm;
        }
        private static List<SelectListItem> GetCurrentWorkExperience()
        {
            var selectListItesm = new List<SelectListItem>();
            selectListItesm.Add(new SelectListItem()
            {
                Value = "-1",
                Text = "سنوات خدمت فعلی را انتخاب نمایید"
            });
            foreach (var education in Enum.GetValues(typeof(CurrentWorkExperience)))
            {
                selectListItesm.Add(new SelectListItem()
                {
                    Text = ((CurrentWorkExperience)education).ToDescriptionEnum(),
                    Value = ((int)education).ToString()
                });
            }

            return selectListItesm;
        }
        private static List<SelectListItem> GetGender()
        {
            var selectListItesm = new List<SelectListItem>();
            selectListItesm.Add(new SelectListItem()
            {
                Value = "-1",
                Text = "جنسیت را انتخاب نمایید"
            });
            foreach (var education in Enum.GetValues(typeof(Gender)))
            {
                selectListItesm.Add(new SelectListItem()
                {
                    Text = ((Gender)education).ToDescriptionEnum(),
                    Value = ((int)(Gender)education).ToString()
                });
            }

            return selectListItesm;
        }
    }
}