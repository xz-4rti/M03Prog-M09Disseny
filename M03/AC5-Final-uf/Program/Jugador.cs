class Jugador : Personaje {

    public Jugador(string nombre, int puntovida, int nivel, int puntohabilidad) 
    : base(nombre, puntovida, nivel, puntohabilidad) {
        
    }

    public int CalcularPuntoHabilidad() {
        var ran = new Random();
        return ran.Next(0,11);
    }
}