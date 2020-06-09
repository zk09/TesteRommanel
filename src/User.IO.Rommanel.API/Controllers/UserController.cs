using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using User.IO.Rommanel.API.ResultSet;
using User.IO.Rommanel.Application.Interfaces;
using User.IO.Rommanel.Application.ViewModels;
using User.IO.Rommanel.Domain.Core.Notifications;

namespace User.IO.Rommanel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserAppService _userAppService;
        private readonly MethodResultNotification _methodResult;
        public UserController(MethodResultNotification methodResult,IUserAppService userAppService, DomainNotification notificationContext) : base(notificationContext)
        {
            _userAppService = userAppService;
            _methodResult = methodResult;


        }

        [HttpPost("RegisterNewUser")]
        public async Task<IActionResult> RegisterNewUser([FromBody]UserViewModel model)
        {
            try
            {
                var user = await _userAppService.Register(model);

                if (OperacaoValida() && user)
                {
                    _methodResult.AddResult(user.ToString(), "Usuário registrado com sucesso!");

                    return Ok(new
                    {
                        success = true,
                        data = _methodResult.Notifications.Select(n => n.Message)
                    });    
                }

                return BadRequest();
            
            }
            catch (Exception e)
            {

                var result = new
                {
                    success = false,
                    errors = e.Message
                };

                return BadRequest(result);
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody]UserViewModel model)
        {
            try
            {
                var user = await _userAppService.Update(model);

                if (OperacaoValida() && user)
                {

                    _methodResult.AddResult(user.ToString(), "Usuário alterado com sucesso!");

                    return Ok(new
                    {
                        success = true,
                        data = _methodResult.Notifications.Select(n => n.Message)
                    });
                }

                return BadRequest();
                
            }
            catch (Exception e)
            {


                var result = new
                {
                    success = false,
                    errors = e.Message
                };

                return BadRequest(result);
            }
        }


        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                var user = await _userAppService.Delete(id);

                if (OperacaoValida() && user)
                {
                    _methodResult.AddResult(user.ToString(), "Usuário deletado com sucesso!");

                    return Ok(new
                    {
                        success = true,
                        data = _methodResult.Notifications.Select(n => n.Message)
                    });
                }

                return BadRequest();
            }

            catch (Exception e)
            {


                var result = new
                {
                    success = false,
                    errors = e.Message
                };

                return BadRequest(result);
            }
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var user = await _userAppService.GetAll();

                return Ok(new
                {
                    success = true,
                    data = user
                });


            }
            catch(Exception e)
            {


                var result = new
                {
                    success = false,
                    errors = e.Message
                };

                return BadRequest(result);
            }

        }

        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            try
            {
                var user = await _userAppService.GetById(id);


                return Ok(new
                {
                    success = true,
                    data = user
                });

            }

            catch (Exception e)
            {

                var result = new
                {
                    success = false,
                    errors = e.Message
                };

                return BadRequest(result);
            }

        }
    }
}
