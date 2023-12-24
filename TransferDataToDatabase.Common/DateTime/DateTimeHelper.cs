using System;
using System.Globalization;
using TransferDataToDatabase.Common.String;

namespace TransferDataToDatabase.Common.DateTime
{
    public static class DateTimeHelper
    {
        // ••••••••••••
        // DEFINATIONS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ••••••••••••

        #region Variable

        private static readonly int Jm = 1;
        public static readonly string ShamsiMonthFarsi;
        private static readonly string ShamsiWeek;

        #endregion

        #region Properties

        private static int MiladiYear { get; set; }

        private static int MiladiMonth { get; set; }

        private static int MiladiDay { get; set; }

        private static int ShamsiBeginYear { get; set; }

        public static int ShamsiYear { get; private set; }

        public static int ShamsiMonth { get; private set; }

        private static int ShamsiDay { get; set; }

        private static int MiladiPassDay { get; set; }

        private static int ShamsiPassDay { get; set; }

        private static System.DateTime DateTime { get; set; }

        #endregion

        #region Array

        private static readonly int[] Year = {0, 31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 29};
        private static readonly int[] LeapYear = {0, 31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 30};

        #endregion

        // ••••••••••••
        // METHODS     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ••••••••••••

        #region static DateTimeHelper()

        static DateTimeHelper()
        {
            DateTime = System.DateTime.Now;

            MiladiYear = DateTime.Year;
            MiladiMonth = DateTime.Month;
            MiladiDay = DateTime.Day;
            ShamsiBeginYear = MiladiYear - 622;
            MiladiPassDay = DateTime.DayOfYear;

            if (System.DateTime.IsLeapYear(MiladiYear) && !System.DateTime.IsLeapYear(MiladiYear - 1) &&
                IsShamsiYearLeap(ShamsiBeginYear) && !IsShamsiYearLeap(ShamsiBeginYear - 1))
            {
                const int miladi = 80;
                const int shamsi = 286;
                if ((MiladiMonth < 3) || ((MiladiMonth == 3) && (MiladiDay < 21)))
                {
                    ShamsiYear = ShamsiBeginYear;
                    ShamsiPassDay = shamsi + MiladiPassDay;

                }
                else
                {
                    ShamsiYear = ShamsiBeginYear + 1;
                    ShamsiPassDay = MiladiPassDay - miladi;
                }
            }
            if (!System.DateTime.IsLeapYear(MiladiYear) && System.DateTime.IsLeapYear(MiladiYear - 1) &&
                !IsShamsiYearLeap(ShamsiBeginYear) && IsShamsiYearLeap(ShamsiBeginYear - 1))
            {
                const int miladi = 78;
                const int shamsi = 287;
                if ((MiladiMonth < 3) || ((MiladiMonth == 3) && (MiladiDay < 20)))
                {
                    ShamsiYear = ShamsiBeginYear;
                    ShamsiPassDay = shamsi + MiladiPassDay;
                }
                else
                {
                    ShamsiYear = ShamsiBeginYear + 1;
                    ShamsiPassDay = MiladiPassDay - miladi;
                }
            }
            if (!System.DateTime.IsLeapYear(MiladiYear) && System.DateTime.IsLeapYear(MiladiYear - 1) &&
                !IsShamsiYearLeap(ShamsiBeginYear) && !IsShamsiYearLeap(ShamsiBeginYear - 1))
            {
                const int miladi = 78;
                const int shamsi = 287;
                if ((MiladiMonth < 3) || ((MiladiMonth == 3) && (MiladiDay < 20)))
                {
                    ShamsiYear = ShamsiBeginYear;
                    ShamsiPassDay = shamsi + MiladiPassDay;
                }
                else
                {
                    ShamsiYear = ShamsiBeginYear + 1;
                    ShamsiPassDay = MiladiPassDay - miladi;
                }
            }
            if (!System.DateTime.IsLeapYear(MiladiYear) && !System.DateTime.IsLeapYear(MiladiYear - 1) &&
                !IsShamsiYearLeap(ShamsiBeginYear) && !IsShamsiYearLeap(ShamsiBeginYear - 1))
            {
                const int miladi = 79;
                const int shamsi = 286;
                if ((MiladiMonth < 3) || ((MiladiMonth == 3) && (MiladiDay < 21)))
                {
                    ShamsiYear = ShamsiBeginYear;
                    ShamsiPassDay = shamsi + MiladiPassDay;
                }
                else
                {
                    ShamsiYear = ShamsiBeginYear + 1;
                    ShamsiPassDay = MiladiPassDay - miladi;
                }
            }
            if (!System.DateTime.IsLeapYear(MiladiYear) && System.DateTime.IsLeapYear(MiladiYear - 1) &&
                IsShamsiYearLeap(ShamsiBeginYear) && !IsShamsiYearLeap(ShamsiBeginYear - 1))
            {
                const int miladi = 79;
                const int shamsi = 287;
                if ((MiladiMonth < 3) || ((MiladiMonth == 3) && (MiladiDay < 21)))
                {
                    ShamsiYear = ShamsiBeginYear;
                    ShamsiPassDay = shamsi + MiladiPassDay;
                }
                else
                {
                    ShamsiYear = ShamsiBeginYear + 1;
                    ShamsiPassDay = MiladiPassDay - miladi;
                }
            }
            if (!System.DateTime.IsLeapYear(MiladiYear) && !System.DateTime.IsLeapYear(MiladiYear - 1) &&
                !IsShamsiYearLeap(ShamsiBeginYear) && IsShamsiYearLeap(ShamsiBeginYear - 1))
            {
                const int miladi = 79;
                const int shamsi = 286;
                if ((MiladiMonth < 3) || ((MiladiMonth == 3) && (MiladiDay < 21)))
                {
                    ShamsiYear = ShamsiBeginYear;
                    ShamsiPassDay = shamsi + MiladiPassDay;
                }
                else
                {
                    ShamsiYear = ShamsiBeginYear + 1;
                    ShamsiPassDay = MiladiPassDay - miladi;
                }
            }

            if (!System.DateTime.IsLeapYear(MiladiYear) && !System.DateTime.IsLeapYear(MiladiYear - 1) &&
                IsShamsiYearLeap(ShamsiBeginYear) && !IsShamsiYearLeap(ShamsiBeginYear - 1))
            {
                const int miladi = 80;
                const int shamsi = 286;
                if ((MiladiMonth < 3) || ((MiladiMonth == 3) && (MiladiDay < 22)))
                {
                    ShamsiYear = ShamsiBeginYear;
                    ShamsiPassDay = shamsi + MiladiPassDay;
                }
                else
                {
                    ShamsiYear = ShamsiBeginYear + 1;
                    ShamsiPassDay = MiladiPassDay - miladi;
                }
            }
            if (System.DateTime.IsLeapYear(MiladiYear) && !System.DateTime.IsLeapYear(MiladiYear - 1) &&
                !IsShamsiYearLeap(ShamsiBeginYear) && !IsShamsiYearLeap(ShamsiBeginYear - 1))
            {
                const int miladi = 79;
                const int shamsi = 286;
                if ((MiladiMonth < 3) || ((MiladiMonth == 3) && (MiladiDay < 20)))
                {
                    ShamsiYear = ShamsiBeginYear;
                    ShamsiPassDay = shamsi + MiladiPassDay;
                }
                else
                {
                    ShamsiYear = ShamsiBeginYear + 1;
                    ShamsiPassDay = MiladiPassDay - miladi;
                }
            }
            if (System.DateTime.IsLeapYear(MiladiYear) && !System.DateTime.IsLeapYear(MiladiYear - 1) &&
                !IsShamsiYearLeap(ShamsiBeginYear) && IsShamsiYearLeap(ShamsiBeginYear - 1))
            {
                const int miladi = 79;
                const int shamsi = 286;
                if ((MiladiMonth < 3) || ((MiladiMonth == 3) && (MiladiDay < 20)))
                {
                    ShamsiYear = ShamsiBeginYear;
                    ShamsiPassDay = shamsi + MiladiPassDay;
                }
                else
                {
                    ShamsiYear = ShamsiBeginYear + 1;
                    ShamsiPassDay = MiladiPassDay - miladi;
                }
            }

            if (IsShamsiYearLeap(ShamsiYear))
            {
                for (int i = 1; ShamsiPassDay > LeapYear[i]; i++)
                {
                    ShamsiPassDay -= LeapYear[i];
                    Jm++;
                }
            }
            else
            {
                for (int i = 1; ShamsiPassDay > Year[i]; i++)
                {
                    ShamsiPassDay -= Year[i];
                    Jm++;
                }
            }

            switch (DateTime.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    ShamsiWeek = "شنبه";
                    break;
                case DayOfWeek.Sunday:
                    ShamsiWeek = "یکشنبه";
                    break;
                case DayOfWeek.Monday:
                    ShamsiWeek = "دوشنبه";
                    break;
                case DayOfWeek.Tuesday:
                    ShamsiWeek = "سه شنبه";
                    break;
                case DayOfWeek.Wednesday:
                    ShamsiWeek = "چهارشنبه";
                    break;
                case DayOfWeek.Thursday:
                    ShamsiWeek = "پنج شنبه";
                    break;
                case DayOfWeek.Friday:
                    ShamsiWeek = "جمعه";
                    break;
            }
            ShamsiMonth = Jm;
            ShamsiDay = ShamsiPassDay;
            switch (Jm)
            {
                case 1:
                    ShamsiMonthFarsi = "فروردین";
                    break;
                case 2:
                    ShamsiMonthFarsi = "اردیبهشت";
                    break;
                case 3:
                    ShamsiMonthFarsi = "خرداد";
                    break;
                case 4:
                    ShamsiMonthFarsi = "تیر";
                    break;
                case 5:
                    ShamsiMonthFarsi = "مرداد";
                    break;
                case 6:
                    ShamsiMonthFarsi = "شهریور";
                    break;
                case 7:
                    ShamsiMonthFarsi = "مهر";
                    break;
                case 8:
                    ShamsiMonthFarsi = "آبان";
                    break;
                case 9:
                    ShamsiMonthFarsi = "آذر";
                    break;
                case 10:
                    ShamsiMonthFarsi = "دی";
                    break;
                case 11:
                    ShamsiMonthFarsi = "بهمن";
                    break;
                case 12:
                    ShamsiMonthFarsi = "اسفند";
                    break;
            }
        }

