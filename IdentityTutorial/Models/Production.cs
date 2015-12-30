using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityTutorial.Models
{
    public class Production
    {
        [DisplayName("Production ID")]
        public int ProductionID { get; set; }
        [DisplayName("User")]
        public string UserID { get; set; }
        [DisplayName("Shift Type")]
        public int ShiftID { get; set; }
        [DisplayName("Plant Name")]
        public int PlantID { get; set; }
        [DisplayName("Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [DisplayName("End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }
        [DisplayName("Actual Mix")]
        public int ActualMix { get; set; }
        [DisplayName("Crumb Waste")]
        public int CrumbWaste { get; set; }
        [DisplayName("Compactor Waste")]
        public int Cmp_Waste { get; set; }
        public int Manning { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int TotalWaste { get; set; }
        public int TotalProdMins { get; set; }

        // all the fancy foreign keys
        public virtual User User { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual Plant Plant { get; set; }

        public class ProdViewModel
        {
           
            public int totalWaste { get;set;}
            public DateTime TotalProduction { get; set; }
        }
       
    }
}