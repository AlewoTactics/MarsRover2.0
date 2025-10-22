using Xunit.Sdk;

namespace MarsRovers;

public class MarsRover
{
    private int _posicionX = 0;
    private int _posicionY = 0;
    private PuntoCardinal _orientacion = PuntoCardinal.Norte;

    public string EjecutarComando(string comando)
    {
            switch(comando)
            {
                case "M" :
                    (_posicionX, _posicionY) = CalcularPosicion(_orientacion, _posicionX, _posicionY);
                    break;
                case "R" :  _orientacion = GirarDerecha(); break;
                case "L" : _orientacion = GirarIzquierda(); break;
            };

        return $"{_posicionX}:{_posicionY}:{(char)_orientacion}";
    }


    private static (int posicionFinalX, int posicionFinalY) CalcularPosicion(PuntoCardinal orientacionInicial,
        int posicionInicialX, int posicionInicialY)
    {
        return orientacionInicial switch
        {
            PuntoCardinal.Norte => (posicionInicialX, posicionInicialY + 1),
            PuntoCardinal.Sur => (posicionInicialX, posicionInicialY - 1),
            PuntoCardinal.Oeste => (posicionInicialX - 1, posicionInicialY),
            _ => (posicionInicialX + 1, posicionInicialY)
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