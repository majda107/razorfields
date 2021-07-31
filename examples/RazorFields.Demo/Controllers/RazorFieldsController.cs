using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RazorFields.Api.Controllers;
using RazorFields.Interfaces;

namespace RazorFields.Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RazorFieldsController : RazorFieldsControllerBase
    {
        public RazorFieldsController(IRazorFieldsService rfs) : base(rfs)
        {
        }
    }
}