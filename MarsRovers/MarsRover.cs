using Xunit.Sdk;

namespace MarsRovers;

public class MarsRover
{
    private Coordenada _coordenada = new(0, 0);
    private PuntoCardinal _orientacion = PuntoCardinal.Norte;

    private MarsRover() { }

    public static MarsRover UbicarEn00N()
    {
        return new MarsRover();
    }

    public static MarsRover UbicarEn(Coordenada ubicacionInicial, PuntoCardinal orientacionInicial)
    {
       
        return new MarsRover(ubicacionInicial, orientacionInicial);
    }


    private MarsRover(Coordenada ubicacionInicial, PuntoCardinal orientacion)
    {
        _coordenada = ubicacionInicial;
        _orientacion = orientacion;
    }

    public string EjecutarComando(string comando)
    {
        foreach (char instruccion in comando)
        {
            switch (instruccion)
            {
                case 'M': _coordenada = CalcularPosicion(_orientacion, _coordenada); break;
                case 'R': _orientacion = GirarDerecha(); break;
                case 'L': _orientacion = GirarIzquierda(); break;
            }
        }

        return $"{_coordenada}:{(char)_orientacion}";
    }


    private static Coordenada CalcularPosicion(PuntoCardinal orientacionInicial, Coordenada posicionInicial)
    {
        return orientacionInicial switch
        {
            PuntoCardinal.Norte => posicionInicial.IrAlNorte(),
            PuntoCardinal.Sur => posicionInicial.IrAlSur(),
            PuntoCardinal.Oeste => posicionInicial.IrAlOeste(),
            _ => posicionInicial.IrAlEste()
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