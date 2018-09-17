using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttitudeMeasurement.DAL.Enums
{
    public enum Education
    {
        [Description("زیر دیپلم")]
        UnderDiploma = 1,
        [Description("دیپلم")]
        Diploma = 2,
        [Description("کاردانی")]
        AssociateDegree = 3,
        [Description("کارشناسی")]
        Bachelor = 4,
        [Description("کارشناسی ارشد")]
        Masters = 5,
        [Description("دکترا و بالاتر")]
        PhDAndAbove = 6,

    }
}
