/* Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07 */

using System;
using static System.Console;

Clear();
ShowArr(SpiralArr(ArrInd("Введите кол-во строк: "), ArrInd("Введите кол-во столбцов: ")));// Вызываем метод вывода массива в терминал предавя в него метод заполняющий массив которому в свою очередь передаём метод запроса

int ArrInd(string text)                                                                      // Метод ввода-вывода данных с передачей ему текста
{
    Write(text);
    int num = int.Parse(ReadLine()!);
    return num;
}

int[,] SpiralArr(int r, int c)                                                               // Метод заполняет массив по спирали
{
    int res;
    int i = 0;
    int j = 0;
    int[,] arr = new int[r, c];
    for (res = 1; res <= r * c; res++)
    {
        if (arr[i, j] == 0) arr[i, j] = res;
        else if (j + 1 < c && arr[i, j + 1] == 0 && (i - 1 < 0 || arr[i - 1, j] > 0)) { j++; arr[i, j] = res; }
        else if (i + 1 < r && arr[i + 1, j] == 0 && (j + 1 >= c || arr[i, j + 1] > 0)) { i++; arr[i, j] = res; }
        else if (j - 1 >= 0 && arr[i, j - 1] == 0 && (i + 1 >= r || arr[i + 1, j] > 0)) { j--; arr[i, j] = res; }
        else if (i - 1 >= 0 && arr[i - 1, j] == 0 && (j - 1 < 0 || arr[i, j - 1] > 0)) { i--; arr[i, j] = res; }
    }
    return arr;
}

void ShowArr(int[,] array)                                                         // Метод выводит в терминал массив
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Write(array[i, j].ToString("D3") + " ");                              // ToString() фарматирует выводимое значение в строку с тремя элементами
        }
        WriteLine();
    }
}