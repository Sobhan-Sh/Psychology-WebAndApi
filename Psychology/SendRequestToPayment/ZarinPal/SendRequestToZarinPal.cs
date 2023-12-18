using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PC.Utility.Dto;
using PC.Utility.ReturnFuncResult;
using PC.Utility.Validation;
using System.Text;
using ZarinPal.Class;

namespace PC.Utility.SendRequestToPayment.ZarinPal;

public class SendRequestToZarinPal
{
    private static Payment _payment;

    public SendRequestToZarinPal(Payment payment)
    {
        _payment = payment;
    }

    public static async Task<BaseResult<string>> SendRequest(CreateRequestZarinPal createRequestZarinPal)
    {
        try
        {
            using (var client = new HttpClient())
            {
                createRequestZarinPal.merchant_id = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";
                createRequestZarinPal.metadata = new string[2];
                if (createRequestZarinPal.Phone != null)
                {
                    createRequestZarinPal.metadata[0] = createRequestZarinPal.Phone;
                }
                if (createRequestZarinPal.Email != null)
                {
                    createRequestZarinPal.metadata[1] = createRequestZarinPal.Email;
                }

                createRequestZarinPal.callback_url =
                    $"{SD.BaseUrlProject}{createRequestZarinPal.callback_url}?{createRequestZarinPal.Data}";
                var json = JsonConvert.SerializeObject(createRequestZarinPal);

                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://sandbox.zarinpal.com/pg/v4/payment/request.json", content);

                string responseBody = await response.Content.ReadAsStringAsync();

                JObject jo = JObject.Parse(responseBody);
                string errorscode = jo["errors"].ToString();

                JObject jodata = JObject.Parse(responseBody);
                string dataauth = jodata["data"].ToString();


                if (dataauth != "[]")
                {


                    createRequestZarinPal.Authority = jodata["data"]["authority"].ToString();
                    string gatewayUrl = "https://sandbox.zarinpal.com/pg/StartPay/" + createRequestZarinPal.Authority;

                    return new()
                    {
                        Data = gatewayUrl,
                        StatusCode = ValidationCode.Success,
                        IsSuccess = true,
                        Message = createRequestZarinPal.Authority
                    };
                }
                else
                    return new()
                    {
                        IsSuccess = false,
                        Message = createRequestZarinPal.Authority,
                        StatusCode = ValidationCode.BadRequest
                    };
            }
            //Request resultPayment = await _payment.Request(new DtoRequest()
            //{
            //    Mobile = createRequestZarinPal.Phone,
            //    CallbackUrl = ,
            //    Description = createRequestZarinPal.Description,
            //    Email = createRequestZarinPal.Email,
            //    Amount = createRequestZarinPal.Amount,
            //    MerchantId = ,
            //}, Payment.Mode.sandbox);
            //if (resultPayment.Status == 100)
            //    return new()
            //    {
            //        Data = $"https://sandbox.zarinpal.com/pg/StartPay/{resultPayment.Authority}",
            //        StatusCode = ValidationCode.Success,
            //        IsSuccess = true,
            //        Message = resultPayment.Status.ToString()
            //    };

            //return new()
            //{
            //    IsSuccess = false,
            //    Message = resultPayment.Status.ToString(),
            //    StatusCode = ValidationCode.BadRequest
            //};
        }
        catch (Exception e)
        {
            return new()
            {
                IsSuccess = false,
                Message = e.Message,
                StatusCode = ValidationCode.BadRequest
            };
        }
    }
}