
abstract class Personaje {
    public string Nombre{ get; set; }
    public int PuntoVida{ get; set; }
    public int Nivel{ get; set; }
    public int PuntoHabilidad{ get; set; }
    
    public Personaje(string nombre, int puntovida, int nivel, int puntohabilidad) {
        this.Nombre = nombre;
        this.PuntoVida = puntovida;
        this.Nivel = nivel;
        this.PuntoHabilidad = puntohabilidad;
    }

}