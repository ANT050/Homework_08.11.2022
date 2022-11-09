/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка*/

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

//Нахождение суммы каждой строки
List<int> SumOfLineElements(int[,] matrix)
{
	int summ;
	List<int> sumLines = new List<int>();
	for (int i = 0; i < matrix.GetLength(0); i++)
	{
		summ = 0;
		for (int j = 0; j < matrix.GetLength(1); j++)
		{
			summ += matrix[i, j];
		}
		sumLines.Add(summ);
	}
	return sumLines;
}

//Нахождение строки с наименьшей суммой элементов
int MinimumAmount(List<int> lineAmount)
{
	int minValue = lineAmount.Min();
	int minIndex = lineAmount.IndexOf(minValue);
	return minIndex;
}

int rows = EnteringRowsColumnsMatrix("\nВведите количество строк двумерного массива: ");
int сolumns = EnteringRowsColumnsMatrix("Введите количество столбцов двумерного массива: ");
int minNumber = EnteringRowsColumnsMatrix("\nВведите минимальное число двумерого массива: ");
int maxNumber = EnteringRowsColumnsMatrix("Введите максимальное число двумерного массива: ");

int[,] matrix = InitMatrix(rows, сolumns, minNumber, maxNumber);
Console.WriteLine();
PrintMatrix(matrix);
Console.WriteLine();
List<int> lineAmount = SumOfLineElements(matrix);
int minSum = MinimumAmount(lineAmount);
Console.WriteLine($"Cтрока с наименьшей суммой элементов: {minSum+1}");
