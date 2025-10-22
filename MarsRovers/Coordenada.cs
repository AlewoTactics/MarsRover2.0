namespace MarsRovers;

public class Coordenada(int x, int y)
{
    private const int LimiteNorte = 9;
    private const int LimiteSur = 0;
    private const int LimiteEste = 9;
    private const int LimiteOeste = 0;
    private const int MagnitudDesplazamiento = 1;
    public override string ToString() => $"{x}:{y}";

    public Coordenada IrAlNorte()
    {
        if (y == LimiteNorte)
            return new Coordenada(x, LimiteSur);

        return new Coordenada(x, y + MagnitudDesplazamiento);
    }

    public Coordenada IrAlSur()
    {
        if (y == LimiteSur)
            return new Coordenada(x, LimiteNorte);
        return new Coordenada(x, y - MagnitudDesplazamiento);
    }

    public Coordenada IrAlOeste()
    {
        return new Coordenada(x - MagnitudDesplazamiento, y);
    }

    public Coordenada IrAlEste()
    {
        if (x == LimiteEste)
            return new Coordenada(LimiteOeste, y);
        return new Coordenada(x + MagnitudDesplazamiento, y);
    }
}