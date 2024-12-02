public class EnemigoEspecial : Enemigo
{
    public int Resistencia {get; set;}
    public EnemigoEspecial(string nombre) 
    : base(nombre, new Random().Next(5,13), new Random().Next(0, 16))
    {
        Resistencia = new Random().Next(0,6);
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
}