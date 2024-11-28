using System;
using System.IO;

class Program
{
    static void Main()
    {

        // 1- Escribe un programa en C# que solicite al usuario ingresar dos números y realice la división entre ellos. 
        // Maneja una excepción cuando el usuario introduce valores no numéricos.

        try {

            Console.WriteLine("introduce el primer numero 1: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("introduce el primer numero 2: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int resultado = num1 / num2;

            Console.WriteLine("Su división es: " + resultado);

        }
        catch(FormatException) {
            Console.WriteLine("Error: El valor introducido no es numérico");
        }
        catch (Exception e){
            Console.WriteLine("Error: " + e.Message);
        }

        // -------------------------------------------------------------------------------------------------------------------------

        // 2- Escribe un programa en C# que implemente un método que reciba un número entero como entrada y lance una excepción 
        // si el número es negativo. Maneja la excepción en el código que llama al método.
        try {
            Console.WriteLine("introduce un numero positivo: ");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num < 0) {
                // modificar el mensaje de  error si el numero es negativo
                throw new ArgumentException("Es un numero negativo, debe ser un numero positivo");
            }

            Console.WriteLine("Número ingresado: " + num);

        } catch (Exception error){
            Console.WriteLine("Error: " + error.Message);
        }

        // -------------------------------------------------------------------------------------------------------------------------

        // 3- Escribe un programa en C# que lea una ruta de archivo proporcionada por el usuario e intente abrir el archivo. 
        // Maneja excepciones si el archivo no existe.
        try {

            Console.WriteLine("Introduce la ruta del archivo: ");
            string ruta = Console.ReadLine();

            string content = File.ReadAllText(ruta);
            Console.WriteLine("Contenido del archivo:");
            Console.WriteLine(content);

        }
        catch(FileNotFoundException) {
            Console.WriteLine("Error: Archivo no encontrado");
        }
        catch(Exception ex) {
            Console.WriteLine("Error: " + ex.Message);
        }

        // -------------------------------------------------------------------------------------------------------------------------

        // 4- Escribe un programa en C# que solicite al usuario ingresar un número entero.
        // Lanza una excepción si el número es menor que 0 o mayor que 1000.
        try {
            Console.WriteLine("introduce un numero entero: ");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num < 0 || num > 1000) {
                // modificar el mensaje de  error
                throw new ArgumentOutOfRangeException("el numero no debe ser menor quee 0 o mayor que 1000");
            }

            Console.WriteLine("Número ingresado: " + num);

        }
        catch(ArgumentOutOfRangeException er) {
            Console.WriteLine("Error: " + er.Message);
        }
        catch (Exception ex){
            Console.WriteLine("Error: " + ex.Message);
        }

        // -------------------------------------------------------------------------------------------------------------------------

        // 5- Escribe un programa en C# que implemente un método que reciba un arreglo de enteros como entrada y calcule el valor promedio. 
        // Maneja la excepción si el índice está fuera de rango


        // TRY - CATCH - FINALLY (EXCEPTION)

        int[] numbers = { 10, 20, 30, 40, 50 };

        try {

            double promedio = CalcularPromedio(numbers);
            Console.WriteLine("El promedio es: " + promedio);

        }
        catch (IndexOutOfRangeException){
            Console.WriteLine("Índice fuera de rango en el arreglo.");
        }
        catch (Exception error){
            Console.WriteLine("Error: " + error.Message);
        }
        finally {
            Console.WriteLine("Processo completado");
        }

        static double CalcularPromedio(int[] arreglo) {

            int suma = 0;
            for (int i = 0; i < arreglo.Length; i++)
            {
                suma += arreglo[i];
            }

            return (double)suma / arreglo.Length;
        }

    }
}
