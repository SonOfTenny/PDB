using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityTutorial.Models
{
    public class Downtime
    {
        [DisplayName("Downtime ID")]
        public int DowntimeID { get; set; }
        [DisplayName("Username")]
        public string UserID { get; set; }
        [DisplayName("Shift Type")]
        public int ShiftID { get; set; }
        [DisplayName("Downtime ID")]
        public int DowntimeTypeID { get; set; }
        [DisplayName("Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [DisplayName("End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }
        public string Reason { get; set; }
        public string Action { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public double TotalDownMins { get; set; }

        // all the fancy foreign keys
        public virtual User User { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual  Plant Plant { get; set; }
        public virtual DowntimeType DowntimeType { get; set; }
    }
}