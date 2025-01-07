public class Narrador 
{
    public static void MostrarMensajePrincipio(string mensaje) {

        foreach (var c in mensaje) {
            Console.Write(c);
            Thread.Sleep(5);
        }
        Console.WriteLine();
    }
    public static void MostrarMensaje(string mensaje) {

        foreach (var c in mensaje) {
            Console.Write(c);
            Thread.Sleep(50);
        }
        Console.WriteLine();
    }

}