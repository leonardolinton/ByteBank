using ByteBank.Models;

bool menu = true;
List<string> Nomes = new List<string>();
List<string> Cpfs = new List<string>();
List<double> Saldo = new List<double>();

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
        Console.WriteLine("5 - QUANTIDADE ARMAZENADA NO BANCO");
        Console.WriteLine("6 - MANIPULAR CONTA");
        Console.WriteLine("0 - PARA SAIR DO PROGRAMA");
        Console.WriteLine();
        Console.WriteLine("DIGITE A OPÇÃO DESEJADA");
        int opcao = int.Parse(Console.ReadLine());

        Console.Clear();
        switch (opcao)
        {
            case 1:
                AdicionarCliente();
                break;
            case 2:
                DeletarCliente();
                break;
            case 3:
                ListarClientes();
                break;
            case 4:
                DetalhesCliente();
                break;
            case 5:
                Console.WriteLine("Quantidade Armazenada!!!");
                ValorTotalBanco();
                break;
            case 6:
                Console.WriteLine("Manipular Conta!!!");
                break;
            case 0:
                EncerrarMenu();
                break;
            default:
                Console.WriteLine("Opção Invalida!!!");
                break;
        }
        Console.WriteLine();
        Console.WriteLine("APERTE UMA TECLA PARA CONTINUAR");
        Console.ReadLine();

    } while (menu == true);
}


/*========== FUNÇÃO ENCERRAR MENU =========*/
void EncerrarMenu()
{
    Console.WriteLine("Deseja sair? [1 - Sim]  [2 - Não]");
    int sair = int.Parse(Console.ReadLine());
    if (sair == 1)
    {
        Console.WriteLine("Saindo do programa!!!");
        menu = false;
    }
    else if (sair == 2)
    {
        Console.WriteLine("Retornando para o menu principal!!!");
    }
    else
    {
        Console.WriteLine("Opção inválida!!!");
    }
}

void AdicionarCliente()
{
    Console.WriteLine("Adicionando Cliente!!!");
    Console.Write("Digite o nome: ");
    string? nomeCliente = Console.ReadLine();
    Nomes.Add(nomeCliente);

    Console.Write("Digite o CPF: ");
    string? cpfCliente = Console.ReadLine();
    Cpfs.Add(cpfCliente);

    Console.Write("Digite saldo: ");
    double saldoCliente = double.Parse(Console.ReadLine());
    Saldo.Add(saldoCliente);

    Console.WriteLine();
    Console.WriteLine($"Cliente {nomeCliente}, adicionado com sucesso!!!");

}

void DeletarCliente()
{
    Console.WriteLine("Deletar cliente!!!");
    Console.Write("Digite o CPF do cliente: ");
    string dellClient = Console.ReadLine();
    int? posicao = null;

    for (int i = 0; i < Cpfs.Count; i++)
    {
        if (Cpfs[i] == dellClient)
        {
            posicao = i;
        }
    }

    if (posicao == null)
    {
        Console.WriteLine($"CPF {dellClient}, não existe!");
    }
    else
    {
        Console.WriteLine($"Cliente {Nomes[(int)posicao]} sendo excluido!");
        Cpfs.RemoveAt((int)posicao);
        Saldo.RemoveAt((int)posicao);
        Nomes.RemoveAt((int)posicao);
        Console.WriteLine($"Deletado com sucesso!!!");
    }
}

void ListarClientes()
{
    Console.WriteLine("Lista de clientes");
    Console.WriteLine();

    for (int i = 0; i < Nomes.Count; i++)
    {
        Console.WriteLine($"{i + 1} - CPF = {Cpfs[i]} | NOME = {Nomes[i]} | SALDO = {Saldo[i]:f2}");
    }
    int totalClient = Nomes.Count;
    Console.WriteLine();
    Console.WriteLine($"Total de clientes: {totalClient}");
}

void DetalhesCliente()
{
    Console.WriteLine("Consultar cliente!!!");
    Console.WriteLine("Digite o CPF do cliente");
    string cpfCliente = Console.ReadLine();

    int? posicao = null;

    for (int i = 0; i < Cpfs.Count; i++)
    {
        if (Cpfs[i] == cpfCliente)
        {
            posicao = i;
        }
    }

    Console.Clear();
    if (posicao == null)
    {
        Console.WriteLine($"CPF {cpfCliente}, não existe!");
    }
    else
    {
        Console.WriteLine($"Detalhes do cliente!!!");
        Console.WriteLine($"CPF: {Cpfs[(int)posicao]}");
        Console.WriteLine($"Nome: {Nomes[(int)posicao]}");
        Console.WriteLine($"Saldo: R$ {Saldo[(int)posicao]:f2}");
    }
}

void ValorTotalBanco()
{
    double total = Saldo.Sum();
    Console.WriteLine($"valor total em caixa: R$ {total:f2}");
}