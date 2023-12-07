using System;

namespace DensityCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double density;

            try
            {
                Console.WriteLine("Введите массу вещества:");
                if (!double.TryParse(Console.ReadLine(), out double mass) || mass < 0)
                {
                    throw new FormatException("Некорректный ввод. Введите положительное число для массы.");
                }

                Console.WriteLine("Введите объем вещества:");
                if (!double.TryParse(Console.ReadLine(), out double volume) || volume <= 0)
                {
                    throw new FormatException("Некорректный ввод. Введите положительное число для объема.");
                }

                if (volume == 0)
                {
                    throw new DivideByZeroException("Ошибка: Попытка деления на ноль. Объем не может быть равен нулю.");
                }

                density = mass / volume;
                Console.WriteLine($"Плотность вещества: {density} кг/м³");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Ошибка ввода: {e.Message}");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"Ошибка деления на ноль: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка: {e.Message}");
            }
        }
    }
}
