using SPROUTEXAM.Domain.Enums;

namespace SPROUTEXAM.Domain.Entities
{
    public class AuditTrail : BaseEntity
    {
        public string Action { get; set; }
        public AuditTrailType Type { get; set; }
        public string PrimaryKey { get; set; }
        public string ColumnName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string User { get; set; }
        public string Transaction { get; set; }
    }
}