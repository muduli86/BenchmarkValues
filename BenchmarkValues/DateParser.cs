using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkValues
{
    public class DateParser
    {
        public int GetYearFromDate(string dateAsString) {
            var dateTime = DateTime.Parse(dateAsString);
            return dateTime.Year;
        }

        public int GetYearFromDateSplit(string dateAsString) {
            var dateTime = dateAsString.Split('-');
            return int.Parse(dateTime[0]);
        }

        public int GetYearFromDateSubString(string dateAsString) {
            var indexOfHyphen = dateAsString.IndexOf('-');
            return int.Parse(dateAsString.Substring(0, indexOfHyphen));
        }

        public int GetYearFromDateSpan(ReadOnlySpan<char> dateAsString)
        {
            var indexOfHyphen = dateAsString.IndexOf('-');
            return int.Parse(dateAsString.Slice(0,indexOfHyphen));
        }

       
    }
}
