namespace Enterprise.Application.DTOs.Account.Responses
{
    public class AuthenticationResponse
    {
        public required string Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required IList<string> Roles { get; set; }
        public bool IsVerified { get; set; }
        public required string JwToken { get; set; }
    }
}
