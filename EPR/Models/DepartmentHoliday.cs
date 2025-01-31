namespace EPR.Models
{
    public class DepartmentHoliday
    {
        public int DepartmentID { get; set; }
        public int DesignationID { get; set; }
        public int HolidayID { get; set; }
        public Department Department { get; set; } // Assuming you have a Department model
        public Designation Designation { get; set; } // Assuming you have a Designation model
        public HolidayMaster Holiday { get; set; }
    }

}
