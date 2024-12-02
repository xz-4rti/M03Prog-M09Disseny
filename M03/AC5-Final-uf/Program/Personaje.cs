
public abstract class Personaje 
{
    public string Nombre{ get; set; }
    public int Vida{ get; set; }
    public int Nivel{ get; set; }
    
    public Personaje(string nombre, int vida, int nivel) 
    {
        this.Nombre = nombre;
        this.Vida = vida;
        this.Nivel = nivel;
    }

    public abstract int Atacar();

    // Methodo para que reciba danyo
    public virtual void RecibirDanyo(int danyo) 
    {
        Vida -= danyo;
        if (Vida < 0)
            Vida = 0;
    }

    public bool EstaVivo() 
    {
        return Vida > 0;
    }

}