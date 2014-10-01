// Type: BillingEntities.HijriDate
// Assembly: BillingCalendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 44ED7BD3-A0FC-475F-9B75-C55DBACCBF0F
// Assembly location: D:\Tests\JewishHilidays\bin\BillingCalendar.dll

using BillingCalendar;
using System;
using System.Globalization;

namespace BillingEntities
{
  public class HijriDate
  {
    private HijriCalendar _hijCal;

    public int Day { get; private set; }

    public int Month { get; private set; }

    public int Year { get; private set; }

    public HijriDate()
    {
      this._hijCal = new HijriCalendar();
    }

    public HijriDate(DateTime gregorian)
      : this()
    {
      this.Day = this._hijCal.GetDayOfMonth(gregorian);
      this.Month = this._hijCal.GetMonth(gregorian);
      this.Year = this._hijCal.GetYear(gregorian);
    }

    public override string ToString()
    {
      return string.Format("{0} {1} {2}", (object) this.GetMonthName(), (object) this.Day, (object) this.Year);
    }

    private string GetMonthName()
    {
      return HijriMonthes.ResourceManager.GetString(((object) (eHijriMonths) this.Month).ToString());
    }
  }
}
