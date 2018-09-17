using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttitudeMeasurement.DAL.Enums
{
    public enum CoefficentType
    {
        [Description("ضریب مثبت")]
        Positive = 1,
        [Description("ضریب منفی")]
        Negative = 2
    }
}
