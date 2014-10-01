// Type: BillingEntities.Holiday
// Assembly: BillingCalendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 44ED7BD3-A0FC-475F-9B75-C55DBACCBF0F
// Assembly location: D:\Tests\JewishHilidays\bin\BillingCalendar.dll

using BillingCalendar;
using System;
using System.Collections.Generic;

namespace BillingEntities
{
  public class Holiday
  {
    private HolidayDate _dateFrom;
    private HolidayDate _leapDateFrom;
    private HolidayDate _leapDateTo;
    private HolidayDate _dateTo;

    public DayCorrctionType DayCorrectionType { get; set; }

    public DateTime GrerorianDateFrom { get; set; }

    public DateTime GregorianDateTo { get; set; }

    public virtual eHolidayReligion Religion { get; set; }

    public HolidayDate DateFrom
    {
      get
      {
        return this._dateFrom;
      }
      set
      {
        if (value > this.DateTo)
          this.DateTo = value;
        this._dateFrom = value;
      }
    }

    public HolidayDate LeapDateFrom
    {
      get
      {
        return this._leapDateFrom;
      }
      set
      {
        if (value > this.LeapDateTo)
          this.LeapDateTo = value;
        this._leapDateFrom = value;
      }
    }

    public HolidayDate LeapDateTo
    {
      get
      {
        if (this._leapDateTo < this.LeapDateFrom)
          this._leapDateTo = this.LeapDateFrom;
        return this._leapDateTo;
      }
      set
      {
        this._leapDateTo = value;
      }
    }

    public HolidayDate DateTo
    {
      get
      {
        if (this._dateTo < this.DateFrom)
          this._dateTo = this.DateFrom;
        return this._dateTo;
      }
      set
      {
        this._dateTo = value;
      }
    }

    public List<DayOfWeekWrapper> CantBeOnDays { get; set; }

    public int? Length { get; set; }

    public string HolidayName { get; set; }

    public bool IsOutOfWork { get; set; }

    public Holiday()
    {
      this.DateFrom = new HolidayDate()
      {
        Day = 1,
        Month = 1
      };
      this.DateTo = new HolidayDate()
      {
        Day = 1,
        Month = 1
      };
    }
  }
}
