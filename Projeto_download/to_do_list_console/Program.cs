using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace to_do_list_console
{
    class Program
    {
        static void Main(string[] args)
        {
            GerenciadorTarefa gerenciador = new GerenciadorTarefa();

            Tarefa t1 = new Tarefa("Estudar C#", "Estudar Herança", new DateTime(2005, 07, 19));
            gerenciador.addTarefa(t1);
            Tarefa t2 = new Tarefa("Lavar louça", "Lavar Pratos", new DateTime(2025, 11, 17));
            gerenciador.addTarefa(t2);
            Tarefa t3 = new Tarefa("Testar Projeto", "Testar métodos", new DateTime(2025, 2, 22));
            gerenciador.addTarefa(t3);
            Console.WriteLine(t1.relatorio());
            Console.WriteLine(t2.relatorio());
            Console.WriteLine(t3.relatorio());

            gerenciador.procurarTarefa();
            gerenciador.listarTarefa();
           
            Console.ReadKey();
        }

    }
}
