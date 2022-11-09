/*Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2*/

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

//Создание двумерного массива, заполненного случайными числами
int[,] InitMatrix(int rows, int columns, int minNumber, int maxNumber)
{
	int[,] resultMatrix = new int[rows, columns];
	Random rnd = new Random();

	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < columns; j++)
		{
			resultMatrix[i, j] = rnd.Next(minNumber, maxNumber);
		}
	}
	return resultMatrix;
}

//Вывод двумерного массива в консоли
void PrintMatrix(int[,] matrix)
{
	for (int i = 0; i < matrix.GetLength(0); i++)
	{
		for (int j = 0; j < matrix.GetLength(1); j++)
		{
			Console.Write($"{matrix[i, j]}\t");
		}
		Console.WriteLine();
	}
}

//Упорядочивание по убыванию элементов каждой строки двумерного массива
void SortDescendingOrder(int[,] matrix)
{
	for (int i = 0; i < matrix.GetLength(0); i++)
	{
		for (int j = 0; j < matrix.GetLength(1); j++)
		{
			for (int k = 0; k < matrix.GetLength(1) - 1; k++)
			{
				if (matrix[i, k] < matrix[i, k + 1])
				{
					int variable = matrix[i, k + 1];
					matrix[i, k + 1] = matrix[i, k];
					matrix[i, k] = variable;
				}
			}
		}
	}
}

int rows = EnteringRowsColumnsMatrix("\nВведите количество строк двумерного массива: ");
int сolumns = EnteringRowsColumnsMatrix("Введите количество столбцов двумерного массива: ");
int minNumber = EnteringRowsColumnsMatrix("\nВведите минимальное число двумерого массива: ");
int maxNumber = EnteringRowsColumnsMatrix("Введите максимальное число двумерного массива: ");

int[,] matrix = InitMatrix(rows, сolumns, minNumber, maxNumber);
Console.WriteLine();
PrintMatrix(matrix);
Console.WriteLine();
SortDescendingOrder(matrix);
PrintMatrix(matrix);

