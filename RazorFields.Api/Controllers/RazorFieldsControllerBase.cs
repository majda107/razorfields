using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Newtonsoft.Json;
using RazorFields.Interfaces;

namespace RazorFields.Api.Controllers
{
    // TODO virtual override
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
            var type = this._rfs.FindType(name);
            if (type == null) return NotFound();

            try
            {
                var model = JsonConvert.DeserializeObject(value.ToString() ?? "", type);
                this._rfs.UpdateModel(model);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost("{name}/reset")]
        public async Task<ActionResult> ResetModel([FromRoute] string name)
        {
            var type = this._rfs.FindType(name);
            if (type == null) return NotFound();

            this._rfs.ResetModel(type);
            return NoContent();
        }
    }
}