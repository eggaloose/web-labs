using FirstWebApi.Bll.Base;
using FirstWebApi.Bll.Components.DirectorComponent.Dtos;
using FirstWebApi.Bll.Components.DirectorComponent.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApi.Bll.Components.DirectorComponent.Services
{
    public class DirectorService
    {
        private readonly ApplicationDbContext _context;

        public DirectorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Director>> GetAllDirectorsAsync()
        {
            return await _context.Directors.Include(d => d.films).ToListAsync();
        }

        public async Task<Director?> GetDirectorByIdAsync(int id)
        {
            return await _context.Directors.Include(d => d.films).FirstOrDefaultAsync(d => d.Id == id);
        }

        public Director AddDirector(DirectorEditDto model)
        {
            var director = new Director
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            _context.Directors.Add(director);
            return director;
        }

        public Director UpdateDirector(DirectorEditDto model)
        {
            var existingDirector = _context.Directors.Find(model.Id);
            if (existingDirector == null)
            {
                throw new Exception("Director not found");
            }

            existingDirector.FirstName = model.FirstName;
            existingDirector.LastName = model.LastName;
            return existingDirector;
        }

        public bool DeleteDirector(int id)
        {
            var director = _context.Directors.Find(id);
            if (director == null)
            {
                throw new Exception("Category not found");
            }

            _context.Directors.Remove(director);
            return true;
        }
    }
}
