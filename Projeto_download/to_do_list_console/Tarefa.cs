using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace to_do_list_console
{
    class Tarefa : IComparable<Tarefa>
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataVencimento { get; set; }
        public bool Feito { get; set; }
        public Tarefa(string Titulo, string descricao, DateTime? dataVencimento = null)
        {
            if (string.IsNullOrWhiteSpace(Titulo))
            {
                Console.WriteLine("Título inválido");
            }
            if (string.IsNullOrWhiteSpace(descricao))
            {
                Console.WriteLine("Descrição inválida");
            }

            this.Titulo = Titulo;
            this.Descricao = descricao;
            this.DataVencimento = dataVencimento ?? DateTime.MaxValue;
            this.Feito = false;
        }
        public void concluir()
        {
            Feito = true;
        }
        public int CompareTo(Tarefa t)
        {
            if (t == null) return 1;
            return Titulo.CompareTo(t.Titulo);
        }

        public override String ToString()
        {
            return $"Titulo: {Titulo}, Descrição: {Descricao}, Data De Vencimento: {DataVencimento:d/M/yyyy}, Status: {status()}";
        }
        public string status()
        {
            if (Feito)
            {
                return "(Concluída)";
            }
            else if (DateTime.Now > DataVencimento)
            {
                return "(Vencida)";
            }
            else
            {
                int dias = (DataVencimento.Value - DateTime.Now).Days;
                return $"(Vence em {dias} dias!)";
            }
        }
    }
}
