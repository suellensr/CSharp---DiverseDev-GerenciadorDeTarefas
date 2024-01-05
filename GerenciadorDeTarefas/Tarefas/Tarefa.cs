using GerenciadorDeTarefas.Usuarios;

namespace GerenciadorDeTarefas.Tarefas
{
    public class Tarefa
    {
        private static int contadorId = 0;
        public string? IdTarefa { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public List<Usuario>? Responsavel {  get; set; }

        public string? DataEntrega {  get; set; }
        public EStatusTarefa Status { get; set; }



        //criar o construtor de tarefa





        public static string GerarID()
        {
            contadorId++;
            if (contadorId > 999999)
            {
                throw new InvalidOperationException("Limite de IDs alcançado");
            }

            return contadorId.ToString().PadLeft(6, '0');
        }


    }
}

