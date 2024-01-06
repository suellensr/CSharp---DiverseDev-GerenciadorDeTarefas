using GerenciadorDeTarefas.Tarefas.DadosTarefas;
using GerenciadorDeTarefas.Usuarios;
using GerenciadorDeTarefas.Interfaces;

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


            Interface.FazerLogin();

            //Usuario usuario = new Usuario("Julia Barbosa","juliab@example.com", "juliab", "12345@", Usuarios.DadosUsuarios.ECargo.TechLead);
            //TechLead techLead = new TechLead("Julia Barbosa", "juliab@example.com", "juliab", "12345@", Usuarios.DadosUsuarios.ECargo.TechLead);
            //techLead.AdicionarUsuario(usuario);
          
        }
    }
}
