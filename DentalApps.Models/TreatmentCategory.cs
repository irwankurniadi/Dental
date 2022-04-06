using System;
using System.ComponentModel.DataAnnotations;

namespace DentalApps.Models
{
	public class TreatmentCategory
	{
        public TreatmentCategory()
        {
            SubTreatmentCategories = new List<SubTreatmentCategory>();
        }

        [Key]
        public int TreatmentCategoryID { get; set; }
        public string TenantID { get; set; } = string.Empty;
        public string TreatmentName { get; set; } = string.Empty;

        public ICollection<SubTreatmentCategory> SubTreatmentCategories { get; set; }

    }
}

