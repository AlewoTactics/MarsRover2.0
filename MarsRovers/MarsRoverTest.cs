using FluentAssertions;

namespace MarsRovers;

public class MarsRoverTest
{
    [Fact]
    public void Debe_obtener_ubicacion_inicial()
    {
        // Arrange
        var ubicacion = new Ubicacion();

        // Act
        var coordenada = ubicacion.ObtenerCoordernada();

        // Assert
        coordenada.Should().Be("0:0:N");
    }

    [Fact]
    public void Si_envio_comando_R_debe_retonar_OOE()
    {
        // Arrange
        var ubicacion = new Ubicacion();
        // Act
        ubicacion.RealizarGiro('R');
        // Assert
        ubicacion.ObtenerCoordernada().Should().Be("0:0:E");
    }
}

public class Ubicacion
{
    const string CoordenadaInicial = "0:0:";
    private char Orientacion { get; set; }

    public Ubicacion()
    {
        Orientacion = 'N';
    }

    public string ObtenerCoordernada()
    {
        return CoordenadaInicial + Orientacion;
    }

    public void RealizarGiro(char comando)
    {
        if (comando == 'R')
        {
            if (Orientacion == 'N')
                Orientacion = 'E';
        }
    }
}