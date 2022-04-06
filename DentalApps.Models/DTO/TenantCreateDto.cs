using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalApps.Models.DTO
{
    public class TenantCreateDto
    {
        [Required]
        public string TenantName { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

         [Required]
        public string PrefixMR { get; set; } = string.Empty;
        
        [Required]
        public Status TenantStatus { get; set; } = Status.Active;
        
        [Required]
        public DateTime JoinDate { get; set; } = DateTime.Now;
    }
}