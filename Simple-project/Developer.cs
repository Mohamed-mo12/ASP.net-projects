using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_project
{
    class Developer : Employee
    {

        protected const decimal commsion = 0.07m;

        public bool TaskCompleted { get; set; }

        public Developer(string name, int id, decimal loggedhour, decimal wage , bool Taskcompleted) : base(name, id, loggedhour, wage) {

            this.TaskCompleted = Taskcompleted; 
        }


        private decimal Bouns() {
            if (TaskCompleted)
            {
                return base.caculate() * commsion; 
            }
            return 0 ; 

        }


        public override decimal caculate()
        {
            return base.caculate() + Bouns();
        }

        public override string ToString()
        {
            return  $" your salary is : {caculate()} \n " +
                $"id : {Id} \n name: {Name} \n wage :{Wage} \n loggedhours {Loggedhour} ";
        }





    }

}
