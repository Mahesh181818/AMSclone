using AMS_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApartmentManagementSystem.Controllers.AMS_UI_Controllers
{
    public class ComplaintUIController : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/

        public IActionResult showAllComplaintDetails()
        {
            IEnumerable<Complaint> com = null;
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var us = cln.GetAsync("ComplaintAPI");
            us.Wait();
            var usd = us.Result;
            if (usd.IsSuccessStatusCode)
            {
                var data = usd.Content.ReadAsAsync<IList<Complaint>>();
                data.Wait();
                com = data.Result;
            }
            return View(com);
        }
        public IActionResult ShowComplaintById(int Cid)
        {
            Complaint com = null;
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var getusrID = cln.GetAsync("ComplaintAPI/" + Cid);
            getusrID.Wait();
            var result = getusrID.Result;
            if (result.IsSuccessStatusCode)
            {
                var data = result.Content.ReadAsAsync<Complaint>();
                data.Wait();
                com = data.Result;
            }
            return View(com);
        }
        public IActionResult insertComplaintDetails()
        {
            IEnumerable<Complaint> docs = null;
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var getuser = cln.GetAsync("ComplaintAPI");
            getuser.Wait();
            var result = getuser.Result;
            if (result.IsSuccessStatusCode)
            {
                var data = result.Content.ReadAsAsync<IEnumerable<Complaint>>();
                data.Wait();
                docs = data.Result;

            }
            return View();
        }
        [HttpPost]
        public IActionResult insertComplaintDetails(Complaint complaintdet)
        {
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var post = cln.PostAsJsonAsync<Complaint>("ComplaintAPI/", complaintdet);
            post.Wait();
            var res = post.Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("CustomerMenuLandingPage","Home");
            }
            return View(complaintdet);
        }

        [HttpGet]
        public IActionResult EditComplaint(string Cid)
        {
            Complaint flight = null;
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var getflight = cln.GetAsync("ComplaintAPI/" + Cid);
            getflight.Wait();

            var res = getflight.Result;
            if (res.IsSuccessStatusCode)
            {
                var dat = res.Content.ReadAsAsync<Complaint>();
                dat.Wait();
                flight = dat.Result;
            }
            return View(flight);
        }
        [HttpPost]
        public IActionResult EditComplaint(Complaint complaintdet)
        {
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var updateflight = cln.PutAsJsonAsync<Complaint>("ComplaintAPI", complaintdet);
            updateflight.Wait();

            var res = updateflight.Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("showAllComplaintDetails");
            }
            return RedirectToAction("Index");
        }

    }
}
