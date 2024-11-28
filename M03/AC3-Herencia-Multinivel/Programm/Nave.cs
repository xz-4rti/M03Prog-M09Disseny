namespace NavesEstelares
{
    // Clase base: Nave Estelar Genérica
    public class Nave
    {
        public string Nombre { get; set; }
        public int CapacidadDeCarga { get; set; }
        public double VelocidadMax { get; set; }

        public Nave(string nombre, int capacidadDeCarga, int velocidadMax)
        {
            this.Nombre = nombre;
            this.CapacidadDeCarga = capacidadDeCarga;
            this.VelocidadMax = velocidadMax;
        }
        public virtual void ActivarNave()
        {
            Console.WriteLine($"La nave estelar basica ha activado sus sistemas.");
        }

        public virtual void EjecutarMision()
        {
            Console.WriteLine($"La nave estelar basica está realizando una misión de exploración.");
        }

        public virtual void ApagarNave()
        {
            Console.WriteLine($"La nave estelar basica ha apagado sus sistemas.");
        }
    }
}


