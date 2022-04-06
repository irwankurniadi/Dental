using System;
using System.ComponentModel.DataAnnotations;

namespace DentalApps.Models
{
	public class DoctorSchedule
	{
        public DoctorSchedule()
        {
            RegisterSchedules = new List<RegisterSchedule>();
        }

        [Key]
        public int DoctorScheduleID { get; set; }
        public string EmployeeID { get; set; } = string.Empty;
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Employee Employee { get; set; } 

        public ICollection<RegisterSchedule> RegisterSchedules;
    }
}

