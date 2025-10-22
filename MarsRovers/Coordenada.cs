namespace MarsRovers;

public class Coordenada(int x, int y)
{
    private const int LimiteNorte = 9;
    private const int LimiteSur = 0;
    public override string ToString() => $"{x}:{y}";

    public Coordenada IrAlNorte()
    {
        if (y == LimiteNorte)
            return new Coordenada(x, LimiteSur);

        return new Coordenada(x, y + 1);
    }

    public Coordenada IrAlSur()
    {
        if (y == LimiteSur)
            return new Coordenada(x, LimiteNorte);
        return new Coordenada(x, y - 1);
    }

    public Coordenada IrAlOeste()
    {
        return new Coordenada(x - 1, y);
    }

    public Coordenada IrAlEste()
    {
        return new Coordenada(x + 1, y);
    }
}