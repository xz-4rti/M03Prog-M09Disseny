public class Program
{
    public static LinkedList<Usuario> ListaUsuarios = new LinkedList<Usuario>();
    public static LinkedList<Empleado> ListaEmpleados = new LinkedList<Empleado>();
    public static LinkedList<VideoJuego> ListaVideoJuegos = new LinkedList<VideoJuego>();

    static void Main(string[] args)
    {
        int option;

        do
        {
            MostrarMenu();

            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Por favor, introduce un número válido.");
                continue;
            }

            switch (option)
            {
                case 1:
                    AltaDeUsuarios();
                    break;
                case 2:
                    BajaDeUsuarios();
                    break;
                case 3:
                    AltaDeEmpleados();
                    break;
                case 4:
                    BajaDeEmpleados();
                    break;
                case 5:
                    AltaDeVideoJuegos();
                    break;
                case 6:
                    BajaDeVideoJuegos();
                    break;
                case 7:
                    ListaVideoJuegosDisponibles();
                    break;
                case 8:
                    ListaVideoJuegosAlquilados();
                    break;
                case 9:
                    ListaVideoJuegosPorUsuario();
                    break;
                case 10:
                    ListaVideoJuegosConPrestados();
                    break;
                case 11:
                    AlquilarVideoJuego();
                    break;
                case 0:
                    Console.WriteLine("Saliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (option != 0);


    }

    private static void MostrarMenu()
    {

        Console.WriteLine("");
        Console.WriteLine("SISTEMA DE ALQUILER DE VIDEOJUEGOS");
        Console.WriteLine("0  -  Salir");
        Console.WriteLine("1  -  Alta de Usuarios");
        Console.WriteLine("2  -  Baja de Usuarios");
        Console.WriteLine("3  -  Alta de Empleados");
        Console.WriteLine("4  -  Baja de Empleados");
        Console.WriteLine("5  -  Alta de Videojuegos");
        Console.WriteLine("6  -  Baja de Videojuegos");
        Console.WriteLine("7  -  Listar Videojuegos disponibles");
        Console.WriteLine("8  -  Listar videojuegos alquilados");
        Console.WriteLine("9  -  Listar videojuegos por usuario");
        Console.WriteLine("10 -  Listar usuarios con juegos prestados");
        Console.WriteLine("11 -  Alquillar Juego");
        Console.WriteLine("");
        Console.WriteLine("Introduce una opción: ");
    }

    private static void AltaDeUsuarios()
    {
        Console.Clear();
        Console.WriteLine("ALTA DE USUARIOS");
        Console.WriteLine("----------------");
        Console.WriteLine("Introduce el nombre del usuario: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Introduce el apellido del usuario: ");
        string apellido = Console.ReadLine();
        Console.WriteLine("Introduce el edad del usuario: ");
        int edad = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Introduce la direccion: ");
        string direccion = Console.ReadLine();
        Console.WriteLine("Introduce el telefono: ");
        int telefono = Convert.ToInt32(Console.ReadLine());

        Usuario usuario = new Usuario(nombre, apellido, edad, direccion, telefono);
        ListaUsuarios.AddLast(usuario);

        Console.WriteLine("Usuario añadido correctamente.");
        Console.WriteLine("");
    }

    private static void BajaDeUsuarios()
    {
        Console.Clear();
        Console.WriteLine("BAJA DE USUARIOS");
        Console.WriteLine("----------------");

        Console.WriteLine("Introduce el nombre del empleado a eliminar: ");
        string nombre = Console.ReadLine();

        Usuario usuario = BuscarUsuario(nombre);
        if (usuario != null)
        {
            ListaUsuarios.Remove(usuario);
            Console.WriteLine("Usuario eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Usuario no encontrado.");
        }
        Console.WriteLine("");

    }

    private static void AltaDeEmpleados()
    {
        Console.Clear();
        Console.WriteLine("ALTA DE EMPLEADOS");
        Console.WriteLine("-----------------");

        Console.WriteLine("Introduce el nombre del empleado: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Introduce el apellido del empleado: ");
        string apellido = Console.ReadLine();
        Console.WriteLine("Introduce el edad del empleado: ");
        int edad = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Introduce la direccion: ");
        string direccion = Console.ReadLine();
        Console.WriteLine("Introduce el telefono: ");
        int telefono = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Introduce la categoria: ");
        string categoria = Console.ReadLine();
        Console.WriteLine("Introduce el salario: ");
        decimal salario = Convert.ToDecimal(Console.ReadLine());

        Empleado empleado = new Empleado(nombre, apellido, edad, direccion, telefono, categoria, salario);
        ListaEmpleados.AddLast(empleado);

        Console.WriteLine("Empleado añadido correctamente.");
        Console.WriteLine("");
    }

    private static void BajaDeEmpleados()
    {
        Console.Clear();
        Console.WriteLine("BAJA DE EMPLEADOS");
        Console.WriteLine("-----------------");

        Console.Write("Introduce el nombre del empleado a eliminar: ");
        string nombre = Console.ReadLine();

        Empleado empleado = BuscarEmpleado(nombre);
        if (empleado != null)
        {
            ListaEmpleados.Remove(empleado);
            Console.WriteLine("Empleado eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
        Console.WriteLine("");
    }

    private static void AltaDeVideoJuegos()
    {
        Console.Clear();
        Console.WriteLine("ALTA DE VIDEOJUEGOS");
        Console.WriteLine("-------------------");

        Console.WriteLine("Introduce el titulo del juego: ");
        string titulo = Console.ReadLine();
        Console.WriteLine("Introduce el año de lanzamiento: ");
        int anyolanzamiento = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Introduce la tematica: ");
        string tematica = Console.ReadLine();
        Console.WriteLine("Introduce el estudio: ");
        string estudio = Console.ReadLine();


        VideoJuego juego = new VideoJuego(titulo, anyolanzamiento, tematica, estudio);
        ListaVideoJuegos.AddLast(juego);
        Console.WriteLine("Videojuego añadido correctamente.");
        Console.WriteLine("");

    }
    private static void BajaDeVideoJuegos()
    {
        Console.Clear();
        Console.WriteLine("BAJA DE VIDEOJUEGOS");
        Console.WriteLine("-------------------");

        Console.Write("Introduce el título del videojuego a eliminar: ");
        string titulo = Console.ReadLine();

        VideoJuego juego = BuscarVideoJuego(titulo);
        if (juego != null)
        {
            ListaVideoJuegos.Remove(juego);
            Console.WriteLine("Videojuego eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Videojuego no encontrado.");
        }
        Console.WriteLine("");
    }

    private static void ListaVideoJuegosDisponibles()
    {
        Console.Clear();
        Console.WriteLine("LISTA DE VIDEOJUEGOS DISPONIBLES");
        Console.WriteLine("--------------------------------");

        bool hayDisponibles = false;

        if (ListaVideoJuegos.Count == 0)
        {
            Console.WriteLine("No hay videojuegos registrados.");
        }
        else
        {
            foreach (VideoJuego videojuego in ListaVideoJuegos)
            {
                // Comprobar si el juego está alquilado por algún usuario
                bool alquilado = ListaUsuarios.Any(usuario => usuario.JuegosAlquilados.Contains(videojuego));
                if (!alquilado)
                {
                    Console.WriteLine(videojuego);
                    hayDisponibles = true;
                }
            }

            if (!hayDisponibles)
            {
                Console.WriteLine("No hay videojuegos disponibles actualmente.");
            }
        }

        Console.WriteLine("");
    }
    
    private static void ListaVideoJuegosAlquilados()
    {
        Console.Clear();
        Console.WriteLine("VIDEOJUEGOS ALQUILADOS");
        Console.WriteLine("---------------------");

        bool hayAlquilados = false;

        foreach (Usuario usuario in ListaUsuarios)
        {
            foreach (VideoJuego juego in usuario.JuegosAlquilados)
            {
                Console.WriteLine(juego);
                hayAlquilados = true;
            }
        }

        if (!hayAlquilados)
        {
            Console.WriteLine("No hay videojuegos alquilados.");
        }

        Console.WriteLine("");
    }

    private static void ListaVideoJuegosPorUsuario()
    {
        Console.Clear();
        Console.WriteLine("VIDEOJUEGOS POR USUARIO");
        Console.WriteLine("-----------------------");

        Console.Write("Introduce el nombre del usuario: ");
        string nombre = Console.ReadLine();

        Usuario usuario = BuscarUsuario(nombre);
        if (usuario != null)
        {
            if (usuario.JuegosAlquilados.Count == 0)
            {
                Console.WriteLine($"{usuario.Nombre} no ha alquilado ningún videojuego.");
            }
            else
            {
                Console.WriteLine($"Juegos alquilados por {usuario.Nombre}:");
                foreach (VideoJuego juego in usuario.JuegosAlquilados)
                {
                    Console.WriteLine(juego);
                }
            }
        }
        else
        {
            Console.WriteLine("Usuario no encontrado.");
        }
        Console.WriteLine("");
    }

    private static void ListaVideoJuegosConPrestados()
    {
        Console.Clear();
        Console.WriteLine("USUARIOS CON JUEGOS PRESTADOS");
        Console.WriteLine("-----------------------------");

        bool hayPrestados = false;

        foreach (Usuario usuario in ListaUsuarios)
        {
            if (usuario.JuegosAlquilados.Count > 0)
            {
                Console.WriteLine(usuario);
                hayPrestados = true;
            }
        }

        if (!hayPrestados)
        {
            Console.WriteLine("No hay usuarios con juegos prestados.");
        }

        Console.WriteLine("");
    }

    private static void AlquilarVideoJuego()
    {
        Console.Clear();
        Console.WriteLine("ALQUILAR VIDEOJUEGO");
        Console.WriteLine("-------------------");

        // Buscar usuario
        Console.Write("Introduce el nombre del usuario que alquilará el videojuego: ");
        string nombreUsuario = Console.ReadLine();
        Usuario usuario = BuscarUsuario(nombreUsuario);
        if (usuario == null)
        {
            Console.WriteLine("Usuario no encontrado.");
            return;
        }

        // Buscar videojuego
        Console.Write("Introduce el título del videojuego a alquilar: ");
        string tituloJuego = Console.ReadLine();
        VideoJuego juego = BuscarVideoJuego(tituloJuego);
        if (juego == null)
        {
            Console.WriteLine("Videojuego no encontrado.");
            return;
        }

        // Alquilar el juego al usuario
        foreach (Usuario u in ListaUsuarios)
        {
            if (u.JuegosAlquilados.Contains(juego))
            {
                Console.WriteLine($"El videojuego '{juego.Titulo}' ya está alquilado por {u.Nombre}. No se puede alquilar de nuevo.");
                return;
            }
        }

        // Add the game to the user's rented list and update the game's rental count
        usuario.JuegosAlquilados.AddLast(juego);
        juego.VecesAlquilado++;
        Console.WriteLine($"El videojuego '{juego.Titulo}' ha sido alquilado por {usuario.Nombre}.");
        Console.WriteLine("");
    }

    private static Usuario BuscarUsuario(string nombre)
    {
        foreach (Usuario usuario in ListaUsuarios)
        {
            if (usuario.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                return usuario;
            }
        }
        return null;
    }

    private static Empleado BuscarEmpleado(string nombre)
    {
        foreach (Empleado empleado in ListaEmpleados)
        {
            if (empleado.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                return empleado;
            }
        }
        return null;
    }

    private static VideoJuego BuscarVideoJuego(string titulo)
    {
        foreach (VideoJuego juego in ListaVideoJuegos)
        {
            if (juego.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                return juego;
            }
        }
        return null;
    }
}
