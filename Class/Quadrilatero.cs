class Quadrilatero : IEstrategiaArea
{
    public double calculaArea(int lado1, int lado2)
    {
        double area = lado1 * lado2;
        return area;
    }
}