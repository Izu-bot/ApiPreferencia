using ApiPreferencia.Data.Context;
using ApiPreferencia.Model;
using ApiPreferencia.Model.MockData;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPreferencia.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EmailMockController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public EmailMockController(DatabaseContext context) => _context = context;

        [MapToApiVersion(1)]
        [HttpGet]
        public ActionResult<IEnumerable<EmailModel>> GetEmail()
        {
            var emails = EmailMock.GetMockEmail();
            return Ok(emails);
        }

        [MapToApiVersion(1)]
        [HttpGet("{id}")]
        public ActionResult<EmailModel> Get(int id)
        {
            var email = EmailMock.GetEmailById(id);
            if (email == null) return NotFound();

            return Ok(email);
        }

        [MapToApiVersion(1)]
        [HttpPut("{emailId}/label/{labelId}")]
        public ActionResult Put(int emailId, int labelId)
        {
            // Verifica se o label existe no banco de dados
            var labelExist = _context.Labels.Count(l => l.Id == labelId) > 0;

            if (!labelExist) return NotFound($"Label com ID {labelId} não foi encontrado na base de dados!");

            var email = EmailMock.GetEmailById(emailId);
            if (email == null) return NotFound($"Email com ID {emailId} não foi encontrado na base de dados!");

            email.LabelId = labelId;
            return NoContent();
        }

        [MapToApiVersion(1)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var email = EmailMock.GetEmailById(id);
            if (email == null) return NotFound();

            EmailMock.GetMockEmail().Remove(email);
            return NoContent();
        }
    }
}
