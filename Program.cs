using ByteBank.Models;

Clientes cliente = new Clientes();
bool menu = true;
int user;
int other;

ExibirMenu();
Console.WriteLine("PROGRAMA ENCERRADO!!!");

/*========== FUNÇÃO EXIBIR MENU =========*/
void ExibirMenu()
{
    do
    {
        Console.Clear();

        Console.WriteLine("=============== BYTEBANK ===============");
        Console.WriteLine();
        Console.WriteLine("1 - ADICIONAR CLIENTE");
        Console.WriteLine("2 - DELETAR CLIENTE");
        Console.WriteLine("3 - LISTAR TODAS AS CONTAS REGISTRADAS");
        Console.WriteLine("4 - DETALHES DE UM CLIENTE");
        Console.WriteLine("5 - VALOR TOTAL NO BANCO");
        Console.WriteLine("6 - MANIPULAR CONTA");
        Console.WriteLine("0 - PARA SAIR DO PROGRAMA");
        Console.WriteLine();
        Console.Write("DIGITE A OPÇÃO DESEJADA: ");
        string opcao = Console.ReadLine();

        Console.Clear();
        switch (opcao)
        {
            case "0":
                EncerrarMenu();
                break;
            case "1":
                cliente.AdicionarCliente();
                break;
            case "2":
                cliente.DeletarCliente();
                break;
            case "3":
                cliente.ListarClientes();
                break;
            case "4":
                cliente.DetalhesCliente();
                break;
            case "5":
                cliente.ValorTotalBanco();
                break;
            case "6":
                Console.WriteLine("LOGIN...");
                Console.WriteLine();
                user = cliente.Login();
                if (user >= 0)
                {
                    SubMenu();
                }
                else if (user < 0)
                {
                    Console.WriteLine("ERRO AO LOGAR!!!");
                }
                break;
            default:
                Console.WriteLine("OPÇÃO INVALIDA!!!");
                break;
        }
        Console.WriteLine();
        Console.WriteLine("APERTE UMA TECLA PARA CONTINUAR");
        Console.ReadLine();

    } while (menu == true);
}

/*========== FUNÇÃO ENCERRAR MENU PRINCIPAL=========*/
void EncerrarMenu()
{
    Console.WriteLine("Deseja sair? [1 - Sim]  [2 - Não]");
    string sair = Console.ReadLine();
    if (sair == "1")
    {
        Console.WriteLine("Saindo do programa!!!");
        menu = false;
    }
    else if (sair == "2")
    {
        Console.WriteLine("Retornando para o menu principal!!!");
    }
    else
    {
        Console.WriteLine("Opção inválida!!!");
    }
}
/*========== FUNÇÃO EXIBIR SUBMENU =========*/
void SubMenu()
{

    bool rep = true;

    string nomeTitular;
    string nomeDestinatario;
    double saldoTitular;


    do
    {
        nomeTitular = cliente.NomeTitular(user);
        saldoTitular = cliente.SaldoConta(user);

        Console.Clear();

        Console.WriteLine($"=============== CONTA {nomeTitular.ToUpper()} ===============");
        Console.WriteLine();
        Console.WriteLine("1 - EXTRATO");
        Console.WriteLine("2 - DEPOSITAR");
        Console.WriteLine("3 - SACAR");
        Console.WriteLine("4 - TRANSFERIR");
        Console.WriteLine("0 - PARA SAIR DO PROGRAMA");
        Console.WriteLine();
        Console.Write("DIGITE A OPÇÃO DESEJADA: ");
        string op = Console.ReadLine();

        Console.Clear();

        switch (op)
        {
            case "0":
                rep = false;
                break;
            case "1":
                Console.WriteLine($"EXTRATO");
                Console.WriteLine();
                Console.WriteLine($"Titular: {nomeTitular.ToUpper()}");
                Console.WriteLine($"Saldo: R$ {saldoTitular:f2}");
                break;
            case "2":
                Console.WriteLine($"DEPOSITO");
                Console.WriteLine();
                Console.WriteLine($"Titular: {nomeTitular.ToUpper()}");
                Console.WriteLine($"Saldo: R$ {saldoTitular:f2}");
                Console.WriteLine();
                Console.WriteLine($"Saldo atual: R$ {cliente.DepositoConta(user):f2}");
                Console.WriteLine();
                break;
            case "3":
                Console.WriteLine("SAQUE");
                Console.WriteLine();
                Console.WriteLine($"Titular: {nomeTitular.ToUpper()}");
                Console.WriteLine($"Saldo: R$ {saldoTitular:f2}");
                Console.WriteLine();
                Console.WriteLine($"Saldo atual: R$ {cliente.SaqueConta(user):f2}");
                Console.WriteLine();
                break;
            case "4":
                Console.WriteLine("TRANSFERÊNCIA PARA O DESTINATÁRIO");
                Console.WriteLine();
                other = cliente.BuscarIndex();
                Console.Clear();
                if (other >= 0 && other != user)
                {
                    Console.WriteLine($"DESTINATÁRIO: {cliente.NomeTitular(other).ToUpper()}");
                    Console.WriteLine();
                    Console.WriteLine($"Valor Transferido para {cliente.NomeTitular(other)}: R$ {cliente.TransferenciaDeConta(user, other):f2}");
                }
                else if (other >= 0 && other == user)
                {
                    Console.WriteLine("NÃO PODE TRANSFERIR PARA VC MESMO!!!");
                }
                else if (other < 0)
                {
                    Console.WriteLine("TITULAR NÂO EXISTE!!!");
                }
                break;
            default:
                Console.WriteLine("OPÇÃO INVALIDA!!!");
                break;
        }
        Console.WriteLine();
        Console.WriteLine("APERTE UMA TECLA PARA CONTINUAR");
        Console.ReadLine();

    } while (rep == true);
    Console.WriteLine("RETORNANDO PARA MENU PRINCIPAL!!!");

}