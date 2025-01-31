namespace EPR.Models
{
    public class EmployeeAttendance
    {
        public int AttendanceID { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; } // Assuming you have an Employee model
        public DateTime AttendanceDate { get; set; }
        public AttendanceStatus Status { get; set; }
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
    }

    public enum AttendanceStatus
    {
        Present,
        Absent,
        Leave,
        Holiday
    }
}
