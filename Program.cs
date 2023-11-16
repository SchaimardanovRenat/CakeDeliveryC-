using System;
using System.Collections.Generic;
using System.IO;

public class Cake
{
    public string Shape { get; set; }
    public string Size { get; set; }
    public string Flavor { get; set; }
    public int Quantity { get; set; }
    public string Glaze { get; set; }
    public string Decor { get; set; }
    public decimal Price { get; set; }

    public Cake()
    {
        Price = 0;
    }

    public void ShowSummary()
    {
        Console.WriteLine("Торт:");
        Console.WriteLine("Форма: " + Shape);
        Console.WriteLine("Размер: " + Size);
        Console.WriteLine("Вкус: " + Flavor);
        Console.WriteLine("Количество: " + Quantity);
        Console.WriteLine("Глазурь: " + Glaze);
        Console.WriteLine("Декор: " + Decor);
        Console.WriteLine("Цена: " + Price);
        
    }
}
        

public static class Menu
{
    public enum MenuOption
    {
        None,
        Shape,
        Size,
        Flavor,
        Quantity,
        Glaze,
        Decor,
        Exit

    }

    public static MenuOption ShowMenu(string title, List<string> options)
    {
        Console.Clear();
        Console.WriteLine(title);
        Console.WriteLine();
        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + options[i]);
        }
        Console.WriteLine();
        Console.WriteLine("Esc - выход");
        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey(true);
        } while (keyInfo.Key != ConsoleKey.Escape && (keyInfo.Key < ConsoleKey.D1 || keyInfo.Key > ConsoleKey.D1 + options.Count - 1));
        if (keyInfo.Key == ConsoleKey.Escape)
        {
            return MenuOption.Exit;
        }
        else
        {
            return (MenuOption)(keyInfo.Key - ConsoleKey.D1 + 1);
        }
    }
}
 

public class Order
{
    private Cake cake;

    public void StartOrder()
    {
        cake = new Cake();
        while (true)
        {
            var option = Menu.ShowMenu("Выберите пункт:", new List<string> { "Форма", "Размер", "Вкус", "Количество", "Глазурь", "Декор", "Заказать" });
            switch (option)
            {
                case Menu.MenuOption.Shape:
                    ChooseOption("Форма", new List<string> { "Круглая", "Прямоугольная", "Квадратная" }, value => cake.Shape = value);
                    break;
                case Menu.MenuOption.Size:
                    ChooseOption("Размер", new List<string> { "Маленький", "Средний", "Большой" }, value => cake.Size = value);
                    break;
                case Menu.MenuOption.Flavor:
                    ChooseOption("Вкус", new List<string> { "Шоколадный", "Ванильный", "Фруктовый" }, value => cake.Flavor = value);
                    break;
                case Menu.MenuOption.Quantity:
                    ChooseOption("Количество", new List<string> { "1", "2", "3" }, value => cake.Quantity = int.Parse(value));
                    break;
                case Menu.MenuOption.Glaze:
                    ChooseOption("Глазурь", new List<string> { "Шоколадная", "Сливочная", "Фруктовая" }, value => cake.Glaze = value);
                    break;
                case Menu.MenuOption.Decor:
                    ChooseOption("Декор", new List<string> { "Цветы", "Фигурки", "Текст" }, value => cake.Decor = value);
                    break;
                case Menu.MenuOption.Exit:
                    return;
                case Menu.MenuOption.None:
                    break;
            }
        }
    }

    private void ChooseOption(string title, List<string> options, Action<string> action)
    {
        int pos = 1;
        ConsoleKeyInfo key;
        do
        {
            Console.Clear();
            Console.WriteLine(title);
            Console.WriteLine();
            for (int i = 0; i < options.Count; i++)
            {
                if (pos - 1 == i)
                {
                    Console.WriteLine("-> " + options[i]);
                }
                else
                {
                    Console.WriteLine("   " + options[i]);
                }
            }
            key = Console.ReadKey();

            if (key.Key == ConsoleKey.UpArrow && pos != 1)
                pos--;
            else if (key.Key == ConsoleKey.DownArrow && pos != options.Count)
                pos++;

        } while (key.Key != ConsoleKey.Enter);
        Console.Clear();

        var selectedOption = options[pos - 1];
        action(selectedOption);
    }

    public void PlaceOrder()
    {
        CalculatePrice();
        Console.Clear();
        Console.WriteLine("Ваш заказ:");
        cake.ShowSummary();

        SaveOrder();

        Console.WriteLine("Заказ успешно оформлен!");
        Console.ReadKey();
    }

    private void CalculatePrice()
    {
        decimal basePrice = 10.0m;
        decimal sizePrice = 0.0m;
        decimal flavorPrice = 0.0m;
        decimal glazePrice = 0.0m;
        decimal decorPrice = 0.0m;

        switch (cake.Size)
        {
            case "Маленький":
                sizePrice = 5.0m;
                break;
            case "Средний":
                sizePrice = 10.0m;
                break;
            case "Большой":
                sizePrice = 15.0m;
                break;
        }

        switch (cake.Flavor)
        {
            case "Шоколадный":
                flavorPrice = 2.0m;
                break;
            case "Ванильный":
                flavorPrice = 1.5m;
                break;
            case "Фруктовый":
                flavorPrice = 2.5m;
                break;
        }

        switch (cake.Glaze)
        {
            case "Шоколадная":
                glazePrice = 1.0m;
                break;
            case "Сливочная":
                glazePrice = 0.5m;
                break;
            case "Фруктовая":
                glazePrice = 1.5m;
                break;
        }

        switch (cake.Decor)
        {
            case "Цветы":
                decorPrice = 3.0m;
                break;
            case "Фигурки":
                decorPrice = 2.5m;
                break;
            case "Текст":
                decorPrice = 2.0m;
                break;
        }

        decimal totalPrice = basePrice + sizePrice + flavorPrice + glazePrice + decorPrice;
        cake.Price = totalPrice * cake.Quantity;
    }

    private void SaveOrder()
    {
        string filePath = "История заказов.txt";
        string orderInfo = $"Торт: {cake.Shape}, {cake.Size}, {cake.Flavor}, {cake.Quantity}, {cake.Glaze}, {cake.Decor}, Цена: {cake.Price}";
        File.WriteAllText(@"C:\Users\Ringer\Desktop\OrderHistory",orderInfo);
        Console.WriteLine("Order accept");
        Console.ReadKey();
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(orderInfo);
        }
    }
}

public static class Program
{
    public static void Main()
    {
        while (true)
        {
            var order = new Order();
            order.StartOrder();
            order.PlaceOrder();
        }
    }
}
