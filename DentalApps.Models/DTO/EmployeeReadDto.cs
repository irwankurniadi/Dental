namespace DentalApps.Models.DTO;

public class EmployeeReadDto
{
        public string EmployeeID { get; set; } = Guid.NewGuid().ToString();
        public string TenantID { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public Status Status { get; set; } = Status.Active;

        public string FullName { get; set; } = string.Empty;
        public Gender Gender { get; set; } = Gender.Male;
        public DateTime Birthdate { get; set; } = DateTime.Now;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string MobilePhone { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; } = DateTime.Now;
}
