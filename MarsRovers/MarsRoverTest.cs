using FluentAssertions;

namespace MarsRovers;

public class MarsRoverTest
{
    [Fact]
    public void Si_ElComandoEsVacio_Debe_Retornar00N()
    {
        var marsRover = new MarsRover();
        string ubicacion = marsRover.EjecutarComando("");
        ubicacion.Should().Be("0:0:N");
    }

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
}

public class MarsRover
{
    private string _posicionX = "0";
    private string _posicionY = "0";
    private string _orientacion = "N";

    public string EjecutarComando(string comando)
    {
        if (comando == "R")
        {
            if (_orientacion == "N")
            {
                _orientacion = "E";
            }
            else if( _orientacion == "E")
            {
               _orientacion = "S";
            }
            else
            {
                _orientacion = "W";
            }
        }


        
        return $"{_posicionX}:{_posicionY}:{_orientacion}";
    }
}