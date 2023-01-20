using Newtonsoft.Json;
using System.Collections.Generic;

namespace Application.Common.Models
{
    internal class Constants
    {
        public static readonly Dictionary<string, MultilangResponse> Messages =
            new Dictionary<string, MultilangResponse>
        {
            { "200", new() { En = "Success", Sw = "Success" } },
            { "301", new() { En = "Invalid Service Code", Sw = "Service Code Haifahamiki" } },
            { "302", new() { En = "Malformed Request Data", Sw = "Taarifa Unazotuma Zimevurugika" } },
            { "303", new() { En = "Unknown Error", Sw = "Tatizo Halijajulikana" } },
            { "304", new() { En = "No Records Found", Sw = "Hakuna Taarifa" } },
            { "305", new() { En = "Internal Service Error", Sw = "Kuna Tatizo La Kiufundi" } },
            { "306", new() { En = "Invalid Token", Sw = "Token Sio Sahihi" } },
            { "307", new() { En = "Expired Token", Sw = "Token Imeisha Muda" } },
            { "308", new() { En = "Invalid Service Endpoint", Sw = "Huduma Haipo" } },
            { "309", new() { En = "Service Misconfiguration", Sw = "Huduma Haipo Sawa" } },
            { "310", new() { En = "Service Failed To Process Queue Msg", Sw = "Huduma Imeshindwa Kusoma Msg za Queue" } },
            { "311", new() { En = "Request timed-out", Sw = "Request timed-out" } },
            { "312", new() { En = "Invalid Request Data", Sw = "Invalid Request Data" } },
            { "313", new() { En = "Validation Error", Sw = "Validation Error" } },
        };

        public static MultilangResponse Ml(string code)
        {
            if (Messages.TryGetValue(code, out var response))
                return response;
            else return Messages["303"];
        }
    }


    public class ResponseModel
    {
        public bool IsSuccessful { get; set; }
        public string Code { get; set; }
        public MultilangResponse Data { get; set; }

        protected ResponseModel() { }

        public static ResponseModel Success(string message = null)
        {
            return new ResponseModel()
            {
                IsSuccessful = true,
                Code = "200",
                Data = message != null ? new() { En = message, Sw = message } : Constants.Ml("200")
            };
        }

        public static ResponseModel Failure(string code = null, string message = null)
        {
            return new ResponseModel()
            {
                Code = code ?? "303",
                Data = Constants.Ml(code ?? "303")
            };

        }

        /// <summary>
        /// Validation Failure
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseModel Vf(string message)
        {
            return new ResponseModel()
            {
                Code = "313",
                Data = new() { En = message }
            };

        }
    }

    public class ResponseModel<T> : ResponseModel
    {
        public new T Data { get; set; }

        public static ResponseModel<T> Success(T data, string code = null)
        {
            return new ResponseModel<T>()
            {
                IsSuccessful = true,
                Code = code ?? "200",
                Data = data,
            };
        }
        public static ResponseModel<T> Failure(T data, string code = null)
        {
            return new ResponseModel<T>()
            {
                IsSuccessful = false,
                Code = code ?? "303",
                Data = data,
            };
        }
    }
}
