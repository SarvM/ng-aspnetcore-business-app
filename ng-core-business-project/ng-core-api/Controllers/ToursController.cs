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
    [Route("api/tours")]
    [ApiController]
    public class ToursController : ControllerBase
    {

        private readonly ITourManagementRepository _tourManagementRepository;

        public ToursController(ITourManagementRepository tourManagementRepository)
        {
            _tourManagementRepository = tourManagementRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var toursFromRepo = await _tourManagementRepository.GetTours();
                var tours = Mapper.Map<IEnumerable<Tour>>(toursFromRepo);
                return Ok(tours);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return Ok();
        }

        [HttpGet("{tourId}")]
        public async Task<IActionResult> Get(string tourId)
        {
            try
            {
                var tourFromRepo = await _tourManagementRepository.GetTour(tourId);
                var tour = Mapper.Map<Tour>(tourFromRepo);
                return Ok(tour);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
            return Ok();
        }

    }
}
