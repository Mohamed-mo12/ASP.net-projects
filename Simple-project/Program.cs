using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_project
{
    class Program
    {
        static void Main(string[] args)
        {

            Developer D1 = new Developer("mohamed",12099,200,0.8m,true);
            Console.WriteLine(D1);
            

            Console.ReadKey(); 
            
        }
    }
}
