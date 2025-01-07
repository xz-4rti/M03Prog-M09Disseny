public class EnemigoBasico : Enemigo
{
    public EnemigoBasico(string nombre) 
    : base(nombre, new Random().Next(5,13), new Random().Next(0, 16))
    {
    }
}