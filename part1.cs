using System;

class MyMatrix
{
    private int[,] matrix;
    private Random random = new Random();

    public int Rows { get; }
    public int Cols { get; }

    public MyMatrix(int rows, int cols, int minValue, int maxValue)
    {
        Rows = rows;
        Cols = cols;
        matrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue);
            }
        }
    }

    public int this[int row, int col]
    {
        get { return matrix[row, col]; }
        set { matrix[row, col] = value; }
    }

    public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.Rows != matrix2.Rows || matrix1.Cols != matrix2.Cols)
        {
            throw new InvalidOperationException("Матрицы должны быть одинакового размера");
        }

        MyMatrix result = new MyMatrix(matrix1.Rows, matrix1.Cols, 0, 0);

        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Cols; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }

    public static MyMatrix operator -(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.Rows != matrix2.Rows || matrix1.Cols != matrix2.Cols)
        {
            throw new InvalidOperationException("Матрицы должны быть одинакового размера");
        }

        MyMatrix result = new MyMatrix(matrix1.Rows, matrix1.Cols, 0, 0);

        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Cols; j++)
            {
                result[i, j] = matrix1[i, j] - matrix2[i, j];
            }
        }

        return result;
    }

    public static MyMatrix operator *(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.Cols != matrix2.Rows)
        {
            throw new InvalidOperationException("Число столбцов первой матрицы должно быть равно числу строк второй матрицы");
        }

        MyMatrix result = new MyMatrix(matrix1.Rows, matrix2.Cols, 0, 0);

        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix2.Cols; j++)
            {
                for (int k = 0; k < matrix1.Cols; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        return result;
    }

    public static MyMatrix operator *(MyMatrix matrix, int scalar)
    {
        MyMatrix result = new MyMatrix(matrix.Rows, matrix.Cols, 0, 0);

        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Cols; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }

        return result;
    }

    public static MyMatrix operator *(int scalar, MyMatrix matrix)
    {
        return matrix * scalar;
    }

    public static MyMatrix operator /(MyMatrix matrix, int scalar)
    {
        if (scalar == 0)
        {
            throw new InvalidOperationException("Деление на ноль запрещено");
        }

        MyMatrix result = new MyMatrix(matrix.Rows, matrix.Cols, 0, 0);

        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Cols; j++)
            {
                result[i, j] = matrix[i, j] / scalar;
            }
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите число строк матрицы: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Введите число столбцов матрицы: ");
        int cols = int.Parse(Console.ReadLine());

        Console.Write("Введите минимальное значение для случайных чисел: ");
        int minValue = int.Parse(Console.ReadLine());

        Console.Write("Введите максимальное значение для случайных чисел: ");
        int maxValue = int.Parse(Console.ReadLine());
        MyMatrix matrix = new MyMatrix(rows, cols, minValue, maxValue);

        Console.WriteLine("Матрица:");

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
