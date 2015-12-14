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
        [DisplayName("Duration")]
        public int duration { get; set; }
        public string Reason { get; set; }
        public string Action { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        // all the fancy foreign keys
        public virtual User User { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual DowntimeType DowntimeType { get; set; }
    }
}