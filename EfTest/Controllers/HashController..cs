using EfTest.DTOs;
using EfTest.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashController : ControllerBase
    {
        [HttpGet("")]
        public async Task<ActionResult> HashPassword( HashPasswordRequest request)
        {
            
            string hashedPassword = PasswordHasher.Hash(request.Password1);

            return Ok(new
            {
                InputPassword = request.Password1,
                InputToCompare = request.Password2,
                HashedPassword = hashedPassword,
                Correct = PasswordHasher.Verify(request.Password2, hashedPassword)
            });
        }
    }
}
