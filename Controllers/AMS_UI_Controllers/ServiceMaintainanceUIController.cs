using AMS_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApartmentManagementSystem.Controllers.AMS_UI_Controllers
{
    public class ServiceMaintainanceUIController : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/
        public IActionResult showservicedetails()
        {
            IEnumerable<ServiceMaintanence> src = null;
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var us = cln.GetAsync("ServiceMaintainanceAPI");
            us.Wait();
            var usd = us.Result;
            if (usd.IsSuccessStatusCode)
            {
                var data = usd.Content.ReadAsAsync<IList<ServiceMaintanence>>();
                data.Wait();
                src = data.Result;
            }
            return View(src);
        }
        public IActionResult showservicedetailstoCustomer()
        {
            IEnumerable<ServiceMaintanence> src = null;
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var us = cln.GetAsync("ServiceMaintainanceAPI");
            us.Wait();
            var usd = us.Result;
            if (usd.IsSuccessStatusCode)
            {
                var data = usd.Content.ReadAsAsync<IList<ServiceMaintanence>>();
                data.Wait();
                src = data.Result;
            }
            return View(src);
        }

        [HttpGet]
        public IActionResult ServiceMaintenanceDetails(string Srno)
        {
            ServiceMaintanence flight = null;
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var getflight = cln.GetAsync("ServiceMaintainanceAPI/" + Srno);
            getflight.Wait();

            var res = getflight.Result;
            if (res.IsSuccessStatusCode)
            {
                var dat = res.Content.ReadAsAsync<ServiceMaintanence>();
                dat.Wait();
                flight = dat.Result;
            }
            return View(flight);
        }
        public IActionResult insertservicemaintenance()
        {
            IEnumerable<ServiceMaintanence> docs = null;
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var getuser = cln.GetAsync("ServiceMaintainanceAPI");
            getuser.Wait();
            var result = getuser.Result;
            if (result.IsSuccessStatusCode)
            {
                var data = result.Content.ReadAsAsync<IEnumerable<ServiceMaintanence>>();
                data.Wait();
                docs = data.Result;
            }
            return View();
        }
        [HttpPost]
        public IActionResult insertserviceMaintenance(ServiceMaintanence servicedet)
        {
            //send_email(userdet.UserName, userdet.EmailId);// to get the details from the user and pass it on to the send_email method
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var post = cln.PostAsJsonAsync<ServiceMaintanence>("ServiceMaintainanceAPI/", servicedet);
            post.Wait();
            var res = post.Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("showservicedetails", "ServiceMaintainanceUI");
            }
            return View(servicedet);
        }
        [HttpGet]
        public IActionResult EditServiceMaintainance(string Srno)
        {
            ServiceMaintanence flight = null;
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var getflight = cln.GetAsync("ServiceMaintainanceAPI/" + Srno);
            getflight.Wait();

            var res = getflight.Result;
            if (res.IsSuccessStatusCode)
            {
                var dat = res.Content.ReadAsAsync<ServiceMaintanence>();
                dat.Wait();
                flight = dat.Result;
            }
            return View(flight);
        }
        [HttpPost]
        public IActionResult EditServiceMaintainance(ServiceMaintanence prop)
        {
            var cln = new HttpClient();
            cln.BaseAddress = new Uri("https://localhost:44389/api/");
            var updateflight = cln.PutAsJsonAsync<ServiceMaintanence>("ServiceMaintainanceAPI", prop);
            updateflight.Wait();

            var res = updateflight.Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("showservicedetails");
            }
            return RedirectToAction("EditProperty");
        }
    }
}
