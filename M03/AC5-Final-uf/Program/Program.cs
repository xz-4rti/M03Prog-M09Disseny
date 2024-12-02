public class Program
{
    private Jugador jugador;
    private List<Enemigo> enemigos;
    private DateTime inicioPartida;

    public Program(Jugador jugador)
    {
        this.jugador = jugador;
        enemigos = new List<Enemigo>();
        inicioPartida = DateTime.Now;
    }

    public void AgregarEnemigo(Enemigo enemigo)
    {
        enemigos.Add(enemigo);
    }

    public void Iniciar()
    {
        Console.WriteLine($"¡Bienvenido {jugador.Nombre} a la aventura!");
        int turno = 1;

        foreach (var enemigo in enemigos)
        {
            Console.WriteLine($"\nTurno {turno}: Combate contra {enemigo.Nombre} (Nivel {enemigo.Nivel}, Vida {enemigo.Vida})");
            while (jugador.EstaVivo && enemigo.EstaVivo)
            {
                int ataqueJugador = jugador.Atacar();
                enemigo.RecibirDanio(ataqueJugador);
                Console.WriteLine($"{jugador.Nombre} ataca con {ataqueJugador} puntos de daño.");

                if (!enemigo.EstaVivo)
                {
                    Console.WriteLine($"¡{enemigo.Nombre} ha sido derrotado!");
                    jugador.SubirNivel();
                    break;
                }

                int ataqueEnemigo = enemigo.Atacar();
                jugador.RecibirDanio(ataqueEnemigo);
                Console.WriteLine($"{enemigo.Nombre} ataca con {ataqueEnemigo} puntos de daño.");
            }

            turno++;
            if (!jugador.EstaVivo)
            {
                Console.WriteLine("Has sido derrotado. Fin del juego.");
                return;
            }
        }

        Console.WriteLine("\n¡Has completado la aventura!");
        TimeSpan duracion = DateTime.Now - inicioPartida;
        Console.WriteLine($"Duración total: {duracion.Hours:D2}:{duracion.Minutes:D2}:{duracion.Seconds:D2}");
    }
}
