using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using Attitude.DAL.DALRepository;
using Attitude.Shared.Entities;
using AttitudeMeasurement.DAL.Entities;

namespace Attitude.Business
{
    public class QuestionManager
    {
        public static string CacheKey = "6B788FDD-10A5-480B-9354-BD24496B1929";
        MemoryCache memoryCache = MemoryCache.Default;
        IQuestionDal QuestionDal =new QuestionDal();

        public List<Question> GetAllQuestions()
        {
            if (memoryCache.Get(CacheKey) != null)
            {
                return (List<Question>) memoryCache.Get(CacheKey);
            }

            memoryCache.Set(CacheKey, QuestionDal.GetQuestions(),new CacheItemPolicy()
            {
                AbsoluteExpiration = DateTimeOffset.MaxValue
            });

            return (List<Question>)memoryCache.Get(CacheKey);
        }

        public void Insert(QuestionSheet questionSheet)
        {
            QuestionDal.Insert(questionSheet);
        }
    }
}
