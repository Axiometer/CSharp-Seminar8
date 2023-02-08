// Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов

// Заполнение массива
double[,] GetArray(int m, int n, int minValue, int maxValue)
{
    double[,] result = new double[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = Math.Round(new Random().NextDouble() * (maxValue - minValue) + minValue, 2); 
         }
    }
    return result;
}

// Вывод массива в консоль
void WriteArrayToConsole(double[,] doubleArray)
{
    for (int i = 0; i < doubleArray.GetLength(0); i++)
    {
        for (int j = 0; j < doubleArray.GetLength(1); j++)
        {
            Console.Write($"{doubleArray[i, j]}\t");
        }
        Console.WriteLine();
    }
}

// Нахождение строки с минимальныой суммой
int FindMinSumRow(double[,] matrix)
{
    int row = 0;
    double minSum = int.MaxValue;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        double sum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum += matrix[i, j];
        }
        if (sum < minSum)
        {
            minSum = sum;
            row = i;
        }
       Console.WriteLine($"Сумма элементов {i+1} строки = {Math.Round(sum, 2)}"); 
    }
    return row+1;
}

int rows = 3;
int columns = 5;
double[,] d_array = GetArray(rows, columns, -10, 10);
System.Console.WriteLine("Изначальный массив: ");
WriteArrayToConsole(d_array);
System.Console.WriteLine($"\nСтрока с минимальной суммой - {FindMinSumRow(d_array)}");
