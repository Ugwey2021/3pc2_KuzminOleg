using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace pz8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Creator cpf = new PhysicFaceCreator(); // создание создателя
            IBusinessObject physicFace = cpf.Create("Олег","ул. Пушкина д. Колотушкина","89518884848",526); // создание объекта
            Creator cib = new IndividBusinesManCreator();
            IBusinessObject individBusinessMan = cib.Create("Полушка","Гагарина 29а","89324518250",34454,"Лицензия на торгволю");
            Creator cli = new LearningInstitutionCreator();
            IBusinessObject learningInstitution = cli.Create("МКЭИ","Лакова 7","8932334198448",98123987,1480);
            PhoneBook my = new PhoneBook();
            my.AddBusinessObject(physicFace); // добавление объекта в телефонную книгу
            my.AddBusinessObject(individBusinessMan);
            my.AddBusinessObject(learningInstitution);
            IBusinessObject search = my.GetBusinessObjectByPhoneNumber("89518884848");// поиск объекта в телефонной книге, по номеру телефона
            Console.WriteLine($"Имя:{search.GetName()}\nАдресс:{search.GetAdress()}\nДоход{search.GetIncome()}"); // вывод найденной информации об объекте
        }  
    }
    interface IBusinessObject // интерфейс, по которому в дальнейшем создаются объекты
    {
        string GetName();
        string GetAdress();
        string GetPhoneNumber();
        float GetIncome();
    }
    abstract class Creator // абстрактный класс Создателя, по котором дальше создаются создатели для каждого объекта
    {
        public virtual IBusinessObject Create(string name, string adress, string phoneNumber, int income)
        {
            return null;
        }
        public virtual IBusinessObject Create(string name, string adress, string phoneNumber, int income, string license)
        {
            return null;
        }
        public virtual IBusinessObject Create(string name, string adress, string phoneNumber, int income, int countOfStudents)
        {
            return null;
        }
    }
}
