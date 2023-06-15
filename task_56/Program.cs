/* Задача 56: Задайте прямоугольный двумерный массив.
 Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка */

using System;
using static System.Console;

Clear();
int row;
int col;

WritReadRow();                                                         // Вызывая метод WritReadRow() запрашиваем кол-во строк и вводим
WritReadCol();                                                         // Вызывая метод WritReadCol() запрашиваем кол-во столбцов и вводим
int[,] array = CreatArr(row, col);                                     // Вызываем метод CreatArr() и записываем возвращаемый им массив в массив array
ShowArr(array, "Создан массив:");                                      // Вызываем метод ShowArray() для вывода в терминал созданого масива с передачей ему такового и текстового сообщения
ShowMessage(CompArr(TransformArr(array)));                             // Вызываем метод ShowMessage() которому передаётся значение метода CompArr() которому в свою очередь передаётся одномерный массив из метода TransformArr() выводит сообщение

void WritReadRow()                                                     //Метод для ввода - вывода данных
{
    Write("Введите кол-во строк: ");
    row = int.Parse(ReadLine()!);
    if (row < 2)
    {
        Write("Двумерный массив не может содержать менее 2 строк.");
        WritReadRow();
    }
}

void WritReadCol()                                                     //Метод для ввода - вывода данных
{
    Write("Введите кол-во столбцов: ");
    col = int.Parse(ReadLine()!);
    if (col < 1)
    {
        Write("Двумерный массив не может содержать менее 1 столбца.");
        WritReadCol();
    }
}

void ShowArr(int[,] arr, string text)                                 // Метод для вывода в терминал массива с сообщением
{
    WriteLine(text);
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Write($"{arr[i, j]}  ");
        }
        WriteLine();
    }
}

int[,] CreatArr(int r, int c)                                        // Создаём метод для создания и заполнения случайными числами двумерного массива
{
    int[,] array = new int[r, c];
    for (int i = 0; i < r; i++)
    {
        for (int j = 0; j < c; j++)
        {
            array[i, j] = new Random().Next(0, 10);
        }
    }
    return array;
}

int[] TransformArr(int[,] arr)                                      // Метод для преобразования двумерного массива в одномерный где индексы и значения одномерного массива соответствуют индексам и суммам строк двумерного
{
    int[] array = new int[arr.GetLength(0)];
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            array[i] += arr[i, j];
        }
    }
    return array;
}

int CompArr(int[] arr)                                             // Метод вычисляет наименьшее значение передаваемого ему массива из метода TransformArr() и передаёт индекс данного значения. Метод SummArrNums() вспомогательный, для начальной записи минимального значения.
{
    int result = 0;
    int sumArr = SummArrNums(arr);
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] < sumArr)
        {
            sumArr = arr[i];
            result = i + 1;
        }
    }
    return result;
}

int SummArrNums(int[] arr)                                        // Метод сложения всех чисел массива
{
    int summ = 0;
    foreach (int item in arr) summ += item;
    return summ;
}

void ShowMessage(int r)                                           // Метод для вывода в терминал сообщения с результатом
{
    Write($"В массиве сумма значений строки {r} наименьшая.");
}
