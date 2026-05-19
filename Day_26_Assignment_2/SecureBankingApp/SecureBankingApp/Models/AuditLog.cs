namespace SecureBankingApp.Models
{
    public class AuditLog
    {
        public int Id { get; set; }

        public string ActionPerformed { get; set; }

        public string UserEmail { get; set; }

        public DateTime ActionTime { get; set; }
    }
}