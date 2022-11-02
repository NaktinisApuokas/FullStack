using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Academy.Data.Dtos;
using Academy.Data.Entities;
using Academy.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Controllers
{
    [ApiController]
    [Route("api/cinemas")]
    public class ItemController : ControllerBase
    {
        private readonly ICinemaRepository _CinemaRepository;
        private readonly IMapper _mapper;

        public ItemController(ICinemaRepository CinemaRepository, IMapper mapper)
        {
            _CinemaRepository = CinemaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAll()
        {
            var items = await _CinemaRepository.GetAll();
            return Ok(_mapper.Map<ItemDto>(items));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> Get(int id)
        {
            var cinema = await _CinemaRepository.Get(id);
            if (cinema == null) return NotFound($"Cinema with id '{id}' not found.");

            return Ok(_mapper.Map<ItemDto>(cinema));
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> Post(CreateCinemaDto cinemaDto)
        {
            return Ok("random");
            //var cinema = _mapper.Map<Item>(cinemaDto);

            //await _CinemaRepository.Create(cinema);

            //return Created($"/api/cinemas/{cinema.Id}", _mapper.Map<ItemDto>(cinema));
        }

    }
}
