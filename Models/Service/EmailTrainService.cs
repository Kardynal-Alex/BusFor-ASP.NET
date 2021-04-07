using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BusFor.Models.DataModel;
namespace BusFor.Models.Service
{
    public class EmailTrainService
    {
        public async Task SendEmailAsync(TrainPassenger passenger, TrainInfo trainInfo)
        {
            MailMessage mm = new MailMessage("irakardinal@gmail.com", passenger.Email);
            mm.Subject = "Train Ticket";
            mm.Body = BodyHtmlText(passenger, trainInfo);
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
        public string BodyHtmlText(TrainPassenger passenger, TrainInfo trainInfo)
        {
            StringBuilder text = new StringBuilder();
            text.Append("<html>")
               .Append("<head>")
               .Append("</head>")
               .Append("<body>");
            text.Append("<div class=\"text-center\">");
            if(passenger.Mode=="P")
            {
                text.Append("<h2>PlatzKarte</h2>");
            }else
            {
                text.Append("<h2>Coupe</h2>");
            }
            text.Append("</div>");
            text.Append("<div class=\"row\">")
                         .Append("<div class=\"col\">")
                             .Append("<h3>" + trainInfo.Time1 + " " + trainInfo.Date1.ToShortDateString() + "</h3>")
                             .Append("<h3>" + trainInfo.Location1 + "</h3>")
                         .Append("</div>")
                         .Append("<div class=\"col\">")
                             .Append("<h3>" + trainInfo.Time2 + " " + trainInfo.Date2.ToShortDateString() + "</h3>")
                             .Append("<h3>" + trainInfo.Location2 + "</h3>")
                         .Append("</div>");
            text.Append("</div>");
            text.Append("<div class=\"col\">")
                        .Append("<h3>" + passenger.Name + " " + passenger.Surname + "</h3>")
                        .Append("<h3>Van : " + passenger.Van + " Place : " + passenger.Place + "</h3>")
                    .Append("</div>");

            if(passenger.IsPostel==true && passenger.Mode=="P")
            {
                text.Append("<h3> Price : " + trainInfo.PlatzKartePrice + " UAN</h3>")
                    .Append("<h3> Postel + 50 UAN</h3>")
                    .Append("<h3> Total Price : " + (trainInfo.PlatzKartePrice + 50) + " UAN</h3>");
            }
            else
            if(passenger.IsPostel == false && passenger.Mode == "P")
            {
                text.Append("<h3> Price : " + trainInfo.PlatzKartePrice + " UAN</h3>");
            }
            else
            if (passenger.IsPostel == true && passenger.Mode == "C")
            {
                text.Append("<h3> Price : " + trainInfo.CoupePrice + " UAN</h3>")
                    .Append("<h3> Postel + 50 UAN</h3>")
                    .Append("<h3> Total Price : " + (trainInfo.CoupePrice + 50) + " UAN</h3>");
            }
            else
            if (passenger.IsPostel == false && passenger.Mode == "C")
            {
                text.Append("<h3> Price : " + trainInfo.CoupePrice + " UAN</h3>");
            }

            text.Append("</body>")
               .Append("</html>");
            return text.ToString();
        }
    }
}
