

namespace ByteBank
{

    public class Program
    {

        public static void ShowMenu()
        {
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Quantia armazenada no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.Write("Digite a opção desejada: ");
        }
        public static void ShowMenuSec()
        {
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sair");
            Console.Write("Digite a opção desejada: ");
        }

        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o CPF: ");
            cpfs.Add(Console.ReadLine());
            Console.Write("Digite o nome: ");
            titulares.Add(Console.ReadLine());
            Console.Write("Digite a senha: ");
            senhas.Add(Console.ReadLine());
            Console.Write("Insira valor do patrimonio atual: ");
            saldos.Add(double.Parse(Console.ReadLine()));
        }

        static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o CPF: ");
            string cpfParaDeletar = Console.ReadLine();
            int indexParaDeletar = cpfs.FindIndex(cpf => cpf == cpfParaDeletar);

            if (indexParaDeletar == -1)
            {
                Console.WriteLine("Não foi possível deletar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }

            cpfs.Remove(cpfParaDeletar);
            titulares.RemoveAt(indexParaDeletar);
            senhas.RemoveAt(indexParaDeletar);
            saldos.RemoveAt(indexParaDeletar);

            Console.WriteLine("Conta deletada com sucesso");
        }

        static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            for (int i = 0; i < cpfs.Count; i++)
            {
                ApresentaConta(i, cpfs, titulares, saldos);
            }
        }

        static void ApresentarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Write("Digite o CPF: ");
            string cpfParaApresentar = Console.ReadLine();
            int indexParaApresentar = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);



            if (indexParaApresentar == -1)
            {
                Console.WriteLine("Não foi possível apresentar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }

            ApresentaConta(indexParaApresentar, cpfs, titulares, saldos);
        }

        static void ApresentarValorAcumulado(List<double> saldos)
        {
            Console.WriteLine($"Total acumulado no banco: {saldos.Sum():F2}");
            saldos.Sum();

        }

        static void ApresentaConta(int index, List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = R${saldos[index]:F2}");
        }


        static void Depositos(List<string> cpfs, List<double> saldos)
        {
            Console.WriteLine("Digite o CPF para deposito: ");
            string cpfParaDeposito = Console.ReadLine();
            int indexParaDeposito = cpfs.FindIndex(cpf => cpf == cpfParaDeposito);


            Console.WriteLine("Digite o valor para deposito: ");
            int valorDeposito = int.Parse(Console.ReadLine());
            Console.WriteLine($"Confirma o valor de R$ {valorDeposito:F2} para deposito?");
            Console.Write("SIM ou NÃO: ");
            string confirma = Console.ReadLine();

            if (confirma == "SIM")
            {
                int t = cpfs.IndexOf(cpfParaDeposito);
                saldos[t] -= valorDeposito;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Deposito efetuado com sucesso.");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("_______________________________________________________________________________");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Favor, refaça a operação.");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("_______________________________________________________________________________");
                Console.ResetColor();
            }


        }
        static void sacar(List<string> cpfs, List<double> saldos)
        {
            Console.WriteLine("Digite o CPF para saque: ");
            string cpfParaSacar = Console.ReadLine();
            int indexParaSacar = cpfs.FindIndex(cpf => cpf == cpfParaSacar);


            Console.WriteLine("Digite o valor que deseja sacar: ");
            int valorSaque = int.Parse(Console.ReadLine());
            Console.WriteLine($"Confirma o valor de R$ {valorSaque:F2} para saque?");
            Console.Write("SIM ou NÃO: ");
            string confirma = Console.ReadLine();

            if (confirma == "SIM")
            {
                int t = cpfs.IndexOf(cpfParaSacar);
                saldos[t] -= valorSaque;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Saque efetuado com sucesso.");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("_______________________________________________________________________________");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Favor, refaça a operação.");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("_______________________________________________________________________________");
                Console.ResetColor();
            }


        }
        static void transferir(List<string> cpfs, List<double> saldos)
        {
            Console.WriteLine("Digite o CPF para fazer a transferência: ");
            string cpfParaTransferir = Console.ReadLine();
            int indexParaTransferir = cpfs.FindIndex(cpf => cpf == cpfParaTransferir);


            Console.WriteLine("Digite o valor que deseja transferir: ");
            int valorTransferido = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o CPF para receber a transferência: ");
            string cpfParaReceber = Console.ReadLine();
            int indexParaReceber = cpfs.FindIndex(cpf => cpf == cpfParaReceber);

            Console.WriteLine($"Confirma o valor de R$ {valorTransferido:F2} para transferencia?");
            Console.Write("SIM ou NÃO: ");
            string confirma = Console.ReadLine();

            if (confirma == "SIM")
            {
                int t = cpfs.IndexOf(cpfParaTransferir);
                int r = cpfs.IndexOf(cpfParaReceber);

                saldos[t] -= valorTransferido;
                saldos[r] += valorTransferido;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Transferencia efetuada com sucesso.");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("_______________________________________________________________________________");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Favor, refaça a operação.");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("_______________________________________________________________________________");
                Console.ResetColor();
            }


        }
        static void ManipularConta(List<double> saldos, List<string> cpfs)
        {


            Console.Write("Digite o CPF: ");
            string cpfParaAchar = Console.ReadLine();
            int indexParaAchar = cpfs.FindIndex(cpf => cpf == cpfParaAchar);

            if (indexParaAchar == -1)
            {


                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não foi possível apresentar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
                Console.ResetColor();

            }
            else
            {

                Console.WriteLine("Insira como gostaria de ser chamado(a): ");
                string nomeUsuario = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Olá,{nomeUsuario}! Bem-Vindo(a)! ");
                Console.ResetColor();

                int optionSec;


                ShowMenuSec();
                optionSec = int.Parse(Console.ReadLine());
                do
                {

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("_______________________________________________________________________________");
                    Console.ResetColor();

                    switch (optionSec)
                    {
                        case 1:
                            Depositos(cpfs, saldos);
                            break;
                        case 2:
                            sacar(cpfs, saldos);
                            break;
                        case 3:
                            transferir(cpfs, saldos);
                            break;
                        case 4:
                            ShowMenu();
                            break;
                    }


                    Console.WriteLine("1 - Depositar");
                    Console.WriteLine("2 - Sacar");
                    Console.WriteLine("3 - Transferir");
                    Console.WriteLine("4 - Voltar");
                    Console.Write("Digite a opção desejada: ");
                    optionSec = int.Parse(Console.ReadLine());
                }
                while (optionSec != 4);
            }

        }
        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("________________________________OLÁ, BEM VINDO!________________________________");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("Como posso te ajudar? Escolha a opção que melhor lhe atender: ");
            Console.WriteLine();

            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();

            int option;

            do
            {
                ShowMenu();
                option = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("_______________________________________________________________________________");
                Console.ResetColor();

                switch (option)
                {
                    case 0:
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Estou encerrando o programa...Até breve!");
                        Console.ResetColor();

                        break;
                    case 1:
                        RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        DeletarUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 3:
                        ListarTodasAsContas(cpfs, titulares, saldos);
                        break;
                    case 4:
                        ApresentarUsuario(cpfs, titulares, saldos);
                        break;
                    case 5:
                        ApresentarValorAcumulado(saldos);
                        break;
                    case 6:
                        ManipularConta(saldos, cpfs);
                        break;

                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("_______________________________________________________________________________");
                Console.ResetColor();

            } while (option != 0);



        }
    }
}




