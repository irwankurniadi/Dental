using System;
using System.ComponentModel.DataAnnotations;

namespace DentalApps.Models
{
	public class SubTreatmentCategory
	{
        [Key]
        public int SubTreatmentCategoryID { get; set; }
        public int TreatmentCategoryID { get; set; }
        public string SubTreatmentCategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal? DefaultPrice { get; set; } 

        public TreatmentCategory TreatmentCategory { get; set; } 
    }
}

