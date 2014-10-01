using System;
using BillingEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JewishCalendarTests
{
    [TestClass]
    public class JewishCalendarShould
    {
        [TestMethod]
        public void GetHolidaysForYear()
        {
            for (int year = 5770; year < 5780; year++)
            {
                Console.WriteLine("-------------- Holidays in year {0} ----------------", year);
                var holidays = HolidaysCollection.GetHolidays(year);
                foreach (var holiday in holidays)
                {
                    Console.WriteLine("{0} : {1} - {2}, DayOff - {3}",
                         holiday.HolidayName, holiday.GrerorianDateFrom, holiday.GregorianDateTo,
                         holiday.IsOutOfWork);
                }
            }

        }

        [TestMethod]
        public void GetHolidaysForGregorianYears()
        {
            for (int year = 2000; year < 2020; year++)
            {
                Console.WriteLine("-------------- Holidays in year {0} ----------------", year);
                var holidays = HolidaysCollection.GetHolidaysForGregorianYear(year);
                foreach (var holiday in holidays)
                {
                    Console.WriteLine("{0} : {1} - {2}, DayOff - {3}",
                         holiday.HolidayName, holiday.GrerorianDateFrom, holiday.GregorianDateTo,
                         holiday.IsOutOfWork);
                }
            }

        }

        [TestMethod]
        public void GetTodaysHolidais()
        {
            var holidays = HolidaysCollection.GetHolidaysForDate(new DateTime (2014, 12, 18));
            foreach (var holiday in holidays)
            {


                Console.WriteLine("{0} : {1} - {2}, DayOff - {3}",
                           holiday.HolidayName, holiday.GrerorianDateFrom, holiday.GregorianDateTo,
                           holiday.IsOutOfWork);
            }
        }

        [TestMethod]
        public void GetThisYearHolidays()
        {
            var holidays = HolidaysCollection.GetHolidaysForGregorianYear(DateTime.Today.Year);
            foreach (var holiday in holidays)
            {


                Console.WriteLine("{0} : {1} - {2}, DayOff - {3}",
                           holiday.HolidayName, holiday.GrerorianDateFrom, holiday.GregorianDateTo,
                           holiday.IsOutOfWork);
            }
        }
    }
}
