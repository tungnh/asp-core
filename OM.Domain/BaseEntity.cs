namespace OM.Domain
{
    public class BaseEntity
    {
        public bool DeleteFlg { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public string? LastModifiedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }
    }
}
