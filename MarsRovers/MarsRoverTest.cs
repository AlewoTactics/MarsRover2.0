using FluentAssertions;

namespace MarsRovers;

public class MarsRoverTest
{
    [Fact]
    public void Si_enviamos_comando_vacio_debe_retornar_coordena_00N()
    {
        var resultado = ObtenerCoordenadaInicial();
        resultado.Should().Be("0:0:N");
    }

    private string ObtenerCoordenadaInicial()
    {
        return "0:0:N";
    }
}