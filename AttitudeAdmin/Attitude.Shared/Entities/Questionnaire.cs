using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AttitudeMeasurement.DAL.Enums;

namespace AttitudeMeasurement.DAL.Entities
{
    public class Questionnaire
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Gender Sex { get; set; }
        public Age Age { get; set; }
        public WorkExperience WorkExperience { get; set; }
        public CurrentWorkExperience CurrentWorkExperience { get; set; }
        public Education Education { get; set; }
        public Position Position { get; set; }
        public List<Question> Questions { get; set; }
    }
}
