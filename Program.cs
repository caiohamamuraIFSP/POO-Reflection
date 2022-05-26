using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace dotnet
{
    class Program
    {
        static List<string> Estrategias()
        {
            IEnumerable<string> types = from t in AppDomain.CurrentDomain.GetAssemblies()
                                        from s in t.GetTypes()
                                        where s.GetInterface("IEstrategiaArea") != null
                                        select s.ToString();
            return types.ToList();
        }

        static int ConverteInteiro(string mensagem)
        {
            Console.Write(mensagem);
            string valor = Console.ReadLine();
            int saida;
            bool transformou = int.TryParse(valor, out saida);
            if (
                transformou &&
                saida > 0
                )
                return saida;
            return ConverteInteiro(mensagem);
        }
        static void Main(string[] args)
        {
            int dimensao1 = ConverteInteiro("Escolha um valor para a 1ª dimensão: ");
            int dimensao2 = ConverteInteiro("Escolha um valor para a 2ª dimensão: ");

            Console.WriteLine("Escolha uma das estratégias: ");
            Estrategias().ForEach(e => Console.Write(e + " | "));
            Console.CursorLeft -= 3;
            Console.Write("   \n");
            string tipoDigitado = Console.ReadLine() ?? "";
            Type tipoEscolhido = Type.GetType(tipoDigitado);

            if (
                tipoEscolhido?.GetInterface(nameof(IEstrategiaArea)) == null
            )
            {
                Console.WriteLine("Não é uma estratégia válida!");
                return;
            }
            ConstructorInfo construtor = tipoEscolhido.GetConstructor(new Type[] { });
            IEstrategiaArea estrategia = (IEstrategiaArea)construtor.Invoke(null);
            var poligono = new Poligonos(dimensao1, dimensao2, (IEstrategiaArea)estrategia);
            Console.WriteLine(poligono.retornaArea());
        }
    }
}