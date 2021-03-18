using System.Collections.Generic;
namespace DIO.Bank.Classes
{

    public class CreditoService
    {

        private Dictionary<string, double> dictCredito;

        public CreditoService(){
            dictCredito = new Dictionary<string, double>();
            registraDicionarioCredito();
        }         
        public void analisaCredito( Conta contaCliente) {
            if(contaCliente.Saldo > 10)
            {
                if(contaCliente.Idade >= 18 && contaCliente.Idade <= 25){
                    contaCliente.Credito = contaCliente.Saldo * dictCredito.GetValueOrDefault("Jovem");
                }
                else if(contaCliente.Idade >= 26 && contaCliente.Idade <= 40){
                    contaCliente.Credito = contaCliente.Saldo * dictCredito.GetValueOrDefault("Adulto");
                }
                else if(contaCliente.Idade >= 41 && contaCliente.Idade <= 55){
                    contaCliente.Credito = contaCliente.Saldo * dictCredito.GetValueOrDefault("Master");
                }
                else if(contaCliente.Idade >= 56){
                    contaCliente.Credito = contaCliente.Saldo * dictCredito.GetValueOrDefault("Senior");
                }
            }
             
        }   

        private void registraDicionarioCredito(){

            dictCredito.Add("Jovem",0.25);
            dictCredito.Add("Adulto",0.50);
            dictCredito.Add("Master",0.65);
            dictCredito.Add("Senior",0.80);

        }

    }
}