// Type: BillingEntities.HolidayDate
// Assembly: BillingCalendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 44ED7BD3-A0FC-475F-9B75-C55DBACCBF0F
// Assembly location: D:\Tests\JewishHilidays\bin\BillingCalendar.dll

using System;
using System.Globalization;

namespace BillingEntities
{
  public struct HolidayDate
  {
    public int Month { get; set; }

    public int Day { get; set; }

    public static bool operator ==(HolidayDate date1, HolidayDate date2)
    {
      return date1.Equals(date2);
    }

    public static bool operator !=(HolidayDate date1, HolidayDate date2)
    {
      return !(date1 == date2);
    }

    public static bool operator >(HolidayDate date1, HolidayDate date2)
    {
      return date1.Month > date2.Month || date1.Month == date2.Month && date1.Day > date2.Day;
    }

    public static bool operator <(HolidayDate date1, HolidayDate date2)
    {
      return date2.Month > date1.Month || date2.Month == date1.Month && date2.Day > date1.Day;
    }

    public static bool operator >=(HolidayDate date1, HolidayDate date2)
    {
      return !(date2 < date1);
    }

    public static bool operator <=(HolidayDate date1, HolidayDate date2)
    {
       return !(date2 > date1);
    }

    public override bool Equals(object obj)
    {
      return this.Equals((HolidayDate) obj);
    }

    public bool Equals(HolidayDate dateObj)
    {
      return this.Day == dateObj.Day && this.Month == dateObj.Month;
    }

    public override int GetHashCode()
    {
      return this.Month * 31 + this.Day;
    }

    public DateTime ToGregorianDate(Calendar usedCalendar, int year)
    {
      return usedCalendar.ToDateTime(year, this.Month, this.Day, 0, 0, 0, 0);
    }

    internal HolidayDate AddDays(Calendar useCalendar, int year, int days)
    {
      DateTime time = this.ToGregorianDate(useCalendar, year).AddDays((double) days);
      return new HolidayDate()
      {
        Day = useCalendar.GetDayOfMonth(time),
        Month = useCalendar.GetMonth(time)
      };
    }
  }
}
