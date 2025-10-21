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
        var coordenada= ubicacion.ObtenerCoordernada();
        
        // Assert
        coordenada.Should().Be("0:0:N");
    }

    [Fact]
    public void Si_envio_comando_R_debe_retonar_OOE()
    {
        // Arrange
        var ubicacion = new Ubicacion();
        // Act
        var coordenada= ubicacion.RealizarGiro('R');
        // Assert
        coordenada.Should().Be("0:0:E");
    }
    
}

public class Ubicacion
{
    const string CoordenadaInicial = "0:0:N";

    public string ObtenerCoordernada()
    {
        return CoordenadaInicial;
    }

    public object RealizarGiro(char comando )
    {
        if (comando == 'R')
            return CoordenadaInicial.Replace("N", "E");
        return CoordenadaInicial;
    }
}