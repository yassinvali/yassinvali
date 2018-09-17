using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attitude.Shared.Entities;
using AttitudeMeasurement.DAL.Entities;

namespace Attitude.DAL.DALRepository
{
    public interface IQuestionDal
    {
        List<Question> GetQuestions();
        void Insert(QuestionSheet questionnaire);
    }
}
