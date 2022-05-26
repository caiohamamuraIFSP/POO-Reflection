public class Poligonos
{
    private static IEstrategiaArea estrategiaNula = new EstrategiaNula();
    private IEstrategiaArea estrategia;
    private int lado1;
    private int lado2;

    public Poligonos(int lado1, int lado2)
    {
        this.lado1 = lado1;
        this.lado2 = lado2;
        this.estrategia = estrategiaNula;
    }

    public Poligonos(int lado1, int lado2, IEstrategiaArea estrategia)
    {
        this.lado1 = lado1;
        this.lado2 = lado2;
        this.estrategia = estrategia;
    }

    public void mudaForma(IEstrategiaArea? estrategiaMudanca)
    {
        if (estrategiaMudanca == null)
            estrategia = estrategiaNula;
        else
            estrategia = estrategiaMudanca;
    }

    public double retornaArea()
    {
        return this.estrategia.calculaArea(lado1, lado2);
    }
}