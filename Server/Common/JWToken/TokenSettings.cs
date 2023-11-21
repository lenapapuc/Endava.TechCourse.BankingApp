namespace Endava.TechCourse.BankApp.Server.Common.JWToken
{
    public class TokenSettings
    {
        public string SecretKey { get; set; } = null!;
        public int ExpirationInMinutes { get; set; }
    }
}
