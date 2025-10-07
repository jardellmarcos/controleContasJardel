using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleContasGui
{
    public class Conta
    {
        private long _numero;
        private decimal _saldo;
        private Cliente _titular;
        private Agencia _agencia;

        // Construtor — só é possível criar conta informando saldo, número e titular
        public Conta(long numero, decimal saldoInicial, Cliente titular, Agencia agencia)
        {
            if (titular == null)
                throw new ArgumentException("A conta deve possuir um titular.");
            if (saldoInicial <= 10)
                throw new ArgumentException("O saldo inicial deve ser superior a R$10,00.");
            if (agencia == null)
                throw new ArgumentException("A conta deve pertencer a uma agência.");

            _numero = numero;
            _saldo = saldoInicial;
            _titular = titular;
            _agencia = agencia;
        }

        public long Numero => _numero;
        public decimal Saldo => _saldo;
        public Cliente Titular => _titular;
        public Agencia Agencia => _agencia;

        // Método de saque com taxa de R$0,10
        public decimal Sacar(decimal valor)
        {
            decimal total = valor + 0.10m; // inclui a taxa

            if (total > _saldo)
            {
                Console.WriteLine("Saldo insuficiente para realizar o saque!");
                return _saldo;
            }

            _saldo -= total;
            Console.WriteLine($"Saque de {valor:C} realizado com taxa de R$0,10. Saldo atual: {_saldo:C}");
            return _saldo;
        }

        // Método de transferência
        public void Transferir(decimal valor, Conta destino)
        {
            if (valor + 0.10m > _saldo)
            {
                Console.WriteLine("Saldo insuficiente para realizar a transferência!");
                return;
            }

            _saldo -= valor + 0.10m; // taxa também é cobrada na transferência
            destino._saldo += valor;

            Console.WriteLine($"Transferência de {valor:C} realizada com taxa de R$0,10.");
            Console.WriteLine($"Saldo origem: {_saldo:C} | Saldo destino: {destino._saldo:C}");
        }
    }
}

