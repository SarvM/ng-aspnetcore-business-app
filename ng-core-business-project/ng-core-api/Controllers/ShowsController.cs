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
    [Route("api/tours/{tourId}/shows")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private readonly ITourManagementRepository _tourManagementRepository;
        public ShowsController(ITourManagementRepository tourManagementRepository)
        {
            _tourManagementRepository = tourManagementRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get(string tourId)
        {
            try
            {
                var showsFromRepo = await _tourManagementRepository.GetShows(tourId);
                var shows = Mapper.Map<IEnumerable<Show>>(showsFromRepo);
                return Ok(shows);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return Ok();
        }
    }
}
