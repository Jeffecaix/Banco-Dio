using System;
using System.Collections.Generic;

namespace TransferenciaBancaria
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos servi~çoes.");
            Console.WriteLine();
        }

        // Lista as contas contidas no ListConta

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write($"# {i} - ");
                Console.WriteLine(conta);
            }
        }

        //Insere uma conta na ListConta
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Conta Juridica: ");
            int entradaTipoConta1 = int.Parse(Console.ReadLine());
            int entradaTipoConta2 = 0;

            //Validação de Tipo Conta
            while(entradaTipoConta2 == 0)
            {
                
                if (entradaTipoConta1 == 1 || entradaTipoConta1 == 2)
                {
                    entradaTipoConta2 = entradaTipoConta1;
                    
                } 
                else
                {
                    Console.WriteLine("Valor informado não é válido!");
                    Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Conta Juridica: ");
                    entradaTipoConta1 = int.Parse(Console.ReadLine());
                }
                
            }

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            //Cria uma nova instacia da Conta
            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta2,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        name: entradaNome);

            listContas.Add(novaConta);
        }

        // Método Transferir dindin

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write($"Digite o valor a ser transferido para {listContas[indiceContaDestino].Name}: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Tranferir(valorTransferencia, listContas[indiceContaDestino]);
            Console.WriteLine("Tranferencia realizada com sucesso!");
        }

        // Método Sacar dindin

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        // Método Depositar dindin

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        //Opção usúario 

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Banco a seu dispor!!!");
            Console.WriteLine($"Informe a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Tranferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
