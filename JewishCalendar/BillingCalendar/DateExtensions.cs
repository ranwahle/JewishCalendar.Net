// Type: BillingEntities.DateExtensions
// Assembly: BillingCalendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 44ED7BD3-A0FC-475F-9B75-C55DBACCBF0F
// Assembly location: D:\Tests\JewishHilidays\bin\BillingCalendar.dll

using System;
using System.Globalization;

namespace BillingEntities
{
  public static class DateExtensions
  {
    public static HolidayDate TotHolidayDate(this DateTime gregorianDate)
    {
      HebrewCalendar hebrewCalendar = new HebrewCalendar();
      return new HolidayDate()
      {
        Day = hebrewCalendar.GetDayOfMonth(gregorianDate),
        Month = hebrewCalendar.GetMonth(gregorianDate)
      };
    }
  }
}
