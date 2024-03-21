namespace VendingApp;

public class Inventory
{
    private Dictionary<string, Items> _items;

    public Inventory()
    {
        _items = new Dictionary<string, Items>();
    }

    public void AddItem(string description, int cost)
    {
            _items[description] = new Items(description, cost);
    }

    public void GetInventory()
    {
        Console.WriteLine("Korg");
        foreach (var item in _items)
        {
            Console.WriteLine($"Föremål: {item.Key}, Kostnad: {item.Value.Cost}");
        }
    }
}
