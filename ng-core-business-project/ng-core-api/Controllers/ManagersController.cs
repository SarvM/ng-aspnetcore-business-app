using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ng_core_api.Services;
using AutoMapper;
using ng_core_api.Dtos;
using System.Diagnostics;

namespace ng_core_api.Controllers
{
    [Route("api/managers")]
    [ApiController]
    public class ManagersController : ControllerBase
    {

        private readonly ITourManagementRepository _tourManagementRepository;

        public ManagersController(ITourManagementRepository tourManagementRepository)
        {
            _tourManagementRepository = tourManagementRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var managersFromRepo = await _tourManagementRepository.GetManagers();
                var managers = Mapper.Map<IEnumerable<Manager>>(managersFromRepo);
                return Ok(managers);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return Ok();
        }

    }
}
