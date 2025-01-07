using System;
using System.Collections.Generic;
using RobotManagement;

public partial class Program
{
    static List<Droide> droides = new List<Droide>();
    static void Main()
    {
        int opcion;

        do
        {
            Console.WriteLine("SISTEMA GESTION DE ROBOTS");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1- Almacenar Robots");
            Console.WriteLine("2- Mostrar Robots segun su categoria");
            Console.WriteLine("3- Salir");
            Console.WriteLine(" ");
            Console.WriteLine("Introduce una opcion: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion) {
                case 1:
                    almanecarRobot();
                    break;
                case 2:
                    mostrarPorCategoria();
                    break;
                case 3:
                    opcion = 3;
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
        } while (opcion != 3);
        
    }

    static void almanecarRobot() {

        Console.WriteLine("TIPO DE DROIDE");
        Console.WriteLine("1- Droide Protocolo");
        Console.WriteLine("2- Droide Astromecánico");
        Console.WriteLine("3- Droide Combate");
        Console.WriteLine("Introduce la opcion de droide: ");
        int opcionDroide = int.Parse(Console.ReadLine());

        Console.WriteLine("Introduce el nombre: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Introduce el tipo de Unidad: ");
        string tipoUnidad = Console.ReadLine();
        Console.WriteLine("Introduce el NivelBateria: ");
        string nivelBateria = Console.ReadLine();

        switch (opcionDroide)
        {
            case 1:
                droides.Add(new DroideProtocolo(nombre, tipoUnidad, nivelBateria));
                break;
            case 2:
                Console.WriteLine("Introduce la ultima reparacion");
                string ultimaReparacion = Console.ReadLine();   
                droides.Add(new DroideAstromecanico(nombre, tipoUnidad, nivelBateria, ultimaReparacion));
                break;
            case 3:
                Console.WriteLine("Introduce el nivel potencia de fuego");
                int nivelPotenciaFuego = int.Parse(Console.ReadLine());

                droides.Add(new DroideCombate(nombre, tipoUnidad, nivelBateria, nivelPotenciaFuego));
                break;
            default:
                Console.WriteLine("Opcion no valida");
                break;
        }

        Console.WriteLine("Droide añadido correctamente.");
    }

    static void mostrarPorCategoria() {

        Console.WriteLine("MOSTRAR ROBOTS POR CATEGORIA");
        Console.WriteLine("1- Droide Protocolo");
        Console.WriteLine("2- Droide Astromecánico");
        Console.WriteLine("3- Droide Combate");
        Console.WriteLine("Introduce la opcion de droide: ");
        int opcionDroide = int.Parse(Console.ReadLine());

        switch (opcionDroide)
        {
            case 1:
                foreach (var droide in droides)
                {
                    if (droide is DroideProtocolo) {
                        droide.showInfo();
                    }
                }
                break;
            case 2:
                foreach (var droide in droides)
                {
                    if (droide is DroideAstromecanico) {
                        droide.showInfo();
                    }
                }
                break;
            case 3:
                foreach (var droide in droides)
                {
                    if (droide is DroideCombate) {
                        droide.showInfo();
                    }
                }
                break;
            default:
                Console.WriteLine("Opcion tipo de robot no válido.");
                break;
        }

    }

}