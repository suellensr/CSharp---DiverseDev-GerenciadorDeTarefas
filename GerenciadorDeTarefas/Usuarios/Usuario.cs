using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Usuarios;

namespace GerenciadorDeTarefas.Usuarios
{
    public class Usuario
    {
        private static int contadorId = 0;
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

        public static string GerarID()
        {
            contadorId++;
            if (contadorId > 99999)
            {
                throw new InvalidOperationException("Limite de IDs alcançado");
            }

            return contadorId.ToString().PadLeft(5, '0');
        }

        private static string LerSenha()
        {
            string senha = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Enter)
                {
                    senha += key.KeyChar;
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return senha;
        }

        public static void FazerLogin()
        {
            GerenciaUsuarios gerenciaUsuarios = new GerenciaUsuarios();
            List<Usuario> usuarios = gerenciaUsuarios.ReceberUsuarios();

            while (true)
            {
                string? nomeUsuario;
                string? senhaUsuario;

                do
                {
                    Console.Write("Digite seu nome de usuário: ");
                    nomeUsuario = Console.ReadLine();

                    if (string.IsNullOrEmpty(nomeUsuario))
                    {
                        Console.WriteLine("Entrada inválida. Tente novamente.");
                    }
                } while (string.IsNullOrEmpty(nomeUsuario));

                do
                {
                    Console.Write("Digite sua senha: ");
                    senhaUsuario = LerSenha();

                    if (string.IsNullOrEmpty(senhaUsuario))
                    {
                        Console.WriteLine("Entrada inválida. Tente novamente.");
                    }
                } while (string.IsNullOrEmpty(nomeUsuario));

                Usuario? usuario = usuarios.FirstOrDefault(predicate: u => u.NomeUsuario == nomeUsuario);
                if (usuario != null && usuario.Senha == senhaUsuario)
                {
                    Console.WriteLine($"Login bem-sucedido! Bem-vindo, {usuario.Nome}.");
                    if (usuario.Cargo == ECargo.TechLead)
                    {
                        Console.WriteLine("Você é um Tech Lead");
                    }
                    else
                    {
                        Console.WriteLine("Você um desenvolvedor");
                    }

                    //fazer um if para verificar se é tech Lead ou Desenvolvedor

                    //return professor;

                }
                else
                {
                    Console.WriteLine("Nome de usuário ou a senha incorreto.");
                }
            }
        }
        //Criar um Exibir Lista de Funcionários e exibir só Id, Nome e email
        //Criar um busca Por nome

        //usar o geradorDeId para quando for criar um novo usuario
        //quando for criar novo funcionário, forçar o cargo para desenvolvedor

        
    }
}
