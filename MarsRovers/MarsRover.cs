namespace MarsRovers;

public class MarsRover
{
    private string _posicionX = "0";
    private int _posicionY = 0;
    private PuntoCardinal _orientacion = PuntoCardinal.Norte;

    public string EjecutarComando(string comando)
    {
        if (comando == "M")
        {
            if (_orientacion == PuntoCardinal.Norte)
            {
                _posicionY++;
            }
            else
            {
                if (_orientacion == PuntoCardinal.Este)
                {
                    _posicionX = "1";
                }
            }
        }

        _orientacion = Rotar(comando);

        return $"{_posicionX}:{_posicionY}:{(char)_orientacion}";
    }

    private PuntoCardinal Rotar(string comando)
    {
        return comando switch
        {
            "R" => GirarDerecha(),
            "L" => GirarIzquierda(),
            _ => _orientacion
        };
    }

    private PuntoCardinal GirarIzquierda()
    {
        return _orientacion switch
        {
            PuntoCardinal.Norte => PuntoCardinal.Oeste,
            PuntoCardinal.Oeste => PuntoCardinal.Sur,
            PuntoCardinal.Sur => PuntoCardinal.Este,
            PuntoCardinal.Este => PuntoCardinal.Norte,
            _ => _orientacion
        };
    }

    private PuntoCardinal GirarDerecha()
    {
        return _orientacion switch
        {
            PuntoCardinal.Norte => PuntoCardinal.Este,
            PuntoCardinal.Este => PuntoCardinal.Sur,
            PuntoCardinal.Sur => PuntoCardinal.Oeste,
            PuntoCardinal.Oeste => PuntoCardinal.Norte,
            _ => _orientacion
        };
    }
}