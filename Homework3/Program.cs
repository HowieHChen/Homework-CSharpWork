namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1
            Console.WriteLine("\nQuestion1\n");
            GenericList<int> intlist = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }
            int sum = 0;
            int max = int.MinValue;
            int min = int.MaxValue;
            intlist.ForEach(x => Console.WriteLine(x));
            intlist.ForEach(x => sum += x);
            intlist.ForEach(x => { max = max > x ? max : x; });
            intlist.ForEach(x => { min = min < x ? min : x; });
            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Max: " + max);
            Console.WriteLine("Min: " + min);
            //Question 2
            Console.WriteLine("\nQuestion2\n");
            AlarmClock alarmClock = new AlarmClock();
            Console.WriteLine("几秒后响铃？请输入一个正整数。注意！闹钟只会运行一分钟");
            string alarmDelay = Console.ReadLine();
            if (!int.TryParse(alarmDelay, out int secDelay))
            {
                Console.WriteLine("输入有误");
            }
            alarmClock.SetAlarm(secDelay);
            alarmClock.Start();
        }
    }
}
