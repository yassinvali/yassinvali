using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attitude.Shared.Entities
{
   public class QuestionSheet
    {
        public int Id { get; set; }
        public int QuestionnairesId { get; set; }
        public int QuestionId { get; set; }
        public int SelectOptionId { get; set; }
    }
}
