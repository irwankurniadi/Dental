using System;
using System.ComponentModel.DataAnnotations;

namespace DentalApps.Models
{
	public class RegisterSchedule
	{
        [Key]
        public int ScheduleID { get; set; }
        public int DoctorScheduleID { get; set; }
        public string PatientID { get; set; } = string.Empty;
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Request;

        public DoctorSchedule DoctorSchedule { get; set; } 
        public Patient Patient { get; set; } = new();
    }
}

