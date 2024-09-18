namespace email_api.Models
{
    public class Email
    {
        public string? Remetente { get; set; }
        public string? Destinatario { get; set; }
        public string? Assunto { get; set; }
        public string? Conteudo { get; set; }
        public string? DataHora { get; set; }
    }
}