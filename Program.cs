using System;
using System.Reflection;

/*namespace dotnet
{
    class Program
    {
            enum Poligono
{
    Quadrilatero,
    Triangulo,
    Losango
}

class PoligonoDuasDimensoes
{
    int dimensao1;
    int dimensao2;
    Poligono poligono;

    public PoligonoDuasDimensoes(Poligono poligono, int dimensao1, int dimensao2)
    {
        this.dimensao1 = dimensao1;
        this.dimensao2 = dimensao2;
        this.poligono = poligono;
    }

    public int calculaArea(Poligono poligono)
    {
        switch (poligono)
        {
            case Poligono.Quadrilatero:
                return dimensao1 * dimensao2;
            case Poligono.Triangulo:
                return (dimensao1 * dimensao2) / 2;
            case Poligono.Losango:
                return (dimensao1 * dimensao2) / 2;
            default:
                return 0;
        }
    }
}

        static void Main(string[] args)
        {
            Poligono quadrilatero = new Poligono();
            PoligonoDuasDimensoes quadrilatero1 = new PoligonoDuasDimensoes(quadrilatero, 2, 2);
            Console.WriteLine(quadrilatero1.calculaArea(quadrilatero));
        }
    }
}*/
namespace dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            string tipoDigitado = Console.ReadLine() ?? "";
            Type? tipoEscolhido = Type.GetType(tipoDigitado);

            if (
                tipoEscolhido?.GetInterface(nameof(IEstrategiaArea)) == null
            ) 
            {
                Console.WriteLine("Não é uma estratégia válida!");
                return;
            }
            ConstructorInfo construtor = tipoEscolhido.GetConstructor(new Type[] {});
            IEstrategiaArea estrategia = (IEstrategiaArea)construtor.Invoke(null);
            var poligono = new Poligonos(4, 5, (IEstrategiaArea)estrategia);
            System.Console.WriteLine(poligono.retornaArea());    
        
            

        }
    }
}