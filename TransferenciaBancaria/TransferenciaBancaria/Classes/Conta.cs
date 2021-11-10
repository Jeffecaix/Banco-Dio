using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferenciaBancaria
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        public string Name { get; set; }


        // Contrutor
        // Método construtor, utilizado para chamar e criar os objetos

        public Conta(TipoConta tipoConta, double saldo, double credito, string name)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Name = name;
        }

        // Contrutor
        // Método Sacar

        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito * - 1))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine($"Saldo atual da conta de {Name} é R$ {Saldo} ");

            return true;
        }

        // Contrutor
        // Método Depositar

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine($"Saldo atual da conta de {Name} é R$ {Saldo}");
        }

        // Contrutor
        // Método Transferir

        public void Tranferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        // Contrutor 
        // Método para sobre escrever o ToString

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo de Conta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Name + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito + " | ";
            return retorno;

        }
    }
}
