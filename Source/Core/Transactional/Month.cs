using System;

namespace Core.Transactional
{
    public class Month
    {
        public DateTime Date { get; }
        public int MonthNumber { get; }
        public int Year { get; }

        public string MonthName { get; set; }

        public Month(DateTime date)
        {
            Date = new DateTime(date.Year, date.Month, 1);
            MonthNumber = Date.Month;
            Year = Date.Year;
            MonthName = Date.ToString("MMMM");
        }

        public static Month[] GetLastt12Months(DateTime date)
        {
            Month[] months = new Month[12];
            months[0] = new Month(date);

            for(int i = 1; i < 12; i++ )
            {
                months[i] = new Month(months[i - 1].Date.AddMonths(-1));
            }
            return months;
        }
    }
}
