public class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Departamento { get; set; }

    public Empleado(int id, string nombre, string departamento)
    {
        Id = id;
        Nombre = nombre;
        Departamento = departamento;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {Nombre}, Departamento: {Departamento}";
    }
}