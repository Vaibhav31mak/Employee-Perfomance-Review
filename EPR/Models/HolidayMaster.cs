namespace EPR.Models
{
    public class HolidayMaster
    {
        public int HolidayID { get; set; }
        public string HolidayName { get; set; }
        public DateTime HolidayDate { get; set; }
        public bool IsWeekend { get; set; }
    }
}
