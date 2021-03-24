using System;

namespace ProductDispensor
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string numInput = "";
            int cleanNum = 0;
            Calculate.Instance.Amount=Convert.ToDecimal(0.00);
           
            do      //Loop should get executed Once, and should get continue till user exit
            {
                Console.WriteLine("Choose an option from following list:");
                Console.WriteLine("\t1 - Insert Coin");
                Console.WriteLine("\t2 - Get Product");
                Console.WriteLine("\t3 - Exit");
            
                Console.Write("Your option? ");

            
                numInput=Console.ReadLine();
               
                
                cleanNum=ValidateInput(numInput);

                switch(cleanNum)
                {
                    case 1:              //Insert Coin 
                        int coinSize=0;
                        int coinWeight=0;
                        
                        CaptureInput(out coinSize,out coinWeight);

                        
                        VendingMachine machine=new VendingMachine();
                        Coin insertedCoin=new Coin();
                        machine.ValidateInsertedCoin(coinSize,coinWeight,out insertedCoin);
                        if (insertedCoin==null)
                        {
                            Console.WriteLine("INVALID COIN"); 
                            Console.WriteLine("INSERT COIN");
                            Console.WriteLine("Total Available Coin Amount : $"+Calculate.Instance.Amount.ToString()); 
                            //break;   
                        }
                        else
                        {
                            Calculate.Instance.Amount = Calculate.Instance.Amount+ insertedCoin.Amount;
                            Console.WriteLine("Total Available Coin Amount : $"+Calculate.Instance.Amount.ToString()); 
                        }
                        break;
                    case 2:              //Get Product   
                        if (Calculate.Instance.Amount <=0)
                        {
                            Console.WriteLine("INSERT COIN");
                            Console.WriteLine("Total Available Coin Amount : $"+Calculate.Instance.Amount.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Total Available Coin Amount : $"+Calculate.Instance.Amount.ToString());
                            Dispensor dispensor = new Dispensor();
                            Product releasedProduct =dispensor.DispenseProduct(Calculate.Instance.Amount);
                            if (releasedProduct==null)
                            {
                                Console.WriteLine("INSERT COIN");
                                Console.WriteLine("Total Available Coin Amount : $"+Calculate.Instance.Amount.ToString());
                            }
                        
                        }
                        break;
                    case 3:
                        break;
                    default :
                        Console.WriteLine("This is not valid input.");
                        break; 
                }

               
                    

                if (cleanNum==1)       
                {
                    
                      
                }
                
            }while(cleanNum!=3);

           
            
           
        }
         static int ValidateInput(string inputString)
            {
                int cleanNum = 0;
                while (!int.TryParse(inputString, out cleanNum) )
                {
                    Console.WriteLine("This is not valid input.");
                    inputString = Console.ReadLine();
                }
                return cleanNum;
            }

        static void CaptureInput(out int coinSize,out int coinWeight)
        {
            string inputStrSize="";
            string inputStrWeight="";

            Console.WriteLine("Nickles Size :10, Weight:10 \t Dimes Size:20, Weight:20 \t Quarters Size:30, Weight:30 \t Pennies Size:40, Weight:40");
            Console.Write("\t1 Coin Size:");
            inputStrSize=Console.ReadLine();
            coinSize=ValidateInput(inputStrSize);
                        
            Console.WriteLine("\t Coin Weight:");
            inputStrWeight=Console.ReadLine();
            coinWeight=ValidateInput(inputStrWeight);
        }
    }
}
