using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manageHub.Classes
{
    class Programmer : Personnel //Subclass
    {
        private List<string> langs = new List<string>();
        private string languages;

        public Programmer(string name, string surname, string depart, long salary, string languages) : base(name, surname, depart, salary)
        {
            langs.Add(languages);
        }

        public string showInfos()
        {
            string showInfos = "Name: " + getName() + "\n" +
                               "Surname: " + getSurname() + "\n" +
                               "Depart: " + getDepart() + "\n" +
                               "Salary: " + getSalary() + "\n" +
                               "Languages : " + showLangs() + "\n";
            return showInfos;
        }

        public void addLanguage(string language)
        {
            langs.Add(language);
        }

        public string showLangs()
        {
            string lng = string.Join(",", langs.ToArray());
            return lng;
        }

        public void deleteLanguage(string language)
        {
            langs.Remove(language);
        }

        public string getLanguage()
        {
            return this.languages;
        }

        public void setLanguage(string languages)
        {
            langs.Add(languages);
        }
    }
}
