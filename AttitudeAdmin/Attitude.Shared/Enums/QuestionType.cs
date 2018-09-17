using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttitudeMeasurement.DAL.Enums
{
    public enum QuestionType
    {
        [Description("رضایت شغلی")]
        Job = 1,
        [Description("رضایت از نفس کار")]
        Job1 = 101,
        [Description("رضایت از مافوق")]
        Job2 = 102,
        [Description("رضیایت از حقوق")]
        Job3 = 103,
        [Description("رضایت از همکاران")]
        Job4 = 104,
        [Description("رضایت از ارتقا")]
        Job5 = 105,
        [Description("رضایت از عوامل نگهدارنده")]
        Job6 = 106,
        [Description("تعهد سازمانی")]
        OC = 2,
        [Description("ماندگاری-عدم تمایل به ترک خدمت")]
        TI = 3,
        [Description("بهداشت روانشناختی")]
        PW = 4,
        [Description("نبود اعتیاد به کار")]
        WH = 5,
        [Description("تعادل کاروزندگی")]
        WLB = 6,
        [Description("عجین شدن با شغل/پیوند کاری")]
        JI = 7,
        [Description("اشتیاق و پیوند سازمانی")]
        OE = 8,
        [Description("حمایت سازمانی ادراک شده")]
        POS = 9,
        [Description("هویت سازمانی")]
        OI = 10,
        [Description("نبود رفتارهای ضد شهروندی")]
        ACB = 11,
        [Description("رفتارهای شهروندی")]
        OCB = 12,
    }
}
