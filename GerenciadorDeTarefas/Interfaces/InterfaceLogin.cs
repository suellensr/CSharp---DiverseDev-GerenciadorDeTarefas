﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios;

namespace GerenciadorDeTarefas.Interfaces
{
    internal class InterfaceLogin
    {
        //neste caso só tem um login de usuário. Pelo cargo que eu descido qual menu charmar
        
        //internal static void EscolherUsuario()
        //{
        //    Console.WriteLine("Selecione login desejado:");
        //    Console.WriteLine("1- Tech Lead\n2- Desenvolvedor\n3- Sair do Sistema");
        //    int opcaoUsuario;
        //    while (!int.TryParse(Console.ReadLine(), out opcaoUsuario) || opcaoUsuario < 1 || opcaoUsuario > 3)
        //    {
        //        Console.Write("Digite o número correspondente ao seu login.\n");
        //    }

        //    switch (opcaoUsuario)
        //    {
        //        case 1:
        //            Console.WriteLine("\nLOGIN DE ESTUDANTE");

        //            Estudante estudante = new Estudante();
        //            Estudante? estudanteLogado = estudante.Login() as Estudante;

        //            if (estudanteLogado != null)
        //            {
        //                InterfaceEstudante.MenuEstudante(estudanteLogado);
        //            }
        //            return;

        //        case 2:
        //            Console.WriteLine("\nLOGIN DE PROFESSOR");
        //            Professor professor = new Professor();
        //            Professor? professorLogado = professor.Login() as Professor;

        //            if (professorLogado != null)
        //            {
        //                InterfaceProfessor.MenuProfessor(professorLogado);
        //            }
        //            return;

        //        case 3:
        //            Console.WriteLine("\nLOGIN DE FUNCIONÁRIO");

        //            Funcionario funcionario = new Funcionario();
        //            Funcionario funcionarioLogado = funcionario.Login() as Funcionario;

        //            if (funcionarioLogado == null)
        //            {
        //                VoltarMenu();
        //            }

        //            Console.WriteLine($"Logado como {funcionarioLogado.Nome}");
        //            if (funcionarioLogado.Cargo == Cargos.Atendente)
        //            {
        //                Atendente atendente = InterfaceFuncionario.TransformarAtendente(funcionarioLogado);
        //                InterfaceFuncionario.MenuAtendente(atendente);
        //            }
        //            else if (funcionarioLogado.Cargo == Cargos.Bibliotecario)
        //            {
        //                Bibliotecario bibliotecario = InterfaceFuncionario.TransformarBibliotecario(funcionarioLogado);
        //                InterfaceFuncionario.MenuBibliotecario(bibliotecario);
        //            }
        //            else
        //            {
        //                Diretor diretor = InterfaceFuncionario.TransformarDiretor(funcionarioLogado);
        //                InterfaceFuncionario.MenuDiretor(diretor);
        //            }
        //            return;

        //        case 4:
        //            Console.WriteLine("Agradecemos por usar nossos serviços. Até mais!");
        //            Environment.Exit(0);
        //            return;
        //        default:
        //            Console.WriteLine("Número digitado não corresponde a nenhuma das opções");
        //            return;
        //    }

        //    internal static void VoltarMenu()
        //    {
        //        Console.WriteLine("\nO que deseja fazer?");
        //        Console.WriteLine("1- Voltar ao menu principal\n2- Sair");

        //        int opcao;
        //        while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 2)
        //        {
        //            Console.Write("Digite o número correspondente à sua escolha: ");
        //        }

        //        switch (opcao)
        //        {
        //            case 1:
        //                Console.Clear();
        //                EscolherUsuario();
        //                return;
        //            case 2:
        //                Console.WriteLine("Obrigado por usar nossos serviços. Até mais!");
        //                Environment.Exit(0);
        //                return;
        //            default:
        //                Console.WriteLine("Número digitado não corresponde a nenhuma das opções.");
        //                break;
        //        }
    }
}