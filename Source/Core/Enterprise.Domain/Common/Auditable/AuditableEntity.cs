using Enterprise.Domain.Common.Base;

namespace Enterprise.Domain.Common.Auditable
{
    public abstract class AuditableEntity<Tkey> : BaseEntity<Tkey>
    {
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }

    public abstract class AuditableEntity : AuditableEntity<long> { }
}
