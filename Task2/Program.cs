/*
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/
class Program {
    public static void Main (string[] args) {
        int[,] matrix = GetArray();
        PrintMatrix(matrix);
        SumRowsArray(matrix);
    }
    static int[,] GetArray() {
        var lowerLmit = 2;
        var upperLimit = 11;
        Random rand = new Random();
        int countRow = rand.Next(lowerLmit, upperLimit);
        int countCol = rand.Next(lowerLmit, upperLimit);
        int[,] arr = new int[countRow, countCol != countRow ? countCol : countCol + 1];
        FillArray(arr);
        return arr;
    }
    
    static void FillArray(int[,] arr) {
        var maxValue = 10;
        Random rand = new Random();
        for (int i = 0; i < arr.GetLength(0); i++) {
            for (int j = 0; j < arr.GetLength(1); j++) {
                arr[i,j] = rand.Next(maxValue);
            }
        }
    }

    static void PrintMatrix(int[,] array) {
        for (int i = 0; i < array.GetLength(0); i++) {
            for (int j = 0; j < array.GetLength(1); j++) {
                Console.Write(array[i,j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void SumRowsArray(int[,] array) {
        var numberRow = 0;
        var minSumRow = 0;
        var sumRow = 0;
        for (int i = 0; i < array.GetLength(0); i++) {
            sumRow = 0;
            for (int j = 0; j < array.GetLength(1); j++) {
                sumRow += array[i,j];
            }
            Console.WriteLine($"Сумма элементов {i + 1} строки = {sumRow}");
            if (i == 0) {
               minSumRow = sumRow;
               numberRow = i + 1;
               continue; 
            }
            if (sumRow < minSumRow) {
               minSumRow = sumRow;
               numberRow = i + 1; 
            }
            
        }
        Console.WriteLine($"Наименьшая сумма в {numberRow} строке.");
    }
}