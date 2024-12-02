class Mago : Jugador{

    public int ContadorTurno { get; set; }
    public Mago(string nombre) 
    : base(nombre) 
    {
        Vida = 8; // Vida inicial de mago
    }

    public override int Atacar()
    {
        ContadorTurno++;
        // Ataquev addicional de +4 puntos en cada tirada
        return base.Atacar() + 4;
    }

    public void RecuperarVida() 
    {
        if(ContadorTurno % 3 == 0) 
        {
            Vida += 2;
        }
    }
}