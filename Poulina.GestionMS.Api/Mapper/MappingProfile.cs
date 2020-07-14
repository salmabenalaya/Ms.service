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
            #region Map CommentaireTyoe

            CreateMap<Commentaire, CommentaireQuestionDto>()
                .ForMember(a => a.IdCom, i => i.MapFrom(src => src.IdCom))
                .ForMember(a => a.Description, i => i.MapFrom(src => src.Description))
                .ForMember(a => a.IdQuestion, i => i.MapFrom(src => src.IdQuestion))
                .ForMember(a => a.nameQuestion, i => i.MapFrom(src => src.demande_Information.Titre))
                .ReverseMap();
            #endregion
            #region Map CategorieTyoe

            CreateMap<sous_categorie,SousCategorieQuestionDto>()
                .ForMember(a => a.IdSC, i => i.MapFrom(src => src.IdSC))
                .ForMember(a => a.Label, i => i.MapFrom(src => src.Label))
                .ForMember(a => a.CategorieFK, i => i.MapFrom(src => src.CategorieFK))
                .ForMember(a => a.nameCategorie, i => i.MapFrom(src => src.Categorie.Label))
                .ReverseMap();
            #endregion

        }
    }
}
