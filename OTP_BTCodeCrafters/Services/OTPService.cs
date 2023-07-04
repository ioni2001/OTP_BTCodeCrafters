using OtpNet;
using System.Text;

namespace OTP_BTCodeCrafters.Services
{
    public class OTPService : IOTPService
    {
        public string GenerateOTP(string userId)
        {
            var totp = new Totp(Encoding.ASCII.GetBytes(userId));

            DateTime currentDateTime = DateTime.UtcNow;
            return totp.ComputeTotp(currentDateTime);
        }

        public bool IsOTPValid(string userId, string totp)
        {
            string newTOTP = GenerateOTP(userId);
            return newTOTP.Equals(totp);
        }
    }
}
