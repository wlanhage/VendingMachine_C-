namespace VendingApp;

public class User
{
    public string Name { get; }
    public List<Items> Inventory { get; }

    public User(string name)
    {
        Name = name;
        Inventory = new List<Items>();
    }

    public void AddItem(Items item)
    {
        Inventory.Add(item);
    }
}