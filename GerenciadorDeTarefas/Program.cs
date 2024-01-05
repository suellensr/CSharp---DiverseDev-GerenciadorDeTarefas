using GerenciadorDeTarefas.Tarefas;
using GerenciadorDeTarefas.Usuarios;

namespace GerenciadorDeTarefas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TarefasService tarefaService = new TarefasService();
            //Console.WriteLine(tarefaService.Caminho);

            //GerenciaTarefas gerenciaTarefas = new GerenciaTarefas();
            //gerenciaTarefas.ExibirTarefas();


            //UsuarioService usuarioService = new UsuarioService();
            //Console.WriteLine(usuarioService.Caminho);

            //GerenciaUsuarios gerenciaUsuarios = new GerenciaUsuarios();
            //gerenciaUsuarios.ExibirUsuarios();

            Usuario.Login();

        }
    }
}
