using ControleTarefas;

namespace GerenciadorDeTarefas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            TarefasService tarefaService = new TarefasService();
            Console.WriteLine(tarefaService.Caminho);
            //List<Professor> professores = professorService.LerJsonProfessores() ?? new List<Professor>();
        }
    }
}
