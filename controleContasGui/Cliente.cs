using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleContasGui
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }

        public Cliente(string nome, string cpf, int idade)
        {
            if (idade < 18)
                throw new ArgumentException("O cliente deve ter mais de 18 anos.");
            if (cpf.Length != 11)
                throw new ArgumentException("O CPF deve conter 11 dígitos (sem ponto e traço).");

            Nome = nome;
            CPF = cpf;
            Idade = idade;
        }

        // Método opcional – idade em números romanos
        public string IdadeEmRomanos()
        {
            int idade = Idade;
            var mapa = new[]
            {
                new { Valor = 100, Simbolo = "C" },
                new { Valor = 90, Simbolo = "XC" },
                new { Valor = 50, Simbolo = "L" },
                new { Valor = 40, Simbolo = "XL" },
                new { Valor = 10, Simbolo = "X" },
                new { Valor = 9, Simbolo = "IX" },
                new { Valor = 5, Simbolo = "V" },
                new { Valor = 4, Simbolo = "IV" },
                new { Valor = 1, Simbolo = "I" },
            };

            string resultado = "";
            foreach (var item in mapa)
            {
                while (idade >= item.Valor)
                {
                    resultado += item.Simbolo;
                    idade -= item.Valor;
                }
            }
            return resultado;
        }
    }
}
  