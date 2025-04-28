using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using TraversalCoreProje.Models;
using DocumentFormat.OpenXml.Wordprocessing;


namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage(); 

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "ozanates22@gmail.com");
            
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User",mailRequest.ReceiverMail);

            mimeMessage.To.Add(mailboxAddressTo);
            
            var bodybulder =new BodyBuilder();
            bodybulder.TextBody = mailRequest.Body;
            mimeMessage.Body = bodybulder.ToMessageBody();

            mimeMessage.Subject = mailRequest.Subject;
            
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com",587,false);
            client.Authenticate("ozanates22@gmail.com", "apvkkghgxmelsctg");
            client.Send(mimeMessage);
            client.Disconnect(true);


            return View();
        }


    }
}
