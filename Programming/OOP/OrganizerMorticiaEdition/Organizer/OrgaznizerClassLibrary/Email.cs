using OrganizerClassLibrary.Interfaces;
using System;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace OrganizerClassLibrary
{
    public class Email : OrganizerObject, IMail
    {
        //properties
        public string SendTo { get; set; }
        public string Subject { get; set; }
        public string TextBody { get; set; }
        public string FilePath { get; set; }

        //constructor
        public Email(string sendTo, string subject,
            string body, string filePath = @"..\..\..\test.txt", string comment = "")
            : base(comment)
        {
            this.SendTo = sendTo;
            this.Subject = subject;
            this.TextBody = body;
            this.FilePath = filePath;
        }

        //methods
        /// <summary>
        /// Method for creating and sending of Email
        /// </summary>
        /// <param name="from"> Sender of email</param>
        /// <param name="to"> Receiver of email</param>
        /// <param name="subject"> email Subject</param>
        /// <param name="body"> email Body</param>
        /// <param name="filePath"> path to file to be attached</param>
        public void SendEmail()
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            try
            {
                //message parameters
                message.From = new MailAddress("morticia.team@gmail.com", "Morticia Team");
                message.To.Add(new MailAddress(SendTo, "Display name To"));
                message.Subject = Subject;
                message.IsBodyHtml = true;
                message.Body = TextBody;

                //format for Path => "D:\\test.txt"
                if (string.IsNullOrEmpty(FilePath))
                {
                    this.FilePath = @"..\..\..\test.txt";
                }
                FileStream fileStream = new FileStream(FilePath,
                                   FileMode.Open, FileAccess.Read);
                Attachment attachment = new Attachment(fileStream, Path.GetFileName(FilePath),
                                   MediaTypeNames.Application.Octet);
                message.Attachments.Add(attachment);

                //smtp host parameters
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.Credentials = new
                    System.Net.NetworkCredential("morticia.team@gmail.com", "telerik.team");
                smtpClient.EnableSsl = true;
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new OrganizerException("Something went wrong!");
            }
        }

        //overriding methods
        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine("Receiver : " + SendTo);
            buffer.AppendLine("Subject : " + Subject);
            buffer.AppendLine("Path of attached file : " + FilePath);
            buffer.AppendLine("Body : " + TextBody);

            return buffer.ToString();
        }
    }
}

