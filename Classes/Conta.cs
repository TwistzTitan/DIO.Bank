
using DIO.Bank.Commons;
using System;
using System.Diagnostics;
using System.Threading;
namespace DIO.Bank.Classes
{
    public class Conta
    {
        #region Fields 
        private TipoConta _tipoConta;
        private double _saldo;
        private double _credito;

        private int _idade;
        private string _nome;

        #endregion

        #region  Properties

        public TipoConta TipoConta
        {
            get
            {
                return this._tipoConta;
            }
            set
            {
                this._tipoConta = value;
            }
        }
        public double Saldo
        {
            get
            {
                if(this._saldo.Equals(null)) return 0.0;
                return this._saldo;
            }
            set
            {
                this._saldo = value;
            }
        }

        public int Idade { get { return this._idade;} private set{ this._idade = value;} }

        public double Credito {
            get
            {
                if(this._credito.Equals(null)) return 0.0;
                return this._credito;
            }
            set
            {
                this._credito = value;
            }
        }
        
        public string Nome {

            get
            {
                return this._nome?? "";
            }
            set
            {
                this._nome = value;
            }
        } 
        #endregion
        public Conta(TipoConta tipoConta, double saldo, int idade, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Idade = idade;
            this.Nome = nome;
        }

        public void ObterCredito(CreditoService credService) {

            bool retorno = false;

            credService.analisaCredito(this);
            
            retorno = this.Credito > 0 ? true : false;

            if (retorno) {

                Console.WriteLine("\nParabéns você teve credito aprovado de: R${0}", this.Credito);
                Thread.Sleep(3000);
                Console.Clear();
            }

            else{

                Console.WriteLine("\nInfelizmente seu credito não foi aprovado, deposite pelo menos R$ 10, seu saldo e: {0}",this.Saldo);
                Thread.Sleep(3000);
                Console.Clear();
            }

        }

        public bool Sacar (double valorSaque){

            bool retorno = false;

            Debug.Assert(!valorSaque.Equals(null));
            Debug.Assert(valorSaque > 0);

            if(Saldo > 0 && Saldo > valorSaque){
                Saldo = Saldo - valorSaque;
                Console.WriteLine("\nSaldo atual da conta de {0} é: {1}",Nome,Saldo);
                Thread.Sleep(5000);
                Console.Clear();
                retorno = true;
            }
             
            return retorno;
        }

        public bool Depositar(double valorDeposito)
        {
           
            Debug.Assert(!valorDeposito.Equals(null));
            Debug.Assert(valorDeposito > 0);

            Saldo += valorDeposito;
            
            Console.WriteLine("\nDeposito realizado com sucesso!\n");
            Thread.Sleep(500);
            Console.WriteLine("\nSaldo atual da conta de {0} é: {1}",this.Nome,this.Saldo);
            Console.Clear();
            return true;
        }

    
        public bool Transferencia (double valorTransf, Conta contaTransf) 
        {
            bool retorno = false;

            Debug.Assert(!valorTransf.Equals(null));
            Debug.Assert(!contaTransf.Equals(null));
            Debug.Assert(valorTransf > 0);

            if(Sacar(valorTransf)){
                contaTransf.Depositar(valorTransf);
                Console.WriteLine("\nTransferencia realizada de {0} para {1} no valor de: {2}",this.Nome,contaTransf.Nome,valorTransf);
                Thread.Sleep(5000);
                Console.Clear();
                retorno = true;
            }

            return retorno;
        }

    
    }

}