﻿/* Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
 Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1) */


/* Примечание: прога работает для массивов не более чем 5х4х4 т.к. для больших массивов необходимо 
записывать в массив трёхзначные числа (не хватает двузначных чисел!) */
using System;
using static System.Console;

Clear();                                                                          // Очищаем терминал
TripArr(ArrInd("Введите первый индекс массива: "),                                // Вызываем метод создающий массив и передаём в него 
        ArrInd("Введите второй индекс массива: "),                                // методы ввода-вывода передающие ему индексы массива
        ArrInd("Введите третий индекс массива: "));

int ArrInd(string text)                                                           // Метод ввода-вывода данных с передачей ему текста
{
    Write(text);
    int num = int.Parse(ReadLine()!);
    return num;
}

void TripArr(int r, int c, int b)                                                 // Метод создаёт массив и выводит его в терминал
{
    int[,,] tr = new int[r, c, b];
    for (int i = 0; i < tr.GetLength(0); i++)
    {
        for (int j = 0; j < tr.GetLength(1); j++)
        {
            for (int k = 0; k < tr.GetLength(2); k++)
            {
                int m = new Random().Next(10, 100);
                tr[i, j, k] = SortMeth(tr, m);                                    // Вызываем метод для вычисления числа не существующего в массиве и присваиваем это число очередной ячейке массива
                Write($"{tr[i, j, k]}({i},{j},{k})  ");
            }
            WriteLine();
        }
        WriteLine();
    }
    WriteLine();
}

int SortMeth(int[,,] arr, int n)                                                  // Метод возвращает двузначное число которое ещё не существует в массиве
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int k = 0; k < arr.GetLength(2); k++)
            {
                foreach (int item in arr)
                {
                    if (item == n) k--;
                    else n = new Random().Next(10, 100);
                }
            }
        }
    }
    return n;
}