using Microsoft.AspNetCore.Mvc;
using System_for_sending_e_mail.Database;
using System_for_sending_e_mail.Emails.Models;
using System_for_sending_e_mail.EmailService;
using System_for_sending_e_mail.ViewModels;

namespace System_for_sending_e_mail.Controllers
{
    [Route("notification")]
    public class NotificationController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IEmailSender _emailSender;
        private readonly EmailConfiguration _emailConfiguration;

        public NotificationController(DataContext dataContext, IEmailSender emailSender, EmailConfiguration emailConfiguration)
        {
            _dataContext = dataContext;
            _emailSender = emailSender;
            _emailConfiguration = emailConfiguration;
        }
        #region List

        [HttpGet("/", Name = "notification-list")]
        public IActionResult List()
        {
            var model = _dataContext.Notifications
                .Select(b => new ListViewModel(b.Title, b.FromEmail, $"{b.Email.ToEmail}")).ToList();
            return View("~/Views/Notification/List.cshtml", model);

        }

        #endregion

        #region Add

        [HttpGet("add", Name = "notification-add")]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost("add", Name = "notification-add")]
        public IActionResult Add([FromForm] AddViewModel model)
        {

            //if (!ModelState.IsValid)
            //{
            //    return View("~/Views/Notification/Add.cshtml", model);
            //}




            var notification = new Notification
            {
                FromEmail = _emailConfiguration.From,
                Email = model.Email,
                Title = model.Title,
                Content = model.Content
            };
            _dataContext.Notifications.Add(notification);
            _dataContext.Email.Add(notification.Email);

            var emails = model.Email.ToEmail.Trim().Split(',');

            List<string> emailAdress = new List<string>();


            if (model.EmailBulk == true)
            {
                foreach (var email in emails)
                {
                    emailAdress.Add(email);

                }
            }
            else
            {
                emailAdress.Add(model.Email.ToEmail);

            }
            var message = new Message(emailAdress, model.Title, model.Content);

            _emailSender.SendEmail(message);

            _dataContext.SaveChanges();
            return RedirectToAction(nameof(List));
        }
        #endregion
    }
}
