using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // --- 1. Введення номера студента ---
        Console.Write("Введіть свій номер у журналі K: ");
        int K = int.Parse(Console.ReadLine());

        // --- 2. Обчислення розміру масиву ---
        int N = (int)(20 + 0.6 * K);
        Console.WriteLine($"Розмір масиву N = {N}");

        // --- 3. Заповнення масиву випадковими числами (10-100) ---
        int[] arr = new int[N];
        Random rnd = new Random();
        for (int i = 0; i < N; i++)
            arr[i] = rnd.Next(10, 101);

        Console.WriteLine("\nПочатковий масив:");
        PrintArray(arr);

        // --- 4. Сортування вставками ---
        InsertionSort(arr);

        Console.WriteLine("\nВідсортований масив (методом вставок):");
        PrintArray(arr);

        // --- 5. Введення ключового значення ---
        Console.Write("\nВведіть ключове значення для пошуку: ");
        int key = int.Parse(Console.ReadLine());

        // --- 6. Підрахунок кількості входжень ---
        int count = CountOccurrences(arr, key);
        Console.WriteLine($"Ключ {key} зустрічається {count} раз(и).");

        // --- 7. Бінарний пошук ---
        int indexBinary = BinarySearch(arr, key);
        if (indexBinary != -1)
            Console.WriteLine($"(Бінарний пошук) Елемент {key} знайдено на позиції {indexBinary + 1}.");
        else
            Console.WriteLine($"(Бінарний пошук) Елемент {key} не знайдено.");

        // --- 8. Послідовний пошук ---
        int indexSeq = SequentialSearch(arr, key);
        if (indexSeq != -1)
            Console.WriteLine($"(Послідовний пошук) Елемент {key} знайдено на позиції {indexSeq + 1}.");
        else
            Console.WriteLine($"(Послідовний пошук) Елемент {key} не знайдено.");
    }

    // --- Метод виведення масиву ---
    static void PrintArray(int[] arr)
    {
        foreach (int x in arr)
            Console.Write(x + " ");
        Console.WriteLine();
    }

    // --- Метод сортування вставками ---
    static void InsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int temp = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > temp)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = temp;
        }
    }

    // --- Метод підрахунку кількості входжень ---
    static int CountOccurrences(int[] arr, int key)
    {
        int count = 0;
        foreach (int x in arr)
            if (x == key) count++;
        return count;
    }

    // --- Метод бінарного пошуку ---
    static int BinarySearch(int[] arr, int key)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (arr[mid] == key)
                return mid;
            else if (arr[mid] < key)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }

    // --- Метод послідовного пошуку ---
    static int SequentialSearch(int[] arr, int key)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == key)
                return i;
        }
        return -1;
    }
}