class Arquero : Jugador{

    public int ContadorTurno { get; set; }
    public Arquero(string nombre) : base(nombre) 
    {
    }

    // Ataque adicional de +3 puntos en cada tirada.
    public override int Atacar()
    {
        // Ataquev addicional de +3 puntos en cada tirada
        return base.Atacar() + 3;
    }

    public bool PuedeRealizarAttaqueDouble() 
    {
        // Cada 3 tres turno puede bloquear una tirada enemiga
        return ContadorTurno % 3 == 0;
    }
}