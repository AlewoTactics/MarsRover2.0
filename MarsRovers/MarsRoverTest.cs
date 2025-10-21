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

    [Theory]
    [InlineData(1, "0:0:E")]
    [InlineData(2, "0:0:S")]
    [InlineData(3, "0:0:W")]
    [InlineData(4, "0:0:N")]
    [InlineData(5, "0:0:E")]
    [InlineData(10, "0:0:S")]
    public void Si_giro_n_veces_a_la_derecha_desde_el_norte_debe_retornar_la_cordenada_correspondiente(
        int cantidadGiros, string orientacionEsperada)
    {
        //Arrange
        var utilidadesUbicacion = new Utilidades();
        //act
        utilidadesUbicacion.RealizarGiros(cantidadGiros);

        //assert
        utilidadesUbicacion.Ubicacion.ObtenerCoordernada().Should().Be(orientacionEsperada);
    }

    [Fact]
    public void si_giro_a_la_izquierda_desde_el_norte_debe_retornar_la_coordenada_00W()
    {
        //arrange
        var ubicacion = new Ubicacion();
        
        //act
        ubicacion.RealizarGiro('L');
        
        //assert
        ubicacion.ObtenerCoordernada().Should().Be("0:0:W");
    }
    
}

public class Utilidades
{

    public readonly Ubicacion Ubicacion = new();
    public void RealizarGiros(int numeroGiros)
    {
        for (var iteracion = 0; iteracion < numeroGiros; iteracion++)
        {
            Ubicacion.RealizarGiro('R');
        }
    }
}