namespace RobotManagement
{
    public class DroideCombate : Droide {
        private int NivelPotenciaFuego { get; set;}
        public DroideCombate(string nombre, string tipoUnidad, string nivelBateria, int nivelPotenciaFuego) 
        : base(nombre, tipoUnidad, nivelBateria) 
        {
            NivelPotenciaFuego = nivelPotenciaFuego;
        }

        public int CombatesParticipados()
        {
            Random random = new Random();
            return random.Next(1, 20); 
        }

        public override void showInfo(){
            base.showInfo();
            Console.WriteLine("Nivel potencia de fuego: " + NivelPotenciaFuego);
        }
    }
}
