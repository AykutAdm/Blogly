using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace PresentationLayer.Controllers
{
    public class MessageController : Controller
    {

        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();

        public IActionResult InBox()
        {

            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerID);
            return View(values);
        }

        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var values = mm.GetSendBoxListByWriter(writerID);
            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
            var values = mm.TGetById(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {

            List<SelectListItem> recieverUsers = GetUsers()
                .Select(x => new SelectListItem
                {
                    Text = x.Email,
                    Value = x.Id.ToString()
                }).ToList();

            ViewBag.RecieverUser = recieverUsers;
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message2 p)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            p.SenderId = writerID;
            p.ReceiverId = 3;
            p.MessageStatus = true;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm.TAdd(p);
            return RedirectToAction("Inbox");
        }
        //sonradan ekledim aşağıdaki kodu normalde burda olmaması gerekiyor. Gönderici bilgisi çekmek için
        public List<AppUser> GetUsers()
        {
            using (var context = new Context())
            {
                return context.Users.ToList();
            }
        }

    }
}
