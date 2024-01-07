using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorDeTarefas.Tarefas.DadosTarefas;
using GerenciadorDeTarefas.Usuarios.DadosUsuarios;
using GerenciadorDeTarefas.Usuarios;

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

        public List<Tarefa> ReceberListaTarefas()
        {
            return Tarefas;
        }

        public static string GerarId()
        {
            int contadorId;
            if (Tarefas.Any())
            {
                Tarefa ultimaTarefa = Tarefas.Last();
                contadorId = int.Parse(ultimaTarefa.IdTarefa);
            }
            else
            {
                contadorId = 0;
            }

            if (contadorId > 99999)
            {
                throw new InvalidOperationException("Limite de IDs alcançado");
            }
            else
            {
                contadorId++;
            }

            return contadorId.ToString().PadLeft(5, '0');
        }

        public void ExibirTarefa(Tarefa tarefa)
        {

            Console.WriteLine($"IdTarefa: {tarefa.IdTarefa}");
            Console.WriteLine($"Título: {tarefa.Titulo}");
            Console.WriteLine($"Descrição: {tarefa.Descricao}");
            Console.WriteLine("Responsáveis: ");
            foreach (Usuario usuario in tarefa.Responsavel)
            {
                GerenciaUsuarios.ExibirUsuario(usuario);
            }
            Console.WriteLine($"Data da Entrega: {tarefa.DataEntrega}");
            Console.WriteLine($"Status: {tarefa.Status}");
            Console.WriteLine();

        }

        public static bool BuscarPeloTitulo(string titulo)
        {
            try
            {
                if (Tarefas.Any())
                {
                    foreach (var tarefa in Tarefas)
                    {
                        if (tarefa.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"Existe um usuário cadastrado com esse nome de usuário.");
                            return true;
                            break;
                        }
                    }
                    return false;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao buscar tarefa por título: {e}");
                return false;
            }
        }

        public void CriarTarefa(Tarefa novaTarefa)
        {
            Tarefas.Add(novaTarefa);
            tarefasService.SalvarJsonTarefas(Tarefas);
        }

    }
}
