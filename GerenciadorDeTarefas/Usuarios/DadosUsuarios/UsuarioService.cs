using GerenciadorDeTarefas.Tarefas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Usuarios.DadosUsuarios
{
    internal class UsuarioService
    {
        public string? Caminho { get; set; }
        public UsuarioService(string arquivoJson = "JsonUsuarios.json")
        {
            Caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, arquivoJson);
            Caminho = Caminho.Replace("bin\\Debug\\net8.0", "Usuarios\\DadosUsuarios");
        }

        //LerJasonTarefas retorna uma lista com os objetos do json
        public List<Usuario>? LerJsonUsuarios()
        {
            try
            {
                if (File.Exists(Caminho))
                {
                    var conteudoJson = File.ReadAllText(Caminho);
                    List<Usuario>? usuarios = JsonConvert.DeserializeObject<List<Usuario>>(conteudoJson);
                    return usuarios;
                }

                else
                {
                    Console.WriteLine("O arquivo json não foi encontrado");
                    return new List<Usuario>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao ler o json de Usuarios: {e}");
                return new List<Usuario>();
            }
        }
        public void SalvarJsonUsuario(List<Usuario> usuarios)
        {
            try
            {
                if (File.Exists(Caminho)) // conferir se vai dar erro
                {
                    // Serializa a lista de professores de volta para o formato JSON
                    string json = JsonConvert.SerializeObject(usuarios, Formatting.Indented);

                    // Escreve o JSON de volta no arquivo
                    File.WriteAllText(Caminho, json);

                    Console.WriteLine("Alterações salvas com sucesso no arquivo JSON.");
                }
                else
                {
                    Console.WriteLine("Não foi encontrado nenhum arquivo JSON para ser atualizado.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao tentar salvar as alterações no arquivo JSON: " + e.Message);
            }
        }

    }
}
