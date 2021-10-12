using AMS_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApartmentManagementSystem.Controllers.AMS_UI_Controllers
{
    public class PropertyUIController : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/
        public IActionResult showPropertyDetails()
        {
            IEnumerable<Property> usr = null;
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var us = cln.GetAsync("PropertyAPI");
            us.Wait();
            var usd = us.Result;
            if (usd.IsSuccessStatusCode)
            {
                var data = usd.Content.ReadAsAsync<IList<Property>>();
                data.Wait();
                usr = data.Result;
            }
            return View(usr);
        }
        public IActionResult showPropertyDetailstoCustomer()
        {
            IEnumerable<Property> usr = null;
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var us = cln.GetAsync("PropertyAPI");
            us.Wait();
            var usd = us.Result;
            if (usd.IsSuccessStatusCode)
            {
                var data = usd.Content.ReadAsAsync<IList<Property>>();
                data.Wait();
                usr = data.Result;
            }
            return View(usr);
        }

        [HttpGet]
        public IActionResult PropertyDetails(string Pid)
        {
            Property flight = null;
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var getflight = cln.GetAsync("PropertyAPI/" + Pid);
            getflight.Wait();

            var res = getflight.Result;
            if (res.IsSuccessStatusCode)
            {
                var dat = res.Content.ReadAsAsync<Property>();
                dat.Wait();
                flight = dat.Result;
            }
            return View(flight);
        }
        public IActionResult insertproperty()
        {
            IEnumerable<Property> docs = null;
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var getuser = cln.GetAsync("PropertyAPI");
            getuser.Wait();
            var result = getuser.Result;
            if (result.IsSuccessStatusCode)
            {
                var data = result.Content.ReadAsAsync<IEnumerable<Property>>();
                data.Wait();
                docs = data.Result;
            }
            return View();
        }
        [HttpPost]
        public IActionResult insertproperty(Property prodet)
        {
            //send_email(userdet.UserName, userdet.EmailId);// to get the details from the user and pass it on to the send_email method
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var post = cln.PostAsJsonAsync<Property>("PropertyAPI/", prodet);
            post.Wait();
            var res = post.Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("showPropertyDetails", "PropertyUI");
            }
            return View(prodet);
        }


        [HttpGet]
        public IActionResult EditProperty(string Pid)
        {
            Property flight = null;
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var getflight = cln.GetAsync("PropertyAPI/" + Pid);
            getflight.Wait();

            var res = getflight.Result;
            if (res.IsSuccessStatusCode)
            {
                var dat = res.Content.ReadAsAsync<Property>();
                dat.Wait();
                flight = dat.Result;
            }
            return View(flight);
        }
        [HttpPost]
        public IActionResult EditProperty(Property prop)
        {
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var updateflight = cln.PutAsJsonAsync<Property>("PropertyAPI", prop);
            updateflight.Wait();

            var res = updateflight.Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("showPropertyDetails");
            }
            return RedirectToAction("EditProperty");
        }
    }
}
