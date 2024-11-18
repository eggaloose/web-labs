using AutoMapper;
using FirstWebApi.Bll.Components.DirectorComponent.Dtos;
using FirstWebApi.Bll.Components.DirectorComponent.Entities;
using FirstWebApi.Bll.Components.FilmComponent.Dtos;
using FirstWebApi.Bll.Components.FilmComponent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FirstWebApi.Bll.Base
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Film, FilmDto>().ReverseMap();
            CreateMap<Director, DirectorDto>().ReverseMap();
        }

    }
}
