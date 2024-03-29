﻿using GerenciadorDeTarefas.Usuarios.DadosUsuarios;
using GerenciadorDeTarefas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorDeTarefas.Tarefas;
using GerenciadorDeTarefas.Tarefas.DadosTarefas;

namespace GerenciadorDeTarefas.Usuarios
{
    public class TechLead : Usuario
    {
        public TechLead(string id, string nome, string email, string nomeUsuario, string senha, ECargo cargo) : base(id, nome, email, nomeUsuario, senha, ECargo.TechLead)
        {
        }
        public TechLead(Usuario usuario)
        : base(usuario.IdUsuario, usuario.Nome, usuario.Email, usuario.NomeUsuario, usuario.Senha, usuario.Cargo)
        {
        }

        GerenciaUsuarios gerenciaUsuarios = new GerenciaUsuarios();
        GerenciaTarefas gerenciaTarefas = new GerenciaTarefas();
        TarefasService tarefasService = new TarefasService();

        public void AdicionarUsuario(TechLead techLead)
        {
            Console.WriteLine("Digite o nome de usuário do novo usuário : ");
            string? nomeUsuario = Console.ReadLine();

            while (string.IsNullOrEmpty(nomeUsuario))
            {
                Console.WriteLine("O nome do usuário não pode ser vazio. Por favor, digite novamente:");
                nomeUsuario = Console.ReadLine();
            }
            //Tratamento para ver se o nome de usuário já existe no sistema
            if (GerenciaUsuarios.VerificarUsuarioExiste(nomeUsuario) == true)
            {
                Console.WriteLine($"Já existe um usuário cadastrado com esse nome de usuário.");
                Console.WriteLine("Não é possível cadastrar dois usuários com o mesmo nome de usuário.");
                Thread.Sleep(1500);
                Console.Clear();
                Interface.MenuTechLead(techLead);
            }

            //Daqui em diante recebe todos os dados necessários para criar um Usuário
            Console.Write("Digite o nome do novo usuário: ");
            string? nome = Console.ReadLine();

            while (string.IsNullOrEmpty(nome))
            {
                Console.Write("O nome do usuário não pode ser vazio. Por favor, digite novamente: ");
                nome = Console.ReadLine();
            }

            Console.Write("Digite o email do novo usuário: ");
            string? email = Console.ReadLine();

            while (string.IsNullOrEmpty(email))
            {
                Console.Write("O nome do usuário não pode ser vazio. Por favor, digite novamente: ");
                email = Console.ReadLine();
            }

            string id = GerenciaUsuarios.GerarId();
            string senhaPadrao = "12345@";
            ECargo cargo = ECargo.Desenvolvedor;
            Usuario novoUsuario = new Usuario(id, nome, email, nomeUsuario, senhaPadrao, cargo);
            gerenciaUsuarios.CriarUsuario(novoUsuario);
        }

        public void AdicionarTarefa(TechLead techLead)
        {
            try
            {

                Console.WriteLine("Digite o título da nova tarefa : ");
                string? titulo = Console.ReadLine();

                while (string.IsNullOrEmpty(titulo))
                {
                    Console.WriteLine("O título da tarefa não pode ser vazio. Por favor, digite novamente:");
                    titulo = Console.ReadLine();
                }
                //Tratamento para ver se o título da tarefa já existe no sistema
                if (GerenciaTarefas.BuscarPeloTitulo(titulo) == true)
                {
                    Console.WriteLine("Não é possível cadastrar outra tarefa com o mesmo título de uma já existente.");
                    Thread.Sleep(1500);
                    Console.Clear();
                    Interface.MenuTechLead(techLead);
                }

                //Daqui em diante recebe todos os dados necessários para criar uma Tarefa
                Console.Write("Digite uma descrição para a nova tarefa: ");
                string? descricao = Console.ReadLine();

                while (string.IsNullOrEmpty(descricao))
                {
                    Console.Write("A descriçao não pode ser vazio. Por favor, digite novamente: ");
                    descricao = Console.ReadLine();
                }
                
                List<Usuario> responsaveis = AdicionarResponsavel();
                string dataEntrega = AdicionarPrazoEntrega();
                string idProjeto = AdicionarIdProjeto();
                string id = GerenciaTarefas.GerarId();
                EStatusTarefa status = EStatusTarefa.Desenvolvimento;
                Tarefa novaTarefa = new Tarefa(id, titulo, descricao, responsaveis, dataEntrega, status, idProjeto);
                gerenciaTarefas.CriarTarefa(novaTarefa);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao adicionar tarefas: {e}");
            }
        }

        public static List<Usuario> AdicionarResponsavel()
        {
            try
            {
                //perguntando a quantidade de responsáveis e quem são eles
                int qtd_responsaveis;
                do
                {
                    Console.Write("Digite quantos usuários serão adicionados como responsáves pela tarefa: ");
                } while (!int.TryParse(Console.ReadLine()?.Trim(), out qtd_responsaveis));
                List<Usuario> responsavel = new List<Usuario>();
                //laço para receber o user dos responsáveis e adicionar na lista
                for (int i = 1; i <= qtd_responsaveis; i++)
                {
                    Console.Write($"Digite o nome de usuário do {i}º responsável : ");
                    string? user = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(user) || GerenciaUsuarios.VerificarUsuarioExiste(user) != true)
                    {
                        Console.Write("O nome de usuário vazio ou inválido. Por favor, digite novamente: ");
                        user = Console.ReadLine()?.Trim();
                    }
                    Usuario usuario = GerenciaUsuarios.BuscarPeloUser(user);
                    responsavel.Add(usuario);
                }
                return responsavel;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao adicionar responsaveis pela tarefa: {e}");
                return new List<Usuario>();
            }
        }

