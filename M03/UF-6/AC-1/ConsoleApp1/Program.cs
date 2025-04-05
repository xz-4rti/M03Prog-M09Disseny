using System;
using System.Data.SQLite;
using System.IO;

namespace Crud
{
    class Program
    {
        static string dbFile = "productos.db";

        static void Main()
        {
            if (!File.Exists(dbFile))
                CrearBaseDeDatos();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== CRUD de Productos ===");
                Console.WriteLine("1. Crear Producto");
                Console.WriteLine("2. Listar Productos");
                Console.WriteLine("3. Buscar Producto por Nombre");
                Console.WriteLine("4. Actualizar Producto");
                Console.WriteLine("5. Eliminar Producto");
                Console.WriteLine("0. Salir");
                Console.Write("Selecciona una opción: ");

                string opcion = Console.ReadLine();
                Console.Clear();

                switch (opcion)
                {
                    case "1":
                        CrearProducto();
                        break;
                    case "2":
                        ListarProductos();
                        break;
                    case "3": 
                        BuscarProducto(); 
                        break;
                    case "4": 
                        ActualizarProducto(); 
                        break;
                    case "5": 
                        EliminarProducto(); 
                        break;
                    case "0": 
                        return;
                    default: 
                        Console.WriteLine("Opción no válida."); break;
                }

                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void CrearBaseDeDatos()
        {
            SQLiteConnection.CreateFile(dbFile);
            using var conn = new SQLiteConnection($"Data Source={dbFile}");
            conn.Open();

            string query = @"CREATE TABLE Producto (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nombre TEXT NOT NULL,
                            Precio REAL NOT NULL,
                            Cantidad INTEGER NOT NULL
                        );";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.ExecuteNonQuery();
        }

        static void CrearProducto()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Precio: ");
            double precio = double.Parse(Console.ReadLine());

            Console.Write("Cantidad: ");
            int cantidad = int.Parse(Console.ReadLine());

            using var conn = new SQLiteConnection($"Data Source={dbFile}");
            conn.Open();

            string query = "INSERT INTO Producto (Nombre, Precio, Cantidad) VALUES (@nombre, @precio, @cantidad)";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@precio", precio);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Producto agregado correctamente.");
        }

        static void ListarProductos()
        {
            using var conn = new SQLiteConnection($"Data Source={dbFile}");
            conn.Open();

            string query = "SELECT * FROM Producto";
            using var cmd = new SQLiteCommand(query, conn);
            using SQLiteDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("Lista de productos:");
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["Id"]} | Nombre: {reader["Nombre"]} | Precio: {reader["Precio"]}€ | Cantidad: {reader["Cantidad"]}");
            }
        }

        static void BuscarProducto()
        {
            Console.Write("Nombre del producto: ");
            string nombre = Console.ReadLine();

            using var conn = new SQLiteConnection($"Data Source={dbFile}");
            conn.Open();

            string query = "SELECT * FROM Producto WHERE Nombre LIKE @nombre";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@nombre", $"%{nombre}%");

            using SQLiteDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("Resultados:");
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["Id"]} | Nombre: {reader["Nombre"]} | Precio: {reader["Precio"]} | Cantidad: {reader["Cantidad"]}");
            }
        }

        static void ActualizarProducto()
        {
            Console.Write("ID del producto a actualizar: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nuevo nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Nuevo precio: ");
            double precio = double.Parse(Console.ReadLine());

            Console.Write("Nueva cantidad: ");
            int cantidad = int.Parse(Console.ReadLine());

            using var conn = new SQLiteConnection($"Data Source={dbFile}");
            conn.Open();

            string query = "UPDATE Producto SET Nombre=@nombre, Precio=@precio, Cantidad=@cantidad WHERE Id=@id";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@precio", precio);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.Parameters.AddWithValue("@id", id);

            int rowsAffected = cmd.ExecuteNonQuery();
            Console.WriteLine(rowsAffected > 0 ? "Producto actualizado." : "Producto no encontrado.");
        }

        static void EliminarProducto()
        {
            Console.Write("ID del producto a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            using var conn = new SQLiteConnection($"Data Source={dbFile}");
            conn.Open();

            string query = "DELETE FROM Producto WHERE Id=@id";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            int rowsAffected = cmd.ExecuteNonQuery();
            Console.WriteLine(rowsAffected > 0 ? "Producto eliminado." : "Producto no encontrado.");
        }
    }

}
