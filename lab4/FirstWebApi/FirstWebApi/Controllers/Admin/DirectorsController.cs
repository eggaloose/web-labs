using AutoMapper;
using FirstWebApi.Bll.Base;
using FirstWebApi.Bll.Components.DirectorComponent.Dtos;
using FirstWebApi.Bll.Components.DirectorComponent.Services;
using FirstWebApi.Controllers.Admin.Base;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers.Admin
{
    public class DirectorsController : AdminApiController
    {
        private readonly DirectorService _directorService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DirectorsController(DirectorService directorService, ApplicationDbContext context, IMapper mapper)
        {
            _directorService = directorService;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectorDto>>> GetDirectors()
        {
            var directors = await _directorService.GetAllDirectorsAsync();
            var directorDtos = _mapper.Map<List<DirectorDto>>(directors);
            return Ok(directorDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorDto>> GetDirector(int id)
        {
            var director = await _directorService.GetDirectorByIdAsync(id);
            if (director == null)
            {
                return NotFound();
            }

            var directorDto = _mapper.Map<DirectorDto>(director);
            return Ok(directorDto);
        }

        [HttpPost]
        public async Task<ActionResult<DirectorDto>> CreateDirector(DirectorEditDto model)
        {
            var director = _directorService.AddDirector(model);

            await _context.SaveChangesAsync();

            var directorDto = _mapper.Map<DirectorDto>(director);
            return Ok(directorDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDirector(int id, DirectorEditDto model)
        {
            model.Id = id;

            var director = _directorService.UpdateDirector(model);

            await _context.SaveChangesAsync();

            var directorDto = _mapper.Map<DirectorDto>(director);
            return Ok(directorDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirector(int id)
        {
            var deleted = _directorService.DeleteDirector(id);
            if (!deleted)
            {
                return NotFound();
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
