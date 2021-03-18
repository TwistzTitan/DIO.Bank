using System;
using System.Threading;
using System.Collections.Generic;
using DIO.Bank.Commons;

namespace DIO.Bank.Classes
{
    public class Menu
    {   
        private List<Conta> contas {get; set;}

        public bool executar {get; set;}
        public Menu(List<Conta> contasDIO){
            this.executar = true;
            this.contas = contasDIO; 
        }
        public void ApresentaMenu(){
            Console.WriteLine("\t\t### Bem vindo ao DIO Bank! ###\n");
            Console.WriteLine("\tSeleciona a operação que você deseja acessar:\n");
            Console.WriteLine("\t[1] Criar Conta");
            Console.WriteLine("\t[2] Listar Contas");
            Console.WriteLine("\t[3] Sacar");
            Console.WriteLine("\t[4] Depositar");
            Console.WriteLine("\t[5] Transferir");
            Console.WriteLine("\t[6] Limpar Tela");
            Console.WriteLine("\t[7] Sair");
            int op = int.Parse(Console.ReadLine());
            switch(op)
            {
                case 1: 
                    CriarConta(this.contas);
                    break;
                case 2: 
                    ListarContas();
                    break;
                case 3: 
                    Sacar();
                    break;
                case 4: 
                    Depositar();
                    break;
                case 5:
                    Transferir();
                    break;
                case 6:
                    LimparTela();
                    break;
                case 7:
                    Sair();
                    break;
                default: 
                    Console.WriteLine("Por favor selecione uma operação");
                    break;
            }
        }
        public void CriarConta(List<Conta> listaContas){
            
            Console.WriteLine("\nFaltam apenas alguns passos para você ser mais um dos nossos clientes!\n");
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
            int cred = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual o tipo de conta desejada ?");
            Console.WriteLine("\n\t[1] Pessoa Fisica \n\t [2] Pessoa Juridica");
            TipoConta entradaTipoConta = (TipoConta) int.Parse(Console.ReadLine());
            Console.WriteLine("\nAguarde um momento, estamos criando sua conta em nosso banco!\n");
            
            Conta novaConta = new Conta(tipoConta: entradaTipoConta,saldo: saldo,idade: idade,nome: nome);
            
            if(cred == 1){
                Console.WriteLine("Estamos avaliando sua linha de crédito.. aguarde mais alguns minutos.");
                
                var creditoService = new CreditoService();

                novaConta.ObterCredito(creditoService);
            }

            contas.Add(novaConta);

            Console.WriteLine("\nParabéns {0}, nosso mais novo cliente no DIO Bank!", novaConta.Nome);
        }

        public void ListarContas(){
             
            foreach (Conta c in this.contas)
            {
                Console.WriteLine("\nNome: {0} - Saldo: {1} - Credito: {2}", c.Nome, c.Saldo, c.Credito);
            }

        }

        public void Sacar(){
            
            Console.WriteLine("Por favor, nos informe o valor para saque");
            
            double saque = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Informe o nome do titular para saque");
            
            string nome = Console.ReadLine();
            
            var contaSaque = contas.Find((c)=> c.Nome == nome);
            
            if(contaSaque != null)
             {
                 contaSaque.Sacar(saque);

                 Console.Write("Saque realizado com sucesso para o titular {0}", contaSaque.Nome);   
             }

             else 
             { 
                 Console.WriteLine("Saque não realizado, conta não encontrada.");
             }
             
        }

        public void Depositar(){
             Console.WriteLine("Por favor, nos informe o valor para depósito");
             
             double deposito = double.Parse(Console.ReadLine());
             
             Console.WriteLine("Informe o nome do titular para depósito");
             
             string nome = Console.ReadLine();
             
             var contaDeposito = contas.Find((c)=> c.Nome == nome);
             
             if(contaDeposito != null)
             {
                 contaDeposito.Depositar(deposito);

                 Console.Write("Deposito realizado com sucesso para {0}", contaDeposito.Nome);   
             }

             else 
             { 
                 Console.WriteLine("Deposito não realizado, conta não encontrada.");
             }
        }
        
        public void Transferir()
        {
            Console.WriteLine("\nPor favor, nos informe o valor para transferir");

            double valorTransf = double.Parse(Console.ReadLine());

            Console.WriteLine("\nInforme o nome da conta de origem da tranferência");

            string nome = Console.ReadLine();

            var contaTransferencia = contas.Find((c) => c.Nome == nome);

            if (contaTransferencia == null)
            {
                Console.WriteLine("\nTitular da conta não encontrado");

                Thread.Sleep(2000);

                LimparTela();

                return;
            }

            Console.WriteLine("Informe o nome da conta de destino para tranferência");

            string nomeReceptor = Console.ReadLine();

            var contaTransferenciaReceptor = contas.Find((c) => c.Nome == nomeReceptor);


            if (contaTransferenciaReceptor == null)
            {
                Console.WriteLine("\nConta para recebimento não encontrado");

                Thread.Sleep(2000);

                LimparTela();

                return;
            }


            bool transfResult = contaTransferencia.Transferencia(valorTransf,contaTransferenciaReceptor);

            if (!transfResult)
            {
                Console.WriteLine("Não foi possivel realizar a transferencia desejada, consulte a informações de sua conta");
            }
        
        }
        public void LimparTela()=> Console.Clear();

        public void Sair(){
            Console.WriteLine("\n\nObrigado por utilizar o DIO Bank");
            this.executar = false;
        }
    }
}