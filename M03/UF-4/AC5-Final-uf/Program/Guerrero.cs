class Guerrero : Jugador
{

    public int ContadorTurno = 0;
    public Guerrero(string nombre) : base(nombre)
    {
        Vida = 12; // Vida inicial de guerrero
    }

    public override int Atacar() 
    {
        ContadorTurno++;
        // Ataquev addicional de +2 puntos en cada tirada
        return base.Atacar() + 2;
    }

    // Methodo para saber si el guerrero puede bloquear el ataque 
    public bool PuedeBloquearAtque() 
    {
        // Cada 3 tres turno puede bloquear una tirada enemiga
        return ContadorTurno % 3 == 0;
    }
}