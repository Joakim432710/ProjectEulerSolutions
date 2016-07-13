using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem19
{
    class Program
    {
        /*
            You are given the following information, but you may prefer to do some research for yourself.

            1 Jan 1900 was a Monday.
            Thirty days has September,
            April, June and November.
            All the rest have thirty-one,
            Saving February alone,
            Which has twenty-eight, rain or shine.
            And on leap years, twenty-nine.
            A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

            How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
        */
        static void Main(string[] args)
        {
            var years = new List<Year>();
            for (var iii = 1900; iii <= 2000; ++iii)
                years.Add(new Year(iii));

            var countSundays = 0;
            foreach (var year in years.Skip(1)) //1900 doesn't count
                foreach (var month in year.Months)
                    if (month.Days[0].Type == Year.Month.Day.DayType.Sunday)
                        ++countSundays;

            Console.WriteLine(countSundays + " Sundays fell on the first of the month from 1 Jan 1901 to 31 Dec 2000");
            Console.ReadLine();
        }

        private static int CountDays = -1; //Not Thread Safe - has to be created in correct order starting on Jan 1 1900
        private static Year.Month.Day.DayType RequestNewDay()
        {
            return (Year.Month.Day.DayType)((++CountDays) % 7); //Not Thread Safe - has to be created in correct order starting on Jan 1 1900
        }

        private class Year
        {
            public int Id; //1994, 1995, 2001, and so on
            public List<Month> Months { get; } = new List<Month>();
            public bool LeapYear => ((Id % 4) == 0) && (((Id % 400) == 0) || ((Id % 100) != 0));

            public Year(int id)
            {
                Id = id;
                Months = new List<Month>
                {
                    new Month(Month.MonthType.January,      this),
                    new Month(Month.MonthType.February,     this),
                    new Month(Month.MonthType.March,        this),
                    new Month(Month.MonthType.April,        this),
                    new Month(Month.MonthType.May,          this),
                    new Month(Month.MonthType.June,         this),
                    new Month(Month.MonthType.July,         this),
                    new Month(Month.MonthType.August,       this),
                    new Month(Month.MonthType.September,    this),
                    new Month(Month.MonthType.October,      this),
                    new Month(Month.MonthType.November,     this),
                    new Month(Month.MonthType.December,     this),
                };
            }

            public class Month
            {
                public enum MonthType
                {
                    January,
                    February,
                    March,
                    April,
                    May,
                    June,
                    July,
                    August,
                    September,
                    October,
                    November,
                    December
                }

                public MonthType Type { get; }
                public List<Day> Days { get; } = new List<Day>();

                public Month(MonthType type, Year year)
                {
                    Type = type;
                    var numdays = 31;
                    switch(type)
                    {
                        case MonthType.September:
                        case MonthType.April:
                        case MonthType.June:
                        case MonthType.November:
                            numdays = 30;
                            break;
                        case MonthType.February:
                            numdays = year.LeapYear ? 29 : 28;
                            break;
                    }
                    for (var iii = 1; iii <= numdays; ++iii) Days.Add(new Day(this, iii));
                }

                public class Day
                {
                    public enum DayType
                    {
                        Monday,
                        Tuesday,
                        Wednesday,
                        Thursday,
                        Friday,
                        Saturday,
                        Sunday
                    }

                    public int Id { get; }
                    public DayType Type { get; }

                    public Day(Month month, int day)
                    {
                        Id = day;
                        Type = RequestNewDay();
                    }
                }
            }
        }

    }
}
