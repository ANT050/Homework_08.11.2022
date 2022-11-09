/*Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07*/

// Получение строк и столбцов с консоли, проверка на правильность ввода
int EnteringRowsColumnsMatrix(string message)
{
	int result = 0;
	bool isCorrect = false;

	while (!isCorrect)
	{
		Console.Write(message);
		isCorrect = int.TryParse(Console.ReadLine(), out result);

		if (!isCorrect)
			Console.WriteLine("\nВведите корректное число!\n");
	}
	return result;
}

//Вывод двумерного массива в консоли
void PrintMatrix(int[,] matrix)
{
	for (int i = 0; i < matrix.GetLength(0); i++)
	{
		for (int j = 0; j < matrix.GetLength(1); j++)
		{
			Console.Write($"{matrix[i, j],3:d2}\t");
		}
		Console.WriteLine();
	}
}

//Заполнение массива по спирали
int[,] SpiralArray(int rows, int сolumns)
{
	if (rows != сolumns || rows != 4)
		throw new Exception($"\nВведите размер матрицы 4 на 4!\n");
	int[,] resaltMatrix = new int[rows, сolumns];

	int value = 0;
	int i = 0;
	int j = 0;

	while (value < resaltMatrix.GetLength(0) * resaltMatrix.GetLength(1))
	{
		resaltMatrix[i, j] = value;
		value++;

		if (i <= j + 1 && i + j < resaltMatrix.GetLength(1) - 1)
			j++;
		else if (i < j && i + j >= resaltMatrix.GetLength(0) - 1)
			i++;
		else if (i >= j && i + j > resaltMatrix.GetLength(1) - 1)
			j--;
		else
			i--;
	}
	return resaltMatrix;
}

try
{
int rows = EnteringRowsColumnsMatrix("\nВведите количество строк двумерного массива: ");
int сolumns = EnteringRowsColumnsMatrix("Введите количество столбцов двумерного массива: ");
Console.WriteLine();

int[,] matrix = SpiralArray(rows, сolumns);
PrintMatrix(matrix);
}

catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}
