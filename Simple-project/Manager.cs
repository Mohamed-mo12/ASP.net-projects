using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_project
{
    class Manager : Employee 
    {

       

        public Manager() { 
        }
        public Manager(string name, int id, decimal loggedhour, decimal wage) : base(name , id , loggedhour,wage)
        {
            this.Id = id;
            this.Name = name;
            this.Loggedhour = loggedhour;
            this.Wage = wage;
             
        }

        
        public override decimal caculate()
        {
            const decimal addition_money = 0.05m;
            return base.caculate() + addition_money * base.caculate();

        }

        

        


    }
}
