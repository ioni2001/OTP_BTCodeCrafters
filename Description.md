# OTP Generator

## Project description

* Services package:
  - **IOTPService** that contains two methods. **GenerateOTP** that generates an OTP (One-Time Password) as a string based on the provided userId and **IsOTPValid** which checks whether the provided OTP is valid for the given userId. It returns true if the OTP is valid, otherwise it returns false.
  - **OTPService** which implements IOTPService:
    - *GenerateOTP* method takes a userId as input and generates a One-Time Password (OTP) as a string. It utilizes the Totp class to compute the OTP based on the provided userId and the current UTC datetime. By default the generated OTP is valid for up to 30 seconds. The computed OTP is then returned as a string.
    -  *IsOTPValid* method takes a userId and an OTP (totp) as inputs. It calls the GenerateOTP method to generate a new OTP based on the provided userId. Then, it compares the generated OTP (newTOTP) with the provided OTP (totp). If they are equal, it returns true, indicating that the OTP is valid for the given userId. Otherwise, it returns false.
* Controllers package:
  - **OTPController** that represents the API. It contains two endpoints:
    - *GenerateOTP* with a route parameter {userId}. It accepts a userId as input from the route and calls the _oTPService.GenerateOTP(userId) method to generate an OTP. If the userId is null, it returns a BadRequest response with the message "UserId is null!". Otherwise, it returns an Ok response with the generated OTP.
    - *CheckOTP* with a route parameter {userId}. It accepts a userId from the route and an OTP (totp) from the request body. The method first checks if the userId is null. If it is, it returns a BadRequest response with the message "UserId is null!". Next, it checks if the totp is null or if the OTP is invalid by calling the _oTPService.IsOTPValid(userId, totp) method. If the totp is null or the OTP is invalid, it returns a BadRequest response with the message "Invalid OTP!". If the totp is not null and the OTP is valid for the given userId, it returns an Ok response with the message "Authenticated :)" to indicate a successful authentication.
