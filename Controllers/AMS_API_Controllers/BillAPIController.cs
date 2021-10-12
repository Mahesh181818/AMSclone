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
    public class BillAPIController : ControllerBase
    {
        private BAL_Bill bal;
        public BillAPIController(BAL_Bill bill_bal)
        {
            bal = bill_bal;
        }
        [HttpGet]
        public IActionResult getalluser()
        {
            return Ok(bal.GetAllUserBill());
        }
        [HttpGet("{BillId}")]
        public IActionResult getuserbyid(int BillId)
        {
            return Ok(bal.ShowBillById(BillId));
        }
        [HttpPost]
        public IActionResult insertuserdetails(Bill data)
        {
            return Ok(bal.AddUserBillDetails(data));
        }
    }
}
