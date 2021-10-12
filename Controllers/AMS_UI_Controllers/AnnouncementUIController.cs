using AMS_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApartmentManagementSystem.Controllers.AMS_UI_Controllers
{
    public class AnnouncementUIController : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/
        public IActionResult showAllAnnouncement()
        {
            IEnumerable<Announcement> usr = null;
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var us = cln.GetAsync("AnnouncementAPI");
            us.Wait();
            var usd = us.Result;
            if (usd.IsSuccessStatusCode)
            {
                var data = usd.Content.ReadAsAsync<IList<Announcement>>();
                data.Wait();
                usr = data.Result;
            }
            return View(usr);
        }
        public IActionResult insertAnnouncement()
        {
            IEnumerable<Announcement> docs = null;
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var getuser = cln.GetAsync("AnnouncementAPI");
            getuser.Wait();
            var result = getuser.Result;
            if (result.IsSuccessStatusCode)
            {
                var data = result.Content.ReadAsAsync<IEnumerable<Announcement>>();
                data.Wait();
                docs = data.Result;
            }
            return View();
        }
        [HttpPost]
        public IActionResult insertannouncement(Announcement announcementdet)
        {
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var post = cln.PostAsJsonAsync<Announcement>("AnnouncementAPI/", announcementdet);
            post.Wait();
            var res = post.Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("showAllAnnouncement", "AnnouncementUI");
            }
            return View(announcementdet);
        }

    }
}
