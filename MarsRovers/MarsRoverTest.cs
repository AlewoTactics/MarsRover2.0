using FluentAssertions;

namespace MarsRovers;

public class MarsRoverTest
{
    [Fact]
    public void Si_ElComandoEsVacio_Debe_Retornar00N()
    {
        var marsRover = new MarsRover();
        string ubicacion = marsRover.EjecutarComando("");
        ubicacion.Should().Be("0:0:N");
    }

    [Fact]
    public void Si_ElComandoEsR_Debe_Retornar00E()
    {
        var marsRover = new MarsRover();
        string ubicacion = marsRover.EjecutarComando("R");
        ubicacion.Should().Be("0:0:E");
    }

    [Fact]
    public void Si_El_Comando_Es_RR_Debe_Retonar_00S()
    {
        var marsRover = new MarsRover();
        string ubicacion = marsRover.EjecutarComando("RR");
        ubicacion.Should().Be("0:0:S");
    }
}

public class MarsRover
{
    private string _posicionX = "0";
    private string _posicionY = "0";
    private string _orientacion = "N";

    public string EjecutarComando(string comando)
    {
        if (comando == "R")
            _orientacion = "E";

        return $"{_posicionX}:{_posicionY}:{_orientacion}";
    }
}