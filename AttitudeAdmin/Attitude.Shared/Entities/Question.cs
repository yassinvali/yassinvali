using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AttitudeMeasurement.DAL.Enums;

namespace AttitudeMeasurement.DAL.Entities
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Description("شماره سوال")]
        public int Number { get; set; }

        [Description("عنوان سوال")]
        public string Title { get; set; }

        [Description("نوع ضریب سوال")]
        public CoefficentType CoefficentType { get; set; }

        [Description("گروه سوال")]
        public QuestionType Type { get; set; }
    }
}