        #endregion

        #region public static bool IsShamsiYearLeap(this int value)

        public static bool IsShamsiYearLeap(this int value)
        {
            var remaning = value%33;
            return (remaning == 1) || (remaning == 5) || (remaning == 9) || (remaning == 13) || (remaning == 17) ||
                   (remaning == 22) || (remaning == 26) || (remaning == 30);
        }

        #endregion

        #region public static string ToShortDateString()

        public static string ToShortDateString()
        {
            return ShamsiYear.ToString(CultureInfo.InvariantCulture) + "/" + string.Format("{0:D2}", ShamsiMonth) +
                   "/" +
                   string.Format("{0:D2}", ShamsiDay);
        }

        #endregion

        #region public static string ToLongDateString()

        public static string ToLongDateString()
        {
            return ShamsiYear + " " + ShamsiWeek + " " + ShamsiDay.ToString(CultureInfo.InvariantCulture) + " " +
                   ShamsiMonthFarsi;
        }

        #endregion

        #region public static string ClientPersianDate()

        public static string ClientPersianDate()
        {
            var persianCalendar = new PersianCalendar();
            return persianCalendar.GetYear(System.DateTime.Now).ToString("D4") + "/" +
                   persianCalendar.GetMonth(System.DateTime.Now).ToString("D2") + "/" +
                   persianCalendar.GetDayOfMonth(System.DateTime.Now).ToString("D2");
        }

