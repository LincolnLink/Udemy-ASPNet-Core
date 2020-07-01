using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{

    [Route("login/[controller]")] //Define um roteamento
    [ApiController] //Define que é WebApi
    public class LoginController: ControllerBase
    {   

        [AllowAnonymous]
        [HttpPost]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto,[FromServices] ILoginService service)
        {
            //Verifica se a informação que está vindo da rota é valida!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(loginDto == null)
            {
                return BadRequest();
            }

            try
            {
                var result =  await service.FindByLogin(loginDto);
                if(result != null )
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }

            }
            catch(ArgumentException e){

                //Resposta para o navegador! - erro 500
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);

            }



        }
    }
}