        public static string AdicionarPrazoEntrega()
        {
            int prazoEmDias;
            do
            {
                Console.Write("Digite o prazo de excecução da tarefa em dias: ");
            } while (!int.TryParse(Console.ReadLine(), out prazoEmDias));
            string dataEntrega = DateTime.Now.AddDays(prazoEmDias).ToString(("dd/MM/yyyy"));
            return dataEntrega;
        }

        public static string AdicionarIdProjeto()
        {
            int idProjetoInt;
            do
            {
                Console.Write("Qual o id do projeto que a tarefa pertence: ");
            } while (!int.TryParse(Console.ReadLine(), out idProjetoInt));
            string idProjeto = idProjetoInt.ToString().PadLeft(5, '0');
            return idProjeto;
        }

        public void VerTarefas()
        {
            try
            {
                List<Tarefa> listaTarefas = new List<Tarefa>();
                listaTarefas = gerenciaTarefas.ReceberListaTarefas();

                if (listaTarefas.Any())
                {
                    foreach (var tarefa in listaTarefas)
                        gerenciaTarefas.ExibirTarefa(tarefa);
                }
                else
                {
                    Console.WriteLine("Não há tarefas.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao exibir tarefas: {e}");
            }
        }

        public void AnalisarTarefas()
        {
            try
            {
                List<Tarefa> listaTarefas = new List<Tarefa>();
                listaTarefas = gerenciaTarefas.ReceberListaTarefas();

                foreach (var tarefa in listaTarefas)
                {
                    if (tarefa.Status == EStatusTarefa.Analise)
                    {
                        gerenciaTarefas.ExibirTarefa(tarefa);

                        Console.WriteLine("Digite:");
                        Console.WriteLine("1- Para aprovar a tarefa\n2- Para rejeitar a tarefa\n3- Para mantê-la em análise");
                        int opcao;
                        while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 3)
                        {
                            Console.Write("Digite o número correspondente a opção desejada: ");
                        }

                        switch (opcao)
                        {
                            case 1:
                                tarefa.Status = EStatusTarefa.Desenvolvimento;
                                //tarefa.Responsavel = AdicionarResponsavel();
                                tarefa.DataEntrega = AdicionarPrazoEntrega();
                                tarefa.IdProjetoPertencente = AdicionarIdProjeto();
                                tarefasService.SalvarJsonTarefas(listaTarefas);
                                Console.WriteLine($"\nPrecione [ENTER] para voltar");
                                Console.ReadLine();
                                Console.Clear();
                                //MenuTechLead(techLead);
                                break;

                            case 2:
                                tarefa.Status = EStatusTarefa.Abandonada;
                                tarefasService.SalvarJsonTarefas(listaTarefas);
                                Console.WriteLine($"\nPrecione [ENTER] para voltar");
                                Console.ReadLine();
                                Console.Clear();
                                //MenuTechLead(techLead);
                                break;
                            default:
                                Console.WriteLine($"\nPrecione [ENTER] para voltar");
                                Console.ReadLine();
                                Console.Clear();
                                //MenuTechLead(techLead);
                                break;
                        }
                    }

                    if (tarefa.Status == EStatusTarefa.AguardandoAprovacao)
                    {
                        Console.WriteLine("Digite:");
                        Console.WriteLine("1- Para aceitar a tarefa como concluída\n2- Para voltar com ela para desenvolvimento\n3- Para mantê-la em Aguardando Aprovação");
                        int opcao;
                        while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 3)
                        {
                            Console.Write("Digite o número correspondente a opção desejada: ");
                        }

                        switch (opcao)
                        {
                            case 1:
                                tarefa.Status = EStatusTarefa.Concluida;
                                tarefasService.SalvarJsonTarefas(listaTarefas);
                                Console.WriteLine($"\nPrecione [ENTER] para voltar");
                                Console.ReadLine();
                                Console.Clear();
                                //MenuTechLead(techLead);
                                break;

                            case 2:
                                DateTime data = DateTime.Parse(tarefa.DataEntrega);
                                if (data > DateTime.Today)
                                {
                                    tarefa.DataEntrega = AdicionarPrazoEntrega();
                                }
                                tarefa.Status = EStatusTarefa.Desenvolvimento;
                                tarefasService.SalvarJsonTarefas(listaTarefas);
                                Console.WriteLine($"\nPrecione [ENTER] para voltar");
                                Console.ReadLine();
                                Console.Clear();
                                //MenuTechLead(techLead);
                                break;
                            default:
                                Console.WriteLine($"\nPrecione [ENTER] para voltar");
                                Console.ReadLine();
                                Console.Clear();
                                //MenuTechLead(techLead);
                                break;
                        }

                        //para o else verificar a data.
                        //Se a data ok, só voltar para desenvolvimento
                        //se estiver atrasado, pedir um novo prazo, mudar a data e então voltar para desenvolvimento

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro durante o processo: {e}");
            }
        }



    }
}
