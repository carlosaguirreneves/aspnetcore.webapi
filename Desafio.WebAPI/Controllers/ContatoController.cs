using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Desafio.Domain;
using Desafio.Repository;
using Desafio.WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.WebAPI.Controllers
{
    [ApiController]
    [Route("/contato")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepository _repository;
        private readonly IMapper _mapper;

        public ContatoController(IContatoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet("{idContato}")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(Error), 401)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(typeof(Error), 500)]
        public async Task<IActionResult> GetById(string idContato)
        {
            try
            {
                var contato = await _repository.GetById(idContato);
                if (contato == null) {
                    return NotFound(new Error(404, "Contato não encontrato."));
                }

                return Ok(_mapper.Map<ContatoDto>(contato));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(Error), 401)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(typeof(Error), 500)]
        public async Task<IActionResult> GetAllPaginated(int page, int size)
        {
            try
            {
                var contato = await _repository.FindAllPaginated(page, size);
                if (contato == null) {
                    return NotFound(new Error(404, "Contato não encontrato."));
                }

                return Ok(_mapper.Map<IEnumerable<ContatoDto>>(contato));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(Error), 401)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public async Task<IActionResult> Insert(ContatoDto model)
        {
            try
            {
                var contato = _mapper.Map<Contato>(model);
                _repository.Add(contato);

                if (await _repository.SaveChangesAsync()) {
                    return Created($"/contato/{contato.Id}", _mapper.Map<ContatoDto>(contato));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return BadRequest();
        }

        [HttpPut("{idContato}")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(Error), 401)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public async Task<IActionResult> Update(string idContato, ContatoDto model)
        {
            try
            {
                var contato = await _repository.GetById(idContato);
                if (contato == null) {
                    return NotFound(new Error(404, "Contato não encontrato."));
                }

                model.Id = contato.Id;

                _mapper.Map(model, contato);
                _repository.Update(contato);

                if (await _repository.SaveChangesAsync()) {
                    return Ok(_mapper.Map<ContatoDto>(contato));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return BadRequest();
        }

        [HttpDelete("{idContato}")]
        [Produces("application/json")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(Error), 401)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public async Task<IActionResult> Delete(string idContato)
        {
            try
            {
                var contato = await _repository.GetById(idContato);
                var id = contato.Id;
                if (contato == null) {
                    return NotFound(new Error(404, "Contato não encontrato."));
                }

                _repository.Delete(contato);

                if (await _repository.SaveChangesAsync()) {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return BadRequest();
        }
    }
}