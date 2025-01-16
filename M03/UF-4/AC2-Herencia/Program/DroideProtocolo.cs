namespace RobotManagement
{
    public class DroideProtocolo : Droide {
        public DroideProtocolo(string nombre, string tipoUnidad, string nivelBateria) 
        : base(nombre, tipoUnidad, nivelBateria) {}

        public override void showInfo(){
            base.showInfo();
            Console.WriteLine("Este es un Droide Protocolo.");
        }
    }
}