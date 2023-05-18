using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz8
{
    class PhysicFace : IBusinessObject //  класс для физических лиц
    {
        private string name;
        private string adress;
        private string phoneNumber;
        private int income;
        public PhysicFace(string name, string adress, string phoneNumber, int income)
        {
            this.name = name;
            this.adress = adress;
            this.phoneNumber = phoneNumber;
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
            return income * 0.87f;
        }
    }
    class PhysicFaceCreator : Creator // Создатель Физических лиц
    {
        public override IBusinessObject Create(string name, string adress, string phoneNumber, int income)
        {
            return new PhysicFace(name, adress, phoneNumber, income);
        }
    }
}
