using System;
using System.IO;
using System.Text.RegularExpressions;

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

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Файла не существует. Программа завершена.");
                    return;
                }

                string[] lines = File.ReadAllLines(filePath);

                double sumOfPositives = 0;
                int countOfPositives = 0;
                double maxNegative = double.MinValue;
                double maxPositive = double.MinValue;
                string pattern = @"-?\d+(\.\d+)?([eE]-?\d+)?";

                foreach (var line in lines)
                {
                    MatchCollection matches = Regex.Matches(line, pattern);

                    foreach (Match match in matches)
                    {
                        if (double.TryParse(match.Value, out double num))
                        {
                            if (num > 0)
                            {
                                sumOfPositives += num;
                                countOfPositives++;
                                maxPositive = Math.Max(maxPositive, num);
                            }
                            else if (num < 0)
                            {
                                maxNegative = Math.Max(maxNegative, num);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"'{match.Value}' не является числом типа double.");
                        }
                    }
                }

                Console.WriteLine($"Сумма положительных элементов: {sumOfPositives}");
                Console.WriteLine($"Количество положительных элементов: {countOfPositives}");

                if (maxNegative == double.MinValue)
                {
                    Console.WriteLine($"Не были переданы отрицательные элементы");
                }
                else if (maxPositive == double.MinValue)
                {
                    Console.WriteLine($"Не были переданы положительные элементы");
                }
                else
                {
                    double poiz = maxNegative * maxPositive;
                    Console.WriteLine($"Произведение максимального отрицательного и положительного элементов: {poiz}");
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
    }
}
