using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttitudeMeasurement.DAL.Enums
{
    public enum Position
    {
        [Description("کارگر")]
        ManualWorker =1,
        [Description("کارمند")]
        Employee = 2,
        [Description("کاردان/تکنسین")]
        Technician = 3,
        [Description("کارشناس")]
        Expert = 4,
        [Description("کارشناس ارشد")]
        Masters = 5,
        [Description("کارشناس مسئول")]
        MSC=6,
        [Description("رییس")]
        Chief = 7,
        [Description("مدیر")]
        Manager = 8,
        [Description("سایر")]
        Other = 9
    }
}
