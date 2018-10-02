using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Net;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace Portfolio.Services.RecaptchaService
{
    public class RecaptchaService : IRecaptchaService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public RecaptchaService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        public async Task<bool> ReCaptchaPassed(string gRecaptchaResponse)
        {
            string secret = _configuration.GetSection("GoogleReCaptcha").GetSection("secret").Value;

            using (var client = _clientFactory.CreateClient())
            {
                var res = await client.GetAsync($"https://www.google.com/recaptcha/api/siteverify?response={gRecaptchaResponse}&secret={secret}");

                if (res.StatusCode != HttpStatusCode.OK)
                {
                    //logger.LogError("rror while sending request to ReCaptcha");
                    return false;
                }

                string JSONres = res.Content.ReadAsStringAsync().Result;
                dynamic JSONdata = JObject.Parse(JSONres);

                if (JSONdata.success != "true") return false;

                return true;
            } 
        }
    }
}
