// Напишите программу, которая заполнит спирально квадратный массив

// Вывод массива в консоль
void WriteArrayToConsole(int[,] Array)
{
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            Console.Write($"{Array[i, j].ToString("00")}\t");
        }
        Console.WriteLine();
    }
}

// Спиральное заполнение
// (алгоритм взят с Хабра :) )
int[,] FillArray(int[,] a)
{
    int N = a.GetLength(0);
    for (int ik = 0; ik < N; ik++)
    {
        for (int jk = 0; jk < N; jk++)
        {
            int i = ik + 1;
            int j = jk + 1;
            int switcher =  (j - i + N) / N;
            int Ic = Math.Abs(i - N / 2  - 1) + (i - 1)/(N /2) * ((N-1) % 2);
            int Jc = Math.Abs(j - N / 2  - 1) + (j - 1)/(N /2) * ((N-1) % 2);
            int Ring = N / 2 - (Math.Abs(Ic - Jc) + Ic + Jc) / 2;
            int Xs = i - Ring + j - Ring - 1;    
            int Coef =  4 * Ring * (N - Ring);
            a[ik,jk] =  Coef + switcher * Xs + Math.Abs(switcher - 1) * (4 * (N - 2 * Ring) - 2 - Xs);
        }   
    }     
    return a;
}

// Другой вариант заполнения
int[,] FillArray2(int[,] M)
{
    int N = M.GetLength(0);
    int Ibeg = 0, Ifin = 0, Jbeg = 0, Jfin = 0;
    
    int k = 1;
    int i = 0;
    int j = 0;

    while (k <= N * N)
    {
        M[i,j] = k;

        // Если у нас верхняя сторона прямоугольника и мы не достигла правой стороны, то двигаемся вправо: ++j
        if (i == Ibeg && j < N - Jfin - 1)
            ++j;
        // Если мы на правой стороне прямоугольника и не достигли нижней стороны, то двигаемся вниз: ++i
        else if (j == N - Jfin - 1 && i < N - Ifin - 1)
            ++i;
        // Если мы на нижней стороне прямоугольника и не достигли левой стороны, то двигаемся влево: --j
        else if (i == N - Ifin - 1 && j > Jbeg)
            --j;
        // Иначе двигаемся вверх: --i
        else
            --i;

        // В конце же каждого прохода проверяем, завершился ли прямоугольник и стои ли начинать прочерчивать новый - меньший
        if ((i == Ibeg + 1) && (j == Jbeg) && (Jbeg != N - Jfin - 1)){
            Ibeg++;
            Ifin++;
            Jbeg++;
            Jfin++;
        }
        k++;
    }
    return M;
}

// возможно только N > 2
int N = 5;
int[,] matrix = new int[N, N];
Console.WriteLine($"Спиральная матрица размера {N}x{N} вариант 1:");
WriteArrayToConsole(FillArray(matrix));
Console.WriteLine($"Спиральная матрица размера {N}x{N} вариант 2:");
WriteArrayToConsole(FillArray2(matrix));
