using System;

while (true)
{
    Console.WriteLine("Введите элементы массива через Enter. ()");

    int[] arr = new int[0];
    while(true)
    {
        if (int.TryParse(Console.ReadLine(), out int result)) ArrayAdd(ref arr, result);
        else break;
    }
    ArrayPrint(arr);

    bool check = true;
    while (check)
    {
        int choice;
        Console.WriteLine("Выберите действие:\n1)Add \n2)Remove \n3)Print");
        choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Console.WriteLine("Введите добавляемое число");
                if (!int.TryParse(Console.ReadLine(), out int result))
                {
                    Console.WriteLine("Число не считывается.");
                    continue;
                }
                ArrayAdd(ref arr, result);
                goto case 3;
            case 2:
                Console.WriteLine("Введите искомое число");
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine("Число не считывается.");
                    continue;
                }
                ArrayRemove(ref arr, result);
                goto case 3;
            case 3:
                ArrayPrint(arr);
                break;
            default:
                check = false;
                break;
        }
    }
}

static void ArrayAdd(ref int[] arr, int num)
{
    if (arr.Length == 0)
    {
        arr = new int[1] { num };
        return;
    }

    int[] resultArr = new int[arr.Length + 1];
    if (arr[0] >= num)
    {
        resultArr[0] = num;
        for (int i = 1; i <= arr.Length; i++)
        {
            resultArr[i] = arr[i - 1];
        }
    }
    else if (arr[arr.Length - 1] <= num)
    {
        resultArr[resultArr.Length - 1] = num;
        for (int i = 0; i < arr.Length; i++)
        {
            resultArr[i] = arr[i];
        }
    }
    else
    {
        bool flag = true;
        resultArr[0] = arr[0];
        for (int i = 1; i < resultArr.Length; i++)
        {
            if (flag)
            {
                if (num >= arr[i - 1] && num <= arr[i])
                {
                    flag = false;
                    resultArr[i] = num;
                    continue;
                }
                resultArr[i] = arr[i];
            }
            else
            {
                resultArr[i] = arr[i - 1];
            }
        }
    }
    arr = resultArr;
}

static void ArrayRemove (ref int[] arr, int num)
{
    if (num < arr[0] || num > arr[arr.Length-1])
    {
        return;
    }
    int[] resultArr = new int[arr.Length - 1];
    bool flag = true;
    for (int i = 0; i < arr.Length; i++)
    {
        if (flag)
        {
            if (arr[i] == num)
            {
                flag = false;
                continue;
            }
            resultArr[i] = arr[i];
        }
        else
        {
            resultArr[i - 1] = arr[i];
        }
    }

    if(!flag) arr = resultArr;
}

static void ArrayPrint (int[] arr)
{
    if (arr.Length == 0)
    {
        Console.WriteLine("Пустой массив");
        return;
    }
    Console.Write('[');
    foreach(int i in arr)
    {
        Console.Write(i + ", ");
    }
    Console.Write("\b\b]\n");
}