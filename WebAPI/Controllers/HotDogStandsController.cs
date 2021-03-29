using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebAPI.Entities;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/stands")]
    public class HotDogStandsController : ControllerBase
    {
        private readonly IHotDogStandService _standService;

        public HotDogStandsController(IHotDogStandService standService)
        {
            _standService = standService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HotDogStand>> GetStands()
        {
            return _standService.GetStands();
        }

        [HttpGet("{id}")]
        public ActionResult<HotDogStand> GetStandById(Guid id)
        {
            return _standService.GetStandById(id);
        }

        [HttpPost]
        public ActionResult CreateNewStand(HotDogStand stand)
        {
            _standService.CreateStand(stand);
            return CreatedAtAction("GetStandById", new { id = stand.Id }, stand);
        }

        [HttpPut]
        public ActionResult UpdateStand(HotDogStand stand)
        {
            _standService.UpdateStand(stand);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult RemoveStand(HotDogStand stand)
        {
            _standService.RemoveStand(stand);
            return NoContent();
        }

    }
}
