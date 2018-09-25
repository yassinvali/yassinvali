using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttitudeAdmin.Entitess;
using AttitudeMeasurement.DAL.Entities;
using AttitudeMeasurement.DAL.Enums;

namespace Attitude.Shared.Entities
{
    public class QuestionSheet
    {
        public string UserId { get; set; }
        public int Gendar { get; set; }
        public int Age { get; set; }
        public int WorkExperience { get; set; }
        public int CurrentWorkExperience { get; set; }
        public int Education { get; set; }
        public int Position { get; set; }
        public int LastQuestionId { get; set; }
        public int LastQuestionAnswerId { get; set; }

        public List<AnswerModel> AnswerList { get; set; }
    }
}
