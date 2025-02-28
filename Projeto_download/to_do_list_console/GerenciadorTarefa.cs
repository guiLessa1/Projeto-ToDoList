using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace to_do_list_console
{
    class GerenciadorTarefa
    {

        private List<Tarefa> tarefas;

        public GerenciadorTarefa()
        {
            tarefas = new List<Tarefa>();
        }
        public void addTarefa(Tarefa t)
        {
            if (t == null)
            {
                Console.WriteLine("Tarefa inválida");
                return;
            }
            tarefas.Add(t);
            tarefas.Sort();

            Console.WriteLine("Tarefa adicionada com sucesso!");
        }
        public void excluiTarefa()
        {
            Console.WriteLine("Informe o título da Tarefa que deseja excluir");
            string titulo = Convert.ToString(Console.ReadLine());

            Tarefa procurar = new Tarefa(titulo, "", new DateTime());
            tarefas.Sort();

            int pos = tarefas.BinarySearch(procurar);
            if (pos < 0)
            {
                Console.WriteLine("Tarefa não existe!");
            }
            else
            {
                tarefas.RemoveAt(pos);
            }
        }
        public void procurarTarefa()
        {
            Console.WriteLine("Escolha como deseja procurar a Tarefa: \n 1: Titulo \n 2: Data de Vencimento:");
            if (!int.TryParse(Console.ReadLine(), out int escolha))
            {
                Console.WriteLine("Opção inválida");
                return;
            }
            switch (escolha)
            {
                case 1:
                    {
                        procurarTarefaPorTitulo();
                        break;
                    }
                case 2:
                    {
                        procurarTarefaPorData();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Opção inválida");
                        break;
                    }
            }
        }
        public void procurarTarefaPorTitulo()
        {
            Console.WriteLine("Informe o título da Tarefa que deseja procurar:");
            string titulo = Convert.ToString(Console.ReadLine());
            Tarefa procurar = new Tarefa(titulo, "");

            tarefas.Sort();
            int pos = tarefas.BinarySearch(procurar);
            if (pos < 0)
            {
                Console.WriteLine("Tarefa não existe!");
            }
            else
            {
                Tarefa encontrada = tarefas[pos];
                Console.WriteLine(encontrada.ToString());
            }
        }
        public void procurarTarefaPorData()
        {
            Console.WriteLine("Informe a Data de Vencimento da Tarefa desejada: ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime data))
            {
                Console.WriteLine("Data inválida");
                return;
            }

            var dataEncontrada = tarefas.Find(t => t.DataVencimento == data);
            if (dataEncontrada != null)
            {
                Console.WriteLine(dataEncontrada.ToString());
            }
            else
            {
                Console.WriteLine("Data não localizada");
            }

        }
        public void editarTarefa()
        {
            Console.WriteLine("Digite o título da Tarefa que deseja alterar:");
            string tituloBusca = Console.ReadLine();
            Tarefa procurar = new Tarefa(tituloBusca, "");
            tarefas.Sort();
            int pos = tarefas.BinarySearch(procurar);
            if (pos < 0)
            {
                Console.WriteLine("Tarefa não encontrada");

            }
            else
            {
                Tarefa encontrada = tarefas[pos];
                Console.WriteLine("Digite o novo título da Tarefa: ");
                string novoTitulo = Convert.ToString(Console.ReadLine());
                encontrada.Titulo = novoTitulo;
                Console.WriteLine("Digite a nova descrição da Tarefa: ");
                string novaDescricao = Convert.ToString(Console.ReadLine());
                encontrada.Descricao = novaDescricao;
                if (encontrada.DataVencimento < DateTime.Now)
                {
                    Console.WriteLine("Informe a nova Data de Vencimento");
                    DateTime novaData = Convert.ToDateTime(Console.ReadLine());
                    encontrada.DataVencimento = novaData;
                }
                Console.WriteLine("Tarefa editada com sucesso!");
            }
        }
        public void listarTarefa()
        {
            if (tarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa encontrada!");
                return;
            }

            Console.WriteLine("lista de Tarefas:");
            tarefas.Sort();
            foreach (Tarefa t in tarefas)
            {
                Console.WriteLine(t.ToString());
            }
        }
    }
}
