namespace MarsRovers;

public class Ubicacion
{
    const string CoordenadaInicial = "0:0:";
    private char Orientacion { get; set; }

    public Ubicacion()
    {
        Orientacion = 'N';
    }

    public string ObtenerCoordernada()
    {
        return CoordenadaInicial + Orientacion;
    }

    public void RealizarGiro(char comando)
    {
        if (comando == 'R')
        {
            Orientacion = Orientacion switch
            {
                'N' => 'E',
                'E' => 'S',
                'S' => 'W',
                'W' => 'N',
                _ => Orientacion
            };
        }
        else if (comando == 'L') 
        {
            if (Orientacion == 'N')
                Orientacion = 'W';
        }
    }
}