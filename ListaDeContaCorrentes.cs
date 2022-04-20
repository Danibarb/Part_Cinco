using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    internal class ListaDeContaCorrentes
    {
        public int Tamanho 
        {
            get
            {
                return _proximaPosicao;
            }
        
        }

        //Criando variaveis para receber a lista de Contas e as posições
        private ContaCorrente[] _itens;
        private int _proximaPosicao;

        //Construtor do array de 5 posições
        public ListaDeContaCorrentes(int capacidadeInicial = 5)
        {
            _itens = new ContaCorrente[capacidadeInicial];
            _proximaPosicao = 0;
        }
        
        //Método para adicionar novos itens à Conta Corrente
        public void Adicionar(ContaCorrente item)
        {
            VerificarCapacidade(_proximaPosicao + 1);

            WriteLine($"Adicionando novo item na posiçao {_proximaPosicao} do Array.");

            _itens[_proximaPosicao] = item;
            _proximaPosicao++;

        }
        public void AdicionarVarios(params ContaCorrente[] itens)
        {
            foreach (ContaCorrente conta in itens)
            {
                Adicionar(conta);
            }
        }
        public ContaCorrente GetItemNoIndice(int indice)
        {
            if (indice <0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }
            return _itens[indice];
        }

        public ContaCorrente this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }
        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }
            int novoTamanho = _itens.Length * 2;

            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            //WriteLine($"Aumentando a Capacidade do Array");

            ContaCorrente[] novoArray = new ContaCorrente[novoTamanho];

            for(int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];
                //WriteLine(".");
            }
            _itens = novoArray;
        }

        public void Remover(ContaCorrente item)
        {
            int indiceItem = -1;
            //Percorrendo o array para localizar o Indice com o valor a ser removido
            for (int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente itemAtual = _itens[i];

                if (itemAtual.Equals(item))
                {
                    indiceItem = i;
                    break;
                }

            }
            //Deslocando os demais valores para a esquerda do valor a ser removido
            for(int i = indiceItem; i < _proximaPosicao-1; i++)
            {
                _itens[i] = _itens[i+1];
            }
            //Deslocando(decrementando) os itens do array
            _proximaPosicao--;

            //Ultima posição agora recebe NULL
            //_itens[_proximaPosicao] = null;
        }

        public void EscreverListaNaTela()
        {
            for(int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente conta = _itens[i];
                WriteLine($"Conta do indice {i}: Número {conta.Numero} {conta.Agencia}");
            }
        }
    }
}
