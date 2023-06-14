/*
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/
class Program {
    public static void Main (string[] args) {
        int[,] matrix = GetArray();
        Console.WriteLine("Исходный массив:");
        PrintMatrix(matrix);
        Console.WriteLine();
        Console.WriteLine("Сортированный массив:");
        SortArray(matrix);
        PrintMatrix(matrix);
    }
    static int[,] GetArray() {
        var lowerLmit = 2;
        var upperLimit = 11;
        Random rand = new Random();
        int[,] arr = new int[rand.Next(lowerLmit, upperLimit), rand.Next(lowerLmit, upperLimit)];
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

    static void SortArray(int[,] array) {
        for (int i = 0; i < array.GetLength(0); i++) {
            for (int j = 0; j < array.GetLength(1); j++) {
                SortRows(array, i, j);
            }
        }
    }

    static void SortRows(int[,] arr, int indexRow, int indexCol) {
        int maxValue = arr[indexRow, indexCol];
        int indexColMaxValue = indexCol;
        for (int k = indexCol; k < arr.GetLength(1); k++) {
            if (arr[indexRow,k] > maxValue) {
                maxValue = arr[indexRow,k];
                indexColMaxValue = k;
            } 
        }
        arr[indexRow, indexColMaxValue] = arr[indexRow, indexCol];
        arr[indexRow, indexCol] = maxValue;
    }
}