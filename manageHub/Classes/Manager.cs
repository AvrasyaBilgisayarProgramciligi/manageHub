using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manageHub.Classes
{
    class Manager : Personnel //Subclass
    {
        private int responsiblePerson;

        public Manager(string name, string surname, string depart, float salary, int responsiblePerson) : base(name, surname, depart, salary)
        {
            this.responsiblePerson = responsiblePerson;
        }

        public string showInfos()
        {
            string showInfos = "Name: " + getName() + "\n" +
                               "Surname: " + getSurname() + "\n" +
                               "Depart: " + getDepart() + "\n" +
                               "Salary: " + getSalary() + "\n" +
                               "Responsible Person: " + getRespon() + "\n";
            return showInfos;
        }

        public int getRespon()
        {
            return responsiblePerson;
        }

        public void setRespon(int respon)
        {
            this.responsiblePerson = respon;
        }
    }
}
