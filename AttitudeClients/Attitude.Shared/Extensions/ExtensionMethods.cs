using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace AttitudeClient.Extensions
{
    public static class Extensions
    {
        public static string ToDescriptionEnum(this Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }
        public static string ToSpecialPersianDateTime(this DateTime dateTime)
        {
            var persianCalendar = new PersianCalendar();
            return string.Format("{0}-{1}-{2}", persianCalendar.GetYear(dateTime), persianCalendar.GetMonth(dateTime).ToString().Length == 1 ? persianCalendar.GetMonth(dateTime).ToString().PadLeft(2, '0') : persianCalendar.GetMonth(dateTime).ToString(), persianCalendar.GetDayOfMonth(dateTime).ToString().Length == 1 ? persianCalendar.GetDayOfMonth(dateTime).ToString().PadLeft(2, '0') : persianCalendar.GetDayOfMonth(dateTime).ToString()).ToFarsiDigit();
        }
        public static string ToPersianDateTime(this DateTime geregorianDateTime)
        {
            var persian = new PersianCalendar();
            var day = persian.GetDayOfMonth(geregorianDateTime);
            var month = persian.GetMonth(geregorianDateTime);
            var year = persian.GetYear(geregorianDateTime);
            var hour = persian.GetHour(geregorianDateTime);
            var min = persian.GetMinute(geregorianDateTime);
            var second = persian.GetSecond(geregorianDateTime);
            var persianDateTime = String.Format("{0}/{1}/{2} - {3}:{4}:{5}", year, month.ToString().PadLeft(2, '0'), day.ToString().PadLeft(2, '0'), hour, min, second).ToFarsiDigit();
            return persianDateTime;
        }

        public static string ToPersianLongDateTimeWithoutHour(this DateTime geregorianDateTime)
        {
            string[] daysFa;
            int day;
            int month;
            int year;
            int min;
            int hour;
            int second;
            var monthFa = CreateFaCalendar(geregorianDateTime, out daysFa, out day, out month, out year, out hour, out min, out second);

            var persianDateTime = String.Format(" {0} {1} {2} {3}", daysFa[(int)geregorianDateTime.DayOfWeek], day.ToString().PadLeft(2, '0'), monthFa[month - 1], year).ToFarsiDigit();
            return persianDateTime;
        }


        public static string ToPersianLongDateTimeWithHour(this DateTime geregorianDateTime)
        {
            string[] daysFa;
            int day;
            int month;
            int year;
            int min;
            int hour;
            int second;
            var monthFa = CreateFaCalendar(geregorianDateTime, out daysFa, out day, out month, out year,out hour,out min,out second);

            var persianDateTime = String.Format(" {0} {1} {2} {3} {4}:{5}", daysFa[(int)geregorianDateTime.DayOfWeek], day.ToString().PadLeft(2, '0'), monthFa[month - 1], year, hour, min).ToFarsiDigit();
            return persianDateTime;
        }
        public static string ToShortPersianDateTime(this DateTime geregorianDateTime)
        {
            var persian = new PersianCalendar();
            var day = persian.GetDayOfMonth(geregorianDateTime);
            var month = persian.GetMonth(geregorianDateTime);
            var year = persian.GetYear(geregorianDateTime);
            return String.Format("{0}/{1}/{2}", year, month.ToString().PadLeft(2, '0'), day).ToFarsiDigit();
        } public static string ToShortPersianDateTimeEn(this DateTime geregorianDateTime)
        {
            var persian = new PersianCalendar();
            var day = persian.GetDayOfMonth(geregorianDateTime);
            var month = persian.GetMonth(geregorianDateTime);
            var year = persian.GetYear(geregorianDateTime);
            return String.Format("{0}/{1}/{2}", year, month.ToString().PadLeft(2, '0'), day);
        }
        public static DateTime ToGeregorianDate(this string persianDateTime)
        {
            var calendar = new PersianCalendar();
            var strings = persianDateTime.Split("/".ToCharArray());
            return calendar.ToDateTime(int.Parse(strings[0]), int.Parse(strings[1].PadLeft(2, '0')), int.Parse(strings[2].PadLeft(2, '0')), 0, 0, 0, 0);
        }
        public static string ToLogPersianDateTime(this DateTime geregorianDateTime)
        {
            var persian = new PersianCalendar();
            var day = persian.GetDayOfMonth(geregorianDateTime);
            var month = persian.GetMonth(geregorianDateTime);
            var year = persian.GetYear(geregorianDateTime);
            return String.Format("{0}-{1}-{2}", year, month.ToString().PadLeft(2, '0'), day.ToString().PadLeft(2, '0')).ToFarsiDigit();
        }

        public static string ToFarsiDigit(this string stringHtml)
        {
            return !string.IsNullOrEmpty(stringHtml) ? stringHtml
                .Replace("0", "٠")
                .Replace("1", "١")
                .Replace("2", "٢")
                .Replace("3", "٣")
                .Replace("4", "٤")
                .Replace("5", "٥")
                .Replace("6", "٦")
                .Replace("7", "٧")
                .Replace("8", "٨")
                .Replace("9", "٩")
                : "";
        }
        public static string ToEnDigit(this string stringHtml)
        {
            return !string.IsNullOrEmpty(stringHtml) ? stringHtml
                .Replace("٠", "0")
                .Replace("١", "1")
                .Replace("٢", "2")
                .Replace("٣", "3")
                .Replace("٤", "4")
                .Replace("٥", "5")
                .Replace("٦", "6")
                .Replace("٧", "7")
                .Replace("٨", "8")
                .Replace("٩", "9")
                : "";
        }
        public static string ToFarsiDigit(this MvcHtmlString stringHtml) => stringHtml.ToHtmlString()
                .Replace("0", "٠")
                .Replace("1", "١")
                .Replace("2", "٢")
                .Replace("3", "٣")
                .Replace("4", "٤")
                .Replace("5", "٥")
                .Replace("6", "٦")
                .Replace("7", "٧")
                .Replace("8", "٨")
                .Replace("9", "٩")
                ;

        public static string ToFarsiDigit(this decimal? stringHtml)
        {
            return stringHtml.HasValue ? ((int)stringHtml).ToString()
                .Replace("0", "٠")
                .Replace("1", "١")
                .Replace("2", "٢")
                .Replace("3", "٣")
                .Replace("4", "٤")
                .Replace("5", "٥")
                .Replace("6", "٦")
                .Replace("7", "٧")
                .Replace("8", "٨")
                .Replace("9", "٩") : "٠";
        }
        public static string ToFarsiDigit(this decimal stringHtml)
        {
            return stringHtml.ToString()
                .Replace("0", "٠")
                .Replace("1", "١")
                .Replace("2", "٢")
                .Replace("3", "٣")
                .Replace("4", "٤")
                .Replace("5", "٥")
                .Replace("6", "٦")
                .Replace("7", "٧")
                .Replace("8", "٨")
                .Replace("9", "٩");
        }

        public static string ToFarsiDigit(this double? stringHtml)
        {
            return stringHtml.HasValue ? ((double)stringHtml).ToString()
                .Replace("0", "٠")
                .Replace("1", "١")
                .Replace("2", "٢")
                .Replace("3", "٣")
                .Replace("4", "٤")
                .Replace("5", "٥")
                .Replace("6", "٦")
                .Replace("7", "٧")
                .Replace("8", "٨")
                .Replace("9", "٩") : "٠";
        }
        public static string ToFarsiDigit(this double stringHtml)
        {
            return stringHtml.ToString()
                .Replace("0", "٠")
                .Replace("1", "١")
                .Replace("2", "٢")
                .Replace("3", "٣")
                .Replace("4", "٤")
                .Replace("5", "٥")
                .Replace("6", "٦")
                .Replace("7", "٧")
                .Replace("8", "٨")
                .Replace("9", "٩");
        }

        public static string ToDigitSeperator(this decimal value)
        {
            return $"{value:n0}";
        }
        public static string ToDigitSeperator(this long value)
        {
            return $"{value:n0}";
        }
        public static string ToDigitSeperator(this int value)
        {
            return $"{value:n0}";
        }
        public static string ToDigitSeperator(this double value)
        {
            return $"{value:n0}";
        }

        //helper
        private static string[] CreateFaCalendar(DateTime geregorianDateTime, out string[] daysFa, out int day, out int month,out int year,out int hour,out int min,out int second)
        {
            var monthFa = new string[]
            {"فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"};
            daysFa = new string[] { "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه", };
            var persian = new PersianCalendar();

            day = persian.GetDayOfMonth(geregorianDateTime);
            month = persian.GetMonth(geregorianDateTime);
            year = persian.GetYear(geregorianDateTime);
            hour = persian.GetHour(geregorianDateTime);
            min = persian.GetMinute(geregorianDateTime);
            second = persian.GetSecond(geregorianDateTime);
            return monthFa;
        }

        public static string HashPassword(this string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }

        private static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }

        public static string CreateMD5(this string input)
        {
            // Use input string to calculate MD5 hash
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

    }
}