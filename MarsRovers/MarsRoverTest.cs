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
        utilidadesUbicacion.RealizarGirosDerecha(cantidadGiros);

        //assert
        utilidadesUbicacion.ObtenerUbicacion().Should().Be(orientacionEsperada);
    }

    [Theory]
    [InlineData(1, "0:0:W")]
    [InlineData(2, "0:0:S")]
    [InlineData(3, "0:0:E")]
    [InlineData(4, "0:0:N")]
    [InlineData(5, "0:0:W")]
    [InlineData(10, "0:0:S")]
    public void Si_giro_N_veces_a_la_izquierda_debe_retornar_la_coordenada_correspondiente(int cantidadGiros, string orientacionEsperada)
    {
        //Arrange
        var utilidadesUbicacion = new Utilidades();
        //act
        utilidadesUbicacion.RealizarGirosIzquierda(cantidadGiros);

        //assert
        utilidadesUbicacion.ObtenerUbicacion().Should().Be(orientacionEsperada);
    }
    
}

public class Utilidades
{
    private readonly Ubicacion Ubicacion = new();

    public void RealizarGirosDerecha(int numeroGiros)
    {
        RealizarGiro(numeroGiros, Giro.Derecha);

    }

    public void RealizarGirosIzquierda(int numeroGiros)
    {
        RealizarGiro(numeroGiros, Giro.Izquierda);
    }

    private void RealizarGiro(int numeroGiros, Giro giro)
    {
        for (var iteracion = 0; iteracion < numeroGiros; iteracion++)
        {
            Ubicacion.RealizarGiro(giro);
        }
    }

    public string ObtenerUbicacion()
    {
        return Ubicacion.ObtenerCoordernada();
    }
}