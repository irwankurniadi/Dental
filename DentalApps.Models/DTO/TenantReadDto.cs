using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalApps.Models.DTO
{
    public class TenantReadDto
    {
        public string TenantID { get; set; } = Guid.NewGuid().ToString();
        public string TenantName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PrefixMR { get; set; } = string.Empty;
        public Status TenantStatus { get; set; } = Status.Active;
        public DateTime JoinDate { get; set; } = DateTime.Now;
    }
}