public class Boss : Enemigo
{

    public int Resistencia {get; set;}
    private int ContadorTurno = 0;
    public Boss(string nombre) : base(nombre, 15, 20)
    {
        Resistencia = 5;
    }

    public virtual void RecibirDanyo(int danyo)
    {
        if (Resistencia > 0) 
        {
            danyo -= Resistencia;
            Resistencia--;
        }

        base.RecibirDanyo(danyo);
    }

    public override int Atacar() 
    {
        ContadorTurno++;
        // Doble ataque: Puede realizar dos tiradas en un turno.
        return base.Atacar() * 2;
    }

    public void RecuperarVida() 
    {
        if(ContadorTurno % 3 == 0) 
        {
            Vida += 2;
        }
    }
}