namespace E_Learning_Platform.Core.Entities
{
    public class BaseAuditEntity
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; } = false; // "Soft Delete"
    }
}
