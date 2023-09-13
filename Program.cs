namespace GR09_06222023;

internal class Program
{
	static void Main(string[] args)
	{
		ProductList products = new();
		products.Add(new Product(1, "Coca-cola", 1.8m, 500, false));
		products.Add(new Product(2, "Sprite", 1.9m, 250, true));
		products.Add(new Product(3, "Mountain dew", 4.5m, 900, false));
        products.Add(new Product(4, "XL", 3m, 900, false));
        products.Add(new Product(5, "Snickers", 1.8m, 900, false));

        //products.Insert(0, new Product(4, "Fanta", 6m, 1200, false));
        products[2] = new Product(3, "Redbull", 8m, 1200, false);
        //products[3].Id = 1;

		foreach (var product in products)
		{  
			Console.WriteLine(product);
		}

		//products.Save(@"D:\Products.txt");
	}
}