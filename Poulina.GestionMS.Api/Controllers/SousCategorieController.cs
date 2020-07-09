using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poulina.GestionMs.Domain.Commands;
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

        #region Constructor
        public SousCategorieController(IRepository<sous_categorie> repository)
        {
            this.repository = repository;

        }
        #endregion

        #region Read Function
        // GET: api/Category
        [HttpGet("GetListCategory")]
        public async Task<IEnumerable<sous_categorie>> GetListCategory() =>
             await (new GetAllHandler<sous_categorie>(repository)).Handle(new GetAllQuery<sous_categorie>(condition: null, includes: null), new CancellationToken());

        #endregion

        #region Read Function1
        [HttpGet("GetListCategory1")]
        public async Task<IEnumerable<sous_categorie>> GetListCategory1(Guid id) =>
             await (new GetAllHandler<sous_categorie>(repository)).Handle(new GetAllQuery<sous_categorie>(condition: x => x.IdSC.Equals(id), includes: null), new CancellationToken());
        #endregion
        #region Read Function2
        // GET: api/Category/5
        [HttpGet("GetCategory")]
        public async Task<sous_categorie> GetCategory(Guid id) =>
            await (new GetByIdHandler<sous_categorie>(repository)).Handle(new GetQueryByID<sous_categorie>(condition: x => x.IdSC.Equals(id), null), new CancellationToken());
        #endregion



        #region Add Function
        // POST: api/Category
        [HttpPost("PostCategory")]
        public async Task<sous_categorie> PostCategory([FromBody] sous_categorie category) =>
            await (new AddHandler<sous_categorie>(repository)).Handle(new AddGeneric<sous_categorie>(category), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/Category/5
        [HttpPut("PutCategory")]
        public async Task<sous_categorie> PutCategory([FromBody] sous_categorie category) =>
           await (new PutHandler<sous_categorie>(repository)).Handle(new PutGeneric<sous_categorie>(category), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/Category/5
        [HttpDelete("DeleteCategory")]
        public async Task<sous_categorie> DeleteCategory(Guid id) =>
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