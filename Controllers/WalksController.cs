using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
using NZWalks.Repositories;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalksRepository _walksRepository;
        private readonly IMapper mapper;

        public WalksController(IWalksRepository walksRepository, IMapper mapper) 
        {
            this._walksRepository = walksRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FormQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending)
        {
            var walksDomain = await _walksRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true);

            return Ok(mapper.Map<List<WalksDto>>(walksDomain));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid Id)
        {
            var walkDomain = await _walksRepository.GetOneAsync(Id);

            return Ok(mapper.Map<Walk>(walkDomain));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequest addWalkRequest)
        {
            var walkDomain = mapper.Map<Walk>(addWalkRequest);

            await _walksRepository.CreateAsync(walkDomain);

            var walkDto = mapper.Map<WalksDto>(walkDomain);

            return CreatedAtAction(nameof(GetOne), new { id = walkDto.Id }, walkDto);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWlakRequest updateWalkRequest)
        {
            var walkDomain = mapper.Map<Walk>(updateWalkRequest);

            walkDomain = await _walksRepository.UpdtaeAsync(id, walkDomain);

            var walkDto = mapper.Map<Walk>(walkDomain);

            return Ok(walkDto);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomain = await _walksRepository.DeleteAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
