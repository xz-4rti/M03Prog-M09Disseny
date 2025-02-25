class Program
{
    static void Main()
    {
        List<Persona> personas = new List<Persona>
        {
        new("Juan", 30),
        new("Pedro", 31),
        new("Miguel", 25),
        new("Luís", 36),
        new("José", 25),
        };


        // SIN EXPRESIONES LAMBDA

        Console.WriteLine("SIN EXPRESIONES LAMBDA");

        // 1- Encuentra el nombre de la persona más joven
        string nombrePersonaMasJoven = 
            (from p in personas orderby p.Edad select p.Nombre)
            .First();

        Console.WriteLine($"La persona más joven es {nombrePersonaMasJoven}");

        // 2- Calcula la edad promedio de las personas
        double edadPromedio = 
            (from p in personas select p.Edad)
            .Average();

        Console.WriteLine($"La edad promedio de las personas es {edadPromedio}");

        // 3- Encuentra la persona personas mayores de 25 años y ordenlas por edad de forma descendente
        var personasMayoresDe25 = 
            from p in personas where p.Edad > 25 orderby p.Edad descending select p;

        Console.WriteLine("Personas mayores de 25 años:");
        foreach (var persona in personasMayoresDe25)
        {
            Console.WriteLine($"{persona.Nombre} - {persona.Edad} años");
        }

        // 4- Verifica si todas las personas tienen más de 18 años
        bool todasMayoresDe18 = 
            (from p in personas select p.Edad)
            .All(p => p > 18);

        Console.WriteLine($"Todas las personas tienen más de 18 años: {todasMayoresDe18}");

        // 5- Encuentra la persona más joven en la lista personas que tenga un nombre que contenga la letra "a"
        string nombrePersonaMasJovenConA = 
            (from p in personas where p.Nombre.Contains("a") orderby p.Edad select p.Nombre)
            .First();

        Console.WriteLine($"La persona más joven con nombre que contiene la letra 'a' es {nombrePersonaMasJovenConA}");

        // 6- Agrupa las personas por su primera letra de nombre y muestra cuántas personas hay en cada grupo
        var personasAgrupadasPorPrimeraLetra = 
            from p in personas
            group p by p.Nombre[0] into grupo
            select new { Letra = grupo.Key, Cantidad = grupo.Count() };

        Console.WriteLine("Personas agrupadas por la primera letra de su nombre:");
        foreach (var grupo in personasAgrupadasPorPrimeraLetra)
        {
            Console.WriteLine($"{grupo.Letra}: {grupo.Cantidad}");
        }


        // CON EXPRESIONES LAMBDA

        Console.WriteLine("SIN EXPRESIONES LAMBDA");

        // 1- Encuentra el nombre de la persona más joven que tenga una edad impar en la lista persona
        string nombrePersonaMasJovenEdadImpar = personas
            .Where(p => p.Edad % 2 != 0)
            .OrderBy(p => p.Edad)
            .First()
            .Nombre;
        Console.WriteLine($"La persona más joven con edad impar es {nombrePersonaMasJovenEdadImpar}");

        // 2- Elimina a todas las personas cuya edades sean múltiplos de 5 de la lista personas y muestra la lista resultante
        var personasSinEdadesMultiplosDe5 = personas
            .Where(p => p.Edad % 5 != 0)
            .ToList();
        Console.WriteLine("Personas sin edades múltiplos de 5:");
        foreach (var persona in personasSinEdadesMultiplosDe5)
        {
            Console.WriteLine($"{persona.Nombre} - {persona.Edad} años");
        }

        // 3- Calcula la diferencia de edad la persona más joven y la persona más vieja en la lista personas
        int diferenciaEdad = personas
            .Max(p => p.Edad) - personas
            .Min(p => p.Edad);
        Console.WriteLine($"La diferencia de edad entre la persona más joven y la persona más vieja es {diferenciaEdad}");

    }
}
