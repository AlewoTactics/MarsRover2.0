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

    [Fact]
    public void Si_enviamos_comando_R_debe_retornar_coordenada_OOE()
    {
        var resultado = Girar("R");
        resultado.Should().Be("0:0:E");
    }

    private string Girar(string comando)
    {
        var posicionInicial = ObtenerCoordenadaInicial();
        if (comando == "R")
            return posicionInicial.Replace("N", "E");
        return posicionInicial;
    }

    private string ObtenerCoordenadaInicial()
    {
        return "0:0:N";
    }
}