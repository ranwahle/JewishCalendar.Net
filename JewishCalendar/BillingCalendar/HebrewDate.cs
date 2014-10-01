// Type: BillingEntities.HebrewDate
// Assembly: BillingCalendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 44ED7BD3-A0FC-475F-9B75-C55DBACCBF0F
// Assembly location: D:\Tests\JewishHilidays\bin\BillingCalendar.dll

using BillingCalendar;
using System;
using System.Globalization;
using System.Text;

namespace BillingEntities
{
  public class HebrewDate
  {
    private const int TET_VAV = 15;
    private const int TET_ZAIN = 16;
    private int _nMonth;
    private HebrewCalendar _cal;

    public int Day { get; set; }

    public int Month
    {
      get
      {
        return this._nMonth;
      }
      set
      {
        this._nMonth = value;
      }
    }

    public int Year { get; set; }

    public static HebrewDate Now
    {
      get
      {
        return HebrewDate.GetDate(DateTime.Now);
      }
    }

    public HebrewDate()
    {
      this._cal = new HebrewCalendar();
    }

    public static HebrewDate GetDate(DateTime gregorianDate)
    {
      HebrewCalendar hebrewCalendar = new HebrewCalendar();
      return new HebrewDate()
      {
        Day = hebrewCalendar.GetDayOfMonth(gregorianDate),
        Month = hebrewCalendar.GetMonth(gregorianDate),
        Year = hebrewCalendar.GetYear(gregorianDate)
      };
    }

    public override string ToString()
    {
      return string.Format("{0} {1} {2}", (object) this.GetDayString(), (object) this.GetMonthString(), (object) this.GetYearString());
    }

    private string GetYearString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (this.Year > 0)
        stringBuilder.Append(HebrewLetters.ResourceManager.GetString(((object) (eLetters) (this.Year / 1000)).ToString()));
      int num1 = this.Year % 1000;
      int num2 = 400;
      while (num1 > num2)
      {
        stringBuilder.Append(HebrewLetters.ResourceManager.GetString(((object) eLetters.Tav).ToString()));
        num1 -= num2;
      }
      if (num1 / 100 > 0)
        stringBuilder.Append(HebrewLetters.ResourceManager.GetString(((object) (eLetters) (num1 / 100 * 100)).ToString()));
      int dayNum = num1 % 100;
      stringBuilder.Append(HebrewDate.GetDayString(dayNum));
      return ((object) stringBuilder).ToString();
    }

    private string GetMonthString()
    {
      if (!this._cal.IsLeapYear(this.Year))
        return HebrewMonthes.ResourceManager.GetString(((object) (eHebrewMonth) this.Month).ToString());
      else
        return HebrewMonthes.ResourceManager.GetString(((object) (eLeapHebrewMonth) this.Month).ToString());
    }

    private string GetDayString()
    {
      return HebrewDate.GetDayString(this.Day);
    }

    private static string GetDayString(int dayNum)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (dayNum == 15)
        stringBuilder.AppendFormat("{0}\"{1}", (object) HebrewLetters.Tet, (object) HebrewLetters.Vav);
      else if (dayNum == 16)
      {
        stringBuilder.AppendFormat("{0}\"{1}", (object) HebrewLetters.Tet, (object) HebrewLetters.Zain);
      }
      else
      {
        string string1 = HebrewLetters.ResourceManager.GetString(((object) (eLetters) (dayNum % 10)).ToString());
        if (dayNum > 10)
        {
          string string2 = HebrewLetters.ResourceManager.GetString(((object) (eLetters) (dayNum / 10 * 10)).ToString());
          if (dayNum % 10 > 0)
            stringBuilder.AppendFormat("{0}\"{1}", (object) string2, (object) string1);
          else
            stringBuilder.AppendFormat("{0}'", (object) string2);
        }
        else
          stringBuilder.AppendFormat("{0}'", (object) string1);
      }
      return ((object) stringBuilder).ToString();
    }
  }
}
