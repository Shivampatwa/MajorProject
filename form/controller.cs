[HttpGet]  
public JsonResult GenerateOTP(string mobile) {  
    string CountryCode = "xx";  
    string appKey = "xxxxxxxxxxxxxxx";  
    var client = new RestClient("sms otp api url ");  
    var request = new RestRequest(Method.POST);  
    request.AddHeader("cache-control", "no-cache");  
    request.AddHeader("application-key", appKey);  
    request.AddParameter("undefined", "{\n \"countryCode\": " + countryCode + ",\n \"mobileNumber\": " + mobile + ",\n \"getGeneratedOTP\": true\n}", ParameterType.RequestBody);  
    IRestResponse response = client.Execute(request);  
    var newResource = JsonConvert.DeserializeObject < OTPVerification > (response.Content);  
    if (newResource.response.code == "OTP_SENT_SUCCESSFULLY") {  
        return Json(newResource.response.code, JsonRequestBehavior.AllowGet);  
    } else if (newResource.response.code == "OTP_EXPRID") {  
        return Json(newResource.response.code, JsonRequestBehavior.AllowGet);  
    } else {  
        return Json(newResource.status, JsonRequestBehavior.AllowGet);  
    }  
}  