using System;

class Calculator
{
    static void Main()
    {
        int choice = -1;
        while (choice != 9)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Сложить 2 числа");
            Console.WriteLine("2. Вычесть первое из второго");
            Console.WriteLine("3. Перемножить два числа");
            Console.WriteLine("4. Разделить первое на второе");
            Console.WriteLine("5. Возвести в степень N первое число");
            Console.WriteLine("6. Найти квадратный корень из числа");
            Console.WriteLine("7. Найти 1 процент от числа");
            Console.WriteLine("8. Найти факториал из числа");
            Console.WriteLine("9. Выйти из программы");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Ошибка ввода. Введите число от 1 до 9.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddNumbers();
                    break;
                case 2:
                    SubtractNumbers();
                    break;
                case 3:
                    MultiplyNumbers();
                    break;
                case 4:
                    DivideNumbers();
                    break;
                case 5:
                    PowNumber();
                    break;
                case 6:
                    SqrtNumber();
                    break;
                case 7:
                    CalculatePercentage();
                    break;
                case 8:
                    CalculateFactorial();
                    break;
                case 9:
                    Console.WriteLine("Выход из программы.");
                    break;
                default:
                    Console.WriteLine("Ошибка выбора. Введите число от 1 до 9.");
                    break;
            }
        }
    }

    static void AddNumbers()
    {
        Console.WriteLine("Введите первое число:");
        string input1 = Console.ReadLine();
        if (!double.TryParse(input1, out double num1))
        {
            Console.WriteLine("Ошибка ввода. Введите число.");
            return;
        }

        Console.WriteLine("Введите второе число:");
        string input2 = Console.ReadLine();
        if (!double.TryParse(input2, out double num2))
        {
            Console.WriteLine("Ошибка ввода. Введите число.");
            return;
        }

        double result = num1 + num2;
        Console.WriteLine($"Результат сложения: {result}");
    }

    static void SubtractNumbers()
    {
        Console.WriteLine("Введите первое число:");
        string input1 = Console.ReadLine();
        if (!double.TryParse(input1, out double num1))
        {
            Console.WriteLine("Ошибка ввода. Введите число.");
            return;
        }

        Console.WriteLine("Введите второе число:");
        string input2 = Console.ReadLine();
        if (!double.TryParse(input2, out double num2))
        {
            Console.WriteLine("Ошибка ввода. Введите число.");
            return;
        }

        double result = num1 - num2;
        Console.WriteLine($"Результат вычитания: {result}");
    }

    static void MultiplyNumbers()
    {
        Console.WriteLine("Введите первое число:");
        string input1 = Console.ReadLine();
        if (!double.TryParse(input1, out double num1))
        {
            Console.WriteLine("Ошибка ввода. Введите число.");
            return;
        }

        Console.WriteLine("Введите второе число:");
        string input2 = Console.ReadLine();
        if (!double.TryParse(input2, out double num2))
        {
            Console.WriteLine("Ошибка ввода. Введите число.");
            return;
        }

        double result = num1 * num2;
        Console.WriteLine($"Результат умножения: {result}");
    }

    static void DivideNumbers()
    {
        Console.WriteLine("Введите первое число:");
        string input1 = Console.ReadLine();
        if (!double.TryParse(input1, out double num1))
        {
            Console.WriteLine("Ошибка ввода. Введите число.");
            return;
        }

        Console.WriteLine("Введите второе число:");
        string input2 = Console.ReadLine();
        if (!double.TryParse(input2, out double num2) || num2 == 0)
        {
            Console.WriteLine("Ошибка ввода. Введите число, отличное от нуля.");
            return;
        }

        double result = num1 / num2;
        Console.WriteLine($"Результат деления: {result}");
    }

    static void PowNumber()
    {
        Console.WriteLine("Введите число:");
        string input1 = Console.ReadLine();
        if (!double.TryParse(input1, out double num1))
        {
            Console.WriteLine("Ошибка ввода. Введите число.");
            return;
        }

        Console.WriteLine("Введите степень:");
        string input2 = Console.ReadLine();
        if (!int.TryParse(input2, out int power))
        {
            Console.WriteLine("Ошибка ввода. Введите целое число.");
            return;
        }

        double result = Math.Pow(num1, power);
        Console.WriteLine($"Результат возведения в степень: {result}");
    }

    static void SqrtNumber()
    {
        Console.WriteLine("Введите число:");
        string input = Console.ReadLine();
        if (!double.TryParse(input, out double num) || num < 0)
        {
            Console.WriteLine("Ошибка ввода. Введите неотрицательное число.");
            return;
        }

        double result = Math.Sqrt(num);
        Console.WriteLine($"Квадратный корень числа: {result}");
    }

    static void CalculatePercentage()
    {
        Console.WriteLine("Введите число:");
        string input1 = Console.ReadLine();
        if (!double.TryParse(input1, out double num1))
        {
            Console.WriteLine("Ошибка ввода. Введите число.");
            return;
        }

        Console.WriteLine("Введите процент:");
        string input2 = Console.ReadLine();
        if (!double.TryParse(input2, out double percentage))
        {
            Console.WriteLine("Ошибка ввода. Введите число.");
            return;
        }

        double result = num1 * (percentage / 100);
        Console.WriteLine($"1 процент от числа: {result}");
    }

    static void CalculateFactorial()
    {
        Console.WriteLine("Введите число:");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int num) || num < 0)
        {
            Console.WriteLine("Ошибка ввода. Введите неотрицательное целое число.");
            return;
        }

        int result = 1;
        for (int i = 2; i <= num; i++)
        {
            result *= i;
        }
        Console.WriteLine($"Факториал числа: {result}");
    }
}