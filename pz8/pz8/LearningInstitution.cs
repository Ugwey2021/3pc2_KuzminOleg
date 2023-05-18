using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz8
{
    class LearningInstitution : IBusinessObject // класс для образовательного учреждения
    {
        private string name;
        private string adress;
        private string phoneNumber;
        private int countOfStudents;
        private int income;
        public LearningInstitution(string name, string adress, string phoneNumber, int countOfStudents, int income)
        {
            this.name = name;
            this.adress = adress;
            this.phoneNumber = phoneNumber;
            this.countOfStudents = countOfStudents;
            this.income = income;
        }

        public string GetName()
        {
            return name;
        }
        public string GetAdress()
        {
            return adress;
        }
        public string GetPhoneNumber()
        {
            return phoneNumber;
        }
        public float GetIncome()
        {
            return income * (0.87f - 0.05f);
        }
        public int GetCountOfStudents()
        {
            return countOfStudents;
        }
    }
    class LearningInstitutionCreator : Creator // Создатель образовательного учреждения
    {
        public override IBusinessObject Create(string name, string phoneNumber, string adress, int countOfStudents, int income)
        {
            return new LearningInstitution(name, adress, phoneNumber, countOfStudents, income);
        }
    }
}
