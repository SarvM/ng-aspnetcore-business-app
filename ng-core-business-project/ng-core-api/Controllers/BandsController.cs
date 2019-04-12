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
    [Route("api/bands")]
    [ApiController]
    public class BandsController : ControllerBase
    {
        private readonly ITourManagementRepository _tourManagementRepository;

        public BandsController(ITourManagementRepository tourManagementRepository)
        {
            _tourManagementRepository = tourManagementRepository;
        }
        // GET: api/Bands
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try{
                var bandsFromRepo = await _tourManagementRepository.GetBands();
                var bands = Mapper.Map<IEnumerable<Band>>(bandsFromRepo);
                return Ok(bands);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);

            }

            // Should be a failure response;
            return BadRequest();
        }

        
    }
}
