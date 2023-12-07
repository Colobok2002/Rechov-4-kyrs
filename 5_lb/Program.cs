using System;
using System.IO;

namespace ReadFileToArray
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath;
                do
                {
                    Console.WriteLine("Введите название файла с расширением .txt на диск D (например, D:\\numbers.txt):");
                    filePath = Console.ReadLine();
                } while (string.IsNullOrEmpty(filePath) || !filePath.EndsWith(".txt"));

                if (File.Exists(filePath))
                {
                    string response;
                    do
                    {
                        Console.WriteLine("Файл уже существует. Хотите его перезаписать? (Y/N)");
                        response = Console.ReadLine();
                        if (response.ToLower() == "n")
                        {
                            Console.WriteLine("Программа завершена.");
                            return;
                        }
                        else if (response.ToLower() != "y")
                        {
                            Console.WriteLine("Пожалуйста, введите 'Y' для подтверждения перезаписи или 'N' для отмены.");
                        }
                    } while (response.ToLower() != "y");
                }

                if (CreateFile(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    int[] numbers = Array.ConvertAll(lines, int.Parse);

                    int sumOfPositives = 0;
                    int countOfPositives = 0;
                    int maxNegative = int.MinValue;
                    int maxPositive = int.MaxValue;

                    foreach (int num in numbers)
                    {
                        if (num > 0)
                        {
                            sumOfPositives += num;
                            countOfPositives++;
                            maxPositive = Math.Min(maxPositive, num);
                        }
                        else if (num < 0)
                        {
                            maxNegative = Math.Max(maxNegative, num);
                        }
                    }

                    long product = (long)maxNegative * maxPositive;

                    Console.WriteLine($"Сумма положительных элементов: {sumOfPositives}");
                    Console.WriteLine($"Количество положительных элементов: {countOfPositives}");
                    Console.WriteLine($"Произведение максимального отрицательного и положительного элементов: {product}");
                }
                else
                {
                    Console.WriteLine("Ошибка при создании файла.");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден.");
            }
            catch (IOException)
            {
                Console.WriteLine("Ошибка ввода/вывода.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка формата файла. Некорректные данные.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        static bool CreateFile(string filePath)
        {
            try
            {
                using StreamWriter writer = new StreamWriter(filePath);
                Console.WriteLine("Введите числа для записи в файл (для завершения введите 'n'):");

                while (true)
                {
                    Console.Write("Введите число или 'n' для завершения: ");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "n")
                    {
                        break;
                    }

                    if (int.TryParse(input, out int number))
                    {
                        writer.WriteLine(number);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите число или 'n'.");
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
