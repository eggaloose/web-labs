using AutoMapper;
using FirstWebApi.Bll.Base;
using FirstWebApi.Bll.Components.FilmComponent.Dtos;
using FirstWebApi.Bll.Components.FilmComponent.Entities;
using FirstWebApi.Bll.Components.FilmComponent.Services;
using FirstWebApi.Controllers.Admin.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace FirstWebApi.Controllers.Admin
{
    public class FilmsController : AdminApiController
    {
        private readonly FilmService _filmService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FilmsController(FilmService filmService, ApplicationDbContext context, IMapper mapper)
        {
            _filmService = filmService;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmDto>>> GetFilms()
        {
            var films = await _filmService.GetAllFilmsAsync();
            var filmDtos = _mapper.Map<List<FilmDto>>(films);
            return Ok(filmDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FilmDto>> GetFilm(int id)
        {
            var film = await _filmService.GetFilmByIdAsync(id);
            if (film == null)
            {
                return NotFound();
            }

            var FilmDto = _mapper.Map<FilmDto>(film);
            return Ok(FilmDto);
        }

        [HttpPost]
        public async Task<ActionResult<FilmDto>> CreateFilm(FilmEditDto model)
        {
            var film = await _filmService.AddFilm(model);

            await _context.SaveChangesAsync();

            var FilmDto = _mapper.Map<FilmDto>(film);
            return Ok(FilmDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFilm(int id, FilmEditDto model)
        {
            model.Id = id;

            var film = _filmService.UpdateFilm(model);

            await _context.SaveChangesAsync();

            var FilmDto = _mapper.Map<FilmDto>(film);
            return Ok(FilmDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var deleted = _filmService.DeleteFilm(id);
            if (!deleted)
            {
                return NotFound();
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
