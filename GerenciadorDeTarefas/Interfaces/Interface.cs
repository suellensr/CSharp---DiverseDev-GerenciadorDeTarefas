using GerenciadorDeTarefas.Usuarios.DadosUsuarios;
using GerenciadorDeTarefas.Usuarios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GerenciadorDeTarefas.Interfaces
{
    public class Interface
    {

        private static string LerSenha()
        {
            string senha = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Enter)
                {
                    senha += key.KeyChar;
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return senha;
        }

        public static void FazerLogin()
        {
            GerenciaUsuarios gerenciaUsuarios = new GerenciaUsuarios();
            List<Usuario> usuarios = gerenciaUsuarios.ReceberUsuarios();
            bool menuOn = true;
            while (menuOn)
            {
                string? nomeUsuario;
                string? senhaUsuario;

                do
                {
                    Console.WriteLine("SISTEMA DE GERENCIAMENTO DE TAREFAS");
                    Console.WriteLine("____________________________________");
                    Console.Write("Digite seu nome de usuário: ");
                    nomeUsuario = Console.ReadLine();

                    if (string.IsNullOrEmpty(nomeUsuario))
                    {
                        Console.WriteLine("Entrada inválida. Tente novamente.");
                    }
                } while (string.IsNullOrEmpty(nomeUsuario));

                do
                {
                    Console.Write("Digite sua senha: ");
                    senhaUsuario = LerSenha();

                    if (string.IsNullOrEmpty(senhaUsuario))
                    {
                        Console.WriteLine("Entrada inválida. Tente novamente.");
                    }
                } while (string.IsNullOrEmpty(senhaUsuario));

                Usuario? usuario = usuarios.FirstOrDefault(predicate: u => u.NomeUsuario == nomeUsuario);
                if (usuario != null && usuario.Senha == senhaUsuario)
                {
                    //menuOn = false;
                    Console.WriteLine($"Login bem-sucedido! Bem-vindo, {usuario.Nome}.");
                    if (usuario.Cargo == ECargo.TechLead)
                    {

                        TechLead techLead = new TechLead(usuario);                        
                        Thread.Sleep(1500);
                        Console.Clear();
                        MenuTechLead(techLead);
                    }
                    else
                    {
                        Desenvolvedor desenvolvedor = new Desenvolvedor(usuario);
                        Thread.Sleep(1500);
                        Console.Clear();
                        MenuDesenvolvedor(desenvolvedor, usuario);
                    }
                }
                else
                {
                    Console.WriteLine("Nome de usuário ou a senha incorreto.");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
        }

        public static void MenuTechLead(TechLead techLead)
        {
            Console.WriteLine("SISTEMA DE GERENCIAMENTO DE TAREFAS");
            Console.WriteLine("____________________________________");
            Console.WriteLine($"Olá, {techLead.NomeUsuario}!");
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1- Ver as tarefas\n2- Criar tarefa\n3- Definir responsável por tarefa\n" +
                "4- Analisar tarefas\n5- Ver estatísticas\n6- Adicionar usuário\n7- Sair");
            int opcao;
            while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 7)
            {
                Console.Write("Digite o número correspondente a opção desejada: ");
            }
            
            switch (opcao)
            {
                case 2:
                    techLead.AdicionarTarefa(techLead);
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    Console.Clear();
                    MenuTechLead(techLead);
                    return;

                case 6:
                    techLead.AdicionarUsuario(techLead);
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    Console.Clear();
                    MenuTechLead(techLead);
                    return;

                default:
                    Console.WriteLine("Número digitado não corresponde a nenhuma das opções");
                    MenuTechLead(techLead);
                    return;
            }
        }

    public static void MenuDesenvolvedor(Desenvolvedor desenvolvedor, Usuario usuario)
        {
            Console.WriteLine("SISTEMA DE GERENCIAMENTO DE TAREFAS");
            Console.WriteLine("____________________________________");
            Console.WriteLine($"Olá, {desenvolvedor.NomeUsuario}!");
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1- Ver minhas tarefas\n2- Criar tarefa\n3- Sair");

            int opcao;
            while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 7)
            {
                Console.Write("Digite o número correspondente a opção desejada: ");
            }

            switch (opcao)
            {
                case 2:
                    desenvolvedor.AdicionarTarefa(desenvolvedor, usuario);
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    Console.Clear();
                    MenuDesenvolvedor(desenvolvedor, usuario);
                    return;

                default:
                    Console.WriteLine("Número digitado não corresponde a nenhuma das opções");
                    MenuDesenvolvedor(desenvolvedor, usuario);
                    return;
            }
        }
    }
}
