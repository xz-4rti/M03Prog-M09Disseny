public class Jugador : Personaje {

    public int Puntohabilidad { get; set; }
    private Random random;

    // El jugador tiene punto de vida inicial y nivel 10 y punto de habilidad 0
    public Jugador(string nombre) : base(nombre, 10, 10) 
    {
        Puntohabilidad = 0;
        random = new Random();
    }

    // Methodo para calcular el nivel del ataque
    public override int Atacar() 
    {
        // Dos dados de 6 caras
        int tirada = random.Next(1, 7) + random.Next(1, 7);
        return  tirada + (int)(Puntohabilidad * 0.10);
    }

    // Methodo para mejorar habilidad de jugador
    public void MejorarHabilidad(int puntosGanado) 
    {
        Puntohabilidad += puntosGanado;
    }

    // Methodo para subir nivel del jugador
    public void SubirNivel()
    {
        Nivel++;
    }

}