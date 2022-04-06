using System;
using System.ComponentModel.DataAnnotations;

namespace DentalApps.Models
{
	public class SubTreatment
	{
        [Key]
        public int SubTreatmentID { get; set; }
        public int SubTreatmentCategoryID { get; set; }
        public int TreatmentID { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public Quadrant Position { get; set; }

        public Treatment Treatment { get; set; }
    }
}

