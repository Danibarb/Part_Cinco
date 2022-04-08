using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos.Properties;

namespace ByteBank.Modelos
{
    internal class ParceiroComercial : IAutenticavel
    {
        public string Senha { get; set; }

        public AutenticacaoHelper autenticacaoHelper = new AutenticacaoHelper();

        public bool Autenticar(string senha)
        {
            return autenticacaoHelper.CompararSenha(Senha, senha);
        }
    }
}