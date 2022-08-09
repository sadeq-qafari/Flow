using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core.Common.Extensions
{
    public static class ConvertToPersian
    {
        public static string ToPersianDaysOfWeek(this DayOfWeek days)
        {
            switch (days)
            {
                case DayOfWeek.Friday:
                    return "جمعه";
                case DayOfWeek.Monday:
                    return "دوشنبه";
                case DayOfWeek.Saturday:
                    return "شنبه";
                case DayOfWeek.Sunday:
                    return "یکشنبه";
                case DayOfWeek.Thursday:
                    return "پنجشنبه";
                case DayOfWeek.Tuesday:
                    return "سه شنبه";
                case DayOfWeek.Wednesday:
                    return "چهارشنبه";
                default:
                    return "";
            }
        }
        public static PersianMonthsOfyear ToPersianMonthsOfyear(int persianMonth)
        {
            switch (persianMonth)
            {
                case 1:
                    return PersianMonthsOfyear.فروردین;
                case 2:
                    return PersianMonthsOfyear.اردیبهشت;
                case 3:
                    return PersianMonthsOfyear.خرداد;
                case 4:
                    return PersianMonthsOfyear.تیر;
                case 5:
                    return PersianMonthsOfyear.مرداد;
                case 6:
                    return PersianMonthsOfyear.شهریور;
                case 7:
                    return PersianMonthsOfyear.مهر;
                case 8:
                    return PersianMonthsOfyear.آبان;
                case 9:
                    return PersianMonthsOfyear.آذر;
                case 10:
                    return PersianMonthsOfyear.دی;
                case 11:
                    return PersianMonthsOfyear.بهمن;
                case 12:
                    return PersianMonthsOfyear.اسفند;
                default :
                    return PersianMonthsOfyear.None;
            }
        }
    }

    public enum PersianDaysOfWeek : int
    {
        None = 0,
        شنبه = 1 << 0,
        یکشنبه = 1 << 1,
        دوشنبه = 1 << 2,
        سهشنبه = 1 << 3,
        چهارشنبه = 1 << 4,
        پنجشنبه = 1 << 5,
        جمعه = 1 << 6,
    }

    public enum PersianMonthsOfyear : int
    {
        None = 0,
        فروردین = 1 << 0,
        اردیبهشت = 1 << 1,
        خرداد = 1 << 2,
        تیر = 1 << 3,
        مرداد = 1 << 4,
        شهریور = 1 << 5,
        مهر = 1 << 6,
        آبان = 1 << 7,
        آذر = 1 << 8,
        دی = 1 << 9,
        بهمن = 1 << 10,
        اسفند = 1 << 11,
    }

    public static class PersianExtensions
    {
        /// <summary>
        /// To the persian date.
        /// </summary>
        /// <param name="EnDate">The en date.</param>
        /// <param name="Format">The format.
        /// Full Format "{0}/{1}/{2} {3}:{4}:{5}.{6}"
        ///             "Year/Month/Day Hour:Minute:Second.Milliseconds"
        /// </param>
        /// <returns></returns>
        public static string ToPersianDateString(this DateTime EnDate, string Format = "{0}/{1}/{2} {3}:{4}:{5}")
        {
            try
            {
                PersianCalendar PC = new PersianCalendar();
                return string.Format(Format,
                    PC.GetYear(EnDate).ToString("0000"),
                    PC.GetMonth(EnDate).ToString("00"),
                    PC.GetDayOfMonth(EnDate).ToString("00"),
                    PC.GetHour(EnDate).ToString("00"),
                    PC.GetMinute(EnDate).ToString("00"),
                    PC.GetSecond(EnDate).ToString("00"),
                    PC.GetMilliseconds(EnDate).ToString("0000")
                );
            }
            catch
            {
                return "";
            }
        }
        
        
        
        
        /// <summary>
        /// Converts the en date.
        /// </summary>
        /// <param name="persianDate">The persian date.</param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this string persianDate)
        {
            try
            {
                if (persianDate.IsEmpty()) return null;

                DateTime fdate = Convert.ToDateTime(persianDate);
                GregorianCalendar gcalendar = new GregorianCalendar();
                PersianCalendar pcalendar = new PersianCalendar();
                DateTime eDate = pcalendar.ToDateTime(
                    gcalendar.GetYear(fdate),
                    gcalendar.GetMonth(fdate),
                    gcalendar.GetDayOfMonth(fdate),
                    gcalendar.GetHour(fdate),
                    gcalendar.GetMinute(fdate),
                    gcalendar.GetSecond(fdate), 0);
                return eDate;

                //bool NightDay = PersianDate.Contains("ب.ظ") | PersianDate.Contains("PM");
                //PersianDate = PersianDate.Replace("ق.ظ", "").Replace("ب.ظ", "").
                //                          Replace("AM", "").Replace("PM", "").Trim();

                //int[] Date = PersianDate.Split('/', ':', ' ').Select(s => Convert.ToInt32(s.Trim(' '))).ToArray();
                //return new DateTime(Date.GetInt(0),// Year
                //                    Date.GetInt(1),// Mounth
                //                    Date.GetInt(2),// Day
                //                    Date.GetInt(3) + (NightDay ? 12 : 0), // Hour
                //                    Date.GetInt(4),// Minute
                //                    Date.GetInt(5),// Seconde
                //                    0, new PersianCalendar());
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the int.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        private static int GetInt(this int[] date, int index)
        {
            return index < date.Count() ? date[index] : 0;
        }

        public static string FixPersianChars(this string value)
        {
            return value.Replace('ي', 'ی').Replace("ك", "ک");
        }

        /// <summary>
        /// Validate IR National Code
        /// </summary>
        /// <param name="nationalcode">National Code</param>
        /// <returns></returns>
        public static bool IsValidNationalCode(this string nationalcode)
        {
            int last;
            return nationalcode.IsValidNationalCode(out last);
        }
        /// <summary>
        /// Validate IR National Code
        /// </summary>
        /// <param name="nationalcode">National Code</param>
        /// <param name="lastNumber">Last Number Of National Code</param>
        /// <returns></returns>
        public static bool IsValidNationalCode(this string nationalcode, out int lastNumber)
        {
            lastNumber = -1;
            if (!nationalcode.IsNumeric()) return false;
            var invalid = new[]
            {
                "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555",
                "6666666666", "7777777777", "8888888888", "9999999999"
            };
            if (invalid.Contains(nationalcode)) return false;
            var array = nationalcode.ToCharArray();
            if (array.Length != 10) return false;
            var j = 10;
            var sum = 0;
            for (var i = 0; i < array.Length - 1; i++)
            {
                sum += Int32.Parse(array[i].ToString(CultureInfo.InvariantCulture)) * j;
                j--;
            }

            var diff = sum % 11;

            if (diff < 2)
            {
                lastNumber = diff;
                return diff == Int32.Parse(array[9].ToString(CultureInfo.InvariantCulture));
            }
            var temp = Math.Abs(diff - 11);
            lastNumber = temp;
            return temp == Int32.Parse(array[9].ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enDate">The en date</param>
        /// <returns>شماره ی روز در ماه</returns>
        public static int GetPersianDayNumber(this DateTime enDate)
        {
            try
            {
                PersianCalendar persianCalendar = new PersianCalendar();
                return persianCalendar.GetDayOfMonth(enDate);
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enDate">The en date</param>
        /// <returns>نام روز هفته به فارسی</returns>
        public static string GetPersianDayName(this DateTime enDate)
        {
            return ConvertToPersian.ToPersianDaysOfWeek(enDate.DayOfWeek).ToString();
        }
        
        public static int GetPersianMonthNumber(this DateTime enDate)
        {
            try
            {
                PersianCalendar persianCalendar = new PersianCalendar();
                return persianCalendar.GetMonth(enDate);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enDate">The en date</param>
        /// <returns>نام ماه به فارسی</returns>
        public static string GetPersianMonthName(this DateTime enDate)
        {
            try
            {
                PersianCalendar persianCalendar = new PersianCalendar();
                return ConvertToPersian.ToPersianMonthsOfyear((int)persianCalendar.GetMonth(enDate).ToString("00").ToInt32()).ToString();
            }
            catch
            {
                return "";
            }
        }
        
        public static int GetDaysInMonth(int year, int month)
        {
            return new PersianCalendar().GetDaysInMonth(year, month);
        }

        public static bool IsLeapYear(int year)
        {
            return new PersianCalendar().IsLeapYear(year);
        }

        public static bool CheckSheba(string input, bool checkLenght)
        {
            if (input.IsEmpty())
            {
                return false;
            }
            input = input.Replace(" ", "").ToLower();
            //بررسی رشته وارد شده برای اینکه در فرمت شبا باشد
            var isSheba = Regex.IsMatch(input, "^[a-zA-Z]{2}\\d{2} ?\\d{4} ?\\d{4} ?\\d{4} ?\\d{4} ?[\\d]{0,2}",
                RegexOptions.Compiled);

            if (!isSheba)
                return false;
            //طول شماره شبا را چک میکند کمتر نباشد
            if (input.Length < 26)
                return false;
            input = input.ToLower();
            //بررسی اعتبار سنجی اصلی شبا
            ////ابتدا گرفتن چهار رقم اول شبا
            var get4FirstDigit = input.Substring(0, 4);
            ////جایگزین کردن عدد 18 و 27 به جای آی و آر
            var replacedGet4FirstDigit = get4FirstDigit.ToLower().Replace("i", "18").Replace("r", "27");
            ////حذف چهار رقم اول از رشته شبا
            var removedShebaFirst4Digit = input.Replace(get4FirstDigit, "");
            ////کانکت کردن شبای باقیمانده با جایگزین شده چهار رقم اول
            var newSheba = removedShebaFirst4Digit + replacedGet4FirstDigit;
            ////تبدیل کردن شبا به عدد  - دسیمال تا 28 رقم را نگه میدارد
            var finalLongData = Convert.ToDecimal(newSheba);
            ////تقسیم عدد نهایی به مقدار 97 - اگر باقیمانده برابر با عدد یک شود این رشته شبا صحیح خواهد بود
            var finalReminder = finalLongData % 97;
            if (finalReminder == 1)
            {
                return true;
            }
            return false;
        }
    }
}