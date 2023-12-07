using System;
using System.Numerics;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в калькулятор!");

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1 - Возвести число в указанную степень");
                Console.WriteLine("2 - Вычислить квадратный корень числа");
                Console.WriteLine("3 - Вычислить проценты");
                Console.WriteLine("4 - Вычислить f = ((x + 2)!) / 7");
                Console.WriteLine("0 - Выйти из калькулятора");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Введите число от 0 до 3.");
                    continue;
                }

                switch (choice)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("До свидания!");
                        return;
                    case 1:
                        Console.Clear();
                        Exponentiation();
                        break;
                    case 2:
                        Console.Clear();
                        SquareRoot();
                        break;
                    case 3:
                        Console.Clear();
                        CalculatePercentage();
                        break;
                    case 4:
                        Console.Clear();
                        CalculateFormula();
                        break;
                    default:

                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        static void Exponentiation()
        {
            Console.WriteLine("Введите число:");
            if (!double.TryParse(Console.ReadLine(), out double number))
            {
                Console.WriteLine("Неверный формат числа.");
                return;
            }

            Console.WriteLine("Введите степень:");
            if (!double.TryParse(Console.ReadLine(), out double exponent))
            {
                Console.WriteLine("Неверный формат степени.");
                return;
            }

            double result = Math.Pow(number, exponent);
            Console.WriteLine($"Результат: {result}");
        }

        static void SquareRoot()
        {
            Console.WriteLine("Введите число для извлечения квадратного корня:");
            if (!double.TryParse(Console.ReadLine(), out double number) || number < 0)
            {
                Console.WriteLine("Неверный формат числа или число отрицательное.");
                return;
            }

            double result = Math.Sqrt(number);

            Console.WriteLine($"Квадратный корень числа: {result}");
        }

        static void CalculatePercentage()
        {
            Console.WriteLine("Введите основное число:");
            if (!double.TryParse(Console.ReadLine(), out double baseNumber))
            {
                Console.WriteLine("Неверный формат числа.");
                return;
            }

            Console.WriteLine("Введите процент (в виде десятичной дроби, например, 0,1 для 10%):");
            if (!double.TryParse(Console.ReadLine(), out double percentage))
            {
                Console.WriteLine("Неверный формат процента.");
                return;
            }

            double result = baseNumber * percentage;
            Console.WriteLine($"Результат: {result}");
        }
        static void CalculateFormula()
        {
            Console.WriteLine("Введите значение переменной x:");
            if (!int.TryParse(Console.ReadLine(), out int x))
            {
                Console.WriteLine("Неверный формат числа.");
                return;
            }

            BigInteger factorial = Calculate(x + 2);

            if (factorial == -1)
            {
                Console.WriteLine("Ошибка: факториал отрицательного числа не определен.");
                return;
            }
            else if (factorial == -2)
            {
                Console.WriteLine("Ошибка: переполнение при вычислении факториала.");
                return;
            }

            double f = (double)factorial / 7;

            if (double.IsInfinity(f))
            {
                Console.WriteLine("Ошибка: результат слишком большой и равен бесконечности.");
                return;
            }

            Console.WriteLine($"Значение f = ((x + 2)!) / 7 = {f}");
        }

        static BigInteger Calculate(BigInteger n)
        {
            if (n < 0)
            {
                return -1;
            }
            else if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                try
                {
                    checked
                    {
                        BigInteger factorial = 1;
                        for (int i = 2; i <= n; i++)
                        {
                            factorial *= i;
                        }
                        return factorial;
                    }
                }
                catch (OverflowException)
                {
                    return -2;
                }
            }
        }
    }
}
