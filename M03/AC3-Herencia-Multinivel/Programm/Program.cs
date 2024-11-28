using System;

namespace NavesEstelares
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instancias de cada tipo de nave
            Nave naveBasica = new Nave ("Nave Básica", 10000, 3200);
            NaveCombate naveCombate = new NaveCombate ("Nave de Combate", 15000, 7);
            NaveCarga naveCarga = new NaveCarga ("Nave de Carga", 12000, 10);

            // Demostrar funcionamiento de cada nave
            naveBasica.ActivarNave();
            naveBasica.EjecutarMision();
            naveBasica.ApagarNave();

            naveCombate.ActivarNave();
            naveCombate.RealizarAtaque(7);
            naveCombate.ApagarNave();

            naveCarga.ActivarNave();
            naveCarga.RealizarAtaque(10);
            naveCarga.EjecutarMision();
            naveCarga.CantidadCargados(2500);
            naveCarga.ApagarNave();
        }
    }
}
