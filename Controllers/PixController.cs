using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
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

            // 📝 Caminho do arquivo de log
            var caminhoLog = Path.Combine(Directory.GetCurrentDirectory(), "log_pix.txt");

            // 🧾 Conteúdo a ser gravado
            var log = $@"
[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]
EndToEndId: {pagamento.endToEndId}
Txid: {pagamento.txid}
Valor: {pagamento.valor}
Chave: {pagamento.chave}
Horário: {pagamento.horario}
-----------------------------";

            // ✏️ Grava no arquivo (append)
            System.IO.File.AppendAllText(caminhoLog, log + Environment.NewLine);

            return Ok(resposta);
        }


    }
}
