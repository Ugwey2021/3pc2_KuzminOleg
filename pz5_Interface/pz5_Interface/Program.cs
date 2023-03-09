using System;
using System.Net.Cache;

namespace pz5_Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Course pk = new Course(3, 8);
            Course nn = new Course(-1, 89423);
            Student s = new Student("Олег","пк",48,4.7,pk,true);
            Student ss = new Student("Изъянов","нн",8924,5.0,nn,true);
            Student sc = (Student) s.Clone();
            Console.WriteLine(s.ToString());
            Console.WriteLine(ss.ToString());
            Console.WriteLine(sc.ToString());
        }
    }
    internal class Student : ICloneable
    {
        private int proffesionalScore; // считается для распределения мест практики
        private double entryScore; // балл аттестата при поступлении
        private Course course;
        public string Name { get; set; }
        public string Group { get; set; }
        public int ProffesionalScore { get { return proffesionalScore;  } set { proffesionalScore = ProffesionalScore + 5; } }
        public double EntryScore { get { return entryScore; } set { entryScore = value; } }
        public int Course { get { return course.Name; } set { course.Name = value; } }
        public bool OnABudget { get; set; }
        public override string ToString()
        {
            return $"Студент {Name} учить на {Course} курсе "+
            $"с входным баллом {EntryScore}";
        }
        public Student(string name,string group,int profScore,
            double entScore, Course c,bool onABudget) // конструктор класс Student
        {
            Name = name;
            Group = group;
            ProffesionalScore = profScore;
            entryScore = entScore;
            course = c;
            OnABudget = onABudget;
        }
        public object Clone() => new Student(Name, Group, ProffesionalScore,
            EntryScore, new Course(course.Name,course.Diffuculty), OnABudget);// глубокое клонирование IClonable
    }

    internal class Course // дополнительный класс "Курс"
    {
        public int Name { get; set; }
        public int Diffuculty { get; set; }
        public Course(int name, int diffuculty)
        {
            Name = name;
            Diffuculty = diffuculty;
        }
    }
}
