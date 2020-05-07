using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{

    [Route("api/[controller]")] //Define um roteamento
    [ApiController] //Define que é WebApi
    public class UsersController : ControllerBase
    {

        private IUserService _service;

        private ILoginService _loginService;

        public UsersController(IUserService service, ILoginService login)
        {
            _service = service;
            _loginService = login;
        }

        [HttpGet]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult> GetAll() //faz referencia do service
        {
            //parametro removido: [FromServices] IUserService service

            //Verifica se a informação que está vindo da rota é valida!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - solicitação invalida!
            }

            try
            {
                return Ok(await _service.GetAll());
                //return Ok(await service.GetAll());
            }
            catch (ArgumentException e) //trata erros de controller!
            {
                //Resposta para o navegador! - erro 500
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        //localhost:5000/api/users/id
        [HttpGet]
        [EnableCors("CorsPolicy")]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            //Verifica se a informação que está vindo da rota é valida!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - solicitação invalida!
            }

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e) //trata erros de controller!
            {
                //Resposta para o navegador! - erro 500
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult> Post([FromBody] UserEntity user)
        {
            //Verifica se a informação que está vindo da rota é valida!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Post(user);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                //Resposta para o navegador! - erro 500
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult> Put([FromBody] UserEntity user)
        {
            //Verifica se a informação que está vindo da rota é valida!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Put(user);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                //Resposta para o navegador! - erro 500
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpDelete("{id}")] //("{id}")
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult> Delete(Guid id)
        {
            //Verifica se a informação que está vindo da rota é valida!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Delete(id);
                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                //Resposta para o navegador! - erro 500
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }


        [HttpGet]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult> GetEmail([FromBody] UserEntity user)
        {
            //Verifica se a informação que está vindo da rota é valida!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var emailValue =  await _loginService.FindByLogin(user);
                if(emailValue != null )
                {
                    return Ok(emailValue);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch(ArgumentException e){

                //Resposta para o navegador! - erro 500
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);

            }



        }

    }
}
