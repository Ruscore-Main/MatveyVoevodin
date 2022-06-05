using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatveiVoevodin
{
    public static class ValidateTest
    {
        public static string ValidateRegistration(string Login, string Password, string Name, string Surname)
        {
            if (Login.Length <= 3)
            {
                return "Длина логина должна быть больше 3х символов";
            }

            if (Password.Length <= 4)
            {
                return "Длина пароля должна быть больше 4х символов";
            }

            if (Name.Length <= 1)
            {
                return "Имя должна быть больше 1-го символов";
            }

            if (Surname.Length <= 4)
            {
                return "Фамилия должна быть больше 4х символов";
            }

            return "Успешно";
        }
    }
}
