using System;
using System.Collections.Generic;
using DIO.Bank.Classes;
namespace DIO.Bank 
{

    
    public class Program
    {
        public static void Main(string[] args)
        {

            Menu menu = new Menu(new List<Conta>());
            while(menu.executar){
                menu.ApresentaMenu();
            }
        
        }
    }


}