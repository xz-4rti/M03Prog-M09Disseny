using System.Diagnostics;

public class Program
{

    public static void Main(string[] args) 
    {
        List<Jugador> jugadores = new List<Jugador>
        {
            new Guerrero("Julian"),
            new Mago("Kagura"),
            new Arquero("Lesley")
        };

        List<Enemigo> enemigos =  new List<Enemigo>
        {
            new EnemigoBasico("Small Demons"),
            new EnemigoEspecial("Titans"),
            new Boss("Lucifer")
        };

        Iniciar();

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        int turn = 0;

        // Main Game loop
        while (jugadores.Count > 0 && enemigos.Count > 0)
        {

            foreach(var jugador in jugadores.ToArray())
            {
                if(enemigos.Count == 0) break;

                turn++;
                Console.WriteLine($" -- Turn: {turn} (Player) -- ");
                Console.WriteLine($"Attacker level ({jugador.Nombre}): {jugador.Nivel}\n");

                var enemigo = enemigos[new Random().Next(0, enemigos.Count)];

                Narrador.MostrarMensaje($"{jugador.Nombre} attacks {enemigo.Nombre}");
                int attackEnemigo = jugador.Atacar();
                enemigo.RecibirDanyo(attackEnemigo);
                Narrador.MostrarMensaje($"{enemigo.Nombre} recives {attackEnemigo} attack point. Enemy life: {enemigo.Vida} \n");
                
                if(!enemigo.EstaVivo()){

                    Narrador.MostrarMensaje($"{enemigo.Nombre} has been defeated!\n");
                    enemigos.Remove(enemigo);

                    jugador.SubirNivel();
                    Narrador.MostrarMensaje($"{jugador.Nombre} has leveled Up to {jugador.Nivel}!");

                    jugador.MejorarHabilidad(CalcularPuntos(enemigo));
                    Narrador.MostrarMensaje($"{jugador.Nombre} has recived {CalcularPuntos(enemigo)} points.");
                }

                // EVENTO RANDOM
                if (new Random().Next(0, 100) < 20) // 20% de probabilidad de evento
                {
                    RandomEvent(jugador);
                }
                
                Thread.Sleep(1000);
                Console.Clear();

            }

            foreach(var enemigo in enemigos.ToArray())
            {
                if(jugadores.Count == 0) break;
                turn++;
                Console.WriteLine($" -- Turn: {turn} (Enemy) -- ");
                Console.WriteLine($"Attacker level ({enemigo.Nombre}): {enemigo.Nivel}\n");

                var jugador = jugadores[new Random().Next(0, jugadores.Count)];

                Narrador.MostrarMensaje($"{enemigo.Nombre} attacks {jugador.Nombre}");
                int attackJugador = enemigo.Atacar();
                jugador.RecibirDanyo(attackJugador);
                Narrador.MostrarMensaje($"{jugador.Nombre} recives {attackJugador} attack point. Player life: {jugador.Vida} \n");
                
                if(!jugador.EstaVivo())
                {
                    Narrador.MostrarMensaje($"{jugador.Nombre} has been defeated.. \n");
                    jugadores.Remove(jugador);
                }

                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        stopwatch.Stop();
        Console.Clear();

        Console.WriteLine(@"  
          ________   __  _______  ____ _   _________  __
         / ___/ _ | /  |/  / __/ / __ \ | / / __/ _ \/ /
        / (_ / __ |/ /|_/ / _/  / /_/ / |/ / _// , _/_/ 
        \___/_/ |_/_/  /_/___/  \____/|___/___/_/|_(_) ");

        if(enemigos.Count == 0)
        {
            Narrador.MostrarMensajePrincipio(@"
            ┌─┐┬  ┌─┐┬ ┬┌─┐┬─┐  ┬ ┬┌─┐┌─┐  ┬ ┬┌─┐┌┐┌┬
            ├─┘│  ├─┤└┬┘├┤ ├┬┘  ├─┤├─┤└─┐  ││││ │││││
            ┴  ┴─┘┴ ┴ ┴ └─┘┴└─  ┴ ┴┴ ┴└─┘  └┴┘└─┘┘└┘o");
        } else if (jugadores.Count == 0) 
        {
            Narrador.MostrarMensajePrincipio(@"
            ┌─┐┌┐┌┌─┐┌┬┐┬┌─┐┌─┐  ┬ ┬┌─┐┬  ┬┌─┐  ┬ ┬┌─┐┌┐┌    
            ├┤ │││├┤ ││││├┤ └─┐  ├─┤├─┤└┐┌┘├┤   ││││ ││││    
            └─┘┘└┘└─┘┴ ┴┴└─┘└─┘  ┴ ┴┴ ┴ └┘ └─┘  └┴┘└─┘┘└┘oooo");
        }
    
        Narrador.MostrarMensaje($"\n                     -> Time Taken: {stopwatch.Elapsed:hh\\:mm\\:ss}");
        Narrador.MostrarMensaje($"                     -> Turns Taken: {turn}\n");

        MostrarResumen(jugadores, enemigos);

    }


    public static void Iniciar()
    {

        // Clear the console 
        Console.Clear();
        Console.WriteLine("\n");
        Narrador.MostrarMensajePrincipio(@" ██████╗ █████╗███╗   ██████████╗    ███████████████╗█████╗██████╗████████╗
██╔════╝██╔══██████╗ ██████╔════╝    ██╔════╚══██╔══██╔══████╔══██╚══██╔══╝
██║  ████████████╔████╔███████╗      ███████╗  ██║  █████████████╔╝  ██║   
██║   ████╔══████║╚██╔╝████╔══╝      ╚════██║  ██║  ██╔══████╔══██╗  ██║   
╚██████╔██║  ████║ ╚═╝ █████████╗    ███████║  ██║  ██║  ████║  ██║  ██║   
 ╚═════╝╚═╝  ╚═╚═╝     ╚═╚══════╝    ╚══════╝  ╚═╝  ╚═╝  ╚═╚═╝  ╚═╝  ╚═╝  ");
        Narrador.MostrarMensajePrincipio(@"       
     ┓ ┏┏┓┓ ┏┓┏┓┳┳┓┏┓  ┏┳┓┏┓  ┏┳┓┓┏┏┓  ┏┓┳┓┓┏┏┓┳┓┏┳┓┳┳┳┓┏┓  ┏┓┏┓┳┳┓┏┓╻
     ┃┃┃┣ ┃ ┃ ┃┃┃┃┃┣    ┃ ┃┃   ┃ ┣┫┣   ┣┫┃┃┃┃┣ ┃┃ ┃ ┃┃┣┫┣   ┃┓┣┫┃┃┃┣ ┃
     ┗┻┛┗┛┗┛┗┛┗┛┛ ┗┗┛   ┻ ┗┛   ┻ ┛┗┗┛  ┛┗┻┛┗┛┗┛┛┗ ┻ ┗┛┛┗┗┛  ┗┛┛┗┛ ┗┗┛•  ");
        Narrador.MostrarMensaje("                       THE GAME HAS STARTED......  \n");

        Thread.Sleep(2000);
        Console.Clear(); 
        
    }

    public static void RandomEvent(Jugador jugador)
    {
        var random = new Random();
        int evento = random.Next(1, 4);
        
        switch(evento) 
        {
            case 1:
                int bonus = random.Next(10, 20);
                jugador.Vida += bonus;
                Narrador.MostrarMensaje($"¡¡¡ Godly doctor was encounted! The player obtained {bonus} bonus life point >-< !!!");
                break;
            case 2:
                int penalization = random.Next(2, 15);
                jugador.Vida -= penalization;
                Narrador.MostrarMensaje($"*** Womp Womp the player just fell in the trap and lost {penalization} life point ***");
                break;
            case 3:
                int extrapoint = random.Next(5,15);
                jugador.MejorarHabilidad(extrapoint);
                Narrador.MostrarMensaje($"¡¡¡ WoW the player just found a treasure! {extrapoint} point was obtained !!!");

                break;
        }
    }
    
    public static void MostrarResumen(List<Jugador> jugadores, List<Enemigo> enemigos) 
    {
        Console.WriteLine("         --------------- TURN SUMMARY --------------");
        Console.WriteLine("         Information about the players or enemies that survived..\n");

        foreach(var jugador in jugadores.ToArray())
        {
            MostrarInformacion(jugador);
        }

        foreach(var enemigo in enemigos.ToArray())
        {
            MostrarInformacion(enemigo);
        }

        Console.WriteLine("         --------- It was fun see you next time!>< --------");
    }

    private static void MostrarInformacion(Personaje personaje)
    {
        Narrador.MostrarMensaje($"                     -> Name: {personaje.Nombre}");
        Narrador.MostrarMensaje($"                       - Level: {personaje.Nivel}");
        Narrador.MostrarMensaje($"                       - Health: {personaje.Vida}");
        if (personaje is Jugador jugador)
        {
            Narrador.MostrarMensaje($"                       - Points: {jugador.Puntohabilidad}\n");
        }
    }

    private static int CalcularPuntos(Enemigo enemigo)
    {
        return enemigo switch
        {
            Boss => 50,
            EnemigoEspecial => 20,
            EnemigoBasico => 10
        };
    }

}
