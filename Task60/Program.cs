/*Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)*/

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

// Создание трёхмерного массива, заполненного случайными уникальными числами
int[,,] InitMatrix(int axisX, int axisY, int axisZ)
{
	HashSet<int> numbers = new HashSet<int>();
	Random rnd = new Random();

	int GenerateUniqueNumber()
	{
		while (true)
		{
			int value = rnd.Next(10, 19);
			if (!numbers.Contains(value))
			{
				numbers.Add(value);
				return value;
			}
		}
	}

	int[,,] resultMatrix = new int[axisX, axisY, axisZ];

	if (axisX != 2 || axisY != 2 || axisZ != 2)
		throw new Exception($"\nРазмер массива не соответствует условию, введите размер 2x2x2!\n");

	for (int i = 0; i < axisX; i++)
	{
		for (int j = 0; j < axisY; j++)
		{
			for (int k = 0; k < axisZ; k++)
			{
				resultMatrix[i, j, k] = GenerateUniqueNumber();
			}
		}
	}
	return resultMatrix;
}

// Вывод массива, добавляя индексы каждого элемента
void PrintIndex(int[,,] matrix)
{
	for (int i = 0; i < matrix.GetLength(0); i++)
	{
		for (int j = 0; j < matrix.GetLength(1); j++)
		{
			Console.WriteLine();
			for (int k = 0; k < matrix.GetLength(2); k++)
			{
				Console.Write($"{matrix[i, j, k]}({i},{j},{k}) ");
			}
		}
	}
}

try
{
	int axisX = EnteringRowsColumnsMatrix("\nВведите значение массива по оси X: ");
	int axisY = EnteringRowsColumnsMatrix("Введите значение массива по оси Y: ");
	int axisZ = EnteringRowsColumnsMatrix("Введите значение массива по оси Z: ");

	int[,,] matrix = InitMatrix(axisX, axisY, axisZ);

	PrintIndex(matrix);
	Console.WriteLine();
}

catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}
