using FluentAssertions;

namespace MarsRovers;

public class CoordenadaTest
{

    [Fact]
    public void Si_RecibeUnaCoordernadaMayorDelLimiteX_Debe_LanzarUnaExcepcion()
    {
        Action coordenada = () => new Coordenada(12, 0);

        coordenada.Should()
            .Throw<ArgumentOutOfRangeException>().WithMessage("*La coordenada en x (12) supera el límite máximo (9)*");
    }

    [Fact]
    public void Si_RecibeUnaCoordernadaMenorDelLimiteX_Debe_LanzarUnaExcepcion()
    {
        Action coordenada = () => new Coordenada(-1, 0);

        coordenada.Should()
            .Throw<ArgumentOutOfRangeException>()
            .WithMessage("*La coordenada en x (-1) no se encuentra en el rango de la plataforma*");
    }

    [Fact]
    public void Si_RecibeUnaCoordernadaMayorDelLimiteY_Debe_LanzarUnaExcepcion()
    {
        Action coordenada = () => new Coordenada(0, 12);

        coordenada.Should()
            .Throw<ArgumentOutOfRangeException>()
            .WithMessage("*La coordenada en y (12) no se encuentra en el rango de la plataforma*");
    }
    
    [Fact]
    public void Si_RecibeUnaCoordernadaMenorDelLimiteY_Debe_LanzarUnaExcepcion()
    {
        Action coordenada =()=> new Coordenada(0, -1);
        
        coordenada.Should()
            .Throw<ArgumentOutOfRangeException>().WithMessage("*La coordenada en y (-1) no se encuentra en el rango de la plataforma*"); 
    }

}