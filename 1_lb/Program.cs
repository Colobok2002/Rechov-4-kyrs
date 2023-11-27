using System;

class Program
{
    static void Main()
    {

        if (TryParseCoefficient("a", out double a) &&
            TryParseCoefficient("b", out double b) &&
            TryParseCoefficient("c", out double c))
        {
            double bb = b * b;

            if (double.IsInfinity(bb))
            {
                Console.WriteLine("Слишком большое значение b");
                return;
            }

            double fora = 4 * a;
            if (double.IsInfinity(fora))
            {
                Console.WriteLine("Слишком большое значение a");
                return;
            }

            double foraC = fora * c;
            if (double.IsInfinity(foraC))
            {
                Console.WriteLine("Слишком большое значение c");
                return;
            }
            double discriminant = bb - foraC;

            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0)
                    {
                        Console.WriteLine("Уравнение имеет бесконечно много корней.");
                    }
                    else
                    {
                        Console.WriteLine("Уравнение не имеет корней.");
                    }
                }
                else
                {
                    double root = -(double)c / b;
                    if (double.IsInfinity(root))
                    {
                        Console.WriteLine($"Слишком больщой корень уменьте значение c или b");
                    }
                    else
                    {
                        Console.WriteLine("Корень: " + root);
                    }
                }
            }
            else if (discriminant > 0)
            {
                double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                if (double.IsInfinity(root1))
                {
                    Console.WriteLine($"Ошибка: Корень не может быть бесконечностью");

                }
                else
                {
                    Console.WriteLine("Корень: " + root1);
                }
                if (double.IsInfinity(root2))
                {
                    Console.WriteLine($"Ошибка: Корень не может быть бесконечностью");
                }
                else
                {
                    Console.WriteLine("Корень: " + root2);
                }
            }
            else if (discriminant == 0)
            {
                double root = -b / (2 * a);
                if (double.IsInfinity(root))
                {
                    Console.WriteLine($"Ошибка: Корень не может быть бесконечностью");
                }
                else
                {
                    Console.WriteLine("Корень: " + root);
                }
            }
            else
            {
                Console.WriteLine("Уравнение не имеет действительных корней.");
            }
        }
    }

    static bool TryParseCoefficient(string coefficientName, out double coefficient)
    {
        Console.WriteLine($"Введите коэффициент {coefficientName}:");
        if (double.TryParse(Console.ReadLine(), out coefficient))
        {
            return true;
        }
        else
        {
            Console.WriteLine($"Ошибка: Коэффициент {coefficientName} должен быть числом.");
            return false;
        }
    }

}
