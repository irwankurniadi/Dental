using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalApps.Models
{
    public class Tenant
    {
        public Tenant()
        {
            Patients = new List<Patient>();
            Employees = new List<Employee>();
        }

        [Key]
        public string TenantID { get; set; } = Guid.NewGuid().ToString();
        public string TenantName { get; set; } = string.Empty;
        public string PrefixMR { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Status TenantStatus { get; set; } = Status.Active;
        public DateTime JoinDate { get; set; } = DateTime.Now;

        public ICollection<Patient> Patients { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }

    
}
