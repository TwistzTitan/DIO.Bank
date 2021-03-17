using System;
using System.Threading;
using System.Collections.Generic;
namespace DIO.Bank.Classes
{
    public class Menu
    {
        public void ApresentaMenu(){
            Console.WriteLine("\t\t### Bem vindo ao DIO Bank! ###\n");
            Console.WriteLine("\tSeleciona a operação que você deseja acessar:\n");
            Console.WriteLine("\t[1] Criar Conta");
            Console.WriteLine("\t[2] Listar Contas");
            Console.WriteLine("\t[3] Sacar");
            Console.WriteLine("\t[4] Depositar");
            Console.WriteLine("\t[5] Limpar Tela");
            Console.WriteLine("\t[6] Sair");
        }
        public void CriarConta(List<Conta> listaContas){
            
            Console.WriteLine("\nFaltam apenas alguns passos para você ser mais um dos nossos clientes!");
            Thread.Sleep(2000);
            Console.WriteLine("Agora, digite seu nome completo por favor..\n");
            string nome = Console.ReadLine();
            Thread.Sleep(1000);
            Console.WriteLine("Digite sua idade por favor..\n");
            int idade = int.Parse(Console.ReadLine());
            Thread.Sleep(1000);
            Console.WriteLine("Digite o saldo que inicial de sua conta..\n");
            double saldo = double.Parse(Console.ReadLine());
            Console.WriteLine("{0} deseja obter uma linha de credito?",nome);
            Console.WriteLine("\n\t[1] Sim, desejo!\n\t[0] Não nesse momento.");
            bool cred = bool.Parse(Console.ReadLine());
            
        }

        public void ListarContas(){
             throw new NotImplementedException();
        }

        public void Sacar(){
             throw new NotImplementedException();
        }

        public void Depositar(){
             throw new NotImplementedException();
        }

    }
}