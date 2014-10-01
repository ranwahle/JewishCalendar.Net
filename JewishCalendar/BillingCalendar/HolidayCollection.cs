// Type: BillingEntities.HolidaysCollection
// Assembly: BillingCalendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 44ED7BD3-A0FC-475F-9B75-C55DBACCBF0F
// Assembly location: D:\Tests\JewishHilidays\bin\BillingCalendar.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using BillingCalendar;
using BillingEntities;

public class HolidaysCollection : List<Holiday>
{
    private static Dictionary<Language, ReturnHolidayName> _languageToHolidayNameDict = new Dictionary<Language, ReturnHolidayName>
    {
        {
            Language.English,
            name => name.English
        },
        {
            Language.Hebrew,
          (name => name.Hebrew)
        }
    };
    private static XmlDocument _holidayDoc;
    private static HolidayName[] _holidayNames;

    static HolidaysCollection()
    {
        InitHolidaysDictionary();
    }

    public HolidaysCollection()
    {
        InitializeHolidays(eHolidayReligion.Jewish);
        InitializeHolidays(eHolidayReligion.Muslim);
    }

    private static void InitHolidaysDictionary()
    {
        using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BillingCalendar.HolidaysDictionary.xml"))
            _holidayNames = Deserialize<HolidayName[]>(manifestResourceStream);
    }

    private void InitializeHolidays(eHolidayReligion religion)
    {
        foreach (XmlNode xmlNode in _holidayDoc.SelectSingleNode(((object) religion).ToString()).SelectNodes("Holiday"))
            Add(new Holiday());
    }

    public static List<Holiday> GetHolidays()
    {
        return GetHolidays(DateTime.Now);
    }

    public static List<Holiday> GetHolidays(int year, Language language = Language.Hebrew)
    {
        InitHolidaysDictionary();
        List<Holiday> list;
        using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BillingCalendar.Holidays.xml"))
        {
            List<Holiday> result = Deserialize<List<Holiday>>(manifestResourceStream);
            ProcessHolidaysDates(result, year, language);
            list = result;
        }
        return list;
    }

    public static List<Holiday> GetHolidays(DateTime date)
    {
        return GetHolidays(new HebrewCalendar().GetYear(date));
    }

    private static void ProcessHolidaysDates(List<Holiday> result, int year, Language language)
    {
        result.ForEach(holiday => ProcessSingleHoliday(holiday, year, language));
    }

