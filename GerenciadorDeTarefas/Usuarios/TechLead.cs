using GerenciadorDeTarefas.Usuarios.DadosUsuarios;
using GerenciadorDeTarefas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorDeTarefas.Tarefas;
using GerenciadorDeTarefas.Tarefas.DadosTarefas;

namespace GerenciadorDeTarefas.Usuarios
{
    public class TechLead: Usuario
    {
        public TechLead(string id, string nome, string email, string nomeUsuario, string senha, ECargo cargo) : base(id, nome, email, nomeUsuario, senha, ECargo.TechLead)
        {
        }
        public TechLead(Usuario usuario)
        : base(usuario.IdUsuario, usuario.Nome, usuario.Email, usuario.NomeUsuario, usuario.Senha, usuario.Cargo)
        {
        }

        GerenciaUsuarios gerenciaUsuarios = new GerenciaUsuarios();
        GerenciaTarefas gerenciaTarefas = new GerenciaTarefas();
        //private Tarefa usuario;

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

            string id = GerenciaUsuarios.GerarId();
            string senhaPadrao = "12345@";
            ECargo cargo = ECargo.Desenvolvedor;
            Usuario novoUsuario = new Usuario(id,nome, email, nomeUsuario, senhaPadrao, cargo);
            gerenciaUsuarios.CriarUsuario(novoUsuario);
        }

        //public void AdicionarTarefa(TechLead techLead)
        //{
        //    Console.WriteLine("Digite o título da nova tarefa : ");
        //    string? titulo = Console.ReadLine();

        //    while (string.IsNullOrEmpty(titulo))
        //    {
        //        Console.WriteLine("O título da tarefa não pode ser vazio. Por favor, digite novamente:");
        //        titulo = Console.ReadLine();
        //    }
        //    //Tratamento para ver se o título da tarefa já existe no sistema
        //    if (GerenciaTarefas.BuscarPeloTitulo(titulo) == true)
        //    {
        //        Console.WriteLine("Não é possível cadastrar outra tarefa com o mesmo título de uma já existente.");
        //        Thread.Sleep(1500);
        //        Console.Clear();
        //        Interface.MenuTechLead(techLead);
        //    }

        //    //Daqui em diante recebe todos os dados necessários para criar uma Tarefa
        //    Console.Write("Digite uma descrição para a nova tarefa: ");
        //    string? descricao = Console.ReadLine();

        //    while (string.IsNullOrEmpty(descricao))
        //    {
        //        Console.Write("O descriçao não pode ser vazio. Por favor, digite novamente: ");
        //        descricao = Console.ReadLine();
        //    }
            
        //    //criar uma pergunta de quantos responsáveis serão
        //    //fazer um laço for para receber o user dos responsáveis
        //    //criar uma busca que retorne um usuário pelo user
        //    //acrescentar o user na List responsáveis


        //    //Perguntar qual será o prazo de execução
        //    //a data recebe um datetime now e acrescenta o prazo acima igual na senha professor

        //    Console.Write("Qual o id do projeto que a tarefa pertence: ");
        //    int? idProjeto = Console.ReadLine();
        //    // colocar pra conferir se é um número e converter p os 000 no começo

        //    string id = GerenciaTarefas.GerarId();
        //    EStatusTarefa status = EStatusTarefa.Desenvolvimento;
        //    Tarefa novaTarefa = new Tarefa(id, titulo, descricao, responsavel, dataEntrega, status, idProjeto);
        //    gerenciaTarefas.CriarTarefa(novaTarefa);
        //}





    }
}
