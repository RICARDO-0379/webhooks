namespace TesteWebhooks.Model
{
    public class PixNotificacao
    {
        public List<PixInfo> pix { get; set; }
    }

    public class PixInfo
    {
        public string endToEndId { get; set; }
        public string txid { get; set; }
        public string valor { get; set; }
        public string horario { get; set; }
        public string infoPagador { get; set; }
        public string chave { get; set; }
        public ComponentesValor componentesValor { get; set; }
        public object devolucoes { get; set; }
    }

    public class ComponentesValor
    {
        public Valor original { get; set; }
        public ValorJuros juros { get; set; }
        public ValorMulta multa { get; set; }
        public ValorAbatimento abatimento { get; set; }
        public ValorDesconto desconto { get; set; }
    }

    public class Valor { public string valor { get; set; } }
    public class ValorJuros { public string valor_juros { get; set; } }
    public class ValorMulta { public string valor_multa_documento_cobranca_pix { get; set; } }
    public class ValorAbatimento { public string valor_abatimento_documento_cobranca_pix { get; set; } }
    public class ValorDesconto { public string valor_desconto_documento_cobranca_pix { get; set; } }

}
