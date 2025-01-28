using System.Text.RegularExpressions;

internal class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("EXPRESIONES REGULARES COMPLEJAS");

        // 1-Valida una dirección de correo electrónico (ej. usuario@dominio.com)
        Console.WriteLine("Introduce Dirreción de correo electronico: ");
        string correo = Console.ReadLine();

        // or @"[A-Za-z]+@[A-Za-z]+\.[A-Za-z][A-Za-z]m"
        Regex regexCorreo = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        Match matchCorreo = regexCorreo.Match(correo);

        if (matchCorreo.Success)
        {
            Console.WriteLine("Dirreccion de correo electronico valido");
        }
        else
        {
            Console.WriteLine("Dirreccion de correo electronico invalido");
        }

        // 2-Valida un número de teléfono con formato de 10 dígitos (ej. 123-456-7890).
        Console.WriteLine("Introduce Numero de telefono: ");
        string telefono = Console.ReadLine();

        Regex regexTele = new Regex(@"^\d{3}-\d{3}-\d{4}$");
        Match matchTele = regexTele.Match(telefono);

        if (matchTele.Success)
        {
            Console.WriteLine("Numero de telefono valido");
        }
        else
        {
            Console.WriteLine("Numero de telefono invalido");
        }

        // 3-Valida una fecha en formato día/mes/año ej. 29/02/2024)
        Console.WriteLine("Introduce Fecha en formato día/mes/anyo: ");
        string fecha = Console.ReadLine();

        Regex regexFecha = new Regex(@"^\d{2}/\d{2}/\d{4}$");
        Match matchFecha = regexFecha.Match(fecha);

        if (matchFecha.Success)
        {
            Console.WriteLine("Fecha valido");
        }
        else
        {
            Console.WriteLine("Fecha invalido");
        }

        // 4-Valida una dirección IP en formato IPv4 (ej. 192.168.1.1)
        Console.WriteLine("Introduce dirección IP en formato IPv4 (ej. 192.168.1.1): ");
        string ip = Console.ReadLine();

        Regex regexIp = new Regex(@"^\d{3}\.\d{3}\.\d{1}\.\d{1}$");
        Match matchIp = regexIp.Match(ip);

        if (matchIp.Success)
        {
            Console.WriteLine("Ip valido");
        }
        else
        {
            Console.WriteLine("Ip invalido");
        }

        // 5-Valida un código postal de 5 dígitos (ej. 12345)
        Console.WriteLine("Introduce código postal de 5 dígitos (ej. 12345): ");
        string codigo = Console.ReadLine();

        Regex regexCodigo = new Regex(@"^\d{5}$");
        Match matchCodigo = regexCodigo.Match(codigo);

        if (matchCodigo.Success)
        {
            Console.WriteLine("Codigo valido");
        }
        else
        {
            Console.WriteLine("Codigo invalido");
        }

        // 6-Valida una palabra que contenga solo letras, sin números ni caracteres especiales (ej. "Hola")
        Console.WriteLine("Introduce una palabra que contenga solo letras, sin números ni caracteres especiales (ej. Hola): ");
        string palabra = Console.ReadLine();

        Regex regexPalabra = new Regex(@"^[A-Za-z]+$");
        Match matchPalabra = regexPalabra.Match(palabra);

        if (matchPalabra.Success)
        {
            Console.WriteLine("Palabra valido");
        }
        else
        {
            Console.WriteLine("Palabra invalido");
        }

        // 7-Valida un número entero positivo, que puede tener más de un dígito (ej. 123).
        Console.WriteLine("Introduce un número entero positivo, que puede tener más de un dígito (ej. 123): ");
        string numero = Console.ReadLine();

        Regex regexNumero = new Regex(@"^\d+$");
        Match matchNumero = regexNumero.Match(numero);

        if (matchNumero.Success)
        {
            Console.WriteLine("Numero valido");
        }
        else
        {
            Console.WriteLine("Numero invalido");
        }

        // 8-Valida una URL (ej. http://www.ejemplo.com/).
        Console.WriteLine("Introduce una URL (ej. http://www.ejemplo.com/).: ");
        string url = Console.ReadLine();

        Regex regexUrl = new Regex(@"^(http|https):\/\/[^\s$.?#].[^\s]*$");
        Match matchUrl = regexUrl.Match(url);

        if (matchUrl.Success)
        {
            Console.WriteLine("Url valido");
        }
        else
        {
            Console.WriteLine("Url invalido");
        }

        // 9-Valida un código de color hexadecimal (ej. #A3C1D7).
        Console.WriteLine("Introduce un código de color hexadecimal (ej. #A3C1D7).: ");
        string color = Console.ReadLine();

        Regex regexColor = new Regex(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$");
        Match matchColor = regexColor.Match(color);

        if (matchColor.Success)
        {
            Console.WriteLine("Código de color hexadecimal valido");
        }
        else
        {
            Console.WriteLine("Código de color hexadecimal invalido");
        }

        // 10-Valida un número decimal con punto (ej. 12.23)
        Console.WriteLine("Introduce un número decimal con punto (ej. 12.23): ");
        string numdecimal = Console.ReadLine();

        Regex regexDecimal = new Regex(@"^\d+\.\d+$");
        Match matchDecimal = regexDecimal.Match(numdecimal);

        if (matchDecimal.Success)
        {
            Console.WriteLine("Numero Decimal valido");
        }
        else
        {
            Console.WriteLine("Numero Decimal invalido");
        }

    }
}