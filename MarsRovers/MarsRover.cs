namespace MarsRovers;

public class MarsRover
{
    private string _posicionX = "0";
    private string _posicionY = "0";
    private string _orientacion = "N";

    public string EjecutarComando(string comando)
    {
        if (comando == "")
            return $"{_posicionX}:{_posicionY}:{_orientacion}";
        if (comando == "R")
        {
            GirarDerecha();
        }
        else
        {
            _orientacion = "W";
        }

        return $"{_posicionX}:{_posicionY}:{_orientacion}";
    }

    private void GirarDerecha()
    {
        _orientacion = _orientacion switch
        {
            "N" => "E",
            "E" => "S",
            "S" => "W",
            "W" => "N",
            _ => _orientacion
        };
    }
}