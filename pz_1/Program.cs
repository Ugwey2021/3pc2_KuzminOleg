using System.Diagnostics;
using System.Globalization;

class Program
{
    internal class Timing // класс timing для замера времени выполнения комманд
    {
        TimeSpan duration; //хранение результата измерения
        TimeSpan[] threads; // значения времени для всех потоков процесса
        public Timing()
        {
            duration = new TimeSpan(0);
            threads = new TimeSpan[Process.GetCurrentProcess().
            Threads.Count];
        }
        public void StartTime() //инициализация массива threads после вызова сборщика мусора
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            for (int i = 0; i < threads.Length; i++)
                threads[i] = Process.GetCurrentProcess().Threads[i].
                UserProcessorTime;
        }
        public void StopTime() //повторный запрос текущего времени и выбирается тот, у которого результат отличается от
        { //предыдущего
            TimeSpan tmp;
            for (int i = 0; i < threads.Length; i++)
            {
                tmp = Process.GetCurrentProcess().Threads[i].
                UserProcessorTime.Subtract(threads[i]);
                if (tmp > TimeSpan.Zero)
                    duration = tmp;
            }
        }
        public TimeSpan Result()
        {
            return duration;
        }
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Первый пункт:"); // сортировка 3 методами
        Random random = new Random();
        int[] a = new int[10000];
        Stopwatch stpWatch = new Stopwatch();
        Timing tim = new Timing();
        tim.StartTime();
        stpWatch.Start();
        a = SortSelection(a); // сортировка выбором
        stpWatch.Stop();
        tim.StopTime();
        Console.WriteLine("StopWatch: " + stpWatch.Elapsed.ToString() +
            "\nTiming: " + tim.Result().ToString());
        tim.StartTime();
        stpWatch.Start();
        a = SortInsertion(a); // сортировка вставкой
        stpWatch.Stop();
        tim.StopTime();
        Console.WriteLine("StopWatch: " + stpWatch.Elapsed.ToString() +
            "\nTiming: " + tim.Result().ToString());
        stpWatch.Start();
        tim.StartTime();
        a = BubleSort(a); // сортировка пузыриком
        stpWatch.Stop();
        tim.StopTime();
        Console.WriteLine("StopWatch: " + stpWatch.Elapsed.ToString() +
            "\nTiming: " + tim.Result().ToString());

        Console.WriteLine("\nВторой пункт:"); // поиск элемента в массиве
        int[] c = new int[5000];
        for (int i = 0; i < c.Length; i++)
        {
            c[i] = random.Next(1, 100);
        }
        int b = -1;
        stpWatch.Start();
        tim.StartTime();
        b = SimpleSearch(c,10);
        stpWatch.Stop();
        tim.StopTime();
        Console.WriteLine("Простой поиск\n"+"StopWatch: " + stpWatch.Elapsed.ToString() +
            "\nTiming: " + tim.Result().ToString());
        stpWatch.Start();
        tim.StartTime();
        b = SearchBinary(c, 10);
        stpWatch.Stop();
        tim.StopTime();
        Console.WriteLine("Бинарный поиск\n" + "StopWatch: " + stpWatch.Elapsed.ToString() +
            "\nTiming: " + tim.Result().ToString());

        Console.WriteLine("\nТретий пункт:"); // поиск элементов в списке
        List<int> l = new List<int>();
        for (int i = 0; i < 5000; i++)
        {
            l.Add(random.Next(1, 100));
        }
        stpWatch.Start();
        tim.StartTime();
        b = SimpleSearchList(l, 10);
        stpWatch.Stop();
        tim.StopTime();
        Console.WriteLine("Простой поиск\n" + "StopWatch: " + stpWatch.Elapsed.ToString() +
            "\nTiming: " + tim.Result().ToString());
        stpWatch.Start();
        tim.StartTime();
        b = SearchBinaryList(l, 10);
        stpWatch.Stop();
        tim.StopTime();
        Console.WriteLine("Бинарный поиск\n" + "StopWatch: " + stpWatch.Elapsed.ToString() +
            "\nTiming: " + tim.Result().ToString());

