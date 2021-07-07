using CatalogoDeJogos_Api.Dto.InputModel;
using CatalogoDeJogos_Api.Dto.ViewModel;
using CatalogoDeJogos_Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _service;

        public JogosController(IJogoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<JogoViewModel>> ObterJogos()
        {
            return Ok(await _service.GetJogoAll());            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JogoViewModel>> ObterJogo(int id)
        {
            return Ok(await _service.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<JogoInputModel>> InserirJogo(JogoInputModel entidade)
        {
            try
            {
                var jogo = await _service.Post(entidade);
                return Ok();
            }
            catch (Exception)
            {
                return UnprocessableEntity("Já existe esse jogo cadastrado");
            }
            
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult> AtualizarJogo(int id)
        //{
        //    try
        //    {                
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult> DesativarCadastro(int id)
        {
            try
            {
                await _service.Disable(id);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }            
        }
    }
}
