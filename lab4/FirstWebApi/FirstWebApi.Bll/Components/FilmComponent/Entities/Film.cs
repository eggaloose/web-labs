using FirstWebApi.Bll.Components.DirectorComponent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWebApi.Bll.Components.FilmComponent.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
}
