using AMS_BAL;
using AMS_Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagementSystem.Controllers.AMS_API_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementAPIController : ControllerBase
    {
        private BAL_Announcement ac_bal;
        public AnnouncementAPIController(BAL_Announcement announcement)
        {
            ac_bal = announcement;
        }
        [HttpGet]
        public IActionResult getallannouncement()
        {
            return Ok(ac_bal.GetAnnouncements());
        }
        [HttpPost]
        public IActionResult insertuserdetails(Announcement data)
        {
            return Ok(ac_bal.AddAnnouncement(data));
        }
    }
}
