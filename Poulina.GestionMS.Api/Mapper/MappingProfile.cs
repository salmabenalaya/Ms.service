using AutoMapper;
using Poulina.GestionMs.Domain.Dto;
using Poulina.GestionMs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poulina.GestionMS.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Commentaire, CommentaireQuestionDto>()
                .ForMember(a => a.IdCom, i => i.MapFrom(src => src.IdCom))
                .ForMember(a => a.Description, i => i.MapFrom(src => src.Description))
                .ForMember(a => a.IdQuestion, i => i.MapFrom(src => src.IdQuestion))
                .ForMember(a => a.nameQuestion, i => i.MapFrom(src => src.demande_Information.Titre))
                .ReverseMap();


        }
    }
}