        Console.WriteLine("\nЧетвертый пункт:"); // поиск элемента в хэш таблице
        Dictionary<int, int> dc = new Dictionary<int, int>();
        for (int i = 0; i < 5000; i++)
        {
            dc.Add(i, random.Next(1, 101));
        }
        stpWatch.Start();
        tim.StartTime();
        int gg = SimpleSearchHashTable(dc, 5);
        stpWatch.Stop();
        tim.StopTime();
        Console.WriteLine("Простой поиск\n" + "StopWatch: " + stpWatch.Elapsed.ToString() +
            "\nTiming: " + tim.Result().ToString());
    }
    public static int SimpleSearch(int[] a,int x) // простой поиск в массиве
    {
        int i = 0;
        while (i < a.Length && a[i] != x)
            i++;
        if (i < a.Length)
            return i;
        else
            return -1;
    }
    public static int SimpleSearchHashTable(Dictionary<int,int> a, int x) // простой поиск в хэш таблице 
    {
        int i = 0;
        while (i < a.Count && a[i] != x)
            i++;
        if (i < a.Count)
            return i;
        else
            return -1;
    }
    public static int SimpleSearchList(List<int> a, int x) // простой поиск в списке
    {
        int i = 0;
        while (i < a.Count && a[i] != x)
            i++;
        if (i < a.Count)
            return i;
        else
            return -1;
    }

    public static int SearchBinary(int[] a,int x) // бинарный поиск в массиве
    {
        int middle, left = 0, right = a.Length - 1;
        do
        {
            middle = (left + right) / 2;
            if (x > a[middle])
                left = middle + 1;
            else
                right = middle - 1;
        }
        while ((a[middle] != x) && (left <= right));
        if (a[middle] == x)
            return middle;
        else
            return -1;
    }
    public static int SearchBinaryList(List<int> l, int x) // бинарный поиск в списке
    {
        int middle, left = 0, right = l.Count-1;
        do
        {
            middle = (left + right) / 2;
            if (x > l[middle])
                left = middle + 1;
            else
                right = middle - 1;
        }
        while ((l[middle] != x) && (left <= right));
        if (l[middle] == x)
            return middle;
        else
            return -1;
    }
    public static int[] SortSelection(int[] a) // сортировка выбором
    {
        int N = a.Length;
        int min = 0, imin = 0, i;
        for(i = 0; i < N-1; i++)
        {
            min = a[i];
            imin = i;
            for (int j = i+1; j < N; j++)
            {
                if (a[j] < min)
                {
                    min = a[j];
                    imin = j;
                }
            }
            if(i != min)
            {
                a[imin] = a[i];
                a[i] = min;
            }
            
        }
        return a;
    }
    public static int[] SortInsertion(int[] a) // сортировка вставкой
    {
        int tmp = a[0];
        int N = a.Length;
        for (int i = 0; i < N; i++)
        {
            int j = i - 1;
            while (j >= 0 && tmp < a[j]) a[j + 1] = a[j--];
            a[j+1] = tmp;
        }
        return a;
    }
    public int[] SortBinInsert(int[] a) // бинарная сортировка вставкой
    {
        int N = a.Length;
        for (int i = 1; i <= N-1; i++)
        {
            int tmp = a[i], left = 1, right = i - 1;
            while(left<=right)
            {
                int m = (left + right) / 2;
                if (tmp < a[m]) right = m - 1;
                else left = m + 1;
            }
            for (int j = i-1; j >= left; j--)
            {
                a[j + 1] = a[j];
            }
            a[left] = tmp;
        }
        return a;
    }
    public static int[] BubleSort(int[] a) // сортировка пузыриком
    {
        int N = a.Length;
        for (int i = 1; i < N; i++)
        {
            for (int j = N-1; j >= i; j--)
            {
                if (a[j - 1] > a[j])
                {
                    int t = a[j - 1];
                    a[j - 1] = a[j];
                    a[j] = t;
                }
            }
        }
        return a;
    }
}
