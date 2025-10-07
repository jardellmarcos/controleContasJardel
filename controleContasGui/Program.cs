using controleContasGui;
using System;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main()
    {
        try
        {
            // Banco e agência
            Banco banco = new Banco("Banco dos Orcs", 123);
            Agencia agencia = new Agencia(1, "12345-678", "(11) 99999-9999", banco);

            // Clientes
            Cliente cliente1 = new Cliente("Nemesis", "12345678901", 250);
            Cliente cliente2 = new Cliente("Thor", "10987654321", 180);

            // Contas
            Conta conta1 = new Conta(111111, 1000.00m, cliente1, agencia);
            Conta conta2 = new Conta(222222, 500.00m, cliente2, agencia);

            // Exibir saldos iniciais
            Console.WriteLine($"\n{cliente1.Nome} - Conta: {conta1.Numero} - Saldo: {conta1.Saldo:C}");
            Console.WriteLine($"{cliente2.Nome} - Conta: {conta2.Numero} - Saldo: {conta2.Saldo:C}");

            // Saque com taxa
            conta1.Sacar(100);

            // Transferência com taxa
            conta1.Transferir(200, conta2);

            Console.WriteLine($"\nSaldo final {cliente1.Nome}: {conta1.Saldo:C}");
            Console.WriteLine($"Saldo final {cliente2.Nome}: {conta2.Saldo:C}");

            Console.WriteLine($"\nIdade de {cliente1.Nome} em romanos: {cliente1.IdadeEmRomanos()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
