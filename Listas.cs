using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    //Criando uma classe genérica para a criação de listas.
    internal class Listas<T>
    {
        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }

        }

        //Criando variaveis para receber a lista de Contas e as posições
        private T[] _itens;
        private int _proximaPosicao;

        //Construtor do array de 5 posições
        public Listas(int capacidadeInicial = 5)
        {
            _itens = new T[capacidadeInicial];
            _proximaPosicao = 0;
        }

        //Método para adicionar novos itens à Conta Corrente
        public void Adicionar(T item)
        {
            VerificarCapacidade(_proximaPosicao + 1);

            //WriteLine($"Adicionando novo item na posiçao {_proximaPosicao} do Array.");

            _itens[_proximaPosicao] = item;
            _proximaPosicao++;

        }
        public void AdicionarVarios(params T[] itens)
        {
            foreach (T conta in itens)
            {
                Adicionar(conta);
            }
        }
        public T GetItemNoIndice(int indice)
        {
            if (indice <0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }
            return _itens[indice];
        }

        public T this[int indice]
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

            T[] novoArray = new T[novoTamanho];

            for (int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];
                //WriteLine(".");
            }
            _itens = novoArray;
        }

        public void Remover(T item)
        {
            int indiceItem = -1;
            //Percorrendo o array para localizar o Indice com o valor a ser removido
            for (int i = 0; i < _proximaPosicao; i++)
            {
                T itemAtual = _itens[i];

                if (itemAtual.Equals(item))
                {
                    indiceItem = i;
                    break;
                }

            }
            //Deslocando os demais valores para a esquerda do valor a ser removido
            for (int i = indiceItem; i < _proximaPosicao-1; i++)
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
            for (int i = 0; i < _proximaPosicao; i++)
            {
                T lista = _itens[i];
                WriteLine($"Item do indice {i}: {lista}");
            }
        }
    }
}
