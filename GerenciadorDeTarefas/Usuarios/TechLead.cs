using GerenciadorDeTarefas.Usuarios.DadosUsuarios;
using GerenciadorDeTarefas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Usuarios
{
    public class TechLead: Usuario
    {
        public TechLead(string nome, string email, string nomeUsuario, string senha, ECargo cargo) : base(nome, email, nomeUsuario, senha, ECargo.TechLead)
        {
        }
        public TechLead(Usuario usuario)
        : base(usuario.Nome, usuario.Email, usuario.NomeUsuario, usuario.Senha, usuario.Cargo)
        {
        }

        GerenciaUsuarios gerenciaUsuarios = new GerenciaUsuarios();
        private Usuario usuario;

        public void AdicionarUsuario(TechLead techLead)
        {
            Console.WriteLine("Digite o nome de usuário do novo usuário : ");
            string? nomeUsuario = Console.ReadLine();

            while (string.IsNullOrEmpty(nomeUsuario))
            {
                Console.WriteLine("O nome do usuário não pode ser vazio. Por favor, digite novamente:");
                nomeUsuario = Console.ReadLine();
            }
            //Tratamento para ver se o nome de usuário já existe no sistema
            if(GerenciaUsuarios.BuscarPeloUser(nomeUsuario) == true)
            {
                Console.WriteLine("Não é possível cadastrar outro usuário com o mesmo nome de usuário.");
                Thread.Sleep(1500);
                Console.Clear();
                Interface.MenuTechLead(techLead);
            }

            //Daqui em diante recebe todos os dados necessários para criar um Usuário
            Console.Write("Digite o nome do novo usuário: ");
            string? nome = Console.ReadLine();

            while (string.IsNullOrEmpty(nome))
            {
                Console.Write("O nome do usuário não pode ser vazio. Por favor, digite novamente: ");
                nome = Console.ReadLine();
            }

            Console.Write("Digite o email do novo usuário: ");
            string? email = Console.ReadLine();

            while (string.IsNullOrEmpty(email))
            {
                Console.Write("O nome do usuário não pode ser vazio. Por favor, digite novamente: ");
                email = Console.ReadLine();
            }

            string senhaPadrao = "12345@";
            ECargo cargo = ECargo.Desenvolvedor;
            Usuario novoUsuario = new Usuario(nome, email, nomeUsuario, senhaPadrao, cargo);
            gerenciaUsuarios.CriarUsuario(novoUsuario);
        }

        //public void CriarLivro(Livro novoLivro)
        //{
        //    try
        //    {
        //        if (VerificaSeLivroJaExiste(novoLivro))
        //            Console.WriteLine("Este livro já existe no sistema.");
        //        else
        //        {
        //            List<Livro> Livros = DeserializaJSON();
        //            Livros.Add(novoLivro);
        //            SerializaJSON(Livros);
        //            Console.WriteLine("Livro criado com sucesso.");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine($"Não foi possível criar um livro: {e}");
        //    }
        //}





    }
}
