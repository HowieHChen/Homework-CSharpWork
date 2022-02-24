namespace CalculatorConsole
{
    public class Program
    {
        static void Main()
        {
            bool isExit = false;
            string num1;
            string num2;
            double number1;
            double number2;
            double result;
            while (!isExit)
            {
                Console.WriteLine("请输入第一个数");
                num1 = Console.ReadLine();
                Console.WriteLine("请输入第二个数");
                num2 = Console.ReadLine();
                if (!double.TryParse(num1, out number1) || !double.TryParse(num2, out number2))
                {
                    Console.WriteLine("我们遇到了些问题，请重新输入\n");
                    continue;
                }
                Console.WriteLine("请输入运算符(+ - * /)");
                string op = Console.ReadLine();
                switch (op)
                {
                    case "+":
                        result = number1 + number2;
                        Console.WriteLine("计算结果：" + number1 + op + number2 + "=" + result);
                        break;
                    case "-":
                        result = number1 - number2;
                        Console.WriteLine("计算结果：" + number1 + op + number2 + "=" + result);
                        break;
                    case "*":
                        result = number1 * number2;
                        Console.WriteLine("计算结果：" + number1 + op + number2 + "=" + result);
                        break;
                    case "/":
                        result = number1 / number2;
                        Console.WriteLine("计算结果：" + number1 + op + number2 + "=" + result);
                        break;
                    default:
                        Console.WriteLine("我们遇到了些问题，请重新输入");
                        break;
                }
                Console.WriteLine("是否继续计算？输入0以退出");
                string exit = Console.ReadLine();
                if (int.TryParse(exit, out int tempExit) && tempExit == 0)
                {
                    isExit = true;
                }
            }
        }
    }
}