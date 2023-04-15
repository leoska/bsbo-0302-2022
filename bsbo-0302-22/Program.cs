using System;
using bsbo_0302_22;

internal class Application
{
    static int N = 5; // Кол-во элементов для массива
    static public Stack tmp = new Stack(); // Временный стэк для перестановок

    // Вывод содержимого массива
    static void PrintArr(int[] arr)
    {
        for(int i = 0; i < N; i++)
        {
            Console.Write($"{arr[i].ToString()} ");
        }
        Console.WriteLine();
    }


    // Сортировка пузырьком массива
    static void SortArr()
    {
        int[] arr = new int[] { 1, 432, 653, 23, 552 };

        PrintArr(arr);

        bool swapFlag = false;

        for (int i = 0; i < N; i++)
        {
            swapFlag = false;

            for (int j = 0; j < N - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Способ #1 (С доп памятью)
                    // O(9), M(1)
                    //int tmp = arr[j];
                    //arr[j] = arr[j + 1];
                    //arr[j + 1] = tmp;

                    // Способ #2 (Без доп памяти)
                    // [1, 4]
                    // 1) [5, 4]
                    // 2) [5, 1]
                    // 3) [4, 1]
                    // O(19), M(0)
                    //arr[j] = arr[j] + arr[j + 1];
                    //arr[j + 1] = arr[j] - arr[j + 1];
                    //arr[j] = arr[j] - arr[j + 1];

                    // Способ #3 (с ValueTuple)
                    // O(6 + k), M(2k)
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);

                    swapFlag = true;
                }
            }

            if (!swapFlag)
            {
                break;
            }
        }

        PrintArr(arr);
    }

    // Пример использования refType переменных
    static void RefTypes()
    {
        Item a = new Item(15);
        Console.WriteLine($"a: {a.value}");

        Item b = a;
        Console.WriteLine($"b: {b.value}");

        a.value = 27;
        Console.WriteLine($"a: {a.value}"); // a == 15?
        Console.WriteLine($"b: {b.value}"); // b == 15?
    }

    // Сортировка стэка с использованием методов Get и Set
    static void StackWithGetSet()
    {
        int n = 5;
        Random rnd = new Random();
        Stack stack = new Stack();

        for (int i = 0; i < n; i++)
        {
            stack.Push(new Item(rnd.Next(0, 100)));
        }

        stack.Print();

        bool swapFlag = false;
        for (int i = 0; i < n; i++)
        {
            swapFlag = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                int current = stack.Get(j, tmp);
                int neighbor = stack.Get(j + 1, tmp);

                if (current > neighbor)
                {
                    stack.Set(j, neighbor, tmp);
                    stack.Set(j + 1, current, tmp);
                    swapFlag = true;
                }
            }

            if (!swapFlag)
                break;
        }

        stack.Print();
    }

    // Сортировка стэка с перегрузкой оператора индексации []
    static void StackWithIndexing()
    {
        int n = 5;
        Random rnd = new Random();
        Stack stack = new Stack();

        for (int i = 0; i < n; i++)
        {
            stack.Push(new Item(rnd.Next(0, 100)));
        }

        stack.Print();

        bool swapFlag = false;
        for (int i = 0; i < n; i++)
        {
            swapFlag = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (stack[j] > stack[j + 1])
                {
                    (stack[j], stack[j + 1]) = (stack[j + 1], stack[j]);
                    swapFlag = true;
                }
            }

            if (!swapFlag)
                break;
        }

        stack.Print();
    }

    static void Main(string[] args)
    {
        //SortArr();
        //RefTypes();

        //StackWithGetSet();
        StackWithIndexing();
    }
}