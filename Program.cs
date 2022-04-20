using System;
using static System.Console;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ByteBank.Modelos;
using ByteBank.Modelos.Comparadores;
using System.Linq;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var idades = new Listas<int>();

            idades.Adicionar(10);
            idades.AdicionarVarios(45, 80, 22, 67, -1);

            WriteLine("Idades sem ordenação em Sort");
            idades.EscreverListaNaTela();
            WriteLine("---------------------");

            var nomes = new List<string>()
            {
                "Marcos",
                "João",
                "Ana Paula",
                "Ana Claudia"
            };

            nomes.Sort();

            WriteLine("Nomes em Sort");

            foreach (var nome in nomes)
            {
                WriteLine(nome);
            }

            WriteLine("---------------------");

            var idades2 = new List<int>()
            {
                1,4,22,11,8
            };

            idades2.Sort();

            foreach (var idade in idades2)
            {
                WriteLine($"Idades em ordem crescente são: {idade}");
            }

            WriteLine("-----------------");
            WriteLine("Contas em Sort: ");
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(123,45678),
                null,
                new ContaCorrente(123,11122),
                new ContaCorrente(001,11111),
                null,
                null,
                new ContaCorrente(121,23423)
            };

            //contas.Sort();

            //Ordenando com Sort de uma classe personalizada
            //contas.Sort(new ComparadorContaCorrentePorAgencia());

            //Ordenando com OrderBy + expressão Lambida condicional de Null
            /*IOrderedEnumerable<ContaCorrente> ContasOrdenadas = contas.OrderBy(conta =>
            { if (conta == null)
                {
                    return int.MinValue;
                }
                return conta.Numero;
                }); */

            //Consulta lambida com Where e condicional de Nao Nulas.
            //IOrderedEnumerable<ContaCorrente> ContasOrdenadas = contas.Where(conta => conta !=null).OrderBy<ContaCorrente, int>(conta => conta.Numero);

            //Forma Condensada

            var ContasOrdenadas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            foreach (var conta in ContasOrdenadas)
            {
                if(conta != null)
                {
                    WriteLine($"Conta: {conta.Numero} / Agencia: {conta.Agencia}");
                } 
            }

            Console.ReadLine();

        }

        private static void AulaSeteArrays()
        {
            int somaIdades = 0;
            int mediaIdades;

            //Array com tamanho delimitado
            //int[] Idades = new int[6];

            //Idades[0] = 12;
            //Idades[1] = 15;
            //Idades[2] = 28;
            //Idades[3] = 37;
            //Idades[4] = 69;
            //Idades[5] = 7;

            //Array sem delimitação de tamanho

            int[] Idades = new int[]
            {
                11,15,18,22,74
            };

            WriteLine("Array de Idades");
            foreach (int i in Idades)
            {
                WriteLine(i);
            }
            WriteLine("Soma das Idades ");
            for (int i = 0; i < Idades.Length; i++)
            {
                somaIdades += Idades[i];
            }
            WriteLine(somaIdades);

            mediaIdades = somaIdades /Idades.Length;
            WriteLine($"A média de Idades é de {mediaIdades}");

            ContaCorrente[] contaArray = new ContaCorrente[]
            {
                new ContaCorrente(578,23456),
                new ContaCorrente(578, 90876),
            };

            foreach (ContaCorrente C in contaArray)
            {
                WriteLine($"Conta {C} criada com array sem delimitação. ");
            }

            Console.ReadLine();
        }
        private static void AulaSeisSubstring()
        {
            // Olá, meu nome é Guilherme e você pode entrar em contato comigo
            // através do número 8457-4456!

            // Meu nome é Guilherme, me ligue em 4784-4546

            //  "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            //  "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            //  "[0-9]{4,5}[-][0-9]{4}";
            //  "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            //  "[0-9]{4,5}-{0,1}[0-9]{4}";
            string padrao = "[0-9]{4,5}-?[0-9]{4}";

            // 879.546.120-20
            // 879546120-20

            string textoDeTeste = "idyufdgfugfjksdhf 99871--5456 sdjkfgsdjgsjgh sfsdjgsdjghsdfj";

            Match resultado = Regex.Match(textoDeTeste, padrao);

            Console.WriteLine(resultado.Value);
            Console.ReadLine();

            string urlTeste = "https://www.bytebank.com/cambio";
            int indiceByteBank = urlTeste.IndexOf("https://www.bytebank.com");

            Console.WriteLine(urlTeste.StartsWith("https://www.bytebank.com"));
            Console.WriteLine(urlTeste.EndsWith("cambio/"));

            Console.WriteLine(urlTeste.Contains("ByteBank"));

            Console.ReadLine();

            // pagina?argumentos
            // 012345678

            //moedaOrigem=real&moedaDestino=dolar
            //          |
            //  -------´

            string urlParametros = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            ExtratorValorDeArgumentosURL extratorDeValores = new ExtratorValorDeArgumentosURL(urlParametros);

            string valor = extratorDeValores.GetValor("moedaDestino");
            Console.WriteLine("Valor de moedaDestino: " + valor);

            string valorMoedaOrigem = extratorDeValores.GetValor("moedaOrigem");
            Console.WriteLine("Valor de moedaOrigem: " + valorMoedaOrigem);

            Console.WriteLine(extratorDeValores.GetValor("VALOR"));

            Console.ReadLine();

            //Testando ToLower
            string mensagemOrigem = "PALAVRA";
            string termoBusca = "ra";

            Console.WriteLine(mensagemOrigem.ToLower());

            // Testando Replace
            termoBusca = termoBusca.Replace('r', 'R');
            Console.WriteLine(termoBusca);

            termoBusca = termoBusca.Replace('a', 'A');
            Console.WriteLine(termoBusca);

            Console.WriteLine(mensagemOrigem.IndexOf(termoBusca));
            Console.ReadLine();

            // Testando o método Remove
            string testeRemocao = "primeiraParte&123456789";
            int indiceEComercial = testeRemocao.IndexOf('&');
            Console.WriteLine(testeRemocao.Remove(indiceEComercial, 4));
            Console.ReadLine();

            // <nome>=<valor>
            string palavra = "moedaOrigem=moedaDestino&moedaDestino=dolar";
            string nomeArgumento = "moedaDestino=";

            int indice = palavra.IndexOf(nomeArgumento);
            Console.WriteLine(indice);

            Console.WriteLine("Tamanho da string nomeArgumento: " + nomeArgumento.Length);

            Console.WriteLine(palavra);
            Console.WriteLine(palavra.Substring(indice));
            Console.WriteLine(palavra.Substring(indice + nomeArgumento.Length));
            Console.ReadLine();

            // Testando o IsNullOrEmpty
            string textoVazio = "";
            string textoNulo = null;
            string textoQualquer = "kjhfsdjhgsdfjksdf";
            Console.WriteLine(String.IsNullOrEmpty(textoVazio));
            Console.WriteLine(String.IsNullOrEmpty(textoNulo));
            Console.WriteLine(String.IsNullOrEmpty(textoQualquer));
            Console.ReadLine();

            ExtratorValorDeArgumentosURL extrator = new ExtratorValorDeArgumentosURL("");

            string url = "pagina?moedaOrigem=real&moedaDestino=dolar";

            int indiceInterrogacao = url.IndexOf('?');

            Console.WriteLine(indiceInterrogacao);

            Console.WriteLine(url);
            string argumentos = url.Substring(indiceInterrogacao + 1);
            Console.WriteLine(argumentos);
        }

        private static void AulaSeteArrays2()
        {
            var ListaDeContas = new ListaDeContaCorrentes();

            ListaDeContas.Adicionar(new ContaCorrente(456, 89765));
            ListaDeContas.Adicionar(new ContaCorrente(456, 78654));
            ListaDeContas.Adicionar(new ContaCorrente(456, 761298));
            ListaDeContas.Adicionar(new ContaCorrente(456, 900122));
            ListaDeContas.Adicionar(new ContaCorrente(456, 980908));
            ListaDeContas.Adicionar(new ContaCorrente(456, 766590));
            ListaDeContas.Adicionar(new ContaCorrente(456, 767564));
            ListaDeContas.Adicionar(new ContaCorrente(456, 897651));

            ListaDeContas.EscreverListaNaTela();

            var contaNova = new ContaCorrente(456, 678000);
            ListaDeContas.Adicionar(contaNova);

            ListaDeContas.EscreverListaNaTela();

            var Remocao = new ListaDeContaCorrentes();
            Remocao.Remover(contaNova);

            ListaDeContas.EscreverListaNaTela();

            var lista = new ListaDeContaCorrentes();

            lista.AdicionarVarios(
            new ContaCorrente(100, 40010),
            new ContaCorrente(101, 40011)
            );
            lista.EscreverListaNaTela();
        }
    }


}
