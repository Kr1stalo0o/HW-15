using System;
using System.Collections.Generic;
using System.Linq;

abstract class Product
{
    public string Name { get; }
    public abstract decimal Price { get; }

    protected Product(string name)
    {
        Name = name;
    }
}

class Carrot : Product
{
    private decimal BasePrice;

    public override decimal Price => BasePrice;

    public Carrot(decimal basePrice) : base("Carrot")
    {
        BasePrice = basePrice;
    }
}

class Potato : Product
{
    private decimal BasePrice;
    private int Count;

    public override decimal Price => BasePrice * Count;

    public Potato(decimal basePrice, int count) : base("Potato")
    {
        BasePrice = basePrice;
        Count = count;
    }

    public int GetCount() => Count;
}

class Cucumber : Product
{
    private decimal BasePrice;
    private int Count;

    public override decimal Price => BasePrice * Count;

    public Cucumber(decimal basePrice, int count) : base("Cucumber")
    {
        BasePrice = basePrice;
        Count = count;
    }

    public int GetCount() => Count;
}

class Tomato : Product
{
    private decimal BasePrice;

    public override decimal Price => BasePrice;

    public Tomato(decimal basePrice) : base("Tomato")
    {
        BasePrice = basePrice;
    }
}

class VegetableShop
{
    private List<Product> Products = new List<Product>();

    public void AddProducts(IEnumerable<Product> products)
    {
        Products.AddRange(products);
    }

    public void PrintProductsInfo()
    {
        decimal totalPrice = 0;

        foreach (var product in Products)
        {
            if (product is Potato potato)
            {
                Console.WriteLine($"Product: {potato.Name}, Price: {potato.Price / potato.GetCount()}, Count: {potato.GetCount()}, Total price: {potato.Price}");
            }
            else if (product is Cucumber cucumber)
            {
                Console.WriteLine($"Product: {cucumber.Name}, Price: {cucumber.Price / cucumber.GetCount()}, Count: {cucumber.GetCount()}, Total price: {cucumber.Price}");
            }
            else
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
            }

            totalPrice += product.Price;
        }

        Console.WriteLine($"Total products price: {totalPrice}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var products = new List<Product>()
        {
            new Carrot(15),
            new Potato(20, 4),
            new Cucumber(14, 2),
            new Tomato(18)
        };

        VegetableShop shop = new VegetableShop();
        shop.AddProducts(products);

        shop.PrintProductsInfo();
    }
}
