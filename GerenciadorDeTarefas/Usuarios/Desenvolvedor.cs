using GerenciadorDeTarefas.Interfaces;
using GerenciadorDeTarefas.Tarefas.DadosTarefas;
using GerenciadorDeTarefas.Tarefas;
using GerenciadorDeTarefas.Usuarios.DadosUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Usuarios
{
    public class Desenvolvedor : Usuario
    {
        public Desenvolvedor(string id, string nome, string email, string nomeUsuario, string senha, ECargo cargo) : base(id, nome, email, nomeUsuario, senha, ECargo.Desenvolvedor)
        {
        }

        public Desenvolvedor(Usuario usuario)
        : base(usuario.IdUsuario, usuario.Nome, usuario.Email, usuario.NomeUsuario, usuario.Senha, usuario.Cargo)
        {
        }

        GerenciaTarefas gerenciaTarefas = new GerenciaTarefas();

        //colocar as classes específicas aqui

        public void AdicionarTarefa(Desenvolvedor desenvolvedor, Usuario usuario)
        {
            Console.WriteLine("Digite o título da nova tarefa : ");
            string? titulo = Console.ReadLine();

            while (string.IsNullOrEmpty(titulo))
            {
                Console.WriteLine("O título da tarefa não pode ser vazio. Por favor, digite novamente:");
                titulo = Console.ReadLine();
            }
            //Tratamento para ver se o título da tarefa já existe no sistema
            if (GerenciaTarefas.BuscarPeloTitulo(titulo) == true)
            {
                Console.WriteLine("Não é possível cadastrar outra tarefa com o mesmo título de uma já existente.");
                Thread.Sleep(1500);
                Console.Clear();
                Interface.MenuDesenvolvedor(desenvolvedor, usuario);
            }

            //Daqui em diante recebe todos os dados necessários para criar uma Tarefa
            Console.Write("Digite uma descrição para a nova tarefa: ");
            string? descricao = Console.ReadLine();

            while (string.IsNullOrEmpty(descricao))
            {
                Console.Write("O descriçao não pode ser vazio. Por favor, digite novamente: ");
                descricao = Console.ReadLine();
            }

            string id = GerenciaTarefas.GerarId();
            List<Usuario> responsavel = new List<Usuario>();
            responsavel.Add(usuario);
            string dataEntrega = "Aguardando definição.";
            EStatusTarefa status = EStatusTarefa.Analise;
            string idProjeto = "Aguardando definição.";
            Tarefa novaTarefa = new Tarefa(id, titulo, descricao, responsavel, dataEntrega, status, idProjeto);
            gerenciaTarefas.CriarTarefa(novaTarefa);
        }

        //Acho que para esse caso, vai ser mais fácil criar projeto e puxar todos as tarefas onde ele estiver presente

        //public void VerTarefas(Desenvolvedor desenvolvedor)
        //{
        //    List<Tarefa> listaTarefas = new List<Tarefa>();
        //    listaTarefas = gerenciaTarefas.ReceberListaTarefas();
        //    List<Tarefa> tarefasUsuario = new List<Tarefa>();
        //    foreach(var tarefa in listaTarefas)
        //    {
        //        foreach(var reponsavel in tarefa.Responsavel)
        //        {
        //            if (desenvolvedor.IdUsuario == reponsavel.IdUsuario)

        //        }

        //    }


        //    gerenciaTarefas.ExibirTarefas(listaTarefas);
        //}

    }
}
