using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
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

                    return Ok(JsonConvert.SerializeObject(_methodResult.Notifications));
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _methodResult.AddResult("500", e.Message);

                return BadRequest(JsonConvert.SerializeObject(_methodResult.Notifications));
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

                    return Ok(JsonConvert.SerializeObject(_methodResult.Notifications));
                }

                return BadRequest();
                
            }
            catch (Exception e)
            {

                _methodResult.AddResult("500", e.Message);

                return BadRequest(JsonConvert.SerializeObject(_methodResult.Notifications));
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

                    return Ok(JsonConvert.SerializeObject(_methodResult.Notifications));
                }

                return BadRequest();
            }

            catch (Exception e)
            {

                _methodResult.AddResult("500", e.Message);

                return BadRequest(JsonConvert.SerializeObject(_methodResult.Notifications));
            }
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var user = await _userAppService.GetAll();

                return Ok(JsonConvert.SerializeObject(user));

            }
            catch(Exception e)
            {

                _methodResult.AddResult("500", e.Message);

                return BadRequest(JsonConvert.SerializeObject(_methodResult.Notifications));
            }

        }

        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            try
            {
                var user = await _userAppService.GetById(id);

                return Ok(JsonConvert.SerializeObject(user));

            }

            catch (Exception e)
            {
                _methodResult.AddResult("500", e.Message);

                return BadRequest(JsonConvert.SerializeObject(_methodResult.Notifications));
            }

        }
    }
}
