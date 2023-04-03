using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

public abstract class ProductPrototype
{

    public decimal Price { get; set; }

    public ProductPrototype(decimal price)
    {
        this.Price = price;
    }

    public ProductPrototype Clone()
    {
        return (ProductPrototype)this.MemberwiseClone();
    }

}


public class Bread : ProductPrototype
{

    public Bread(decimal price) : base(price) { }

}

public class Butter : ProductPrototype
{

    public Butter(decimal price) : base(price) { }

}

public class Supermarket
{

    private Dictionary<string, ProductPrototype> _productList = new Dictionary<string, ProductPrototype>();

    public void AddProduct(string key, ProductPrototype productPrototype)
    {
        _productList.Add(key, productPrototype);
    }

    public ProductPrototype GetClonedProduct(string key)
    {
        if (_productList.ContainsKey(key))
            return _productList[key].Clone();

        else
            throw new DirectoryNotFoundException();
    }

}


class MainClass
{
    public static void Main(string[] args)
    {
        Supermarket supermarket = new Supermarket();

        supermarket.AddProduct("Bread", new Bread(9.50m));
        supermarket.AddProduct("Butter", new Butter(5.30m));

        var product = supermarket.GetClonedProduct("Bread");
        Console.WriteLine("Bread - {0}", product.Price.ToString("c2", CultureInfo.CreateSpecificCulture("pl-PL")));

        product = supermarket.GetClonedProduct("Butter");
        Console.WriteLine("Butter - {0}", product.Price.ToString("c2", CultureInfo.CreateSpecificCulture("pl-PL")));

    }
}