using System;
using System.Collections.Generic;

namespace AppBank
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
                        Trasferir();
                    break;
                    case "4":
                        Sacar();
                    break;
                    case "5":
                        Depositar();
                    break;
                    case "C": Console.Clear();
                    break;

                    default:
                    throw new ArgumentOutOfRangeException();
        
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();

        }

        private static void Trasferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int idOrigem = int.Parse(Console.ReadLine());
            Console.Write("Digite o número da conta de destino: ");
            int idDestino = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor da transferência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[idOrigem].Transferir(valorTransferencia, listContas[idDestino]);

        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int idConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor do depósito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[idConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor do saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuam conta cadastrada.");
                return;
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Iserir nova conta");
            Console.Write("Digite 1 para conta física ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();
            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.Write("Digite o crédito: ");
            double valorCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: valorCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);               
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("AppBank a seu dispor!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar Contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferência");
            Console.WriteLine("4- Saque");
            Console.WriteLine("5- Depósito");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Encerrar");
            Console.WriteLine();

            string opcaUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaUsuario;
        }
    }
}
