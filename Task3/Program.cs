/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18

Матрицу P можно умножить на матрицу K только в том случае, если число столбцов матрицы P равняется числу строк матрицы K.
Произведение матрицы A размера m×n и матрицы B размера n×k — это матрица C размера m×k, 
в которой элемент c[i,j]​ равен сумме произведений элементов i строки матрицы A на соответствующие элементы j столбца матрицы B:
c[i,j]=a[i,1]*b[1,j] + a[i,2]*b[2,j] +...+ a[i,n]*b[n,j]
*/

class Program {
    public static void Main(string[] args) {
        var ArrayCollection = GetArrays();
        // Произведение матрицы A размера m×n и матрицы B размера n×k — это матрица C размера m×k
        int[,] resultArray = new int[ArrayCollection["firstArray"].GetLength(0), ArrayCollection["secondArray"].GetLength(1)];
        MultiplyArrays(ArrayCollection["firstArray"], ArrayCollection["secondArray"], resultArray);
        
        Console.WriteLine("Первая матрца:");
        PrintMatrix(ArrayCollection["firstArray"]);
        Console.WriteLine("Вторая матрица:");
        PrintMatrix(ArrayCollection["secondArray"]);
        Console.WriteLine("Произведение матриц:");
        PrintMatrix(resultArray);
    }

    static Dictionary<string, int[,]> GetArrays() {
        var lowerLmit = 2;
        var upperLimit = 4;
        Random rand = new Random();
        int countCol = rand.Next(lowerLmit, upperLimit);
        int[,] firstArray = new int[rand.Next(lowerLmit, upperLimit), countCol];
        FillArray(firstArray);
        // Матрицу P можно умножить на матрицу K только в том случае, если число столбцов матрицы P равняется числу строк матрицы K.
        int[,] secondArray = new int[countCol, rand.Next(lowerLmit, upperLimit)];
        FillArray(secondArray);
        return new Dictionary<string, int[,]>() {["firstArray"] = firstArray, ["secondArray"] = secondArray};
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
    static void MultiplyArrays(int[,] firstArray, int[,] secondArray, int[,] resultArray) {
        // c[m,k]=a[m,1]*b[1,k] + a[m,2]*b[2,k] +...+ a[m,n]*b[n,k]
        for (int m = 0; m < firstArray.GetLength(0); m++) {
            for (int k = 0; k < secondArray.GetLength(1); k++) {
                for (int n = 0; n < firstArray.GetLength(1); n++)  {
                    resultArray[m,k] += firstArray[m,n]*secondArray[n,k];
                }
            }
        }
    }
}