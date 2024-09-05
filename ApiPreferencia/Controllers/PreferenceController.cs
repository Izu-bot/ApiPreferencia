using ApiPreferencia.Model;
using ApiPreferencia.Services;
using ApiPreferencia.VIewModel.PreferenceVM;
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
    [AllowAnonymous]
    public class PreferenceController : ControllerBase
    {
        private readonly IPreferenceService _service;
        private readonly IMapper _mapper;

        public PreferenceController(IPreferenceService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [MapToApiVersion(1)]
        [HttpGet]
        public ActionResult<PreferenceModel> Get(int id)
        {
            var preference = _service.GetById(id);
            if (preference == null) NotFound();

            var viewModel = _mapper.Map<GetPreferenceViewModel>(preference);
            return Ok(viewModel);
        }

        [MapToApiVersion(1)]
        [HttpPost]
        public ActionResult Post([FromBody] AddPreferenceViewModel viewModel)
        {
            var preference = _mapper.Map<PreferenceModel>(viewModel);
            _service.AddPreference(preference);

            return CreatedAtAction(nameof(Get), new { id = preference.Id }, preference);
        }

        [MapToApiVersion(1)]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] GetPreferenceViewModel preference)
        {
            var isPreference = _service.GetById(id);
            if (isPreference == null) return NotFound();

            _mapper.Map(preference, isPreference);
            _service.UpdatePreference(isPreference);

            return NoContent();
        }

        [MapToApiVersion(1)]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.DeletePreference(id);
            return NoContent();
        }
    }
}
