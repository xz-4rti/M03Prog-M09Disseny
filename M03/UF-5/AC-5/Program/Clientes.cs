public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }

    public Cliente(int id, string nombre, string email)
    {
        Id = id;
        Nombre = nombre;
        Email = email;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {Nombre}, Email: {Email}";
    }
}