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

    [Fact]
    public void Si_enviamos_comando_L_debe_retornar_coordenada_OOW_desde_la_posicion_inicial()
    {
        var resultado = Girar("L");
        resultado.Should().Be("0:0:W");
    }

    [Fact]
    public void Si_enviamos_un_comando_con_LL_debe_retornar_coordenada_00S_desde_la_posicion_inicial()
    {
        var resultado = Girar("LL");
        resultado.Should().Be("0:0:S");
    }

    private string Girar(string comando)
    {
        var posicionInicial = ObtenerCoordenadaInicial();
        return comando switch
        {
            "R" => posicionInicial.Replace("N", "E"),
            "L" => posicionInicial.Replace("N", "W"),
            "LL" => posicionInicial.Replace("N", "S"),
            _ => posicionInicial
        };
    }

    private string ObtenerCoordenadaInicial()
    {
        return "0:0:N";
    }
}