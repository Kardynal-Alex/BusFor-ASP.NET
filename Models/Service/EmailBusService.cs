using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Text;
using BusFor.Models.DataModel;
namespace BusFor.Models.Service
{
    public class EmailBusService
    {
        public async Task SendEmailAsync(Passenger passenger)
        {
            MailMessage mm = new MailMessage("alexandrkardinal@gmail.com",passenger.Email);
            mm.Subject = "Bus Ticket";
            mm.Body = "test"; //BodyHtmlText(passenger);
            mm.IsBodyHtml = false;
            mm.Priority = MailPriority.High;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("alexandrkardinal@gmail.com", "alex60327");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
        }
        public string BodyHtmlText(Passenger passenger)
        {
            StringBuilder text = new StringBuilder();
            text.Append("3456");
            return text.ToString();
        }
    }
}
