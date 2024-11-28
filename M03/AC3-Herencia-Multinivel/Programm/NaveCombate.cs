namespace NavesEstelares{
    class NaveCombate : Nave
    {
        public NaveCombate(string nombre, int capacidadDeCarga, int velocidadMax) 
        : base(nombre, capacidadDeCarga, velocidadMax)
        {
        }

        public override void ActivarNave()
        {
            Console.WriteLine("La nave de combate ha activado sus sistemas de combate.");
        }

        public override void ApagarNave(){
            Console.WriteLine("La nave de combate ha apagado sus sistemas.");
        }

        public virtual void RealizarAtaque(int nivel)
        {
            Console.WriteLine($"La nave de combate está atacando con potencia de fuego nivel {nivel}");
        }
    }
}

