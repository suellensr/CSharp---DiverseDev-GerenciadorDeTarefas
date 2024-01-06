using GerenciadorDeTarefas.Tarefas.DadosTarefas;
using GerenciadorDeTarefas.Usuarios;
using GerenciadorDeTarefas.Usuarios.DadosUsuarios;

namespace GerenciadorDeTarefas.Tarefas
{
    public class Tarefa
    {
        public string? IdTarefa { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public List<Usuario>? Responsavel { get; set; }

        public string? DataEntrega { get; set; }
        public EStatusTarefa Status { get; set; }
        public string? IdProjetoPertencente { get; set; }

        public Tarefa(string id, string titulo, string descricao, List<Usuario> responsavel,
            string dataEntrega, EStatusTarefa status, string idProjeto)
        {
            IdTarefa = id;
            Titulo = titulo;
            Descricao = descricao;
            Responsavel = responsavel;
            DataEntrega = dataEntrega;
            Status = status;
            IdProjetoPertencente = idProjeto;
        }
    }
}