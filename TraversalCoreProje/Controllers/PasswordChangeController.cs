using AutoMapper.Internal;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalCoreProje.Models;
using static TraversalCoreProje.Areas.Admin.Models.BookingHotelSearchViewModel;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            var user = await _userManager.FindByEmailAsync(forgetPasswordViewModel.Mail);
            string passworldResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passworldResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
            {
                userId = user.Id,
                token = passworldResetToken
            }, HttpContext.Request.Scheme);




            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "ozanates22@gmail.com");

            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgetPasswordViewModel.Mail);

            mimeMessage.To.Add(mailboxAddressTo);

            var bodybulder = new BodyBuilder();
            bodybulder.TextBody = passworldResetToken;
            mimeMessage.Body = bodybulder.ToMessageBody();

            mimeMessage.Subject = "Şifre Değişiklik Talebi";

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("ozanates22@gmail.com", "apvkkghgxmelsctg");
            client.Send(mimeMessage);
            client.Disconnect(true);



            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(int userid, string token)
        {
            TempData["userid"] = userid;
            TempData["Token"] = token;

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPassworldViewModel resetPassworldViewModel)
        {
            var userid = TempData["userid"];
            var token = TempData["Token"];
            if (userid == null || token == null)
            {
                //hata mesajı
            }
            var user = await _userManager.FindByIdAsync(userid.ToString());
            var result = await _userManager.ResetPasswordAsync(user, token.ToString(), resetPassworldViewModel.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }

            return View();

        }
    }
}
