using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ControleTarefas
{
    public class TarefasService
    {
        public string? Caminho { get; set; }
        public TarefasService(string arquivoJson = "JsonTarefas.json")
        {
            Caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Professores", arquivoJson);
            Caminho = Caminho.Replace("GerenciadorDeTarefas\\bin\\Debug\\net8.0\\Professores", "ControleTarefas");
        }

        //LerJasonTarefas retorna uma lista com os objetos do json
        public List<Tarefa>? LerJsonTarefas()
        {
            try
            {
                if (File.Exists(Caminho))
                {
                    var conteudoJson = File.ReadAllText(Caminho);
                    List<Tarefa>? tarefas = JsonConvert.DeserializeObject<List<Tarefa>>(conteudoJson);
                    return tarefas;
                }

                else
                {
                    Console.WriteLine("O arquivo json não foi encontrado");
                    return new List<Tarefa>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao ler o json de Professores: {e}");
                return new List<Tarefa>();
            }
        }
        public void SalvarJsonProfessores(List<Tarefa> tarefas)
        {
            try
            {
                if (File.Exists(Caminho)) // conferir se vai dar erro
                {
                    // Serializa a lista de professores de volta para o formato JSON
                    string json = JsonConvert.SerializeObject(tarefas, Formatting.Indented);

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

