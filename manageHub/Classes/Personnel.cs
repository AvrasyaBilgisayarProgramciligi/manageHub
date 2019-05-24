using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manageHub.Classes
{
    public class Personnel //Superclass 
    {
        protected string name;
        protected string surname;
        protected string depart;
        protected float salary;

        public Personnel()
        {
            this.name = "No Information";
            this.surname = "No Information";
            this.depart = "No Information";
            this.salary = 0.0f;
        }
        public Personnel(string name, string surname, string depart, float salary)
        {
            this.name = name;
            this.surname = surname;
            this.depart = depart;
            this.salary = salary;
        }

        public string getName()
        {
            return this.name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getSurname()
        {
            return this.surname;
        }

        public void setSurname(string surname)
        {
            this.surname = surname;
        }

        public string getDepart()
        {
            return this.depart;
        }

        public void setDepart(string position)
        {
            this.depart = position;
        }

        public float getSalary()
        {
            return this.salary;
        }

        public void setSalary(float salary)
        {
            this.salary = salary;
        }

    }
}
