using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Services.RecaptchaService
{
    public interface IRecaptchaService
    {
        Task<bool> ReCaptchaPassed(string gRecaptchaResponse);
    }
}
