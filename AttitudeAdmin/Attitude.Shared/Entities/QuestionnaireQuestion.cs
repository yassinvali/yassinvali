using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttitudeMeasurement.DAL.Entities
{
    public class QuestionnaireQuestion
    {
        [Description("شماره پرسشنامه")]
        public int QuestionnaireId { get; set; }

        [Description("شماره سوال")]
        public int QuestionId { get; set; }

        [Description("گزینه انتخاب شده")]
        [Range(0, 5)]
        public int SelectOption { get; set; }
    }
}
