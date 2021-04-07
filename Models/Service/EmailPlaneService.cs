using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BusFor.Models.DataModel;
namespace BusFor.Models.Service
{
    public class EmailPlaneService
    {
        public async Task SendEmailAsync(PlanePassenger passenger, PlaneInfo planeInfo)
        {
            MailMessage mm = new MailMessage("irakardinal@gmail.com", passenger.Email);
            mm.Subject = "Plane Ticket";
            mm.Body = BodyHtmlText(passenger, planeInfo);
            mm.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("irakardinal@gmail.com", "sasha60327");
            //smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
        }
        public string BodyHtmlText(PlanePassenger passenger, PlaneInfo planeInfo)
        {
            StringBuilder text = new StringBuilder();
            text.Append("<html>")
               .Append("<head>")
               .Append("</head>")
               .Append("<body>");
            text.Append("<div class=\"row\">")
                         .Append("<div class=\"col\">")
                             .Append("<h3>" + planeInfo.Time1 + " " + planeInfo.Date1.ToShortDateString() + "</h3>")
                             .Append("<h3>" + planeInfo.Location1 + "</h3>")
                         .Append("</div>")
                         .Append("<div class=\"col\">")
                             .Append("<h3>" + planeInfo.Time2 + " " + planeInfo.Date2.ToShortDateString() + "</h3>")
                             .Append("<h3>" + planeInfo.Location2 + "</h3>")
                         .Append("</div>");
            text.Append("</div>");
            text.Append("<div class=\"col\">")
                        .Append("<h3>" + passenger.Name + " " + passenger.Surname + "</h3>")
                        .Append("<h3> Place : " + passenger.IntPlace + " " + passenger.StringPlace + "</h3>")
                    .Append("</div>");
            if(passenger.Mode=="B")
            {
                text.Append("<div class=\"col\">")
                    .Append("<h3> Price : " + planeInfo.BusinessPrice + " UAN</h3>")
                .Append("</div>");
            }
            else
            if (passenger.Mode == "E")
            {
                text.Append("<div class=\"col\">")
                    .Append("<h3> Price : " + planeInfo.EconomPrice + " UAN</h3>")
                .Append("</div>");
            }

            text.Append("</body>")
               .Append("</html>");
            return text.ToString();
        }
    }
}
