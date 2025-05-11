using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using app.Models;

namespace app.Servicios
{
    public class ServicioEmailGmail
    {
        private readonly IConfiguration configuration;
        public ServicioEmailGmail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Enviar(ContactoViewModel contacto)
        {
            var emailEmisor = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:EMAIL");
            var passwordEmisor = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:PASSWORD");
            var host = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:HOST");
            var puerto = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:PUERTO");


            var smtpCliente = new SmtpClient(host, puerto);
            smtpCliente.EnableSsl = true;
            smtpCliente.UseDefaultCredentials = false;

            smtpCliente.Credentials = new NetworkCredential(emailEmisor, passwordEmisor);
            var mensaje = new MailMessage(emailEmisor, emailEmisor, $"El cliente {contacto.Nombre} ({contacto.Email}) quiere contactarte", contacto.Mensaje);
        }
    }
}