﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Organization.Core.DTOs;
using Organization.Core.Entity;
using Organization.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Organization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;
        public PositionController(IPositionService positionService, IMapper mapper)
        {
            _positionService = positionService;
            _mapper = mapper;
        }
        // GET: api/<PositionController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> Get()
        {
            var list = await _positionService.GetAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Position>> Get(int id)
        {
            var position = await _positionService.GetAsync(id);
            return Ok(position);
        }

        // POST api/<PositionController>
        [HttpPost]
        public async Task<ActionResult<Position>> Post([FromBody] Position value)
        {
            var position = _mapper.Map<Position>(value);
            await _positionService.PostAsync(position);
            var positionDto = _mapper.Map<PositionDto>(position);
            return Ok(positionDto);
        }

        // PUT api/<PositionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Position value)
        {
            ActionResult<Position> existPosition = await _positionService.GetAsync(id);

            if (existPosition.Value is null)
            {
                return NotFound();
            }
            _mapper.Map(value, existPosition);

            await _positionService.PutAsync(id, existPosition.Value);

            return Ok(_mapper.Map<PositionDto>(existPosition));
        }

        // DELETE api/<PositionController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _positionService.DeleteAsync(id);
        }
    }
}
