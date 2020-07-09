using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Poulina.GestionMs.Data;
using Poulina.GestionMs.Data.Repository;
using Poulina.GestionMs.Domain.Commands;
using Poulina.GestionMs.Domain.Handler;
using Poulina.GestionMs.Domain.Interface;
using Poulina.GestionMs.Domain.Models;
using Poulina.GestionMs.Domain.Queries;
using System.Collections.Generic;

namespace GestionMS.Infr.Ioc
{
    public class DependencyContrainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<Context>();
            services.AddTransient<IRepository<Commentaire>, Repository<Commentaire>>();

           // services.AddScoped<IRepository<Commentaire>, Repository<Commentaire>>();
            //services.AddScoped<IRequestHandler<AddGeneric<Commentaire>, string>, AddHandler<Commentaire>>();
            //services.AddScoped<IRequestHandler<DeleteGeneric<Commentaire>, string>, DeleteHandler<Commentaire>>();
            //services.AddScoped<IRequestHandler<PutGeneric<Commentaire>, string>, PutHandler<Commentaire>>();
            services.AddScoped<IRequestHandler<GetAllQuery<Commentaire>, IEnumerable<Commentaire>>, GetAllHandler<Commentaire>>();
            services.AddScoped<IRequestHandler<GetQueryByID<Commentaire>, Commentaire>, GetByIdHandler<Commentaire>>();


            services.AddScoped<IRepository<Categorie>, Repository<Categorie>>();
            //services.AddScoped<IRequestHandler<AddGeneric<Categorie>, string>, AddHandler<Categorie>>();
            //services.AddScoped<IRequestHandler<DeleteGeneric<Categorie>, string>, DeleteHandler<Categorie>>();
            //services.AddScoped<IRequestHandler<PutGeneric<Categorie>, string>, PutHandler<Categorie>>();
            services.AddScoped<IRequestHandler<GetAllQuery<Categorie>, IEnumerable<Categorie>>, GetAllHandler<Categorie>>();
            services.AddScoped<IRequestHandler<GetQueryByID<Categorie>, Categorie>, GetByIdHandler<Categorie>>();

            services.AddScoped<IRepository<Demande_information>, Repository<Demande_information>>();
            //services.AddScoped<IRequestHandler<AddGeneric<Demande_information>, string>, AddHandler<Demande_information>>();
            //services.AddScoped<IRequestHandler<DeleteGeneric<Demande_information>, string>, DeleteHandler<Demande_information>>();
            //services.AddScoped<IRequestHandler<PutGeneric<Demande_information>, string>, PutHandler<Demande_information>>();
            services.AddScoped<IRequestHandler<GetAllQuery<Demande_information>, IEnumerable<Demande_information>>, GetAllHandler<Demande_information>>();
            services.AddScoped<IRequestHandler<GetQueryByID<Demande_information>, Demande_information>, GetByIdHandler<Demande_information>>();

            services.AddScoped<IRepository<sous_categorie>, Repository<sous_categorie>>();
            //services.AddScoped<IRequestHandler<AddGeneric<sous_categorie>, string>, AddHandler<sous_categorie>>();
            //services.AddScoped<IRequestHandler<DeleteGeneric<sous_categorie>, string>, DeleteHandler<sous_categorie>>();
            //services.AddScoped<IRequestHandler<PutGeneric<sous_categorie>, string>, PutHandler<sous_categorie>>();
            services.AddScoped<IRequestHandler<GetAllQuery<sous_categorie>, IEnumerable<sous_categorie>>, GetAllHandler<sous_categorie>>();
            services.AddScoped<IRequestHandler<GetQueryByID<sous_categorie>, sous_categorie>, GetByIdHandler<sous_categorie>>();

            services.AddScoped<IRepository<Vote>, Repository<Vote>>();
            //services.AddScoped<IRequestHandler<AddGeneric<Vote>, string>, AddHandler<Vote>>();
            //services.AddScoped<IRequestHandler<DeleteGeneric<Vote>, string>, DeleteHandler<Vote>>();
            //services.AddScoped<IRequestHandler<PutGeneric<Vote>, string>, PutHandler<Vote>>();
            services.AddScoped<IRequestHandler<GetAllQuery<Vote>, IEnumerable<Vote>>, GetAllHandler<Vote>>();
            services.AddScoped<IRequestHandler<GetQueryByID<Vote>, Vote>, GetByIdHandler<Vote>>();


        }
    }
}
