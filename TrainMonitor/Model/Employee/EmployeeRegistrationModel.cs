using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TrainMonitor.Model.Employee
{
   public  class EmployeeRegistrationModel
    {
        public static int SendCode(string email)
        {
            Random rnd = new Random();
            int value = rnd.Next(100000, 999999);
            try
            {
                //Где пропущено ставим свои значения, без них отправка письма работать не будет
                //тут пишется email и имя отправителя
                MailAddress from = new MailAddress("", "");
                // кому отправляем
                MailAddress to = new MailAddress(email);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = $"Код регистрации";
                // текст письма
                m.Body = $"Ваш код регистрации {value}";
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                // логин и пароль
                smtp.UseDefaultCredentials = false;
                //тут логин и пароль, сейчас настроео чере mail.ru, а там лучше всего сделать для внешний служб отдельный пароль
                smtp.Credentials = new NetworkCredential("", "");
                smtp.EnableSsl = true;
                smtp.Send(m);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            return value;
        }
    }
}
