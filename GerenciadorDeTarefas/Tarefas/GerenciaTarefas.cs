using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Tarefas
{
    internal class GerenciaTarefas
    {
        public static List<Tarefa>? Tarefas { get; private set; } = new List<Tarefa>();
        TarefasService tarefasService = new TarefasService();

        public GerenciaTarefas()
        {
            Tarefas = tarefasService.LerJsonTarefas();
        }

        //public List<Tarefa> ReceberListaTarefas()
        //{
        //    Tarefas = tarefasService.LerJsonTarefas();
        //    return Tarefas;
        //}

        public void ExibirTarefas()
        {
            //ReceberListaTarefas();
            foreach (var tarefa in Tarefas)
            {
                Console.WriteLine(tarefa.IdTarefa);
                Console.WriteLine(tarefa.Titulo);
                Console.WriteLine(tarefa.Descricao);
                Console.WriteLine(tarefa.Responsavel);
                Console.WriteLine(tarefa.DataEntrega);
                Console.WriteLine(tarefa.Status);
            }
        }

        //public void AdicionarTarefas()
        //{

        //}

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
