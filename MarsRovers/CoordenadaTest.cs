using FluentAssertions;

namespace MarsRovers;

public class CoordenadaTest
{
 
    [Fact]
    public void Si_RecibeUnaCoordernadaFueraDelLimite_Debe_LazarUnaExcepcion()
    {
        Action coordenada =()=> new Coordenada(12, 0);

        coordenada.Should()
            .Throw<ArgumentOutOfRangeException>().WithMessage("*La coordenada en x (12) supera el límite máximo (9)*"); 

    }
}