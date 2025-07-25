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
            var pagamento = notificacao.pix?.FirstOrDefault();

            if (pagamento == null)
                return BadRequest("Nenhuma transação Pix encontrada.");

            var resposta = new
            {
                Mensagem = "Pagamento Pix recebido com sucesso!",
                Valor = pagamento.valor,
                Chave = pagamento.chave,
                Txid = pagamento.txid,
                EndToEndId = pagamento.endToEndId,
                Horario = pagamento.horario
            };

            return Ok(resposta);
        }
    }
}
