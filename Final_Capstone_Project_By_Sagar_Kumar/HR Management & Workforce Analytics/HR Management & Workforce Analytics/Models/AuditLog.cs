namespace HR_Management___Workforce_Analytics.Models
{
    public class AuditLog
    {
        public int AuditLogId { get; set; }
        public string ActionPerformed { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
    }
}
