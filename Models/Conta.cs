using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ByteBank.Models
{
    public class Conta
    {
        /*========== ATRIBUTOS =========*/
        List<double> saldo = new List<double>();

        /*========== METODOS =========*/
        public void AdicionarConta()
        {
            saldo.Add(0);
        }

        public void RemoverConta(int index)
        {
            saldo.RemoveAt(index);
        }

        public double ListarConta(int i)
        {
            return saldo[i];
        }

        public double TotalConta()
        {
            return saldo.Sum();
        }

        public double DepositarConta(int a)
        {
            Console.Write("Digite o valor de Deposito: ");
            double deposito = double.Parse(Console.ReadLine());

            saldo[a] = saldo[a] + deposito;

            return saldo[a];
        }


        public double SacarConta(int a)
        {
            Console.Write("Digite o valor de Saque: ");
            double saque = double.Parse(Console.ReadLine());

            if (saque > saldo[a])
            {
                Console.WriteLine("Você não tem saldo suficiente!!!");
                return saldo[a];
            }
            else
            {
                Console.WriteLine("Saque realizado!!!");
                saldo[a] = saldo[a] - saque;
                return saldo[a];
            }

        }

        public double TransferirConta(int a, int b)
        {
            Console.Write("Digite o valor a Transferir: ");
            double tranferir = double.Parse(Console.ReadLine());

            if (tranferir > saldo[a])
            {
                Console.WriteLine("Você não tem saldo suficiente!!!");
                return 0.0;
            }
            else
            {
                Console.WriteLine("Transferência realizada!!!");
                saldo[a] = saldo[a] - tranferir;
                saldo[b] = saldo[b] + tranferir;

                return tranferir;
            }

        }

    }
}