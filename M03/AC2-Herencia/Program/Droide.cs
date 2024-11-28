namespace RobotManagement
{
    public class Droide {
        public string Nombre { get; set;}
        public string TipoUnidad { get; set;}
        public string NivelBateria { get; set;}

        public Droide(string nombre, string tipoUnidad, string nivelBateria) {
            Nombre = nombre;
            TipoUnidad = tipoUnidad;
            NivelBateria = nivelBateria;
        }

        public virtual void showInfo() {
            Console.WriteLine("Nombre: " + Nombre + " , Tipo Unidad: " + TipoUnidad + " , Nivel Bateria: " + NivelBateria);
        }
    }
}