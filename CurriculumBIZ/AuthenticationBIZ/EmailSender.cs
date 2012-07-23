using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace CurriculumBIZ.AuthenticationBIZ
{
    public class EmailSender
    {
        public static string From = "elevation88@hotmail.it";
        public static string Smtp = "smtp.live.com";
        public static string Pop = "pop3.live.com";
        public static string Pass = "*********";
        public static int PopPort = 995;
        public static int SmtpPort = 25;
        public string To { get; set; }
        public string Subject{get; set;}
        public string Body { get; set; }

        public static bool Send(EmailSender EmailCopy)
        {
            MailMessage Email = new MailMessage(From,EmailCopy.To); //inserisco from e to
            Email.Body = EmailCopy.Body; // imposto il corpo del msg
            Email.Subject = EmailCopy.Subject; // imposto il titolo mail
            
            SmtpClient smtp = new SmtpClient();

            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(From, Pass);
            try
            {
                smtp.Send(Email);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public void CreateEmailMessage(string Subject, string Body,string To)
        {
            this.Subject = Subject;
            this.Body = Body;
            this.To = To;
        }

        public static string RegistrationBody( string username, string email)
        {
            String Message = "<h2><p>Grazie " + username + " per esserti registrato!</p></h2>"+"</ br> <p>La tua nuova password è ABCDE</p><p>Se questa non è la tua mail non considerare il messaggio</p>";
            return Message;
        }

        public static string RegistrationSubject()
        {
            return "Registrazione a CV APPLICATION";
        }
    }
}
