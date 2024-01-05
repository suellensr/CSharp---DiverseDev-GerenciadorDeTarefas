using GerenciadorDeTarefas.Tarefas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Usuarios
{
    internal class GerenciaUsuarios
    {
        public static List<Usuario>? Usuarios { get; private set; } = new List<Usuario>();
        UsuarioService usuarioService = new UsuarioService();

        //public GerenciaUsuarios()
        //{
        //    Usuarios = usuarioService.LerJsonUsuarios();
        //}

        public List<Usuario> ReceberUsuarios()
        {
            Usuarios = usuarioService.LerJsonUsuarios();
            return Usuarios;
        }

        public void ExibirUsuarios()
        {
            ReceberUsuarios();
            foreach (var usuario in Usuarios)
            {
                Console.WriteLine(usuario.IdUsuario);
                Console.WriteLine(usuario.Nome);
                Console.WriteLine(usuario.Email);
                Console.WriteLine(usuario.Cargo);
            }
        }

        public Usuario BuscarUsuarioPorNome(string nome)
        {
            ReceberUsuarios();
            


            //List<Livro> Livros = DeserializaJSON();
            //Livro? livroIgual = Livros.FirstOrDefault(l => l.Titulo == livro.Titulo && l.Autor == livro.Autor && l.Reservas == livro.Reservas);
            //if (livroIgual != null)
            //    return true;
            //return false;
        }

    }
}

