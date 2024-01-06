using GerenciadorDeTarefas.Usuarios.DadosUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Usuarios
{
    public class Desenvolvedor: Usuario
    {
        public Desenvolvedor(string nome, string email, string nomeUsuario, string senha, ECargo cargo) : base(nome, email, nomeUsuario, senha, ECargo.Desenvolvedor)
        {
        }

        public Desenvolvedor(Usuario usuario)
        : base(usuario.Nome, usuario.Email, usuario.NomeUsuario, usuario.Senha, usuario.Cargo)
        {
        }

        //colocar as classes específicas aqui




    }
}


//Console.WriteLine("O que deseja fazer?");
//Console.WriteLine("1- Tentar novamente\n2- Voltar ao menu principal\n3- Sair");

//int opcao;
//while (!int.TryParse(Console.ReadLine(), out opcao))
//{
//    Console.Write("Digite o número correspondente à sua escolha: ");
//}

//switch (opcao)
//{
//    case 1:
//        break;
//    case 2:
//        return null;
//    case 3:
//        Console.WriteLine("Obrigado por usar nossos serviços. Até mais!");
//        Environment.Exit(0);
//        return null;
//    default:
//        Console.WriteLine("Número digitado não corresponde a nenhuma das opções.");
//        break;
//}
//            }