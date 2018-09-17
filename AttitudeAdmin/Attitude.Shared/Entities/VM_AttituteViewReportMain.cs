using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attitude.Shared.Entities
{
    public class VM_AttituteViewReportMain
    {
        public string RowNum { get; set; }
        public string WaveHr { get; set; }
        public string Title { get; set; }
        public float average { get; set; }
        public string description { get; set; }
        public float TotalPoint { get; set; }
        public string Status { get; set; }
    }
}
