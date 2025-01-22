using System.Text.RegularExpressions;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("EXPRESIONES REGULARES");

        string text = "Los correos electrónicos son una forma común de comunicación en la era digital. Un correo electrónico consta de varias partes, como el remitente, el destinatario, el asunto y el cuerpo del mensaje. Algunos ejemplos de direcciones de correo electrónico son: usuario@gmail.com, contacto@empresa.es y teléfono 987654321 o 9876543210.";

        // 1- Identificar y mostrar todas las palabras que contienen la letra "e"
        Console.WriteLine("1- Palabras que contiene la letra \"e\":");
        foreach (Match match in Regex.Matches(text, @"\b\w*e\w*\b"))
        {
            Console.WriteLine(match.Value);
        }

        // 2- Buscar y mostrar todas las palabras que finalizan con la sílaba "dad".
        Console.WriteLine("2- Palabras que finalizan con la sílaba \"dad\"");
        foreach (Match match in Regex.Matches(text, @"\b\w*dad\b"))
        {
            Console.WriteLine(match.Value);
        }

        // 3- Localizar y mostrar todas las apariciones de la palabra "lenguajes" en el texto.
        Console.WriteLine("3- Palabras \"lenguajes\"");
        foreach (Match match in Regex.Matches(text, @"\blenguajes\b"))
        {
            Console.WriteLine(match.Value);
        }

        // 4- Identificar y mostrar todas las palabras que inician con la letra "s" y finalizan con la letra "n".
        Console.WriteLine("4- Palabras que inician con \"s\" y finalizan con \"n\"");
        foreach (Match match in Regex.Matches(text, @"\bs\w*n\b"))
        {
            Console.WriteLine(match.Value);
        }

        // 5- Buscar y mostrar todas las coincidencias con el formato de número de teléfono "9876543210".
        Console.WriteLine("5- Numero \"9876543210\"");
        foreach (Match match in Regex.Matches(text, @"\b9876543210\b"))
        {
            Console.WriteLine(match.Value);
        }

        // 6- Identificar y mostrar todas las direcciones de correo electrónico que finalizan con el dominio ".es".
        Console.WriteLine("6- Correo electronico que finalizan con el dominnio .es \"dad\"");
        foreach (Match match in Regex.Matches(text, @"\b[a\a-zA-Z0-9._%+-]+@[\w.-]+\.es\b"))
        {
            Console.WriteLine(match.Value);
        }

        // 7- Buscar y mostrar todas las palabras que inician con la letra "a" y poseen una longitud mínima de 5 caracteres.
        Console.WriteLine("7- Palabras que incian con la letra \"a\" y posseen una longitud minima de 5 characteres");
        foreach (Match match in Regex.Matches(text, @"\ba\w{4,}\b"))
        {
            Console.WriteLine(match.Value);
        }

        // 8- Identificar y mostrar todas las palabras que están compuestas únicamente por letras en minúscula.
        Console.WriteLine("8- Palabras compuestas por letras minusculas");
        foreach (Match match in Regex.Matches(text, @"\b[a-z]\b"))
        {
            Console.WriteLine(match.Value);
        }

        // 9- Sustituye Python por C#
        Console.WriteLine("9- Sustituye \"Python\" por \"C#\"");
        string textModificado = Regex.Replace(text, @"\bPython\b", "C#");
        Console.WriteLine(textModificado);

    }
}
