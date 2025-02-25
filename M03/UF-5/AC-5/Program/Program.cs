class Program
{
    static void Main(string[] args)
    {
        // Instancias de la API para cada tipo de entidad
        var apiProductos = new Api<Producto>();
        var apiClientes = new Api<Cliente>();
        var apiEmpleados = new Api<Empleado>();

        // Agregar elementos
        apiProductos.AgregarElemento(new Producto(1, "Laptop", 1200.50));
        apiProductos.AgregarElemento(new Producto(2, "Smartphone", 800.00));

        apiClientes.AgregarElemento(new Cliente(1, "Juan Pérez", "juan@example.com"));
        apiClientes.AgregarElemento(new Cliente(2, "Ana Gómez", "ana@example.com"));

        apiEmpleados.AgregarElemento(new Empleado(1, "Carlos Ruiz", "Ventas"));
        apiEmpleados.AgregarElemento(new Empleado(2, "Marta López", "IT"));

        // Mostrar elementos
        Console.WriteLine("Productos:");
        apiProductos.MostrarElementos();

        Console.WriteLine("\nClientes:");
        apiClientes.MostrarElementos();

        Console.WriteLine("\nEmpleados:");
        apiEmpleados.MostrarElementos();

        // Buscar elementos
        var productosCaros = apiProductos.BuscarElementos(p => p.Precio > 1000);
        Console.WriteLine("\nProductos caros:");
        foreach (var producto in productosCaros)
        {
            Console.WriteLine(producto);
        }

        // Actualizar un elemento
        apiProductos.ActualizarElemento(0, new Producto(1, "Laptop Gaming", 1500.00));
        Console.WriteLine("\nProductos después de actualizar:");
        apiProductos.MostrarElementos();

        // Eliminar un elemento
        apiClientes.EliminarElemento(1);
        Console.WriteLine("\nClientes después de eliminar:");
        apiClientes.MostrarElementos();
    }
}