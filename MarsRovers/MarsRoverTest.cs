using FluentAssertions;

namespace MarsRovers;

public class MarsRoverTest
{
    [Fact]
    public void Si_ElComandoEsVacio_Debe_Retornar00N()
    {
        var marsRover = new MarsRover();
        string  ubicacion = marsRover.EjecutarComando("");
        ubicacion.Should().Be("0:0:N");
    }
}

public class MarsRover
{
    private string _ubicacionInicial = "0:0:N";

    public string EjecutarComando(string empty)
    {
        return _ubicacionInicial;
    }
}