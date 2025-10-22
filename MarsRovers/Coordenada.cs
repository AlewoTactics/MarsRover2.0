namespace MarsRovers;

public class Coordenada(int x, int y)
{
    private const int LimiteNorte = 9;
    private const int LimiteSur = 0;
    private const int LimiteEste = 9;
    private const int LimiteOeste = 0;
    private const int MagnitudDesplazamiento = 1;
    public override string ToString() => $"{x}:{y}";

    public Coordenada IrAlNorte() => EstaEnLimiteNorte() ? TeletransportarseAlSur() : AvanzarAlNorte();
    public Coordenada IrAlSur() => EstaEnLimiteSur() ? TeletransportarseAlNorte() : AvanzarAlSur();
    public Coordenada IrAlEste() => EstaEnLimiteEste() ? TeletransportarseAlOeste() : AvanzarAlEste();
    public Coordenada IrAlOeste() => EstaEnLimiteOeste() ? TeletransportarseAlEste() : AvanzarAlOeste();


    private bool EstaEnLimiteNorte() => y == LimiteNorte;
    private bool EstaEnLimiteSur() => y == LimiteSur;
    private bool EstaEnLimiteEste() => x == LimiteEste;
    private bool EstaEnLimiteOeste() => x == LimiteOeste;
    
    private Coordenada AvanzarAlNorte() => new(x, y + MagnitudDesplazamiento);
    private Coordenada AvanzarAlOeste() => new(x - MagnitudDesplazamiento, y);
    private Coordenada AvanzarAlSur() => new(x, y - MagnitudDesplazamiento);
    private Coordenada AvanzarAlEste() => new(x + MagnitudDesplazamiento, y);
    
    private Coordenada TeletransportarseAlNorte() => new(x, LimiteNorte);
    private Coordenada TeletransportarseAlSur() => new(x, LimiteSur);
    private Coordenada TeletransportarseAlEste() => new(LimiteEste, y);
    private Coordenada TeletransportarseAlOeste() => new(LimiteOeste, y);

}