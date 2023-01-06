using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ByteBank.Models
{
    public class Clientes
    {
        /*========== ATRIBUTOS =========*/
        public List<string> titulares = new List<string>();
        List<string> cpfs = new List<string>();
        List<string> senha = new List<string>();
        Conta conta = new Conta();

        /*========== METODOS =========*/
        public void AdicionarCliente()
        {
            Console.WriteLine("ADICIONAR CLIENTE");
            Console.WriteLine();

            Console.Write("Digite o CPF: ");
            string? cpfCliente = Console.ReadLine();
            bool cpfExistente = true;

            for (int i = 0; i < cpfs.Count; i++)
            {
                if (cpfCliente == cpfs[i])
                {
                    cpfExistente = false;
                }
            }

            if (cpfExistente == false)
            {
                Console.WriteLine("CPF Já cadastrado!!!");
            }
            else
            {
                cpfs.Add(cpfCliente);

                Console.Write("Digite o nome: ");
                string? nomeCliente = Console.ReadLine();
                titulares.Add(nomeCliente);

                Console.Write("Insira a senha: ");
                string pwdCliente = Console.ReadLine();
                senha.Add(pwdCliente);

                conta.AdicionarConta();

                Console.WriteLine();
                Console.WriteLine($"Cliente {nomeCliente}, adicionado com sucesso!!!");
            }
        }

        public void DeletarCliente()
        {
            Console.WriteLine("DELETAR CLIENTE");
            Console.WriteLine();

            int posicao = BuscarIndex();

            if (posicao < 0)
            {
                Console.WriteLine($"CPF não existe!");
            }

            else
            {
                Console.WriteLine($"Cliente {titulares[posicao]} sendo excluido!");
                cpfs.RemoveAt(posicao);
                titulares.RemoveAt(posicao);
                senha.RemoveAt(posicao);
                conta.RemoverConta(posicao);
                Console.WriteLine($"Deletado com sucesso!!!");
            }
        }

        public void ListarClientes()
        {
            Console.WriteLine("LISTA DE CLIENTES");
            Console.WriteLine();

            int i = 0;

            foreach (string list in titulares)
            {
                double count = conta.ListarConta(i);
                Console.WriteLine($"{i + 1} - CPF = {cpfs[i]} | TITULAR = {titulares[i]} | SALDO = {count:f2}");
                i++;
            }

            int totalClient = titulares.Count;
            Console.WriteLine();
            Console.WriteLine($"Total de clientes: {totalClient}");
        }

        public void DetalhesCliente()
        {
            Console.WriteLine("CONSULTAR CLIENTE");
            Console.WriteLine();

            int posicao = BuscarIndex();

            Console.Clear();

            if (posicao < 0)
            {
                Console.WriteLine($"CPF não existe!");
            }
            else
            {
                double saldo = conta.ListarConta(posicao);

                Console.WriteLine($"DETALHES DO CLIENTE");
                Console.WriteLine();
                Console.WriteLine($"CPF: {cpfs[posicao]}");
                Console.WriteLine($"Nome: {titulares[posicao]}");
                Console.WriteLine($"Saldo: R$ {saldo:f2}");
            }
        }

        public void ValorTotalBanco()
        {
            double total = conta.TotalConta();
            Console.WriteLine("VALOR TOTAL EM CAIXA");
            Console.WriteLine();
            Console.WriteLine($"Total: R$ {total:f2}");
        }

        public int BuscarIndex()
        {
            Console.Write("Digite o CPF: ");
            string cpfCliente = Console.ReadLine();

            int index = -2;
            int i = 0;

            foreach (string list in cpfs)
            {
                if (list == cpfCliente)
                {
                    index = i;
                }
                i++;
            }

            return index;
        }

        public int Login()
        {
            int indexLogin = BuscarIndex();

            Console.Write("Digite sua senha: ");
            string loginPwd = Console.ReadLine();

            if ((indexLogin >= 0) && (loginPwd == senha[indexLogin]))
            {
                return indexLogin;
            }
            else
            {
                return -1;
            }
        }

        public string NomeTitular(int i)
        {
            return titulares[i];
        }

        public double SaldoConta(int y)
        {
            return conta.ListarConta(y);
        }

        public double DepositoConta(int i)
        {
            return conta.DepositarConta(i);
        }

        public double SaqueConta(int i)
        {
            return conta.SacarConta(i);
        }

        public double TransferenciaDeConta(int x, int y)
        {
            return conta.TransferirConta(x, y);
        }

    }
}