/* Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18 */

using System;
using static System.Console;

Clear();
int colRow = MatrixNum("Введите кол-во столбцов матрицы A и соответственно строк B: ");
int col = MatrixNum("Введите кол-во столбцов матрицы B: ");
int row = MatrixNum("Введите кол-во строк матрицы A: ");
int[,] matrixA = Matrix(row, colRow);
int[,] matrixB = Matrix(colRow, col);
ShowMatrix(matrixA, "Матрица A:");
ShowMatrix(matrixB, "Матрица B:");
ShowMatrix(MatrixC(matrixA, matrixB), "Произведение матриц A и B матрица C:");


int MatrixNum(string text)                                                             // Метод ввода-вывода данных с передачей ему текста
{
    Write(text);
    int num = int.Parse(ReadLine()!);
    return num;
}

int[,] Matrix(int m, int n)                                                            // Метод для создания матрицы и заполнения её случайными числами
{
    int[,] matr = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            matr[i, j] = new Random().Next(-9, 10);
        }
    }
    return matr;
}

void ShowMatrix(int[,] matrx, string text)                                              // Метод для демонстрации матрицы в терминале с выводом текста
{
    WriteLine(text);
    for (int i = 0; i < matrx.GetLength(0); i++)
    {
        for (int j = 0; j < matrx.GetLength(1); j++)
        {
            Write($"{matrx[i, j]}  ");
        }
        WriteLine();
    }
}

int[,] MatrixC(int[,] a, int[,] b)                                                     // Метод вычисления произведения двух матриц
{
    int[,] matrC = new int[a.GetLength(0), b.GetLength(1)];
    for (int i = 0; i < a.GetLength(0); i++)
    {
        for (int j = 0; j < a.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(1); k++)
            {
                matrC[i, k] += a[i, j] * b[j, k];
            }
        }
    }
    return matrC;
}