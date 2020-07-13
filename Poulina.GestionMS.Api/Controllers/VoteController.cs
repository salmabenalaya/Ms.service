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
    public class VoteController : ControllerBase
    {
        private readonly IRepository<Vote> repository;

        #region Constructor
        public VoteController(IRepository<Vote> repository)
        {
            this.repository = repository;

        }
        #endregion

        #region Read Function
        // GET: api/Category
        [HttpGet("GetListCategory")]
        public async Task<IEnumerable<Vote>> GetListCategory() =>
             await (new GetAllHandler<Vote>(repository)).Handle(new GetAllQuery<Vote>(condition: null, includes: null), new CancellationToken());

        #endregion

        #region Read Function1
        [HttpGet("GetListCategory1")]
        public async Task<IEnumerable<Vote>> GetListCategory1(Guid id) =>
             await (new GetAllHandler<Vote>(repository)).Handle(new GetAllQuery<Vote>(condition: x => x.IdVote.Equals(id), includes: null), new CancellationToken());
        #endregion
        #region Read Function2
        // GET: api/Category/5
        [HttpGet("GetCategory")]
        public async Task<Vote> GetCategory(Guid id) =>
            await (new GetByIdHandler<Vote>(repository)).Handle(new GetQueryByID<Vote>(condition: x => x.IdVote.Equals(id), null), new CancellationToken());
        #endregion



        #region Add Function
        // POST: api/Category
        [HttpPost("Postvote")]
        public async Task<Vote> Postvote([FromBody] Vote votes) =>
            await (new AddHandler<Vote>(repository))
            .Handle(new AddGeneric<Vote>(votes), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/Category/5
        [HttpPut("Putvote")]
        public async Task<Vote> Putvote([FromBody] Vote votes) =>
           await (new PutHandler<Vote>(repository))
            .Handle(new PutGeneric<Vote>(votes), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/Category/5
        [HttpDelete("DeleteCategory")]
        public async Task<Vote> DeleteCategory(Guid id) =>
           await (new DeleteHandler<Vote>(repository)).Handle(new DeleteGeneric<Vote>(id), new CancellationToken());
        #endregion
    }
}
//    [Route("api/[controller]")]
//    [ApiController]
//    public class VoteController : ControllerBase
//    {
//        private readonly IMediator _mediator;

//        public VoteController(IMediator mediator)
//        {
//            _mediator = mediator;


//        }
//        // GET: api/Emp
//        [HttpGet]
//        public async Task<ActionResult<Vote>> GETAll()
//        {
//            var x = new GetAllQuery<Vote>();
//            var result = await _mediator.Send(x);
//            return Ok(result);
//        }

//        // GET: api/Emp/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Vote>> Get(Guid id)
//        {
//            var k = new GetQueryByID<Vote>(id);
//            var result = await _mediator.Send(k);
//            return Ok(result);
//        }

//        // POST: api/Emp
//        [HttpPost]
//        public async Task<ActionResult<Vote>> PostAsync(Vote entity)
//        {
//            var k = new AddGeneric<Vote>(entity);
//            var result = await _mediator.Send(k);
//            return Ok(result);
//        }

//        // PUT: api/Emp/5
//        [HttpPut("{id}")]
//        public async Task<ActionResult<Vote>> Put([FromBody] Vote etu)
//        {
//            var k = new PutGeneric<Vote>(etu);
//            var result = await _mediator.Send(k);
//            return Ok(result);

//        }

//        // DELETE: api/ApiWithActions/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<Vote>> Delete(Guid id)
//        {
//            var k = new DeleteGeneric<Vote>(id);
//            var result = await _mediator.Send(k);
//            return Ok(result);
//        }
//    }
//}