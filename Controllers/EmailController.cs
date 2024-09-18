using Microsoft.AspNetCore.Mvc;
using email_api.Models; // Certifique-se de que est� correto

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
                return BadRequest("Dados inv�lidos.");
            }

            if (string.IsNullOrEmpty(request.SendEmail))
            {
                return BadRequest("O email � obrigat�rio.");
            }

            if (string.IsNullOrEmpty(request.Key))
            {
                return BadRequest("A chave � obrigat�ria.");
            }

            // Verifique se a chave fornecida � igual � chave constante
            if (request.Key != RequiredKey)
            {
                return BadRequest("Chave inv�lida.");
            }

            var emails = GetEmails(); // Chame o m�todo sem argumentos
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
                    Assunto = "Reuni�o de Projeto",
                    Conteudo = "Ol� Maria, gostaria de confirmar a reuni�o para amanh� �s 10h.",
                    DataHora = "2024-09-17 09:00"
                },
                new Email
                {
                    Remetente = "ana.santos@example.com",
                    Destinatario = "pedro.alves@example.com",
                    Assunto = "Proposta de Colabora��o",
                    Conteudo = "Ol� Pedro, estou enviando a proposta para nossa colabora��o.",
                    DataHora = "2024-09-17 10:00"
                },
                new Email
                {
                    Remetente = "carlos.martins@example.com",
                    Destinatario = "lucas.costa@example.com",
                    Assunto = "Atualiza��o do Projeto",
                    Conteudo = "Lucas, aqui est� a atualiza��o mais recente do projeto.",
                    DataHora = "2024-09-17 11:00"
                },
                new Email
                {
                    Remetente = "patricia.oliveira@example.com",
                    Destinatario = "giovana.pereira@example.com",
                    Assunto = "Documentos Necess�rios",
                    Conteudo = "Giovana, por favor, veja os documentos anexos.",
                    DataHora = "2024-09-17 12:00"
                },
                new Email
                {
                    Remetente = "felipe.silva@example.com",
                    Destinatario = "andreia.oliveira@example.com",
                    Assunto = "Reuni�o de Equipe",
                    Conteudo = "Andr�ia, confirmo a reuni�o de equipe para amanh�.",
                    DataHora = "2024-09-17 13:00"
                }
            };

            // Retorna os primeiros 5 emails, se houver menos que 5, retornar� todos
            return emails.Take(5).ToList();
        }
    }
}
