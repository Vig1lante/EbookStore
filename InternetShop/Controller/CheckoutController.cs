using InternetShop.Model;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
// Class for exporting checkout summary to user email [draft version: stable]
namespace InternetShop.Controller {
    public class CheckoutController {

        public DbEntities Ctx { get; set; }

        public CheckoutController(DbEntities ctx) => Ctx = ctx;
        
        public void SendVerification(User user) {
            try {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("codetestcc@gmail.com");
                mail.To.Add($"{user.Email}");
                // Order number in mail subject
                mail.Subject = "HALU HALU";
                // Pack order details into pdf and add as attachment
                mail.Body = "ALAKAZAM, IT'S MAGIC!";
                // Port check, not 456?? TLS gmail smtp connection
                SmtpServer.EnableSsl = true;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("codetestcc@gmail.com", "Codecool2019");

                SmtpServer.Send(mail);
                Console.WriteLine("Order has been confirmed, " +
                    "details have been sent to your email account!" +
                    "\nThank you for shopping!");
            }
            catch (Exception) {
                Console.WriteLine("Oops, something went wrong.." +
                    "perhaps your email address is incorrect?");
            }
        }
    }
}
       