namespace Enterprise.Domain.Common.Base
{
    public abstract class BaseEntity<Tkey>
    {
        public Tkey Id { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<long> { }
}
