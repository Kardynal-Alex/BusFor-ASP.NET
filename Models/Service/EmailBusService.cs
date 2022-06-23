using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Text;
using BusFor.Models.DataModel;
namespace BusFor.Models.Service
{
    public class EmailBusService
    {
        public async Task SendEmailAsync(Passenger passenger,BusInfo busInfo)
        {
            MailMessage mm = new MailMessage("email", passenger.Email);
            mm.Subject = "Bus Ticket";
            mm.Body = BodyHtmlText(passenger,busInfo);
            mm.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("email", "password");
            //smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
        }
        public string BodyHtmlText(Passenger passenger, BusInfo busInfo)
        {
            StringBuilder text = new StringBuilder();
            text.Append("<html>")
               .Append("<head>")
               .Append("</head>")
               .Append("<body>");
           text.Append("<div class=\"row\">")
                        .Append("<div class=\"col\">")
                            .Append("<h3>" + busInfo.Time1 + " " + busInfo.Date1.ToShortDateString() + "</h3>")
                            .Append("<h3>" + busInfo.Location1 + "</h3>")
                        .Append("</div>")
                        .Append("<div class=\"col\">")
                            .Append("<h3>" + busInfo.Time2 + " " + busInfo.Date2.ToShortDateString() + "</h3>")
                            .Append("<h3>" + busInfo.Location2 + "</h3>")
                        .Append("</div>");
            text.Append("</div>");
            text.Append("<div class=\"col\">")
                        .Append("<h3>" + passenger.Name + " " + passenger.Surname + "</h3>")
                        .Append("<h3> Place : " + passenger.Place + "</h3>")
                        .Append("<h3> Price : " + busInfo.Price + " UAN </h3>")
                    .Append("</div>");

            text.Append("</body>")
               .Append("</html>");
            return text.ToString();
        }
    }
}
