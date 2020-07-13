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
    public class CommentaireController : ControllerBase
    {
        private readonly IRepository<Commentaire> repository;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        #region Constructor
        public CommentaireController(IRepository<Commentaire> repository, IMediator mediator, IMapper mapper)
        {
            this.repository = repository;
            this.mediator = mediator;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/Category
        [HttpGet("GetListCommentaire")]
        public async Task<IEnumerable<Commentaire>> GetListCommentaire() =>
             await (new GetAllHandler<Commentaire>(repository)).Handle(new GetAllQuery<Commentaire>(condition: null, includes: null), new CancellationToken());

        #endregion

        #region Read Function1
        [HttpGet("GetListCommentaire1")]
        public async Task<IEnumerable<Commentaire>> GetListCommentaire1(Guid id) =>
             await (new GetAllHandler<Commentaire>(repository)).Handle(new GetAllQuery<Commentaire>(condition: x => x.IdQuestion.Equals(id), includes: null), new CancellationToken());
        #endregion
        #region Read Function2
        // GET: api/Category/5
        [HttpGet("GetCommentaire")]
        public async Task<Commentaire> GetCommentaire(Guid id) =>
            await (new GetByIdHandler<Commentaire>(repository)).Handle(new GetQueryByID<Commentaire>(condition: x => x.IdQuestion.Equals(id), null), new CancellationToken());
        #endregion



        #region Add Function
        // POST: api/Category
        [HttpPost("PostCommenataire")]
        public async Task<Commentaire> PostCommenataire([FromBody] Commentaire comm) =>
            await (new AddHandler<Commentaire>(repository))
            .Handle(new AddGeneric<Commentaire>(comm), new CancellationToken());
        #endregion
        #region Update Funtion
        // PUT: api/Category/5
        [HttpPut("PutCommenataire")]
        public async Task<Commentaire> PutCommenataire([FromBody] Commentaire comm) =>
           await (new PutHandler<Commentaire>(repository)).Handle(new PutGeneric<Commentaire>(comm), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/Category/5
        [HttpDelete("DeleteCommentaire")]
        public async Task<Commentaire> DeleteCommentaire(Guid id) =>
           await (new DeleteHandler<Commentaire>(repository)).Handle(new DeleteGeneric<Commentaire>(id), new CancellationToken());
        #endregion
        [HttpGet("getCommentaireDto")]
        public async Task<IEnumerable<CommentaireQuestionDto>> getCommentaireDto()
        {

            return mediator.Send(new GetAllQuery<Commentaire>
                (condition: null, includes: a => a.Include(x => x.demande_Information))
                ).Result.Select(v => mapper.Map<CommentaireQuestionDto>(v)
              );
        }

    }








    //private readonly IMediator _mediator;

    //public CommentaireController(IMediator mediator)
    //{
    //    _mediator = mediator;


    //}
    //// GET: api/Emp
    //[HttpGet]
    //public async Task<ActionResult<Commentaire>> GETAll()
    //{
    //    var x = new GetAllQuery<Commentaire>();
    //    var result = await _mediator.Send(x);
    //    return Ok(result);
    //}

    //// GET: api/Emp/5
    //[HttpGet("{id}")]
    //public async Task<ActionResult<Commentaire>> Get(Guid id)
    //{
    //    var Com = new Commentaire();
    //    var k = new GetQueryByID<Commentaire>(id= Com.IdQuestion);
    //    var result = await _mediator.Send(k);
    //    return Ok(result);
    //}

    //// POST: api/Emp
    //[HttpPost]
    //public async Task<ActionResult<Commentaire>> PostAsync(Commentaire entity)
    //{
    //    var k = new AddGeneric<Commentaire>(entity);
    //    var result = await _mediator.Send(k);
    //    return Ok(result);
    //}

    // PUT: api/Emp/5
    //    [HttpPut]
    //    public async Task<ActionResult<Commentaire>> Put([FromBody] Commentaire etu)
    //    {
    //        var k = new PutGeneric<Commentaire>(etu);
    //        var result = await _mediator.Send(k);
    //        return Ok(result);

    //    }

    //    // DELETE: api/ApiWithActions/5
    //    [HttpDelete("{id}")]
    //    public async Task<ActionResult<Commentaire>> Delete(Guid id)
    //    {
    //        var k = new DeleteGeneric<Commentaire>(id);
    //        var result = await _mediator.Send(k);
    //        return Ok(result);
    //    }
    //}

}