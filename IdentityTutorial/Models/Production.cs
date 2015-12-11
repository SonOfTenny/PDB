using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityTutorial.Models
{
    public class Production
    {
        public int ProductionID { get; set; }
        public string UserID { get; set; }
        public int ShiftID { get; set; }
        public int PlantID { get; set; }
        public int ActualMix { get; set; }
        public int CrumbWaste { get; set; }
        public int Cmp_Waste { get; set; }
        public int Manning { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        // all the fancy foreign keys
        public virtual User User { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual Plant Plant { get; set; }
    }
}