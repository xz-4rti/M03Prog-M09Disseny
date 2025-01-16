namespace NavesEstelares {
    class NaveCarga : NaveCombate
    {
        public NaveCarga(string nombre, int capacidadDeCarga, int velocidadMax) : base(nombre, capacidadDeCarga, velocidadMax)
        {
        }

        public override void ActivarNave()
        {
            Console.WriteLine("La nave de carga especializada ha activado sus sistemas.");
        }

        public override void RealizarAtaque(int nivel)
        {
            Console.WriteLine($"La nave de carga especializada está atacando con potencia de fuego nivel {nivel}");
        }

        public void CantidadCargados(int carga)
        {
            Console.WriteLine($"La nave de carga lleva una cantidad de carga de {carga}kg");
        }

        public override void ApagarNave(){
            Console.WriteLine("La nave de carga especializada ha apagado sus sistemas.");
        }

    }
}

