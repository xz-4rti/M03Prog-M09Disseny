public class Program
{
    static List<Enemigo> enemigos;
    static DateTime inicioPartida;

    static void Main() 
    {
        try {
        enemigos = new List<Enemigo>();
        Iniciar();

        } catch (Exception e) {
            Console.WriteLine("Error: " + e.Message);
        }
    }

    static void Iniciar()
    {
        // Iniciar El contador de Partida
        inicioPartida = DateTime.Now;

        Console.WriteLine("GAME START!");
        
    }

    public void AgregarEnemigo(Enemigo enemigo)
    {
        enemigos.Add(enemigo);
    }
    
}
