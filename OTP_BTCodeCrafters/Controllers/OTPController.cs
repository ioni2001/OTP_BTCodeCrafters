using Microsoft.AspNetCore.Mvc;
using OTP_BTCodeCrafters.Services;

namespace OTP_BTCodeCrafters.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OTPController : ControllerBase
    {
        private readonly IOTPService _oTPService;

        public OTPController(IOTPService oTPService)
        {
            _oTPService = oTPService;
        }

        [HttpPost]
        [Route("generateOTP/{userId}")]
        public IActionResult GenerateOTP([FromRoute] string userId) 
        {
            if(userId == null)
            {
                return BadRequest("UserId is null!");
            }

            var otp = _oTPService.GenerateOTP(userId);
            return Ok(otp);
        }

        [HttpPost]
        [Route("checkOTP/{userId}")]
        public IActionResult CheckOTP([FromRoute] string userId, [FromBody] string totp) 
        {
            if(userId == null) 
            {
                return BadRequest("UserId is null!");
            }

            if(totp == null || !_oTPService.IsOTPValid(userId, totp))
            {
                return BadRequest("Invalid OTP!");
            }

            return Ok("Authenticated :)");
        }
    }
}
