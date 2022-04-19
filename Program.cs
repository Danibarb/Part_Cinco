using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Listas<int> idades = new Listas<int>();

            idades.Adicionar(10);
            idades.AdicionarVarios(22, 45, 67, 80);

            idades.EscreverListaNaTela();

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
            ListaDeContaCorrentes ListaDeContas = new ListaDeContaCorrentes();
            ListaDeContas.Adicionar(new ContaCorrente(456, 89765));
            ListaDeContas.Adicionar(new ContaCorrente(456, 78654));
            ListaDeContas.Adicionar(new ContaCorrente(456, 761298));
            ListaDeContas.Adicionar(new ContaCorrente(456, 900122));
            ListaDeContas.Adicionar(new ContaCorrente(456, 980908));
            ListaDeContas.Adicionar(new ContaCorrente(456, 766590));
            ListaDeContas.Adicionar(new ContaCorrente(456, 767564));
            ListaDeContas.Adicionar(new ContaCorrente(456, 897651));

            ListaDeContas.EscreverListaNaTela();

            ContaCorrente contaNova = new ContaCorrente(456, 678000);
            ListaDeContas.Adicionar(contaNova);

            ListaDeContas.EscreverListaNaTela();

            ListaDeContaCorrentes Remocao = new ListaDeContaCorrentes();
            Remocao.Remover(contaNova);

            ListaDeContas.EscreverListaNaTela();

            ListaDeContaCorrentes lista = new ListaDeContaCorrentes();

            lista.AdicionarVarios(
            new ContaCorrente(100, 40010),
            new ContaCorrente(101, 40011)
            );
            lista.EscreverListaNaTela();
        }
    }


}
