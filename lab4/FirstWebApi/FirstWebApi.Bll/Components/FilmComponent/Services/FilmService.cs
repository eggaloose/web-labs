using FirstWebApi.Bll.Base;
using FirstWebApi.Bll.Components.FilmComponent.Dtos;
using FirstWebApi.Bll.Components.FilmComponent.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWebApi.Bll.Components.FilmComponent.Services
{
    public class FilmService
    {
        private readonly ApplicationDbContext _context;

        public FilmService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Film>> GetAllFilmsAsync()
        {
            return await _context.Films.Include(f => f.Director).ToListAsync();
        }

        public async Task<Film?> GetFilmByIdAsync(int id)
        {
            return await _context.Films.Include(f => f.Director).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Film> AddFilm(FilmEditDto model)
        {
            var directorRef = await _context.Directors.Include(d => d.films).FirstOrDefaultAsync(d => d.Id == model.DirectorId);

            if (directorRef == null)
            {
                throw new Exception("Director not found");
            }

            var film = new Film
            {
                Title = model.Title,
                DirectorId = model.DirectorId,
                Description = model.Description
            };

            _context.Add(film);
            return film;

        } 

        public Film UpdateFilm(FilmEditDto film)
        {
            var existingFilm = _context.Films.Find(film.Id);
            if (existingFilm == null)
            {
                throw new Exception("Film not found");
            }

            existingFilm.Title = film.Title;
            existingFilm.Description = film.Description;
            existingFilm.DirectorId = film.DirectorId;

            return existingFilm;
        }

        public bool DeleteFilm(int id)
        {
            var film = _context.Films.Find(id);
            if (film == null)
            {
                throw new Exception("Film not found");
            }

            _context.Films.Remove(film);
            return true;
        }
    }
}
