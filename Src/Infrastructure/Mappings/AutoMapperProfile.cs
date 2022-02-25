using AutoMapper;
using Core.DTO.Request;
using Core.DTO.Response;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappings
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            /* Apps */
            CreateMap<App, AppDTO>().ReverseMap();
            CreateMap<CreateAppDTO, App>().ReverseMap();

            /* Usuarios */
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioDTO,Usuario>().ReverseMap();

            /* AppVersions */
            CreateMap<AppVersion, AppVersionDTO>().ReverseMap();
            CreateMap<CreateAppVersionDTO, AppVersion>().ReverseMap();

            /* Descarga */
            CreateMap<Descarga, DescargaDTO>().ReverseMap();
            CreateMap<CreateDescargaDTO, Descarga>().ReverseMap();

        }
    }
}
