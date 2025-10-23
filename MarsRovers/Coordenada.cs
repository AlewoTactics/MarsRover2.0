namespace MarsRovers;

public class Coordenada
{
    private readonly int _x;
    private string[] _campoEjeX;
    private string[] _campoEjeY;

    private readonly int _y;
    private const int LimiteNorte = 9;
    private const int LimiteSur = 0;
    private const int LimiteEste = 9;
    private const int LimiteOeste = 0;
    private const int MagnitudDesplazamiento = 1;

    public Coordenada(int x, int y)
    {
        ValidarLimites(x, y);
        _x = x;
        _y = y;
        _campoEjeX = new string[LimiteEste];
        _campoEjeY =new string[LimiteNorte];
    }

    public void AsignarElemento(int x, string elemento)
    {
        if (!string.IsNullOrEmpty(_campoEjeX[x]))
            throw new ArgumentException("La posición ya contiene un elemento.");
        _campoEjeX[x] = elemento;
    }

    public string ObtenerElemento(int x)
    {
        return _campoEjeX[x];
    }


    private static void ValidarLimites(int x, int y)
    {
        if (x > LimiteEste)
            throw new ArgumentOutOfRangeException($"La coordenada en x ({x}) supera el límite máximo ({LimiteEste})");
        if (x < LimiteOeste)
            throw new ArgumentOutOfRangeException(
                $"La coordenada en x ({x}) no se encuentra en el rango de la plataforma");
        if (y > LimiteNorte)
            throw new ArgumentOutOfRangeException(
                $"La coordenada en y ({y}) no se encuentra en el rango de la plataforma");
        if (y < LimiteSur)
            throw new ArgumentOutOfRangeException(
                $"La coordenada en y ({y}) no se encuentra en el rango de la plataforma");
    }


    public override string ToString() => $"{_x}:{_y}";


    public Coordenada IrAlNorte() => EstaEnLimiteNorte() ? TeletransportarseAlSur() : AvanzarAlNorte();
    public Coordenada IrAlSur() => EstaEnLimiteSur() ? TeletransportarseAlNorte() : AvanzarAlSur();
    public Coordenada IrAlEste() => EstaEnLimiteEste() ? TeletransportarseAlOeste() : AvanzarAlEste();
    public Coordenada IrAlOeste() => EstaEnLimiteOeste() ? TeletransportarseAlEste() : AvanzarAlOeste();


    private bool EstaEnLimiteNorte() => _y == LimiteNorte;
    private bool EstaEnLimiteSur() => _y == LimiteSur;
    private bool EstaEnLimiteEste() => _x == LimiteEste;
    private bool EstaEnLimiteOeste() => _x == LimiteOeste;

    private Coordenada AvanzarAlNorte() => new(_x, _y + MagnitudDesplazamiento);
    private Coordenada AvanzarAlOeste() => new(_x - MagnitudDesplazamiento, _y);
    private Coordenada AvanzarAlSur() => new(_x, _y - MagnitudDesplazamiento);
    private Coordenada AvanzarAlEste() => new(_x + MagnitudDesplazamiento, _y);

    private Coordenada TeletransportarseAlNorte() => new(_x, LimiteNorte);
    private Coordenada TeletransportarseAlSur() => new(_x, LimiteSur);
    private Coordenada TeletransportarseAlEste() => new(LimiteEste, _y);
    private Coordenada TeletransportarseAlOeste() => new(LimiteOeste, _y);

    public void AsignarElementoEnY(int y, string elemento)
    {
        _campoEjeY[y] = elemento;
    }

    public object ObtenerElementoEnY(int y)
    {
        return _campoEjeY[y];
    }
}