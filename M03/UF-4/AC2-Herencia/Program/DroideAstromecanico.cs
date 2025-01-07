namespace RobotManagement
{
    public class DroideAstromecanico : Droide {
        private string UltimaRecuperacion { get; set;}
        public DroideAstromecanico (string nombre, string tipoUnidad, string nivelBateria, string ultimaRecuperacion)
        : base(nombre, tipoUnidad, nivelBateria) 
        {
            UltimaRecuperacion = ultimaRecuperacion;
        }

        public int RepararNaves()
        {
            Random random = new Random();
            return random.Next(1, 10);
        }

        public override void showInfo(){
            base.showInfo();
            Console.WriteLine("Ultima Recuperacion: " + UltimaRecuperacion);
        }
    }
}
