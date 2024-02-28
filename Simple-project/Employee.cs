using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_project
{
       class Employee
    {
        public const decimal minimumloggedour = 176;
        public const decimal overtime = 1.25m;
        private string name;
        private int id;
        private decimal loggedhour;
        private decimal wage;
        


        private decimal Caculatebasesalary() {
            return Loggedhour * Wage; 
        }

        private decimal CaculateOverTime()
        {
            var adding_hour = ((loggedhour - minimumloggedour) > 0 ? loggedhour * minimumloggedour : 0);
            return adding_hour *  Loggedhour * Wage;
        }

        public Employee() { 
        }
        
        public Employee(string name , int id, decimal loggedhour,decimal wage)
        {

            Name = name;
            Id = id;
            Loggedhour = loggedhour;
            Wage = wage;

        }
        
        public string Name {
            get { return name; }
            set { name = value;}
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public decimal Loggedhour    
        {
            get { return loggedhour; }
            set { loggedhour = value; }
        }
        public decimal Wage
        {
            get { return wage; }
            set { wage = value; }
        }

        public virtual decimal caculate() {
            decimal adding_hour = ((loggedhour - minimumloggedour) > 0 ? loggedhour * minimumloggedour : 0 );
            return (wage * minimumloggedour) + (adding_hour * wage * overtime) ; 

        }

    }
}
