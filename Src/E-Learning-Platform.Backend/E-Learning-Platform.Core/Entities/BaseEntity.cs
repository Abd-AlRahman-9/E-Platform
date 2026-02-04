namespace WebApplication1.Models
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; } // ممكن يكون int أو string أو Guid
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; } = false; // "Soft Delete" 
    }
}
