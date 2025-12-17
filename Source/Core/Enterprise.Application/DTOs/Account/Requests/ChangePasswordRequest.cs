namespace Enterprise.Application.DTOs.Account.Requests
{
    public class ChangePasswordRequest
    {
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
