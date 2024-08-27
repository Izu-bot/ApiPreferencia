using ApiPreferencia.Model;
using ApiPreferencia.Services;
using ApiPreferencia.VIewModel.UserVM;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPreferencia.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [MapToApiVersion(1)]
        [HttpGet]
        public ActionResult<IEnumerable<GetUserViewModel>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var users = _service.GetAllUsers(page, pageSize);
            var viewModelList = _mapper.Map<IEnumerable<GetUserViewModel>>(users);

            var viewModel = new PaginacaoUserViewModel
            {
                User = viewModelList,
                CurrentPage = page,
                PageSize = pageSize
            };

            return Ok(viewModel);
        }


        [MapToApiVersion(1)]
        [HttpGet("{id}")]
        
        public ActionResult<UserModel> Get(int id)
        {
            var user = _service.GetIdUser(id);
            if (user == null) NotFound();

            var viewModel = _mapper.Map<GetUserViewModel>(user);
            return Ok(viewModel);
        }

        [MapToApiVersion(1)]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post([FromBody] AddUserViewModel user)
        {
            var usuario = _mapper.Map<UserModel>(user);
            _service.AddUser(usuario);

            return CreatedAtAction(nameof(Get), new {id = usuario.Id }, user);
        }

        [MapToApiVersion(1)]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.DeleteUser(id);
            return NoContent();
        }

        [MapToApiVersion(1)]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] GetUserViewModel user)
        {
            var isUser = _service.GetIdUser(id);
            if (isUser == null) return NotFound();

            _mapper.Map(user, isUser);
            _service.UpdateUser(isUser);

            return NoContent();
        }
    }
}
