namespace OTP_BTCodeCrafters.Services
{
    public interface IOTPService
    {
        string GenerateOTP(string userId);
        bool IsOTPValid(string userId, string totp);
    }
}
