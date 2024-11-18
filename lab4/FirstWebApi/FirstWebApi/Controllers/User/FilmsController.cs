using AutoMapper;
using FirstWebApi.Bll.Base;
using FirstWebApi.Bll.Components.FilmComponent.Dtos;
using FirstWebApi.Bll.Components.FilmComponent.Services;
using FirstWebApi.Controllers.User.Base;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers.User
{
    public class FilmsController : UserApiController
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
    }
}
