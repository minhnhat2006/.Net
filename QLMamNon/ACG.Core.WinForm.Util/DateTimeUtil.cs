using System;
using System.Collections.Generic;
using System.Collections;

namespace ACG.Core.WinForm.Util
{
    public class DateTimeUtil
    {
        public static DateTime DateStartOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        public static DateTime DateEndOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month), 23, 59, 59, 999);
        }

        public static bool IsDateBetweenRange(DateTime fromDate, DateTime toDate, DateTime dateToCompare)
        {
            return dateToCompare >= fromDate && dateToCompare <= toDate;
        }

        public static bool IsSameMonthYear(DateTime date, DateTime dateToCompare)
        {
            return date.Year == dateToCompare.Year && date.Month == dateToCompare.Month;
        }

        public static bool Compare(DateTime date, DateTime dateToCompare, string compareFormat)
        {
            string dateStr = date.ToString(compareFormat);
            string dateToCompareStr = dateToCompare.ToString(compareFormat);
            return dateStr.Equals(dateToCompareStr);
        }
    }
}
