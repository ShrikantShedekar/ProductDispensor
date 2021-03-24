using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductDispensor
{
    public class Dispensor
    {
        List<Product> productsList = new List<Product>();

        public Dispensor()
        {
            this.InitializeProducts();    
        }
        public Product DispenseProduct(decimal availableCoinAmount)
        {
        
            Console.WriteLine("Select Products:");
            Console.WriteLine("\t1 - cola for $1:00 ");
            Console.WriteLine("\t2 - chips for $0.50");
            Console.WriteLine("\t3 - candy for $0.65");
            Console.Write("Your option? ");
            
            string numInput = Console.ReadLine();

            int cleanNum = this.VerifyInputStringForProduct(numInput);
            Product prod = productsList.Where(i => i.ProductId == cleanNum).FirstOrDefault(); 
              

            if (!this.ValidateAvailableCoinAmount(availableCoinAmount,prod.Cost))
            {
                return null;
            }
            else
            {
                Console.WriteLine("Product "+prod.ProductName+" dispensed. THANK YOU");
                Calculate.Instance.Amount=Convert.ToDecimal(0.00);
            }
            return prod;
        }

        public int VerifyInputStringForProduct(string numInput)
        {
            int cleanNum = 0;
            while (!int.TryParse(numInput, out cleanNum) || (cleanNum<0 && cleanNum >3))
            {
                Console.WriteLine("This is not valid input.");
                numInput = Console.ReadLine();
                
            }  
            return cleanNum; 
        }

        public bool ValidateAvailableCoinAmount(decimal availableAmount,decimal productAmount)
        {
            if (availableAmount <productAmount)
                return false;
            return true;
        }

        private void InitializeProducts()
        {
            

            Product ColaProduct = new Product();
            ColaProduct.ProductId = 1;
            ColaProduct.ProductName = "Cola";
            ColaProduct.Cost = Convert.ToDecimal(1.00);
            productsList.Add(ColaProduct);

            Product ChipsProduct = new Product();
            ChipsProduct.ProductId = 2;
            ChipsProduct.ProductName = "Chips";
            ChipsProduct.Cost = Convert.ToDecimal(0.50);
            productsList.Add(ChipsProduct);

            Product CandyProduct = new Product();
            CandyProduct.ProductId = 3;
            CandyProduct.ProductName = "Candy";
            CandyProduct.Cost = Convert.ToDecimal(0.65);
            productsList.Add(CandyProduct);

        }
       
    }
}
