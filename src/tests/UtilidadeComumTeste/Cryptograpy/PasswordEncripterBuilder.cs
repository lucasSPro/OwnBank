

using GestorAvaliacao.Application.Services.Cryptography;

namespace UtilidadesComumsTestes.Cryptograpy
{
    public class PasswordEncripterBuilder
    {
        public static PasswordEncripter Build() => new PasswordEncripter("1234ABC");
    }
}
