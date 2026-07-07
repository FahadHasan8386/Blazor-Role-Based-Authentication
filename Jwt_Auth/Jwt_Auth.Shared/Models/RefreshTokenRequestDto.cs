namespace Jwt_Auth.Shared.Models
{
    public class RefreshTokenRequestDto
    {
        public Guid UserId {  get; set; }
        public required string RefreshToken { get; set; }   

    }
}
