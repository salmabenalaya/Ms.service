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
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Categorie> repository;

        #region Constructor
        public CategoryController(IRepository<Categorie> repository)
        {
            this.repository = repository;

        }
        #endregion

        #region Read Function
        // GET: api/Category
        [HttpGet("GetListCategory")]
        public async Task<IEnumerable<Categorie>> GetListCategory() =>
             await (new GetAllHandler<Categorie>(repository)).Handle(new GetAllQuery<Categorie>(condition: null, includes: null), new CancellationToken());

        // GET: api/Category/5
        [HttpGet("GetCategory")]
        public async Task<Categorie> GetCategory(Guid id) =>
            await (new GetByIdHandler<Categorie>(repository)).Handle(new GetQueryByID<Categorie>(condition: x => x.IdCategorie.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/Category
        [HttpPost("PostCategory")]
        public async Task<Categorie> PostCategory([FromBody] Categorie category) =>
            await (new AddHandler<Categorie>(repository)).Handle(new AddGeneric<Categorie>(category), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/Category/5
        [HttpPut("PutCategory")]
        public async Task<Categorie> PutCategory([FromBody] Categorie category) =>
           await (new PutHandler<Categorie>(repository)).Handle(new PutGeneric<Categorie>(category), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/Category/5
        [HttpDelete("DeleteCategory")]
        public async Task<Categorie> DeleteCategory(Guid id) =>
           await (new DeleteHandler<Categorie>(repository)).Handle(new DeleteGeneric<Categorie>(id), new CancellationToken());
        #endregion
    }




    //[Route("api/[controller]")]
    //[ApiController]
    //public class CategorieController : ControllerBase

    //{
    //    private readonly IMediator _mediator;

    //    public CategorieController(IMediator mediator)
    //    {
    //        _mediator = mediator;


    //    }
    //    // GET: api/Emp
    //    [HttpGet]
    //    public async Task<ActionResult<Categorie>> GETAll()
    //    {
    //        var x = new GetAllQuery<Categorie>();
    //        var result = await _mediator.Send(x);
    //        return Ok(result);
    //    }

    //    // GET: api/Emp/5
    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<Categorie>> Get(Guid id)
    //    {
    //        var k = new GetQueryByID<Categorie>(id);
    //        var result = await _mediator.Send(k);
    //        return Ok(result);
    //    }

    //    // POST: api/Emp
    //    [HttpPost]
    //    public async Task<ActionResult<Categorie>> PostAsync(Categorie entity)
    //    {
    //        var k = new AddGeneric<Categorie>(entity);
    //        var result = await _mediator.Send(k);
    //        return Ok(result);
    //    }

    //    // PUT: api/Emp/5
    //    [HttpPut("{id}")]
    //    public async Task<ActionResult<Categorie>> Put([FromBody] Categorie etu)
    //    {
    //        var k = new PutGeneric<Categorie>(etu);
    //        var result = await _mediator.Send(k);
    //        return Ok(result);

    //    }

    //    // DELETE: api/ApiWithActions/5
    //    [HttpDelete("{id}")]
    //    public async Task<ActionResult<Categorie>> Delete(Guid id)
    //    {
    //        var k = new DeleteGeneric<Categorie>(id);
    //        var result = await _mediator.Send(k);
    //        return Ok(result);
    //    }
    //}
}