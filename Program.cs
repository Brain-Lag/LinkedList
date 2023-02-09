using System;

while (true)
{
    Console.WriteLine("Введите длину массива");
    if (!int.TryParse(Console.ReadLine(), out int result)) result = 0;
    int[] arr = new int[result];
    while (true)
    {
        int choice;
        Console.WriteLine("Выберите действие: 1)Add \n2)Remove \n3)Print");
        choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Console.WriteLine("Введите добавляемое число");
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine("Число не считывается.");
                    continue;
                }
                ArrayAdd(arr, result);
                
                break;
            case 2:
                Console.WriteLine("Введите искомое число");
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine("Число не считывается.");
                    continue;
                }
                ArrayRemove(arr, result);
                break;
            case 3:
                ArrayPrint(arr);
                break;
            default:
                continue;
        }
    }


}
static int[] ArrayAdd(int[] arr, int num)
{
    int[] resultArr = new int[arr.Length + 1];
    if (arr[0] >= num)
    {
        resultArr[0] = num;
        for (int i = 1; i < resultArr.Length; i++)
        {
            resultArr[i] = arr[i - 1];
        }
    }
    else if (arr[arr.Length] <= num)
    {
        resultArr[resultArr.Length] = num;
        for (int i = 0; i < resultArr.Length; i++)
        {
            resultArr[i] = arr[i];
        }
    }
    else
    {
        bool flag = true;
        for (int i = 0; i < resultArr.Length-1; i++)
        {
            if (flag)
            {
                if (num >= arr[i] && num <= arr[i + 1])
                {
                    flag = false;
                    arr[i] = num;
                    continue;
                }
                resultArr[i] = arr[i];
            }
            else
            {
                resultArr[i] = arr[i + 1];
            }
        }
    }
    return resultArr;
}

int[] ArrayRemove (int[] arr, int num)
{
    if (num < arr[0] || num > arr[arr.Length-1])
    {
        return arr;
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

    return flag? arr:resultArr;
}

void ArrayPrint (int[] arr)
{
    if (arr.Length == 0)
    {
        Console.WriteLine("Пустой массив");
        return;
    }
    foreach(int i in arr)
    {
        Console.Write(i + " ");
    }
}