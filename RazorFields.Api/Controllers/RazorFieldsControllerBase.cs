using System.Linq;
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
        public async Task<ActionResult> GetFields()
        {
            var models = this._rfs.GetModels();
            return Ok(models.Select(t => new
            {
                Type = t.type.Name,
                Value = t.value
            }));
        }
    }
}