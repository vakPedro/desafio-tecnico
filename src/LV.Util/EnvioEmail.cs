using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LV.Util
{
    public class EnvioEmail
    {
        public static bool enviarEmail(string titulo, string mensagem, string email)
        {
            bool retorno = true;
            try
            {
                using (SmtpClient clienteSmtp = new SmtpClient())
                {
                    using (MailMessage msgEmail = new MailMessage())
                    {
                        msgEmail.To.Add(email);
                        msgEmail.Subject = titulo;
                        msgEmail.Body = mensagem;
                        clienteSmtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        clienteSmtp.Send(msgEmail);
                    }
                }
            }
            catch (Exception)
            {
                retorno = false;
            }
            return retorno;
        }
    }
}
