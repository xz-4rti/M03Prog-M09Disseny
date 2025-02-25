class Persona
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Persona(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {Name}";
    }
}
