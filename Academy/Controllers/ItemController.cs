using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Academy.Data.Dtos;
using Academy.Data.Entities;
using Academy.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace Academy.Controllers
{
    [EnableCors]
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
        public async Task<IEnumerable<ItemDto>> Get()
        {
            return (await _CinemaRepository.Get()).Select(o => _mapper.Map<ItemDto>(o));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> Get(int id)
        {
            var cinema = await _CinemaRepository.Get(id);
            if (cinema == null) return NotFound($"Cinema with id '{id}' not found.");

            return Ok(_mapper.Map<ItemDto>(cinema));
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> Post(AddItemDto cinemaDto)
        {
            var cinema = _mapper.Map<Item>(cinemaDto);

            await _CinemaRepository.Create(cinema);

            return Created($"/api/cinemas/{cinema.Id}", _mapper.Map<ItemDto>(cinema));
        }

    }
}