    private static void ProcessSingleHoliday(Holiday holiday, int year, Language language)
    {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
       EnsureCorrectionTypes(holiday);
        HebrewCalendar hebrewCalendar = new HebrewCalendar();
        if (holiday.Length.HasValue)
            holiday.DateTo = holiday.DateFrom.AddDays((Calendar) hebrewCalendar, year, holiday.Length.Value - 1);
        bool flag = hebrewCalendar.IsLeapYear(year) && holiday.LeapDateFrom != new HolidayDate();
        // ISSUE: variable of a compiler-generated type
        HolidayDate holidayDate;
        DateTime dateTime1;
        if (!flag)
        {
            holidayDate = holiday.DateFrom;
            dateTime1 = holidayDate.ToGregorianDate( hebrewCalendar, year);
        }
        else
        {
            holidayDate = holiday.LeapDateFrom;
            dateTime1 = holidayDate.ToGregorianDate(hebrewCalendar, year);
        }
        // ISSUE: reference to a compiler-generated field
        var cDisplayClassa1 = new { gregorianDateFrom = dateTime1 };
    
        DateTime dateTime2;
        if (!flag)
        {
            holidayDate = holiday.DateTo;
            dateTime2 = holidayDate.ToGregorianDate(hebrewCalendar, year);
        }
        else
        {
            holidayDate = holiday.LeapDateTo;
            dateTime2 = holidayDate.ToGregorianDate(hebrewCalendar, year);
        }
        DateTime gregorianDate = dateTime2;

        // ISSUE: reference to a compiler-generated method
        DayOfWeekWrapper dayOfWeekWrapper =  holiday.CantBeOnDays.SingleOrDefault(day => day == cDisplayClassa1.gregorianDateFrom.DayOfWeek);//.\u003CProcessSingleHoliday\u003Eb__7));
        if (dayOfWeekWrapper != null && dayOfWeekWrapper.DayCorrectionType != DayCorrctionType.Closest)
        {
            int num = dayOfWeekWrapper.DayCorrectionType == DayCorrctionType.Forward ? 1 : -1;
            while (true)
            {
                // ISSUE: reference to a compiler-generated method
                if (holiday.CantBeOnDays.Any(day => day == cDisplayClassa1.gregorianDateFrom.DayOfWeek))
                {
                    if (dayOfWeekWrapper.DayCorrectionType != DayCorrctionType.AddOne)
                    {
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field

                        cDisplayClassa1 = new {gregorianDateFrom = gregorianDate};
                    }
                    gregorianDate = gregorianDate.AddDays(num);
                }
                else
                    break;
            }
        }
        else
        {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            int num = FindClosestDay(holiday, cDisplayClassa1.gregorianDateFrom.DayOfWeek) - cDisplayClassa1.gregorianDateFrom.DayOfWeek;
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            cDisplayClassa1 = new {gregorianDateFrom = cDisplayClassa1.gregorianDateFrom.AddDays(num)};
            gregorianDate = gregorianDate.AddDays( num);
        }
        // ISSUE: reference to a compiler-generated field
        holiday.DateFrom = DateExtensions.TotHolidayDate(cDisplayClassa1.gregorianDateFrom);
        holiday.DateTo = DateExtensions.TotHolidayDate(gregorianDate);
        Holiday holiday1 = holiday;
        holidayDate = holiday.DateTo;
        DateTime dateTime3 = holidayDate.ToGregorianDate((Calendar) hebrewCalendar, year);
        holiday1.GregorianDateTo = dateTime3;
        Holiday holiday2 = holiday;
        holidayDate = holiday.DateFrom;
        DateTime dateTime4 = holidayDate.ToGregorianDate((Calendar) hebrewCalendar, year);
        holiday2.GrerorianDateFrom = dateTime4;
        holiday.HolidayName = GetHolidayName(holiday, language);
    }

    private static string GetHolidayName(Holiday holiday, Language language)
    {
        HolidayName holidayName =
            _holidayNames.SingleOrDefault(name => holiday.HolidayName == name.Hebrew);
        if (holidayName != null)
            return _languageToHolidayNameDict[language](holidayName);
        else
            return holiday.HolidayName;
    }

    private static void EnsureCorrectionTypes(Holiday holiday)
    {
        foreach (
            DayOfWeekWrapper dayOfWeekWrapper in
                holiday.CantBeOnDays.Where(wrapper => wrapper.DayCorrectionType == DayCorrctionType.None))
        {
            dayOfWeekWrapper.DayCorrectionType = holiday.DayCorrectionType;
        }
    }

    private static DayOfWeek FindClosestDay(Holiday holiday, DayOfWeek actualDayOfWeek)
    {
        IEnumerable<DayOfWeek> daysAvailable = new DayOfWeek[7]
        {
            DayOfWeek.Sunday,
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday
        }.Where(day => holiday.CantBeOnDays.All(holidayDAY => (DayOfWeek) holidayDAY != day));
        return daysAvailable.First(
            dayAvailable => Math.Abs(actualDayOfWeek - dayAvailable) == daysAvailable.Min(day => Math.Abs(actualDayOfWeek - day)));
    }

    public static List<Holiday> GetHolidaysForDate(DateTime date)
    {
        List<Holiday> holidays = HolidaysCollection.GetHolidays(date);
        HolidayDate holidayDate = DateExtensions.TotHolidayDate(date);
        return Enumerable.ToList<Holiday>(Enumerable.Where<Holiday>((IEnumerable<Holiday>) holidays, (Func<Holiday, bool>) (holiday => holiday.DateFrom <= holidayDate && holiday.DateTo >= holidayDate)));
    }

    private static T Deserialize<T>(Stream stream)
    {
        stream.Position = 0L;
        return (T) new XmlSerializer(typeof (T)).Deserialize(stream);
    }
    private static string Serialize<T>(T objectToSerialize)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            XmlSerializer serializer = new XmlSerializer(typeof (T));
            serializer.Serialize(stream, objectToSerialize);

            stream.Position = 0L;
            return new StreamReader(stream).ReadToEnd();
        }

    }

    private delegate string ReturnHolidayName(HolidayName name);
}