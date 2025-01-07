public class VideoJuego
{
    public string Titulo { get; set; }
    public int AnyoLanzamiento { get; set; }
    public string Tematica { get; set; }
    public string Estudio { get; set; }
    public int VecesAlquilado { get; set; }

    public VideoJuego(string titulo, int anyolanzamiento, string tematica, string estudio)
    {
        Titulo = titulo;
        AnyoLanzamiento = anyolanzamiento;
        Tematica = tematica;
        Estudio = estudio;
        VecesAlquilado = 0;
    }

    public override string ToString()
    {
        return $"Titulo: {Titulo} ({AnyoLanzamiento}), Temática: {Tematica}, Estudio: {Estudio}, Veces alquilado: {VecesAlquilado}";
    }

}