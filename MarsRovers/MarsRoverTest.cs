using FluentAssertions;

namespace MarsRovers;

public class MarsRoverTest
{
    [Fact]
    public void Debe_obtener_ubicacion_inicial()
    {
        var ubicacion = new Ubicacion();
        ubicacion.ObtenerCoordernada().Should().Be("0:0:N");
    }
}

public class Ubicacion
{
    const string CoordenadaInicial = "0:0:N";

    public string ObtenerCoordernada()
    {
        return CoordenadaInicial;
    }
}