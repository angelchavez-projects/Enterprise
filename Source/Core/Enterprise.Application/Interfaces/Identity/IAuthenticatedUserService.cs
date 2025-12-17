namespace Enterprise.Application.Interfaces.Identity
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
        string UserName { get; }
    }
}
