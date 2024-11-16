using FirstWebApi.Bll.Components.FilmComponent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWebApi.Bll.Components.DirectorComponent.Entities
{
    public class Director
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public ICollection<Film> films { get; set; }

    }
}
