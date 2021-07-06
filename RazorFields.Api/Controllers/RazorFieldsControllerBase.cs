using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorFields.Interfaces;

namespace RazorFields.Api.Controllers
{
    public class RazorFieldsControllerBase : ControllerBase
    {
        private readonly IRazorFieldsService _rfs;

        public RazorFieldsControllerBase(IRazorFieldsService rfs)
        {
            _rfs = rfs;
        }

        [HttpGet]
        public async Task<ActionResult> GetModels()
        {
            var models = this._rfs.GetModels();
            return Ok(models.Select(t => new
            {
                Type = t.type.Name,
                Value = t.value
            }));
        }

        [HttpPut("{name}")]
        public async Task<ActionResult> PutModel([FromRoute] string name, [FromBody] JsonElement value)
        {
            this._rfs.UpdateModel(name, value);
            return NoContent();
        }
    }
}