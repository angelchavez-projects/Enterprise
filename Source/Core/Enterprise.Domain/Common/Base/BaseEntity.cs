namespace Enterprise.Domain.Common.Base
{
    public abstract class BaseEntity<Tkey>
    {
        public required Tkey Id { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<long> { }
}
