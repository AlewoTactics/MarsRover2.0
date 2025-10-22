using FluentAssertions;

namespace MarsRovers;

public class MarsRoverTest
{
    [Fact]
    public void Si_OrientacionEsNorteYGiroAlaDerecha_Debe_OrientarseAlEsteEnCoordenada00E()
    {
        var marsRover = new MarsRover();
        string ubicacion = marsRover.EjecutarComando("R");
        ubicacion.Should().Be("0:0:E");
    }

    [Fact]
    public void Si_OrientacionEsEsteYGiroAlaDerecha_Debe_OrientarseAlEsteEnCoordenada00S()
    {
        //ARRANGE
        var marsRover = new MarsRover();
        marsRover.EjecutarComando("R");
        //ACT
        string ubicacion = marsRover.EjecutarComando("R");
        //ASSERT
        ubicacion.Should().Be("0:0:S");
    }

    [Fact]
    public void Si_OrientacionEsSurYGiroALaDerecha_Debe_OrientarseAlOesteEnCordenada00W()
    {
        //ARRANGE
        var marsRover = new MarsRover();
        marsRover.EjecutarComando("R");
        marsRover.EjecutarComando("R");
        //ACT
        string ubicacion = marsRover.EjecutarComando("R");
        //ASSERT
        ubicacion.Should().Be("0:0:W");
    }

    [Fact]
    public void Si_OrientacionEsOesteYGiroALaDerecha_Debe_OrientarseAlNorteEnCordenada00N()
    {
        //ARRANGE
        var marsRover = new MarsRover();
        marsRover.EjecutarComando("R");
        marsRover.EjecutarComando("R");
        marsRover.EjecutarComando("R");

        //ACT
        string ubicacion = marsRover.EjecutarComando("R");

        //ASSERT
        ubicacion.Should().Be("0:0:N");
    }

    [Fact]
    public void Si_OrientacionEsNorteYGiroAlaIzquierda_Debe_OrientarseAlEsteEnCoordenada00W()
    {
        //ARRANGE
        var marsRover = new MarsRover();

        //ACT
        string ubicacion = marsRover.EjecutarComando("L");

        //ASSERT
        ubicacion.Should().Be("0:0:W");
    }

    [Fact]
    public void Si_OrientacionEsOesteYGiroALaIzquierda_Debe_OrientarseAlSurEnCoordenada00S()
    {
        //ARRANGE
        var marsRover = new MarsRover();
        marsRover.EjecutarComando("L");
        //ACT
        string ubicacion = marsRover.EjecutarComando("L");

        //ASSERT
        ubicacion.Should().Be("0:0:S");
    }
}