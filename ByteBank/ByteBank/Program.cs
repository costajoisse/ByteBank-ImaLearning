

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
            Console.WriteLine("0 - Sair");
            Console.Write("Digite a opção desejada: ");
        }

        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
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
            string cpfParaDeposito = Console.ReadLine();
            int indexParaDeposito = cpfs.FindIndex(cpf => cpf == cpfParaDeposito);
            Console.Write("Digite o valor para deposito: ");
            int valorDeposito = int.Parse(Console.ReadLine());
            Console.Write($"Confirma o valor de R$ {valorDeposito} para deposito?");
            Console.Write("SIM ou NÃO");
            string confirma = Console.ReadLine();

            if (confirma == "SIM")
            {
                int saldoCliente = 0;
                saldoCliente += valorDeposito;
            }
    

        }
        static void transferir(List<string> cpfs, List<double> saldos)
        {
            string cpfParaDeposito = Console.ReadLine();
            int indexParaDeposito = cpfs.FindIndex(cpf => cpf == cpfParaDeposito);
            Console.Write("Digite CPF do usuário que deseja transferir: ");
            double valor = double.Parse(Console.ReadLine());
        }

        static void ManipularConta(List<double> saldos, List<string> cpfs)
        {


            Console.Write("Digite o CPF: ");
            string cpfParaAchar = Console.ReadLine();
            int indexParaAchar = cpfs.FindIndex(cpf => cpf == cpfParaAchar);

            if (indexParaAchar == -1)
            {

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Não foi possível apresentar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
                Console.ResetColor();

            }
            else
            {

                Console.WriteLine("Insira como gostaria de ser chamado(a): ");
                string nomeUsuario = Console.ReadLine();
                Console.WriteLine($"Olá,{nomeUsuario}! Bem-Vindo! ");


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
                        case 0:
                            Console.WriteLine("Estou encerrando o programa...");
                            break;
                        case 1:
                            Depositos(cpfs, saldos);

                            break;
                        case 2:
                            transferir(cpfs, saldos);
                            break;


                    }

                }
                while (optionSec != 0);
            }
        static void Main(string[] args)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("________________________________OLÁ, BEM VINDO!________________________________");
                Console.ResetColor();

                Console.WriteLine("Antes de começar a usar, vamos configurar alguns valores: ");

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
                            Console.WriteLine("Estou encerrando o programa...");
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
}


