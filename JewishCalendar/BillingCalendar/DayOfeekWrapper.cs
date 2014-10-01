// Type: BillingCalendar.DayOfWeekWrapper
// Assembly: BillingCalendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 44ED7BD3-A0FC-475F-9B75-C55DBACCBF0F
// Assembly location: D:\Tests\JewishHilidays\bin\BillingCalendar.dll

using System;

namespace BillingCalendar
{
  public class DayOfWeekWrapper
  {
    public DayOfWeek DayOfWeek { get; set; }

    public DayCorrctionType DayCorrectionType { get; set; }

    public static implicit operator DayOfWeek(DayOfWeekWrapper wrapper)
    {
      return wrapper.DayOfWeek;
    }
  }
}
