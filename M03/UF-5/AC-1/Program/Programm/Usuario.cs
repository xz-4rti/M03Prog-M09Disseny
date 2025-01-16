public class Usuario : Persona
{
    public LinkedList<VideoJuego> JuegosAlquilados { get; set; }
    public Usuario(string nombre, string apellido, int edad, string direccion, int telefono) 
    : base(nombre, apellido, edad, direccion, telefono)
    {
        JuegosAlquilados = new LinkedList<VideoJuego>();
    }

    public override string ToString()
    {
        return base.ToString() + $", Juegos alquilados: {JuegosAlquilados.Count}";
    }
}
