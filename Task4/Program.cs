/*
Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, 
которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/
class Program {
    public static void Main (string[] args) {
        int[,,] matrix = GetArray();
        PrintMatrix(matrix);
    }
    static int[,,] GetArray() {
        int row = Prompt("Задайте количество строк массива: ");
        int column = Prompt("Задайте количество колонок массива: ");
        int deapth = Prompt("Задайте глубину массива: ");
        int[,,] arr = new int[row, column, deapth];
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

    static void FillArray(int[,,] arr) {
        var maxValue = 100;
        var minValue = 10;
        int value;
        int[] searchArray = new int[arr.GetLength(0) * arr.GetLength(1) * arr.GetLength(2)];
        int indexSearchArray = 0;
        Random rand = new Random();
        for (int i = 0; i < arr.GetLength(0); i++) {
            for (int j = 0; j < arr.GetLength(1); j++) {
                for (int k = 0; k < arr.GetLength(2); k++) {
                    do
                    {
                        value = rand.Next(minValue, maxValue);
                    } while (Array.LastIndexOf(searchArray, value) != -1);
                    arr[i,j,k] = value;
                    searchArray[indexSearchArray++] = value;
                }
            }
        }
    }
    static void PrintMatrix(int[,,] array) {
        for (int k = 0; k < array.GetLength(2); k++) {
            for (int i = 0; i < array.GetLength(0); i++) {
                for (int j = 0; j < array.GetLength(1); j++) {
                    Console.Write($"{array[i,j, k]}  ({i}, {j}, {k})" + "\t");
                }
              Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}