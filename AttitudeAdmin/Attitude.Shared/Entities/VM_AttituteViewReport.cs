using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attitude.Shared.Entities
{
    public class VM_AttituteViewReport
    {
        public string RowTitle { get; set; }
        public string ColTitle { get; set; }
        public float Value { get; set; }
        public int SortOrder { get; set; }
        
    }
}
