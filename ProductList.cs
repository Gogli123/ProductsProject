namespace GR09_06222023;

//todo: We need to protect list from duplicating Id.
public class ProductList : List<Product>
{
    public new void Add(Product item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));

        ValidateId(item);
        base.Add(item);
    }

    public new void Insert(int index, Product item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));

        ValidateId(item);
        base.Insert(index, item);
    }

    public new Product this[int index]
    {
        get
        {
            return base[index];
        }
        set
        {
            if (base[index].Id == value.Id)
            {
                base[index] = value;
            }
            else
            {
                ValidateId(value);
                base[index] = value;
            }
        }
    }

    public void Save(string filePath)
    {
        SaveToFile(filePath, this);
    }

    public void Load(string filePath)
    {
        this.Clear();
        foreach (var product in LoadFromFile(filePath))
        {
            this.Add(product);
        }
    }

    private static void SaveToFile(string filePath, IEnumerable<Product> products)
    {
        BinaryWriter writer = new(new FileStream(filePath, FileMode.Create));

        foreach (var product in products)
        {
            writer.Write(product.Id);
            writer.Write(product.Name);
            writer.Write(product.Price);
            writer.Write(product.Quantity);
            writer.Write(product.Discontinued);
        }

        writer.Close();
    }

    private static IEnumerable<Product> LoadFromFile(string filePath)
    {
        List<Product> products = new();
        BinaryReader reader = new(new FileStream(filePath, FileMode.Open));

        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            Product product = new(
                reader.ReadInt32(),
                reader.ReadString(),
                reader.ReadDecimal(),
                reader.ReadInt32(),
                reader.ReadBoolean());

            products.Add(product);
        }
        reader.Close();

        return products;
    }

    private void ValidateId(Product item)
    {
        foreach (Product product in this)
        {
            if (product.Id == item.Id)
            {
                throw new ArgumentException($"The product with ID {product.Id} already exists.");
            }
        }
    }
}
