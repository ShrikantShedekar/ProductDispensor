using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductDispensor
{
    public class VendingMachine
    {
        List<Coin> coins = new List<Coin>();
        public VendingMachine()
        {
            this.InitializeCoins();   
        }
       
        public void ValidateInsertedCoin(int Size,int Weight,out Coin insertedCoin)
        {
            //Coin insertedCoin=new Coin();
            insertedCoin= coins.Where(i => i.Size == Size && i.Weight==Weight).FirstOrDefault();
            if (insertedCoin==null)
                return;

            if (insertedCoin.Name=="pennies")
            {
                
               Console.WriteLine("Rejected Coins :"+insertedCoin.Name);
                insertedCoin=null;
                return;
            }
         
        }



        private void InitializeCoins()
        {
            Coin coinNickles=new Coin();
            coinNickles.Name="nickles";
            coinNickles.Size=10;
            coinNickles.Weight=10;
            coinNickles.Amount=Convert.ToDecimal(0.05);
            coins.Add(coinNickles);

            Coin coinDimes=new Coin();
            coinDimes.Name="dimes";
            coinDimes.Size=20;
            coinDimes.Weight=20;
            coinDimes.Amount=Convert.ToDecimal(0.10);
            coins.Add(coinDimes);

            Coin coinQuarter=new Coin();
            coinQuarter.Name="quarters";
            coinQuarter.Size=30;
            coinQuarter.Weight=30;
            coinQuarter.Amount=Convert.ToDecimal(0.25);
            coins.Add(coinQuarter);

            Coin coinPennies=new Coin();
            coinPennies.Name="pennies";
            coinPennies.Size=40;
            coinPennies.Weight=40;
            coinPennies.Amount=Convert.ToDecimal(0.01);
            coins.Add(coinPennies);
        }
        
        
    }
}
