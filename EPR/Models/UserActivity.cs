namespace EPR.Models
{
    public class UserActivity
    {
        public string? CreateById { get; set; }
        public DateTime CreateOn { get; set; }
        public string? ModeifiedById { get; set; }
        public DateTime ModifiedOn { get; set; }

    }

    public class ApprovalActivity : UserActivity
    {
        public string? ApprovedById { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public string? RejectedById { get; set; }
        public DateTime? RejectedOn { get; set; }
    }
}
