using System.Text;

namespace Homework2
{
    public class Program
    {
        public void Function1()
        {
            Console.WriteLine("请输入要分解的数");
            string num = Console.ReadLine();
            if(!int.TryParse(num, out int number))
            {
                Console.WriteLine("输入有误");
                return;
            }
            StringBuilder result = new StringBuilder();
            result.Append(number + "=");
            for (int i = 2; i <= number;)
            {
                if (number % i == 0)
                {
                    result.Append(i + "*");
                    number /= i;
                }
                else
                {
                    i++;
                }
            }
            result.Length--;
            Console.WriteLine(result.ToString());
            Console.WriteLine("\n");
        }

        public void Function2()
        {
            Console.WriteLine("请输入数组，以半角逗号或空格分割");
            string nums = Console.ReadLine();
            string[] arraynum = nums.Split(',', ' ');
            int temp;
            int max = int.MinValue;
            int min = int.MaxValue;
            int sum = 0;
            int count = arraynum.Length;
            foreach (string num in arraynum)
            {
                if(!int.TryParse(num, out temp))
                {
                    Console.WriteLine("数据有误");
                    return;
                }
                if(temp < min) min = temp;
                if(temp > max) max = temp;
                sum += temp;
            }
            double avg = (double)sum / count;
            Console.WriteLine(
                "最大值: " + max + 
                "\n最小值: " + min +
                "\n平均值: " + avg +
                "\n元素和: " + sum);
            Console.WriteLine("\n");
        }

        public void Function3()
        {
            int n = 100;
            StringBuilder result = new StringBuilder();
            bool[] is_prime = new bool[n + 1];
            for (int i = 0; i < n; i++)
            {
                is_prime[i] = true;
            }
            for (int i = 2; i < n + 1; i++)
            {
                if (is_prime[i])
                {
                    result.Append(i + " ");
                    for (int j = i * 2; j < n + 1; j += i) 
                    {
                        is_prime[j] = false;
                    }
                }
            }
            result.Length--;
            Console.WriteLine("2~100以内的素数: ");
            Console.WriteLine(result.ToString());
            Console.WriteLine("\n");
        }

        public void Function4()
        {
            Console.WriteLine("请输入形状对应的数字 1.长方形 2.正方形 3.三角形");
            string strShape = Console.ReadLine();
            if (!int.TryParse(strShape, out int shape))
            {
                shape = 1;
            }
            switch (shape)
            {
                case 1:
                    strShape = "Rectangle";
                    break;
                case 2:
                    strShape = "Square";
                    break;
                case 3:
                    strShape = "Triangle";
                    break;
                default:
                    strShape = "Rectangle";
                    break;
            }
            ShapeFactory shapeFactory = new ShapeFactory();
            Shape shape1 = shapeFactory.GetShape(strShape);
            if(!shape1.IsLegal())
            {
                Console.WriteLine("Shape is illegal");
                return;
            }
            shape1.DrawShape();
            Console.WriteLine("Area: " + shape1.GetArea());
            Console.WriteLine("\n");
        }

        public void Function5()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            List<Shape> shapes = new List<Shape>();
            Random random = new Random((int)DateTime.Now.Ticks);
            shapes.Clear();
            for (int i = 0; i < 10; i++)
            {
                int shapeType = random.Next(1, 4);
                switch (shapeType)
                {
                    case 1:
                        shapes.Add(shapeFactory.GetShape("Rectangle"));
                        break;
                    case 2:
                        shapes.Add(shapeFactory.GetShape("Square"));
                        break;
                    case 3:
                        shapes.Add(shapeFactory.GetShape("Triangle"));
                        break;
                    default:

                        break;
                }
            }
            double sumArea = 0;
            int count = 0;
            foreach (Shape shape in shapes)
            {
                if (!shape.IsLegal())
                {
                    Console.WriteLine("Shape is illegal");
                    continue;
                }
                shape.DrawShape();
                sumArea += shape.GetArea();
                count++;
            }
            Console.WriteLine("\nThe sum of the areas of these "+ count +" shapes is " + sumArea);
            Console.WriteLine("\n");
        }

        static void Main()
        {
            int userOp = 6;
            while(userOp != 0)
            {
                Console.WriteLine("输入0至5以选择对应功能");
                Console.WriteLine(
                    "0. 退出\n" +
                    "1. 求指定数据的所有素数因子\n" +
                    "2. 求整数数组的最大值、最小值、平均值和所有数组元素的和\n" +
                    "3. 用“埃氏筛法”求2~ 100以内的素数\n" +
                    "4. 实现长方形、正方形、三角形等形状的类\n" +
                    "5. 随机创建10个形状对象，计算这些对象的面积之和\n");
                string op_string = Console.ReadLine();
                if (int.TryParse(op_string, out userOp))
                {
                    var program = new Program();
                    switch (userOp)
                    {
                        case 0:
                            return;
                        case 1:
                            program.Function1();
                            break;
                        case 2:
                            program.Function2();
                            break;
                        case 3:
                            program.Function3();
                            break;
                        case 4:
                            program.Function4();
                            break;
                        case 5:
                            program.Function5();
                            break;
                        default:
                            continue;
                    }
                }
            }


            
        }


    }
}
