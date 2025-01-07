public class Enemigo : Personaje
{
    public Enemigo(string nombre, int vida, int nivel) 
    : base(nombre, vida, nivel)
    {
    }
    public override int Atacar()
    {
        return new Random().Next(1, 7) + new Random().Next(1, 7);
    }

}