        #endregion

        #region public static string ToStandardPersianDate(this DateTime value)

        public static string ToStandardPersianDate(this System.DateTime value)
        {
            var persianCalendar = new PersianCalendar();
            return persianCalendar.GetYear(value).ToString("D4") + "/" +
                   persianCalendar.GetMonth(value).ToString("D2") + "/" +
                   persianCalendar.GetDayOfMonth(value).ToString("D2");
        }

        #endregion

        #region public static string ToStandardPersianDate(this PersianDateTime value)

        public static string ToStandardPersianDate(this PersianDateTime value)
        {
            return value.Year.ToString("D4") + "/" +
                value.Month.ToString("D2") + "/" +
                value.Day.ToString("D2");
        }

        #endregion

        #region public static string ToStandardPersianDateTime(this System.DateTime value)
        public static string ToStandardPersianDateTime(this System.DateTime value)
        {
            var persianCalendar = new PersianCalendar();
            return (" تاریخ: " + persianCalendar.GetYear(value).ToString("D4") + "/" +
                   persianCalendar.GetMonth(value).ToString("D2") + "/" +
                   persianCalendar.GetDayOfMonth(value).ToString("D2") + " زمان: " +
                   persianCalendar.GetHour(value).ToString("D2") + ":" +
                   persianCalendar.GetMinute(value).ToString("D2") + ":" +
                   persianCalendar.GetSecond(value).ToString("D2")).ToFarsi();
        }

        #endregion

        #region public static PersianDateTime ToPersianDateTime(this DateTime value)

        public static PersianDateTime ToPersianDateTime(this System.DateTime value)
        {
            return new PersianDateTime(value);
        }

        #endregion

        #region public static DateTime ToMiladiDateTime(this string value)

        public static System.DateTime ToMiladiDateTime(this string value)
        {
            System.DateTime miladiDate;
            try
            {
                var persianDate = PersianDateTime.Parse(value);
                miladiDate = persianDate.ToDateTime();
            }
            catch
            {
                miladiDate = Convert.ToDateTime("1900/01/01");
            }
            return miladiDate;
        }

        #endregion

        #region public static bool IsPersianDate(this string value)

        public static bool IsPersianDate(this string value)
        {
            return ToMiladiDateTime(value) != Convert.ToDateTime("1900/01/01");
        }

        #endregion

        #region public static System.DateTime GetDateTimeFromSunyDateTime(this string date, string time)
        public static System.DateTime ToDateTimeFromSuny(this string date, string time)
        {
            if (time == "240000") time = "235959";
            var newDate = Convert.ToInt64("13" + date).ToString("####/##/##");
            var newDateTime = newDate.ToMiladiDateTime();

            return new System.DateTime(newDateTime.Year, newDateTime.Month, newDateTime.Day,
                Convert.ToInt32(time.Substring(0, 2)), Convert.ToInt32(time.Substring(2, 2)), Convert.ToInt32(time.Substring(4, 2)));
        }

        #endregion
    }
}
