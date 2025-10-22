using FluentAssertions;
using Xunit.Sdk;

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

    [Fact]
    public void Si_OrientacionEsSurYGiroIzquierda_Debe_OrientarseAlEsteEnCoordenada00E()
    {
        //ARRANGE
        var marsRover = new MarsRover();
        marsRover.EjecutarComando("L");
        marsRover.EjecutarComando("L");
        //ACT
        string ubicacion = marsRover.EjecutarComando("L");

        //ASSERT
        ubicacion.Should().Be("0:0:E");
    }

    [Fact]
    public void Si_OrientacionEsEsteYGiroAlaIzquierda_Debe_OrientarseAlNoreEnCoordenada00N()
    {
        //ARRANGE
        var marsRover = new MarsRover();
        marsRover.EjecutarComando("L");
        marsRover.EjecutarComando("L");
        marsRover.EjecutarComando("L");
        //ACT
        string ubicacion = marsRover.EjecutarComando("L");

        //ASSERT
        ubicacion.Should().Be("0:0:N");
    }

    [Fact]
    public void Si_OrientacionEsNorteYAvanzoUnaPosicion_Debe_MoverseALaCoordenada01N()
    {
        // Arrange
        var marsRover = new MarsRover();

        // Act
        string ubicacion = marsRover.EjecutarComando("M");

        // Assert
        ubicacion.Should().Be("0:1:N");
    }

    [Fact]
    public void Si_OrientacionEsEsteYAvanzoUnaPosicion_Debe_MoverseALaCoordenada10E()
    {
        // Arrange
        var marsRover = new MarsRover();
        marsRover.EjecutarComando("R");
        // Act
        string ubicacion = marsRover.EjecutarComando("M");
        // Assert
        ubicacion.Should().Be("1:0:E");
    }

    [Fact]
    public void Si_LaPosicionEs01SYAvanzo_Debe_Retornar00S()
    {
        // Arrange
        var marsRover = new MarsRover();
        marsRover.EjecutarComando("M");
        marsRover.EjecutarComando("R");
        marsRover.EjecutarComando("R");

        //Act
        string ubicacion = marsRover.EjecutarComando("M");

        //Assert
        ubicacion.Should().Be("0:0:S");
    }

    [Fact]
    public void SI_LaPosicionEs01WYAvanzo_Debe_Retornar00W ()
    {
        // Arrange
        var marsRover = new MarsRover();
        marsRover.EjecutarComando("R");
        marsRover.EjecutarComando("M");
        marsRover.EjecutarComando("L");
        marsRover.EjecutarComando("L");

        //Act
        string ubicacion = marsRover.EjecutarComando("M");

        //Assert
        ubicacion.Should().Be("0:0:W");
    }

    [Fact]
    public void Si_ReciboElComandoMMRMMLM_Debe_RetornarLaCoordenada23N()
    {
        //Arrange
        var marsRover = new MarsRover();
        //act
        var ubicacion = marsRover.EjecutarComando("MMRMMLM");
        
        //assert
        ubicacion.Should().Be("2:3:N");
    }

    [Fact]
    public void Si_SuperoElLimiteEnYHaciaElNorte_Debe_RetornarLaCoordenada00N()
    {
        // Arrange 
        var marsRover = new MarsRover();
        
        // Act
        var ubicacion = marsRover.EjecutarComando("MMMMMMMMMM");
        
        // Assert
        ubicacion.Should().Be("0:0:N");
    }

    [Fact]
    public void Si_SuperaElLimiteEnYHaciaElSur_Debe_RetornarLaCordenanda09S()
    {
        // Arrange 
        var marsRover = new MarsRover();
        
        // Act
        
        var ubicacion = marsRover.EjecutarComando("LLM");
        // Assert
        ubicacion.Should().Be("0:9:S");
    }
}