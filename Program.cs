
bool menu = true;
List<string> Clientes = new List<string>();

ShowMenu();
Console.WriteLine("PROGRAMA ENCERRADO!!!");

/*========== FUNÇÃO EXIBIR MENU =========*/
void ShowMenu()
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
        string opcao = Console.ReadLine();

        Console.Clear();
        switch (opcao)
        {
            case "1":
                Console.WriteLine("Adicionando Cliente!!!");
                AdicionarCliente();
                break;
            case "2":
                DeletarCliente();
                break;
            case "3":
                ListarClientes();
                break;
            case "4":
                Console.WriteLine("Detalhar Cliente!!!");
                break;
            case "5":
                Console.WriteLine("Quantidade Armazenada!!!");
                break;
            case "6":
                Console.WriteLine("Manipular Conta!!!");
                break;
            case "0":
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
    Console.WriteLine("Deseja sair [Y/N]?");
    string sair = Console.ReadLine();
    if (sair == "y" || sair == "Y")
    {
        Console.WriteLine("Saindo do programa!!!");
        menu = false;
    }
    else if (sair == "n" || sair == "N")
    {
        Console.WriteLine("Retornando para o menu!!!");
    }
    else
    {
        Console.WriteLine("Opção Invalida!!!");
    }
}

void AdicionarCliente()
{
    Console.WriteLine("Digite o nome do Cliente");
    string addCliente = Console.ReadLine();
    Clientes.Add(addCliente);
    Console.WriteLine();
    Console.WriteLine($"Cliente {addCliente}, foi adicionado com sucesso!!!");
}

void DeletarCliente()
{
    Console.WriteLine("DELETAR CLIENTE!!!");
    string dellClient = Console.ReadLine();
    //Clientes.Remove(dellClient);
    int? posicao = null;

    for (int i = 0; i < Clientes.Count; i++)
    {
        if (Clientes[i] == dellClient)
        {
            posicao = i;
        }
    }

    if (posicao == null)
    {
        Console.WriteLine($"Cliente {dellClient}, não existe!");
    }
    else
    {
        Clientes.RemoveAt((int)posicao);
        Console.WriteLine($"Cliente {dellClient}, deletado com sucesso!!!");
    }
}

void ListarClientes()
{
    Console.WriteLine("LISTA DE CLIENTES");
    Console.WriteLine();
    int i = 0;
    foreach (string list in Clientes)
    {
        Console.WriteLine($"{list}");
    }
    int totalClient = Clientes.Count;
    Console.WriteLine();
    Console.WriteLine($"TOTAL DE CLIENTES REGISTRADOS: {totalClient}");
}