/* Задача 54: Задайте двумерный массив. Напишите программу,
 которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2 */

using System;
using static System.Console;

Clear();

Write("Введите кол-во строк: ");                                 // Запрашиваем кол-во строк
int row = int.Parse(ReadLine()!);                                // Вводим кол-во строк
Write("Введите кол-во столбцов: ");                              // Запрашиваем кол-во столбцов
int col = int.Parse(ReadLine()!);                                // Вводим кол-во столбцов
int[,] array = CreatArr(row, col);                               // Вызываем метод CreatArr() и записываем возвращаемый им массив в массив array
ShowArr(array, "Массив до сортировки:");                         // Вызываем метод ShowArray() для вывода в терминал созданого масива с передачей ему такового и текстового сообщения
ShowArr(BubbleSortDoubleArr(array), "Массив после сортировки:"); // Вызываем метод ShowArray() для вывода в терминал отсортированного масива с передачей ему, путём вызова в методе метода BubbleSortDoubleArr(), такового и текстового сообщения

int[] BubbleSort(int[] arr)                                      //Создаём метод для сортировки одномерного массива по убыванию
{
    int temp;
    for (int i = 0; i < arr.Length; i++)
    {
        for (int j = i + 1; j < arr.Length; j++)
        {
            if (arr[i] < arr[j])
            {
                temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
    }
    return arr;
}

int[,] CreatArr(int r, int c)                                    // Создаём метод для создания и заполнения случайными числами массива
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

int[,] BubbleSortDoubleArr(int[,] arr)                           // Создаём метод для сортировки двумерного массива
{
    int[] arr1 = new int[arr.GetLength(1)];                      // Создаём вспомогательный одномерный массив равный по длинне кол-ву столбцов в двумерном массиве
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        int j;                                                   // Создали переменную j, общую для двух вложенных циклов
        for (j = 0; j < arr.GetLength(1); j++)
        {
            arr1[j] = arr[i, j];                                 //Записываем построчно в вспомогательный массив значения из двумерного массива
        }
        BubbleSort(arr1);                                        // Методом BubbleSort() сортируем вспомогательный массив по убыванию
        for (j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = arr1[j];                                 // Записываем из вспомогательного массива в двумерный отсортированные значения
        }

    }
    return arr;
}

void ShowArr(int[,] arr, string text)                           // Метод для вывода в терминал результата с сообщением
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
