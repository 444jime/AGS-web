using AGS_Models.DTO;
using AGS_services.Repositories;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AGS_services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> EnviarCorreoContacto(ContactoDTO contacto)
        {
            try
            {
                var emailOrigen = _configuration["EmailSettings:EmailOrigen"];
                var password = _configuration["EmailSettings:Password"];
                var host = _configuration["EmailSettings:Host"];
                var port = int.Parse(_configuration["EmailSettings:Port"]);

                var smtpClient = new SmtpClient(host, port)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(emailOrigen, password)
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(emailOrigen),
                    Subject = $"Nuevo Contacto Web: {contacto.NombreCompleto} - {contacto.TipoProyecto}",
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(emailOrigen);

                mailMessage.Body = $@"
                    <h1>Nuevo Mensaje de Contacto</h1>
                    <hr/>
                    <p><strong>Nombre:</strong> {contacto.NombreCompleto}</p>
                    <p><strong>Email del Cliente:</strong> {contacto.Email}</p>
                    <p><strong>Teléfono:</strong> {contacto.Telefono}</p>
                    <p><strong>Tipo de Proyecto:</strong> {contacto.TipoProyecto}</p>
                    <p><strong>Mensaje:</strong></p>
                    <p>{contacto.Mensaje}</p>
                ";

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al enviar el correo: " + e.Message);
                return false;
            }
        }
    }
}