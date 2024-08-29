using MZM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MZM.Controllers
{
    public class ContactController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        // POST: Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.CreatedDate = DateTime.Now;
                db.Contacts.Add(contact);
                db.SaveChanges();

                // Send email to admin
                SendEmailToAdmin(contact);

                ViewBag.Message = "Your message has been sent!";
                ModelState.Clear();
            }
            return View();
        }
        private void SendEmailToAdmin(Contact contact)
        {
            // SMTP server settings
            string smtpHost = "smtp.gmail.com";
            int smtpPort = 587; // or 25, 465, depending on your server
            string smtpUser = "megazonewebsite@gmail.com";
            string smtpPassword = "thdudsrhinzwbbcb"; 
            string fromAddress = "megazonewebsite@gmail.com";
            string toAddress = "admin@megazone.fm";

            // Create a new MailMessage object
            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromAddress),
                Subject = $"New Contact Request by {contact.Name}",
                Body = $"Name: {contact.Name}\nEmail: {contact.Email}\nMessage: {contact.Message}",
                IsBodyHtml = false
            };

            // Add recipient
            mailMessage.To.Add(toAddress);

            // Configure SMTP client
            using (var smtpClient = new SmtpClient(smtpHost, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(smtpUser, smtpPassword);
                smtpClient.EnableSsl = true; // Set to false if your server doesn't support SSL

                try
                {
                    smtpClient.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    // Log exception (you can also use a logging framework here)
                    // For example: Log.Error("Error sending email", ex);
                }
            }
        }
    }
}