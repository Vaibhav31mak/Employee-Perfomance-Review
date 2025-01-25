using System.ComponentModel.DataAnnotations;

namespace EPR.Models
{
    public class LeaveApplication : ApprovalActivity
    {
        public int Id { get; set; }
        [Display(Name ="Employee Name")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        //Remove This Portion if model validation problem occurs -----------
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        //-------------------

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        [Display(Name = "No. of Leave Days")]
        public int NoOfDays { get; set; }
        public int DurationId { get; set; }
        public SystemCodeDetail Duration { get; set; }
        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }
        public string? Attachment { get; set; }
        [Display(Name = "Notes")]
        public string Description { get; set; }
        [Display(Name = "Status")]
        public int StatusId { get; set; }
        public SystemCodeDetail Status { get; set; }
    }


}
