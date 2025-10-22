namespace MarsRovers;

public class MarsRover
{
    private string _posicionX = "0";
    private string _posicionY = "0";
    private string _orientacion = "N";

    public string EjecutarComando(string comando)
    {
        _orientacion = Rotar(comando);

        return $"{_posicionX}:{_posicionY}:{_orientacion}";
    }

    private string Rotar(string comando)
    {
        return comando switch
        {
            "R" => GirarDerecha(),
            "L" => GirarIzquierda(),
            _ => _orientacion
        };
    }

    private string GirarIzquierda()
    {
        if (_orientacion == "N")
            return "W";
        return "S";
    }

    private string GirarDerecha()
    {
        return _orientacion switch
        {
            "N" => "E",
            "E" => "S",
            "S" => "W",
            "W" => "N",
            _ => _orientacion
        };
    }
}