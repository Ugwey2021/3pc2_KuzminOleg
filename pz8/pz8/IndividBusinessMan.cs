using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz8
{
    class IndividBusinessMan : IBusinessObject // класс для ИП
    {
        private string name;
        private string adress;
        private string phoneNumber;
        private int income;
        private string license;
        public IndividBusinessMan(string name, string adress, string phoneNumber, int income, string License)
        {
            this.name = name;
            this.adress = adress;
            this.phoneNumber = phoneNumber;
            this.income = income;
            this.license = License;
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
    }
    class IndividBusinesManCreator : Creator // Создатель ИП
    {
        public override IBusinessObject Create(string name, string phoneNumber, string adress, int income, string license)
        {
            return new IndividBusinessMan(name, adress, phoneNumber, income, license);
        }
    }
}
