using System;

class Program
{
    public static int GetArraySizeFromInput()
    {
        int size;
        while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
        {
            Console.WriteLine("Пожалуйста, введите положительное целое число для размера массива:");
        }
        return size;
    }

    public static int[] GetArrayData(int size)
    {
        int[] array = new int[size];
        Console.WriteLine($"Введите {size} элементов массива:");
        for (int i = 0; i < size; i++)
        {
            while (!int.TryParse(Console.ReadLine(), out array[i]))
            {
                Console.WriteLine("Пожалуйста, введите целое число:");
            }
        }
        return array;
    }

    public static void DisplayArray(int[] array)
    {
        foreach (var element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }

    public static int GetMaxElement(int[] array)
    {
        return array.Max();
    }

    public static int GetMinElement(int[] array)
    {
        return array.Min();
    }
}

class MainClass
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите размер первого массива:");
        int size1 = Program.GetArraySizeFromInput();

        int[] array1 = Program.GetArrayData(size1);

        Console.WriteLine("Массив 1:");
        Program.DisplayArray(array1);

        int maxElementArray1 = Program.GetMaxElement(array1);
        int minElementArray1 = Program.GetMinElement(array1);

        Console.WriteLine($"Максимальный элемент в массиве 1: {maxElementArray1}");
        Console.WriteLine($"Минимальный элемент в массиве 1: {minElementArray1}");

        Console.WriteLine("\nВведите размер второго массива:");
        int size2 = Program.GetArraySizeFromInput();

        int[] array2 = Program.GetArrayData(size2);

        Console.WriteLine("\nМассив 2:");
        Program.DisplayArray(array2);

        int maxElementArray2 = Program.GetMaxElement(array2);
        int minElementArray2 = Program.GetMinElement(array2);

        Console.WriteLine($"Максимальный элемент в массиве 2: {maxElementArray2}");
        Console.WriteLine($"Минимальный элемент в массиве 2: {minElementArray2}");
    }
}
