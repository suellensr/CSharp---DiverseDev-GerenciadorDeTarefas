﻿using GerenciadorDeTarefas.Tarefas;
using GerenciadorDeTarefas.Usuarios.DadosUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Usuarios
{
    internal class GerenciaUsuarios
    {
        public static List<Usuario>? Usuarios { get; set; } = new List<Usuario>();

        UsuarioService usuarioService = new UsuarioService();

        public GerenciaUsuarios()
        {
            Usuarios = usuarioService.LerJsonUsuarios();
        }

        public List<Usuario> ReceberUsuarios()
        {
            //Usuarios = usuarioService.LerJsonUsuarios();
            return Usuarios;
        }

        public static string GerarId()
        {
            int contadorId;
            if (Usuarios.Any())
            {
                Usuario ultimoUsuario = Usuarios.Last();
                contadorId = int.Parse(ultimoUsuario.IdUsuario);
            }
            else
            {
                contadorId = 0;
            }

            if (contadorId > 99999)
            {
                throw new InvalidOperationException("Limite de IDs alcançado");
            }
            else
            {
                contadorId++;
            }

            return contadorId.ToString().PadLeft(5, '0');
        }

        public static void ExibirUsuario(Usuario usuario)
        {
            Console.WriteLine($"IdUsuario: {usuario.IdUsuario}");
            Console.WriteLine($"Nome: {usuario.Nome}");
            Console.WriteLine($"Usuário: {usuario.NomeUsuario}");
            Console.WriteLine($"E-mail: {usuario.Email}");
            Console.WriteLine($"Cargo: {usuario.Cargo}");
            Console.WriteLine();
        }

        public static bool VerificarUsuarioExiste(string user)
        {
            try
            {
                if (Usuarios.Any())
                {
                    foreach (var usuario in Usuarios)
                    {
                        if (usuario.NomeUsuario.Equals(user, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                            break;
                        }
                    }
                    return false;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao buscar usuário por nome de usuário: {e}");
                return false;
            }
        }

        public void CriarUsuario(Usuario novoUsuario)
        {
            Usuarios.Add(novoUsuario);
            usuarioService.SalvarJsonUsuario(Usuarios);
        }


        public static Usuario BuscarPeloUser(string user)
        {
            foreach (var usuario in Usuarios)
            {
                if (usuario.NomeUsuario.Equals(user, StringComparison.OrdinalIgnoreCase))
                {
                    Usuario usuarioEncontrado = usuario;
                    return usuarioEncontrado;
                    break;
                }
            }
            return new Usuario(null, null, null, null, null, ECargo.Desenvolvedor);
        }

    }
}

