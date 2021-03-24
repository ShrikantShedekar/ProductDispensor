using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductDispensor
{
    public sealed class Calculate
    {
        private Calculate()  
        {  

        }  
        private static Calculate instance = null;  
        public static Calculate Instance  
        {  
            get  
            {  
                if (instance == null)  
                {  
                    instance = new Calculate();  
                }  
                return instance;  
            }  
        } 
        public decimal Amount {get;set;} 
        
    }
}
