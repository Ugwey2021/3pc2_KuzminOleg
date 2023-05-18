using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz8
{
    internal class PhoneBook // класс для телефонной книги
    {
        private List<IBusinessObject> businessObjects = new List<IBusinessObject>();

        public void AddBusinessObject(IBusinessObject bo)
        {
            businessObjects.Add(bo);
        }
        public IBusinessObject GetBusinessObjectByPhoneNumber(string phoneNumber) // поиск информации по объекту ,зная телефонный номер
        {
            foreach  (IBusinessObject bo in businessObjects)
            {
                if (bo.GetPhoneNumber() == phoneNumber) return bo;
            }
            return null;
        }
        public int GetCountBusinessObject()
        {
            return businessObjects.Count;
        }
    }
}
