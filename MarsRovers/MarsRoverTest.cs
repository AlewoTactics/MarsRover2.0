using FluentAssertions;

namespace MarsRovers;

public class MarsRoverTest
{
    private MarsRover _marsRoverEn00N;
    
    public MarsRoverTest()
    {
         _marsRoverEn00N = MarsRover.UbicarEn00N();
    }
    
    
    [Theory]
    [InlineData("R","0:0:E")]
    [InlineData("RR","0:0:S")]
    [InlineData("RRR","0:0:W")]
    [InlineData("RRRR","0:0:N")]
    [InlineData("L","0:0:W")]
    [InlineData("LL","0:0:S")]
    [InlineData("LLL","0:0:E")]
    [InlineData("LLLL","0:0:N")]
    public void Si_Gira_Debe_RetornarLaOrientacionCorrecta(string comando, string coordenadaEsperada)
    {
        _marsRoverEn00N.EjecutarComando(comando).Should().Be(coordenadaEsperada);
    }

    [Theory]
    [InlineData("M","0:1:N")] // Mover norte
    [InlineData("RM","1:0:E")] // Mover este
    [InlineData("MRRM","0:0:S")] // Mover norte y volver al sur 
    [InlineData("RMLLM","0:0:W")] // Mover al este y volver al oeste
    public void Si_SeMueveDesdeSuOrientacion_Debe_RetornarLaCoordenadaCorrecta(string comando, string coordenadaEsperada)
    {
        _marsRoverEn00N.EjecutarComando(comando).Should().Be(coordenadaEsperada);
        
    }

    [Theory]
    [InlineData("MMMMMMMMMM","0:0:N")] // Supera el limite norte
    [InlineData("LLM","0:9:S")] // Supera el limite sur
    [InlineData("RMMMMMMMMMM","0:0:E")] // Supera el limite este
    [InlineData("LM","9:0:W")] // Supera el limite oeste
    public void Si_SeMueveYPasaElLimite_Debe_Teletransportarse(string comando, string coordenadaEsperada)
    {
        _marsRoverEn00N.EjecutarComando(comando).Should().Be(coordenadaEsperada);
    }
    
    [Fact]
    public void Si_ReciboElComandoMMRMMLM_Debe_RetornarLaCoordenada23N()
    {
        //Arrange
      
        //act
        var ubicacion =_marsRoverEn00N.EjecutarComando("MMRMMLM");

        //assert
        ubicacion.Should().Be("2:3:N");
    }

    [Fact]
    public void  Si_RecibeLaCoordeanada01S_Debe_iniciarEnEsaUbicacion()
    {
        // Arrange
        var ubicacionInicial = new Coordenada(0, 1);  
        var orientacion = PuntoCardinal.Sur;
        var marsRover = MarsRover.UbicarEn(ubicacionInicial, orientacion);

        // Act
        var posicionInicial = marsRover.EjecutarComando(string.Empty);
        //
        
        // Assert
        posicionInicial.Should().Be("0:1:S");
    }

    [Fact]
    public void Si_RecibeUnaCoordernadaFueraDelLimite_Debe_LazarUnaExcepcion()
    {
        // Arrange
        var ubicacionInicial = new Coordenada(12, 1);  
        var orientacion = PuntoCardinal.Sur;
        
        //Act
        Action marsRover =()=> MarsRover.UbicarEn(ubicacionInicial, orientacion);
        
        //Assert
        marsRover.Should().Throw<ArgumentException>().WithMessage("Esta fuera del limite");

    }
    
}