
using DIO.Bank.Enum;
using System;
using System.Diagnostics;
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

            if(retorno) Console.WriteLine("Parabéns você teve credito aprovado de: {0}",this.Credito);

            else{

                Console.WriteLine("Infelizmente seu credito não foi aprovado, deposite pelo menos R$ 10, seu saldo e: {0}",this.Saldo);
            }

        }

        public bool Sacar (double valorSaque){

            bool retorno = false;

            Debug.Assert(!valorSaque.Equals(null));
            Debug.Assert(valorSaque > 0);

            if(Saldo > 0 && Saldo > valorSaque){
                Saldo -= valorSaque;
                Console.WriteLine("Saldo atual da conta de {0} é: {1}",this.Nome,this.Saldo);
                retorno = true;
            }
             
            return retorno;
        }

        public bool Depositar(double valorDeposito)
        {
           
            Debug.Assert(!valorDeposito.Equals(null));
            Debug.Assert(valorDeposito > 0);

            Saldo += valorDeposito;
        
            Console.WriteLine("Saldo atual da conta de {0} é: {1}",this.Nome,this.Saldo);

            return true;
        }

    
        public bool Transferencia (double valorTransf, Conta contaTransf) 
        {
            bool retorno = false;

            Debug.Assert(!valorTransf.Equals(null));
            Debug.Assert(!contaTransf.Equals(null));
            Debug.Assert(valorTransf > 0);

            if(this.Sacar(valorTransf)){
                contaTransf.Depositar(valorTransf);
                Console.WriteLine("Transferencia realizada de {0} para {1} no valor de: {2}",this.Nome,contaTransf.Nome,valorTransf);
                retorno = true;
            }

            return retorno;
        }

    
    }

}