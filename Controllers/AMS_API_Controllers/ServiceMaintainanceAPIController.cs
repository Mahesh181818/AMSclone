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
    public class ServiceMaintainanceAPIController : ControllerBase
    {
        private BAL_ServiceMaintainance serbal;
        public ServiceMaintainanceAPIController(BAL_ServiceMaintainance service)
        {
            serbal = service;
        }
        [HttpGet]
        public IActionResult getalluser()
        {
            return Ok(serbal.GetAllServices());
        }
        [HttpGet("{Srno}")]
        public IActionResult getServiceById(int Srno)
        {
            return Ok(serbal.GetServiceById(Srno));
        }
        [HttpPost]
        public IActionResult insertuserdetails(ServiceMaintanence data)
        {
            return Ok(serbal.AddServiceMaintenance(data));
        }
        [HttpPut]
        public IActionResult updatepropertydetails(ServiceMaintanence data)
        {
            return Ok(serbal.UpdateService(data));
        }
    }
}
