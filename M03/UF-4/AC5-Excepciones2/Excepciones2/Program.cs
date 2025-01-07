using System;
using System.IO;

class Program
{
    static void Main()
    {

        // 1- Escribe un programa que solicite al usuario ingresar dos números y realice la división entre ellos. 
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

        // 2- Escribe un programa que implemente un método que reciba un número entero como entrada y lance una excepción 
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

        // 3- Escribe un programa que lea una ruta de archivo proporcionada por el usuario e intente abrir el archivo. 
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

        // 4- Escribe un programa que solicite al usuario ingresar un número entero.
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

        // 5- Escribe un programa que implemente un método que reciba un arreglo de enteros como entrada y calcule el valor promedio. 
        // Maneja la excepción si el índice está fuera de rango
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

        // -------------------------------------------------------------------------------------------------------------------------

        // 6- Escribe un programa que lea una cadena del usuario y la convierta en un entero. 
        // Maneja la excepción si la entrada no se puede  analizar como un entero.

        try {

            Console.WriteLine("Introduce un numero entero: ");
            string input = Console.ReadLine();
            int number = int.Parse(input);
            Console.WriteLine("Número ingresado: " + number);

        } catch (FormatException ex){
            Console.WriteLine("Error: " + ex.Message);
        }

        // -------------------------------------------------------------------------------------------------------------------------

        // 7- Escribe un programa que lea una lista de números enteros del usuario. 
        // Maneja la excepción que ocurre si el usuario ingresa un valor fuera del rango de Int32.
        try {
            Console.WriteLine("Introduce una lista de números enteros separados por espacios: ");
            string[] inputs = Console.ReadLine().Split(' ');
            foreach (string input in inputs)
            {
                int number = Convert.ToInt32(input);
                Console.WriteLine("Número ingresado: " + number);
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Error: El número ingresado está fuera del rango de Int32. " + ex.Message);
        }

        // -------------------------------------------------------------------------------------------------------------------------

        // 8- Escribe un programa que implemente un método que divida dos números. 
        // Controla la excepción DivideByZeroException que se produce si el denominador es 0.
        try {
            Console.WriteLine("Introduce el numerador: ");
            int numerator = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce el denominador: ");
            int denominator = int.Parse(Console.ReadLine());

            int result = Divide(numerator, denominator);
            Console.WriteLine("Resultado de la división: " + result);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        // -------------------------------------------------------------------------------------------------------------------------

        // 9- Escribe un programa que lea un número del usuario y calcule su raíz cuadrada. 
        // Maneja la excepción si el número es negativo.
         try
        {
            Console.WriteLine("Introduce un número para calcular su raíz cuadrada:");
            double number = double.Parse(Console.ReadLine());

            if (number < 0)
                throw new ArgumentException("No se puede calcular la raíz cuadrada de un número negativo.");

            double result = Math.Sqrt(number);
            Console.WriteLine("Raíz cuadrada: " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    

        // -------------------------------------------------------------------------------------------------------------------------

        // 10- Escribe un programa que cree un método que tome una cadena como entrada y la convierta a mayúsculas. 
        // Controla la excepción NullReferenceException que se produce si la cadena de entrada es nula.
        try
        {
            Console.WriteLine("Introduce una cadena para convertir a mayúsculas: ");
            string input = Console.ReadLine();

            if (input == null)
                throw new NullReferenceException("La cadena de entrada no puede ser nula.");

            string upperCase = input.ToUpper();
            Console.WriteLine("Cadena en mayúsculas: " + upperCase);
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        // -------------------------------------------------------------------------------------------------------------------------

        // METHODOS

        // Methodo para calcular el promedio para el ejercicio 5
        static double CalcularPromedio(int[] arreglo) {

            int suma = 0;
            for (int i = 0; i < arreglo.Length; i++)
            {
                suma += arreglo[i];
            }

            return (double)suma / arreglo.Length;
        }

        // Método para dividir dos números para el ejercicio 8
        static int Divide(int numerator, int denominator) {
            return numerator / denominator;
        }

    }
}
