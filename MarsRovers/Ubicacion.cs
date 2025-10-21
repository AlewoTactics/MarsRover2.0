namespace MarsRovers;

public enum PuntoCardinal
{
    Norte = 'N',
    Este = 'E',
    Sur = 'S',
    Oeste = 'W'
}

public enum Giro
{
    Derecha = 'R',
    Izquierda = 'L',
}


public class Ubicacion
{
    const string CoordenadaInicial = "0:0:";
    private PuntoCardinal Orientacion { get; set; }

    public Ubicacion()
    {
        Orientacion = PuntoCardinal.Norte;
    }

    public string ObtenerCoordernada()
    {
        return CoordenadaInicial + (char)Orientacion;
    }

    public void RealizarGiro(Giro comando)
    {
        if (comando == Giro.Derecha)
            GirarDerecha();
        else if (comando == Giro.Izquierda) 
            GirarIzquierda();
    }

    private void GirarIzquierda()
    {
        Orientacion = Orientacion switch
        {
            PuntoCardinal.Norte => PuntoCardinal.Oeste,
            PuntoCardinal.Oeste => PuntoCardinal.Sur,
            PuntoCardinal.Sur => PuntoCardinal.Este,
            PuntoCardinal.Este => PuntoCardinal.Norte,
            _ => Orientacion
        };
    }

    private void GirarDerecha()
    {
        Orientacion = Orientacion switch
        {
            PuntoCardinal.Norte => PuntoCardinal.Este,
            PuntoCardinal.Este => PuntoCardinal.Sur,
            PuntoCardinal.Sur => PuntoCardinal.Oeste,
            PuntoCardinal.Oeste => PuntoCardinal.Norte,
            _ => Orientacion
        };
    }
}