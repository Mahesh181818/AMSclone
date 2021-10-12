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
    public class ComplaintAPIController : ControllerBase
    {
        private BAL_Complaint bal;
        public ComplaintAPIController(BAL_Complaint cbal)
        {
            bal = cbal;

        }
        [HttpGet]
        public IActionResult getalluser()
        {
            return Ok(bal.GetComplaintDetails());

        }

        [HttpGet("{Cid}")]
        public IActionResult getComplaintById(int Cid)
        {
            return Ok(bal.GetComplaintByID(Cid));
        }

        [HttpPost]
        public IActionResult insertproperty(Complaint data)
        {
            return Ok(bal.AddComplaint(data));
        }
        [HttpPut]
        public IActionResult updateComplaint(Complaint data)
        {
            return Ok(bal.UpdateComplaint(data));
        }
        /* [HttpDelete("{Cid}")]
         public IActionResult deleteComplaint(int Cid)
         {
             bal.DeleteComplaint(Cid);
             return Ok("Complaint deleted");
         }*/
    }
}
