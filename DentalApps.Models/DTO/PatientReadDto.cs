using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalApps.Models.DTO
{
    public class PatientReadDto
    {
        public string PatientID { get; set; } = string.Empty;
        public string TenantID { get; set; } = string.Empty;
        public string MedicalRecordNumber { get; set; } = string.Empty;
        public string? Username { get; set; }
        public Status Status { get; set; } = Status.Active;

        public string FullName { get; set; } = string.Empty;
        public Gender Gender { get; set; } = Gender.Male;
        public DateTime Birthdate { get; set; } = DateTime.Now;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string MobilePhone { get; set; } = string.Empty;
        public string BPJSNumber { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; } = DateTime.Now;
    }
}