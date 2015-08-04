using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            TryValidateModel(contact);
            return View(contact);
        }

        public ActionResult Angular()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Angular(Contact contact)
        {
            TryValidateModel(contact);
            return View(contact);
        }
    }
}