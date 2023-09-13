namespace GR09_06222023;

public sealed class Product
{
	public Product(int id, string name, decimal price, int quantity, bool discontinued)
	{
		Id = id;
		Name = name ?? throw new ArgumentNullException(nameof(name));
		Price = price;
		Quantity = quantity;
		Discontinued = discontinued;
	}

	public int Id { get; }
	public string Name { get; }
	public decimal Price { get; }
	public int Quantity { get; }
	public bool Discontinued { get; }

	public override string ToString()
	{
		return $"Id: {Id}, Name: {Name}, Price: {Price:0.00}, Quantity: {Quantity}, Discontinued: {(Discontinued ? "Yes" : "No")}";
	}
}
