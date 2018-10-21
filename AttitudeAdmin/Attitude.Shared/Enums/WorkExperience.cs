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
        [Description("کمتر از 5 سال")]
        FiveYear = 1,
        [Description("بین 5 تا 10 سال")]
        Between5To10 = 2,
        [Description("بین 11 تا 15 سال")]
        Between11To15 = 3,
        [Description("بین 16 تا 20 سال")]
        Between16To20 = 4,
        [Description("بالاتر از 21 سال")]
        Greatethan21 = 5,
    }

}
