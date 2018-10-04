using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Portfolio.Models;
using Portfolio.Services.RecaptchaService;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactViewModel contactViewModel, [FromServices] IRecaptchaService recaptchaService)
        {
            var isRecaptchaSuccessful = await recaptchaService.ReCaptchaPassed(Request.Form["g-recaptcha-response"]);

            if (!isRecaptchaSuccessful)
            {
                Response.StatusCode = 403;

                return View(contactViewModel);
            }

            return View(contactViewModel);
        }
    }
}
