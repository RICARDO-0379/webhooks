using Microsoft.AspNetCore.Mvc;
using TesteWebhooks.Model;

namespace TesteWebhooks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PixController : ControllerBase
    {
        [HttpPost]
        public IActionResult ReceberPix([FromBody] PixNotificacao notificacao)
        {
            // Aqui você pode adicionar log, salvar em banco, etc.
            return Ok("Webhook recebido com sucesso!");
        }
    }
}
