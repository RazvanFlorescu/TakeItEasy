using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicCommon.CqrsCore.CammandHandlers;
using BusinessLogicWriter.CqrsCore.Commands.Email;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BusinessLogicWriter.CqrsCore.CammandHandlers.Email
{
    public class SendEmailCommandHandler : ICommandHandler<SendEmailCommand>
    {
        public void Handle(SendEmailCommand command)
        {
             SendMail(command.DestinatorEmail, command.AuthorEmail, command.Message, command.FirstName, command.LastName).Wait();
        }

        public static async Task SendMail(string toMail, string fromMail, string message, string firstName, string lastName)
        {
            //var apiKey = Environment.GetEnvironmentVariable("SendGridApiKey");
            var client = new SendGridClient("SG.FtjohDFST5SGkJJIDLJp2w.dWQLSkHMVofand_zLgGGINHcDFnVLU6Q251522aIm8k");
            var from = new EmailAddress("takeiteasytakeiteasy10@gmail.com", "TakeItEasy Bot");
            var subject = "TakeItEasy Notification";
            var to = new EmailAddress("florescurazvan5@gmail.com", "Example User");
            var htmlContent = $@"<pre>Dear {firstName} {lastName},                             
   {message}
Best Regards, 
TakeItEasy Team
<a href='mail.google.com'>email: takeiteasytakeiteasy10@gmail.com</a> </pre>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
