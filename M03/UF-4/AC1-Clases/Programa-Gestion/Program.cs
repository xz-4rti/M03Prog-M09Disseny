public class Program 
{
    static void Main(String[] args){
        // Crear un proyecto
        Proyecto proyecto = new Proyecto("Proyecto A", "Descripción del Proyecto A", 30, EstadoTarea.Completa);
        
        // Agregar empleados al proyecto
        proyecto.Empleados.Add(new Empleado("Juan Pérez", "Desarrollador", 50000));
        proyecto.Empleados.Add(new Empleado("Ana Gómez", "Jefe de Proyecto", 75000));
        
        // Agregar tareas al proyecto
        proyecto.Tareas.Add(new Tarea("Diseño de la base de datos", EstadoTarea.Pendiente, "Diseñar la base de datos principal"));
        proyecto.Tareas.Add(new Tarea("Implementación del backend", EstadoTarea.Completa, "Desarrollar la lógica del servidor"));
        
        
        
    }
}

public class Proyecto 
{
    // Propiedad del Proyecto
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int DiasRestantes { get; set; }
    public List<Empleado> Empleados { get; set; }
    public List<Tarea> Tareas { get; set; }
    public double CostoEstimado { get; set; }
    public EstadoTarea Estado { get; set; }
    
    // Constructor
    public Proyecto(string nombre, string descripcion, int diasRestantes, EstadoTarea estado){
        this.Nombre = nombre;
        this.Descripcion = descripcion;
        this.DiasRestantes = diasRestantes;
        this.Estado = estado;
        Empleados = new List<Empleado>();
        Tareas = new List<Tarea>();
    }

    // Método para calcular el costo del proyecto
    public double CostoTotalEstimado(double PrecioPorDia) {
        CostoEstimado = PrecioPorDia * DiasRestantes;
        return CostoEstimado;
    }

    // Mètodo para obtener el numero de empleados
    public int obtenerNumeroEmpleado(){
        return Empleados.Count;
    }
    
}

public class Empleado 
{
    // Propiedades del empleado
    public string Nombre { get; set; }
    public string Cargo { get; set; }
    public double Salario { get; set; }

    // Constructor
    public Empleado(string nombre, string cargo, double salario)
    {
        this.Nombre = nombre;
        this.Cargo = cargo;
        this.Salario = salario;
    }
}

public enum EstadoTarea
{
    Pendiente,
    Completa
}

public class Tarea
{
    // Propiedades de la tarea
    public string Nombre { get; set; }
    public EstadoTarea Estado { get; set; }
    public string Descripcion { get; set; }

    // Constructor
    public Tarea(string nombre, EstadoTarea estado, string descripcion)
    {
        Nombre = nombre;
        Estado = estado;
        Descripcion = descripcion;
    }
}
