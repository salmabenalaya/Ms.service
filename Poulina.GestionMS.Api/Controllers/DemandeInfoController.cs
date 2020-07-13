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
    public class DemandeInfoController : ControllerBase

    {
        private readonly IRepository<Demande_information> repository;

        #region Constructor
        public DemandeInfoController(IRepository<Demande_information> repository)
        {
            this.repository = repository;

        }
        #endregion

        #region Read Function
        // GET: api/Category
        [HttpGet("GetListDemandInfo")]
        public async Task<IEnumerable<Demande_information>> GetListDemandInfo() =>
             await (new GetAllHandler<Demande_information>(repository)).Handle(new GetAllQuery<Demande_information>(condition: null, includes: null), new CancellationToken());

        // GET: api/Category/5
        [HttpGet("GetDemandInfo")]
        public async Task<Demande_information> GetDemandInfo(Guid id) =>
            await (new GetByIdHandler<Demande_information>(repository)).Handle(new GetQueryByID<Demande_information>(condition: x => x.IdInf.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/Category
        [HttpPost("PostDemandInfo")]
        public async Task<Demande_information> PostDemandInfo([FromBody] Demande_information Demand) =>
            await (new AddHandler<Demande_information>(repository))
            .Handle(new AddGeneric<Demande_information>(Demand), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/Category/5
        [HttpPut("PutDemandInfo")]
        public async Task<Demande_information> PutDemandInfo([FromBody] Demande_information category) =>
           await (new PutHandler<Demande_information>(repository)).Handle(new PutGeneric<Demande_information>(category), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/Category/5
        [HttpDelete("DeleteDemandInfo")]
        public async Task<Demande_information> DeleteDemandInfo(Guid id) =>
           await (new DeleteHandler<Demande_information>(repository)).Handle(new DeleteGeneric<Demande_information>(id), new CancellationToken());
        #endregion
    }
}





//    [Route("api/[controller]")]
//    [ApiController]
//    public class DemandeInfoController : ControllerBase
//    {
//        private readonly IMediator _mediator;

//        public DemandeInfoController(IMediator mediator)
//        {
//            _mediator = mediator;


//        }
//        // GET: api/Emp
//        [HttpGet]
//        public async Task<ActionResult<Demande_information>> GETAll()
//        {
//            var x = new GetAllQuery<Demande_information>();
//            var result = await _mediator.Send(x);
//            return Ok(result);
//        }

//        // GET: api/Emp/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Demande_information>> Get(Guid id)
//        {
//            var k = new GetQueryByID<Demande_information>(id);
//            var result = await _mediator.Send(k);
//            return Ok(result);
//        }

//        // POST: api/Emp
//        [HttpPost]
//        public async Task<ActionResult<Demande_information>> PostAsync(Demande_information entity)
//        {
//            var k = new AddGeneric<Demande_information>(entity);
//            var result = await _mediator.Send(k);
//            return Ok(result);
//        }

//        // PUT: api/Emp/5
//        [HttpPut("{id}")]
//        public async Task<ActionResult<Demande_information>> Put([FromBody] Demande_information etu)
//        {
//            var k = new PutGeneric<Demande_information>(etu);
//            var result = await _mediator.Send(k);
//            return Ok(result);

//        }

//        // DELETE: api/ApiWithActions/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<Demande_information>> Delete(Guid id)
//        {
//            var k = new DeleteGeneric<Demande_information>(id);
//            var result = await _mediator.Send(k);
//            return Ok(result);
//        }
//    }
//}