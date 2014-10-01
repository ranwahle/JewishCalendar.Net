// Type: BillingEntities.MuslimHolidays
// Assembly: BillingCalendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 44ED7BD3-A0FC-475F-9B75-C55DBACCBF0F
// Assembly location: D:\Tests\JewishHilidays\bin\BillingCalendar.dll

using System;
using System.Globalization;

namespace BillingEntities
{
  public class MuslimHolidays : HijriCalendar
  {
    public eMuslimHoliday? Holiday { get; set; }

    public int HijriYear { get; set; }

    public int HijriMonth { get; set; }

    public int HijriDay { get; set; }

    public string HolidayName
    {
      get
      {
        return MuslimHolidays.GetHolidayName(this.Holiday);
      }
    }

    public MuslimHolidays()
      : this(DateTime.Now)
    {
    }

    public MuslimHolidays(DateTime georgianDate)
    {
      this.HijriDay = this.GetDayOfMonth(georgianDate);
      this.HijriMonth = this.GetMonth(georgianDate);
      this.HijriYear = this.GetYear(georgianDate);
      this.Holiday = this.GetHoliday();
    }

    private static string GetHolidayName(eMuslimHoliday? holiday)
    {
      string str = string.Empty;
      eMuslimHoliday valueOrDefault = holiday.GetValueOrDefault();
      if (holiday.HasValue)
      {
        switch (valueOrDefault)
        {
          case eMuslimHoliday.MuharamFirst:
            return "ראש השנה המוסלמי";
          case eMuslimHoliday.AshuraDay:
            return "אשורא";
          case eMuslimHoliday.MiladAnabiSuni:
            return "הולדת הנביא מוחמד (סונים)";
          case eMuslimHoliday.MiladAnabiSia:
            return "הולדת הנביא מוחמד (שיעים)";
          case eMuslimHoliday.MiladAlimamAli:
            return "הולדת האימאם עלי";
          case eMuslimHoliday.IsraWalMeeraj:
            return "אלאסראא' ואלמעראג'";
          case eMuslimHoliday.Ramadan:
            return "צום רמדאן";
          case eMuslimHoliday.IdAlAdha:
            return "חג הקרבן";
          case eMuslimHoliday.IdAlFitter:
            return "עיד אלפיטר";
        }
      }
      return holiday.ToString();
    }

    public eMuslimHoliday? GetHoliday()
    {
      eMuslimMonth eMuslimMonth = (eMuslimMonth) this.HijriMonth;
      eMuslimHoliday? nullable = new eMuslimHoliday?();
      switch (eMuslimMonth)
      {
        case eMuslimMonth.Muharram:
          switch (this.HijriDay)
          {
            case 1:
              nullable = new eMuslimHoliday?(eMuslimHoliday.MuharamFirst);
              break;
            case 10:
              nullable = new eMuslimHoliday?(eMuslimHoliday.AshuraDay);
              break;
          }
          break;
        case eMuslimMonth.RabiAlAwal:
          switch (this.HijriDay)
          {
            case 12:
              nullable = new eMuslimHoliday?(eMuslimHoliday.MiladAnabiSuni);
              break;
            case 17:
              nullable = new eMuslimHoliday?(eMuslimHoliday.MiladAnabiSia);
              break;
          }
          break;
        case eMuslimMonth.Rajab:
          switch (this.HijriDay)
          {
            case 13:
              nullable = new eMuslimHoliday?(eMuslimHoliday.MiladAlimamAli);
              break;
            case 27:
              nullable = new eMuslimHoliday?(eMuslimHoliday.IsraWalMeeraj);
              break;
          }
          break;
        case eMuslimMonth.Ramadan:
          nullable = new eMuslimHoliday?(eMuslimHoliday.Ramadan);
          break;
        case eMuslimMonth.Shawwal:
          if (this.HijriDay == 1)
          {
            nullable = new eMuslimHoliday?(eMuslimHoliday.IdAlFitter);
            break;
          }
          else
            break;
        case eMuslimMonth.DhuAlHaj:
          if (this.HijriDay == 10)
          {
            nullable = new eMuslimHoliday?(eMuslimHoliday.IdAlAdha);
            break;
          }
          else
            break;
      }
      return nullable;
    }
  }
}
