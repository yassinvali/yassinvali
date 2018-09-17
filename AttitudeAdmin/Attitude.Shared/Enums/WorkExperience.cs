using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttitudeMeasurement.DAL.Enums
{
    public enum WorkExperience
    {
        [Description("كمتر از 5سال")]
        FiveYear = 1,
        [Description("5-10 سال")]
        Between5To10 = 2,
        [Description("11-15 سال")]
        Between11To15 = 3,
        [Description("16-20 سال")]
        Between16To20 = 4,
        [Description("21 سال به بالا")]
        Greatethan21 = 5,
    }

}
