namespace VendingApp;

public class Items
{
    public string Description { get; }
    public int Cost { get; }

    public Items(string description, int cost)
    {
        Description = description;
        Cost = cost;
    }
}