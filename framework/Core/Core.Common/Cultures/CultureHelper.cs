using System;
using System.Globalization;

namespace Core.Common.Cultures
{
    public static class CultureHelper
    {
        public static CultureInfo PersianCulture { get; }
        public static CultureInfo EnglishCulture { get; }

        static CultureHelper()
        {
            PersianCulture = NewPersianCulture();
            EnglishCulture = NewEnglishCulture();
        }
        
        private static CultureInfo NewPersianCulture()
        {
            var culture = new CultureInfo("fa-IR");
            var info = culture.DateTimeFormat;
            info.AbbreviatedDayNames = new [] { "ی", "د", "س", "چ", "پ", "ج", "ش" };
            info.DayNames = new [] { "یکشنبه", "دوشنبه", "ﺳﻪشنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" };
            info.AbbreviatedMonthNames = new [] { "فروردین", "ارديبهشت", "خرداد", "تير", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "" };
            info.MonthNames = new [] { "فروردین", "ارديبهشت", "خرداد", "تير", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "" };
            info.AMDesignator = "ق.ظ";
            info.PMDesignator = "ب.ظ";
            info.ShortDatePattern = "yyyy/MM/dd";
            info.FirstDayOfWeek = DayOfWeek.Saturday;
            info.FullDateTimePattern = "yyyy MMMM dddd, dd HH:mm:ss";
            info.LongDatePattern = "yyyy MMMM dddd, dd";
            info.ShortTimePattern = "HH:mm";
            culture.DateTimeFormat = info;
            
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
            System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat = info;
            System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat = info;
            //ci.NumberFormat.NumberDecimalSeparator = ".";
            //ci.NumberFormat.CurrencyDecimalSeparator = ".";
            return culture;
        }
        
        private static CultureInfo NewEnglishCulture() => new CultureInfo("en-US");
    }
}
