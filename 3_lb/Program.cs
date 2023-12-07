using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1 - Найти минимум функции y = x^2");
                Console.WriteLine("2 - Найти минимум функции y = 2x^3");
                Console.WriteLine("0 - Выйти из программы");

                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 2)
                {
                    Console.WriteLine("Введите число от 0 до 2.");
                    continue;
                }

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("До свидания!");
                        return;
                    case 1:
                        FindMinXSquare();
                        break;
                    case 2:
                        FindMin2XCube();
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            } while (choice != 0);
        }

        static void FindMinXSquare()
        {
            double a, b, c, q, y1, y2;
            Console.WriteLine("Введите начальную точку");
            while (!double.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Неверный формат числа. Введите число заново:");
            }

            Console.WriteLine("Введите конечную точку");
            while (!double.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Неверный формат числа. Введите число заново:");
            }

            do
            {
                Console.WriteLine("Введите допустимую погрешность q (больше 0):");
                while (!double.TryParse(Console.ReadLine(), out q) || q <= 0)
                {
                    Console.WriteLine("Неверный формат числа или значение должно быть больше 0. Введите число заново:");
                }

                if (q <= 0)
                {
                    Console.WriteLine("Значение погрешности должно быть больше 0. Повторите ввод.");
                }
            } while (q <= 0);

            while (Math.Abs(b + a) > q)
            {
                Console.WriteLine("a={0}", a);
                Console.WriteLine("b={0}", b);
                c = (a + b) / 2;
                y1 = Math.Pow((c - q), 2);
                y2 = Math.Pow((c + q), 2);

                if (y2 < y1)
                    a = c;
                if (y2 > y1)
                    b = c;
                if (y2 == y1)
                {
                    a = c - q;
                    b = c + q;
                }
            }
            Console.WriteLine("Минимум функции y=x^2 находится в точке x=");
            Console.WriteLine((a + b) / 2);
        }

        static void FindMin2XCube()
        {
            double a, b, q, y1, y2;
            Console.WriteLine("Введите начальную точку");
            while (!double.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Неверный формат числа. Введите число заново:");
            }

            Console.WriteLine("Введите конечную точку");
            while (!double.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Неверный формат числа. Введите число заново:");
            }

            do
            {
                Console.WriteLine("Введите допустимую погрешность q (больше 0):");
                while (!double.TryParse(Console.ReadLine(), out q) || q <= 0)
                {
                    Console.WriteLine("Неверный формат числа или значение должно быть больше 0. Введите число заново:");
                }

                if (q <= 0)
                {
                    Console.WriteLine("Значение погрешности должно быть больше 0. Повторите ввод.");
                }
            } while (q <= 0);

            do
            {
                Console.WriteLine("a={0}", a);
                Console.WriteLine("b={0}", b);

                y1 = 2 * Math.Pow(a, 3);
                y2 = 2 * Math.Pow(b, 3);

                if (y2 < y1)
                    a = b;
                else
                    b = a;

            } while (Math.Abs(b - a) > q);

            Console.WriteLine("Минимум функции y=2x^3 находится в точке x=");
            Console.WriteLine((a + b) / 2);
        }
    }
}
