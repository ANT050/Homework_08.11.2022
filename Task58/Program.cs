/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18*/

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

//Нахождение произведения двух матриц
int[,] ProductOfMatrices(int[,] firstMatrix, int[,] secondMatrix)
{
	if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
		throw new Exception($"\nПроизведение двух матриц не имеет смысла: число столбцов первой матрицы не совпадает с числом строк второй матрицы!\n");

	int[,] resultMatrix = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
	int value = 0;

	for (int i = 0; i < firstMatrix.GetLength(0); i++)
	{
		for (int j = 0; j < secondMatrix.GetLength(1); j++)
		{
			for (int k = 0; k < firstMatrix.GetLength(1); k++)
			{
				value += firstMatrix[i, k] * secondMatrix[k, j];
			}
			resultMatrix[i, j] = value;
			value = 0;
		}
	}
	return resultMatrix;
}

try
{
	int rowsFirst = EnteringRowsColumnsMatrix("\nВведите количество строк первой матрицы: ");
	int сolumnsFirst = EnteringRowsColumnsMatrix("Введите количество столбцов первой матрицы: ");
	int rowsSecond = EnteringRowsColumnsMatrix("\nВведите количество строк второй матрицы: ");
	int сolumnsSecond = EnteringRowsColumnsMatrix("Введите количество столбцов второй матрицы: ");
	int minNumber = EnteringRowsColumnsMatrix("\nВведите минимальное число двумерого массива: ");
	int maxNumber = EnteringRowsColumnsMatrix("Введите максимальное число двумерного массива: ");

	int[,] firstMatrix = InitMatrix(rowsFirst, сolumnsFirst, minNumber, maxNumber);
	int[,] secondMatrix = InitMatrix(rowsSecond, сolumnsSecond, minNumber, maxNumber);
	int[,] resultMatrix = ProductOfMatrices(firstMatrix, secondMatrix);
	Console.WriteLine();

	PrintMatrix(firstMatrix);
	Console.WriteLine();
	PrintMatrix(secondMatrix);
	Console.WriteLine();
	PrintMatrix(resultMatrix);
	Console.WriteLine();
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}

