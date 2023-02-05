using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Tonus.Models;
using Umbraco.Web.Mvc;

public class ContactFormController : Umbraco.Web.Mvc.SurfaceController 
{
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SendEmail(ContactFormModel model, string recieverEmail)
    {
        //Check if the dat posted is valid (All required's & email set in email field)
        if (!ModelState.IsValid)
        {
            //Not valid - so lets return the user back to the view with the data they entered still prepopulated
            return CurrentUmbracoPage();
        }

        //Generate an email message object to send
        MailMessage email = new MailMessage("tonusmedcentre@gmail.com", recieverEmail);
        email.Subject = "ТОНУС: Съобщение от " + model.Name + ".";
        email.Body = model.Message;

        try
        {
            //Connect to SMTP credentials set in web.config
            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
            Credentials = new NetworkCredential("tonusmedcentre@gmail.com", "tonusmedmh"),
            EnableSsl = true
        };
            //Try & send the email with the SMTP settings
            smtp.Send(email);
        }
        catch (Exception ex)
        {
            //Throw an exception if there is a problem sending the email
            ViewBag.EmailMessage = "Грешка! Съобщението не е изпратено.";
            throw ex;
        }


        //Update success flag (in a TempData key)
        TempData["IsSuccessful"] = true;
        TempData["EmailMessage"] = "Съобщението е изпратено!";

        //All done - lets redirect to the current page & show our thanks/success message
        return RedirectToCurrentUmbracoPage();
    }
}
