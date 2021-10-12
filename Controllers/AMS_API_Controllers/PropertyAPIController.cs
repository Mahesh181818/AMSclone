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
    public class PropertyAPIController : ControllerBase
    {
        private BAL_Property bal;
        public PropertyAPIController(BAL_Property pbal)
        {
            bal = pbal;

        }
        [HttpGet]
        public IActionResult showallpropety()
        {
            return Ok(bal.GetAllProperty());
        }

        [HttpGet("{Pid}")]
        public IActionResult getpropertybyid(int Pid)
        {
            return Ok(bal.GetPropertyById(Pid));
        }

        [HttpPost]
        public IActionResult insertproperty(Property data)
        {
            return Ok(bal.AddPropertyDetails(data));
        }

        [HttpPut]
        public IActionResult updateuserdetails(Property data)
        {
            return Ok(bal.UpdateProperty(data));
        }
        /*  [HttpDelete("{Pid}")]
          public IActionResult deleteproperty(int Pid)
          {
              bal.DeleteProperty(PID);
              return Ok("Property record deleted");
          }*/

    }
}
