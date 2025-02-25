public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }

    public Producto(int id, string nombre, double precio)
    {
        Id = id;
        Nombre = nombre;
        Precio = precio;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {Nombre}, Precio: {Precio}";
    }
}