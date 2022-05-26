class Losango : IEstrategiaArea
{
    public double calculaArea(int lado1, int lado2)
    {
        double area = (lado1 * lado2) / 2.0;
        return area;
    }
}