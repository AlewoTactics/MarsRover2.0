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

    [Fact]
    public void Si_estoy_en_el_Este_al_girar_a_la_derecha_debe_estar_en_la_coordenada_00S()
    {
        // Arrange
        var ubicacion = new Ubicacion();
        ubicacion.RealizarGiro('R');
        
        // Act
        ubicacion.RealizarGiro('R');
        // Assert
        ubicacion.ObtenerCoordernada().Should().Be("0:0:S");
    }
    
    [Fact]
    public void Si_estoy_en_el_Sur_al_girar_a_la_derecha_debe_estar_en_la_coordenada_00W()
    {
        // Arrange
        var ubicacion = new Ubicacion();
        ubicacion.RealizarGiro('R');
        ubicacion.RealizarGiro('R');
        
        // Act
        ubicacion.RealizarGiro('R');
        // Assert
        ubicacion.ObtenerCoordernada().Should().Be("0:0:W");
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
            else if(Orientacion=='E')
                Orientacion = 'S';
            else if (Orientacion == 'S')
                Orientacion = 'W';
        }
    }
}