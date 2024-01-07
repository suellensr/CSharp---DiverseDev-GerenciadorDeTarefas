using GerenciadorDeTarefas.Tarefas;
using GerenciadorDeTarefas.Usuarios.DadosUsuarios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Usuarios
{
    public class Usuario
    {
        public string? IdUsuario { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? NomeUsuario { get; set; }
        public string? Senha { get; set; }
        public ECargo Cargo { get; set; }

        public Usuario(string id, string nome, string email, string nomeUsuario, string senha, ECargo cargo)
        {
            IdUsuario = id;
            Nome = nome;
            Email = email;
            NomeUsuario = nomeUsuario;
            Senha = senha;
            Cargo = cargo;
        }

        
    }


}




//Criar um Exibir Lista de Funcionários e exibir só Id, Nome e email
//Criar um busca Por nome

//usar o geradorDeId para quando for criar um novo usuario
//quando for criar novo funcionário, forçar o cargo para desenvolvedor