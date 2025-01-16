public class Persona
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Edad { get; set; }
    public string Direccion { get; set; }
    public int Telefono { get; set; }

    public Persona(string nombre, string apellido, int edad, string direccion, int telefono)
    {
        Nombre = nombre;
        Apellido = apellido;
        Edad = edad;
        Direccion = direccion;
        Telefono = telefono;

    }

    public override string ToString()
    {
        return $"Nombre y Appellido: {Nombre} {Apellido}, Edad: {Edad}, Telefono: {Telefono}";
    }
}