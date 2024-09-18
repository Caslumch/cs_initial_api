using Microsoft.AspNetCore.Mvc;
using email_api.Models; // Certifique-se de que está correto

namespace email_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private const string RequiredKey = "ausdh12342111haishiasaaaiuhiudsfhh"; // A chave constante

        [HttpPost]
        public IActionResult Post([FromBody] EmailRequest request)
        {
            if (request == null)
            {
                return BadRequest("Dados inválidos.");
            }

            if (string.IsNullOrEmpty(request.SendEmail))
            {
                return BadRequest("O email é obrigatório.");
            }

            if (string.IsNullOrEmpty(request.Key))
            {
                return BadRequest("A chave é obrigatória.");
            }

            // Verifique se a chave fornecida é igual à chave constante
            if (request.Key != RequiredKey)
            {
                return BadRequest("Chave inválida.");
            }

            var emails = GetEmails(); // Chame o método sem argumentos
            return Ok(emails);
        }

        private List<Email> GetEmails()
        {
            var emails = new List<Email>
            {
                new Email
                {
                    Remetente = "joao.silva@example.com",
                    Destinatario = "maria.souza@example.com",
                    Assunto = "Reunião de Projeto",
                    Conteudo = "Olá Maria, gostaria de confirmar a reunião para amanhã às 10h.",
                    DataHora = "2024-09-17 09:00"
                },
                new Email
                {
                    Remetente = "ana.santos@example.com",
                    Destinatario = "pedro.alves@example.com",
                    Assunto = "Proposta de Colaboração",
                    Conteudo = "Olá Pedro, estou enviando a proposta para nossa colaboração.",
                    DataHora = "2024-09-17 10:00"
                },
                new Email
                {
                    Remetente = "carlos.martins@example.com",
                    Destinatario = "lucas.costa@example.com",
                    Assunto = "Atualização do Projeto",
                    Conteudo = "Lucas, aqui está a atualização mais recente do projeto.",
                    DataHora = "2024-09-17 11:00"
                },
                new Email
                {
                    Remetente = "patricia.oliveira@example.com",
                    Destinatario = "giovana.pereira@example.com",
                    Assunto = "Documentos Necessários",
                    Conteudo = "Giovana, por favor, veja os documentos anexos.",
                    DataHora = "2024-09-17 12:00"
                },
                new Email
                {
                    Remetente = "felipe.silva@example.com",
                    Destinatario = "andreia.oliveira@example.com",
                    Assunto = "Reunião de Equipe",
                    Conteudo = "Andréia, confirmo a reunião de equipe para amanhã.",
                    DataHora = "2024-09-17 13:00"
                }
            };

            // Retorna os primeiros 5 emails, se houver menos que 5, retornará todos
            return emails.Take(5).ToList();
        }
    }
}
