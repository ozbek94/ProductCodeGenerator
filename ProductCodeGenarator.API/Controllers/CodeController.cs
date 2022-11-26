using Microsoft.AspNetCore.Mvc;
using ProductCodeGenarator.Domain.Services.Code;

namespace ProductCodeGenarator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CodeController : ControllerBase
    {
        private readonly ICodeService _codeService; 

        public CodeController(ICodeService codeService)
        {
            _codeService = codeService;
        }

        [HttpGet("Suitability")]
        public async Task<IActionResult> CheckCode(string Code)
        {
            var result = await _codeService.CheckCode(Code);
            return Ok(result);
        }

        [HttpPost("Codes/{Count}")]
        public async Task<IActionResult> GenerateCodes(int Count)
        {
             var codes = await _codeService.GenerateCodes(Count);
            return Ok(codes);
        }
    }
}
