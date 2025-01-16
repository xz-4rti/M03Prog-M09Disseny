public class Empleado : Persona
{
    public string Categoria { get; set; }
    public decimal Salario { get; set; }

    public Empleado(string nombre, string apellido, int edad, string direccion, int telefono, string categoria, decimal salario) 
    : base(nombre, apellido, edad, direccion, telefono)
    {
        Categoria = categoria;
        Salario = salario;
    }

    public override string ToString()
    {
        return base.ToString() + $", Categoría: {Categoria}, Salario: {Salario}";
    }
}