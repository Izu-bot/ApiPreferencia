using ApiPreferencia.Model;
using ApiPreferencia.Services;
using ApiPreferencia.VIewModel.LabelVM;
using ApiPreferencia.VIewModel.PreferenceVM;
using ApiPreferencia.VIewModel.UserVM;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPreferencia.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly ILabelService _service;
        private readonly IMapper _mapper;

        public LabelController(ILabelService service, IMapper mappe)
        {
            _service = service;
            _mapper = mappe;
        }

        [MapToApiVersion(1)]
        [HttpGet]
        public ActionResult<IEnumerable<GetPreferenceViewModel>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var label = _service.GetAll(page, pageSize);
            var labelViewModel = _mapper.Map<IEnumerable<GetLabelViewModel>>(label);

            var viewModel = new PaginacaoLabelViewModel
            {
                Label = labelViewModel,
                CurrentPage = page,
                PageSize = pageSize
            };

            return Ok(viewModel);
        }

        [MapToApiVersion(1)]
        [HttpGet("{id:int}")]
        public ActionResult<LabelModel> Get(int id)
        {
            var label = _service.GetById(id);
            if (label == null) return NotFound();

            var viewModel = _mapper.Map<GetLabelViewModel>(label);
            return Ok(viewModel);
        }

        [MapToApiVersion(1)]
        [HttpGet("{name:alpha}")]
        public ActionResult<LabelModel> Get(string name)
        {
            var label = _service.GetName(name);
            if(label == null) return NotFound();

            var viewModel = _mapper.Map<GetLabelViewModel>(label);

            return Ok(viewModel);
        }


        [MapToApiVersion(1)]
        [HttpPost]
        public ActionResult Post([FromBody] AddLabelViewModel model)
        {
            var label = _mapper.Map<LabelModel>(model);
            _service.AddLabel(label);

            return CreatedAtAction(nameof(Get), new { id = label.Id}, label);
        }

        [MapToApiVersion(1)]
        [HttpPut("{id}")]
        public ActionResult Pust(int id, [FromBody] GetLabelViewModel model)
        {
            var isLabel = _service.GetById(id);
            if(isLabel == null) return NotFound();

            _mapper.Map(model, isLabel);
            _service.UpdateLabel(isLabel);

            return NoContent();
        }

        [MapToApiVersion(1)]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.DeleteLabel(id);
            return NoContent();
        }
    }
}
