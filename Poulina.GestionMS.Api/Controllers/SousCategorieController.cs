using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poulina.GestionMs.Domain.Commands;
using Poulina.GestionMs.Domain.Dto;
using Poulina.GestionMs.Domain.Handler;
using Poulina.GestionMs.Domain.Interface;
using Poulina.GestionMs.Domain.Models;
using Poulina.GestionMs.Domain.Queries;

namespace Poulina.GestionMS.Api.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class SousCategorieController : ControllerBase
    {
        private readonly IRepository<sous_categorie> repository;
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        #region Constructor
        public SousCategorieController(IRepository<sous_categorie> repository, IMediator mediator, IMapper mapper)
        {
            this.repository = repository;
            this.mediator = mediator;
            this.mapper = mapper;
        }
        #endregion
        #region getDTO Function

        [HttpGet("getSousCategorieDto")]
        public async Task<IEnumerable<SousCategorieQuestionDto>> getSousCategorieDto()
        {

            return mediator.Send(new GetAllQuery<sous_categorie>
                (condition: null, includes: a => a.Include(x => x.Categorie))
                ).Result.Select(v => mapper.Map<SousCategorieQuestionDto>(v)
              );
        }
        #endregion
        #region Read Function
        // GET: api/Category
        [HttpGet("GetListSousCategory")]
        public async Task<IEnumerable<sous_categorie>> GetListSousCategory() =>
             await (new GetAllHandler<sous_categorie>(repository)).Handle(new GetAllQuery<sous_categorie>(condition: null, includes: null), new CancellationToken());

        #endregion

        #region Read Function1
        [HttpGet("GetListSousCategory1")]
        public async Task<IEnumerable<sous_categorie>> GetListSousCategory1(Guid id) =>
             await (new GetAllHandler<sous_categorie>(repository)).Handle(new GetAllQuery<sous_categorie>(condition: x => x.IdSC.Equals(id), includes: null), new CancellationToken());
        #endregion
        #region Read Function2
        // GET: api/Category/5
        [HttpGet("GetSousCategory")]
        public async Task<sous_categorie> GetSousCategory(Guid id) =>
            await (new GetByIdHandler<sous_categorie>(repository)).Handle(new GetQueryByID<sous_categorie>(condition: x => x.IdSC.Equals(id), null), new CancellationToken());
        #endregion



        #region Add Function
        // POST: api/Category
        [HttpPost("PostSousCategory")]
        public async Task<sous_categorie> PostSousCategory([FromBody] sous_categorie category) =>
            await (new AddHandler<sous_categorie>(repository))
            .Handle(new AddGeneric<sous_categorie>(category), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/Category/5
        [HttpPut("PutSousCategory")]
        public async Task<sous_categorie> PutSousCategory([FromBody] sous_categorie category) =>
           await (new PutHandler<sous_categorie>(repository)).Handle(new PutGeneric<sous_categorie>(category), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/Category/5
        [HttpDelete("DeleteSousCategory")]
        public async Task<sous_categorie> DeleteSousCategory(Guid id) =>
           await (new DeleteHandler<sous_categorie>(repository)).Handle(new DeleteGeneric<sous_categorie>(id), new CancellationToken());
        #endregion
    }


}
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SousCategorieController: ControllerBase
//    { 
//       private readonly IMediator _mediator;

//    public SousCategorieController(IMediator mediator)
//    {
//        _mediator = mediator;


//    }
//    // GET: api/Emp
//    [HttpGet]
//    public async Task<ActionResult<sous_categorie>> GETAll()
//    {
//        var x = new GetAllQuery<Sous_Categorie>();
//        var result = await _mediator.Send(x);
//        return Ok(result);
//    }

//    // GET: api/Emp/5
//    [HttpGet("{id}")]
//    public async Task<ActionResult<sous_categorie>> Get(Guid id)
//    {
//        var k = new GetQueryByID<Sous_Categorie>(id);
//        var result = await _mediator.Send(k);
//        return Ok(result);
//    }

//    // POST: api/Emp
//    [HttpPost]
//    public async Task<ActionResult<sous_categorie>> PostAsync(sous_categorie entity)
//    {
//        var k = new AddGeneric<sous_categorie>(entity);
//        var result = await _mediator.Send(k);
//        return Ok(result);
//    }

//    // PUT: api/Emp/5
//    [HttpPut("{id}")]
//    public async Task<ActionResult<sous_categorie>> Put([FromBody] sous_categorie etu)
//    {
//        var k = new PutGeneric<sous_categorie>(etu);
//        var result = await _mediator.Send(k);
//        return Ok(result);

//    }

//    // DELETE: api/ApiWithActions/5
//    [HttpDelete("{id}")]
//    public async Task<ActionResult<sous_categorie>> Delete(Guid id)
//    {
//        var k = new DeleteGeneric<sous_categorie>(id);
//        var result = await _mediator.Send(k);
//        return Ok(result);
//    }
//}
//}