namespace MarsRovers;

public class Coordenada(int x, int y)
{

    public override string ToString() => $"{x}:{y}";

    public Coordenada IrAlNorte()
    {
        if (y == 9)
            return new Coordenada(x, 0);
        
        return new Coordenada(x, y + 1);
    }

    public Coordenada IrAlSur()
    {
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