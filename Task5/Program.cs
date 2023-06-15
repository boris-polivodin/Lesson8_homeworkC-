/*
ДОПОЛНИТЕЛЬНАЯ. Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/
class Program {
    public static void Main (string[] args) {
        int[,] matrix = GetArray();
        PrintMatrix(matrix);
    }
    static int[,] GetArray() {
        int row = Prompt("Задайте количество строк массива: ");
        int column = Prompt("Задайте количество колонок массива: ");
  
        int[,] arr = new int[row, column];
        FillArray(arr);
        return arr;
    }

    static int Prompt(string message) {
        Console.Write(message);
        string readInput = Console.ReadLine() ?? "Null";
        int number;
        bool isNumber = int.TryParse(readInput, out number);
        return number;
    }
// решение пусть и "лобовое", зато действенное - заполнит любую матрицу
    static void FillArray(int[,] arr) {  
        var number = 0;
        var count = 0;
        do  {
            for (int i = count, j = count; j < arr.GetLength(1) - count; j++) {
                if (number == arr.GetLength(0) * arr.GetLength(1)) break;
                arr[i,j] = ++number;
            }
          
            for (int i = count + 1, j = arr.GetUpperBound(1) - count; i < arr.GetUpperBound(0) - count; i++) {
                if (number == arr.GetLength(0) * arr.GetLength(1)) break;
                arr[i,j] = ++number;
            }

            for (int i = arr.GetUpperBound(0) - count, j = arr.GetUpperBound(1) - count; j >= count; j--) {
                if (number == arr.GetLength(0) * arr.GetLength(1)) break;
                arr[i,j] = ++number;
            }
          
            for (int i = arr.GetLength(0) - 2 - count, j = count; i >= count + 1; i--) {
                if (number == arr.GetLength(0) * arr.GetLength(1)) break;
                arr[i,j] = ++number;
            }
            count++;
        } while (number < arr.GetLength(0) * arr.GetLength(1)); 
    }
    static void PrintMatrix(int[,] array) {
        for (int i = 0; i < array.GetLength(0); i++) {
            for (int j = 0; j < array.GetLength(1); j++) {
                Console.Write(array[i,j] + "\t");
            }
            Console.WriteLine();
        }
    }
}