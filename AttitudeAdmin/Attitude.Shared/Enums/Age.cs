using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttitudeMeasurement.DAL.Enums
{
    public enum Age
    {
        [Description("زیر 25 سال")]
        LowerThan25 =1,
        [Description("26 - 33 سال")]
        LowerThan26To33 = 2,
        [Description("34-41 سال")]
        LowerThan34To41 = 3,
        [Description("42-49 سال")]
        LowerThan42To49 = 4,
        [Description("بیشتر از 49 سال")]
        GreateThan29 = 5,
    }
}
