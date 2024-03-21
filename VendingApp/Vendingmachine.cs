namespace VendingApp;
using System;


public class Vendingmachine
{
    
    private Stack<Items> _storage = new Stack<Items>();
    public string Name { get; }

    private Inventory inventory = new Inventory();
    public Vendingmachine(string description)
    {
        Name = description;
    }
    public bool AddItem(Items item)
    {
        try
        {
            _storage.Push(item);
            return true;
        }
        catch
        {
            Console.WriteLine("failed");
            return false;
        }
    }
    
    public void ListItems()
    {
        if (_storage.Count > 0)
        {
            foreach (var items in _storage)
            {
                Console.WriteLine(items.Description);
            }
        }
        else
        {
            Console.WriteLine("tomt somfan");
        }
    }

    public IEnumerable<Items> GetItems() // Gör att det går att iterera över varje item
    {
        return _storage;
    }
    
    public void Purchase(string itemName, User user, Bank bank)
    {
        Items selectedItem = GetItems().FirstOrDefault(item => item.Description.Equals(itemName, StringComparison.OrdinalIgnoreCase)); // Itererar över varje item och letar efter första item som har samma namn som det användaren söker, och sparar det i selectedItem.

        if (selectedItem != null)
        {
            if (bank.GetBalance(user.Name) >= selectedItem.Cost)
            {
                bank.DeductBalance(user.Name, selectedItem.Cost);
                user.AddItem(selectedItem);
                Console.WriteLine($"Köpet av {selectedItem.Description} gick igenom!");
                inventory.AddItem(selectedItem.Description, selectedItem.Cost);
                /*Console.WriteLine($"En {selectedItem.Description}{selectedItem.Cost}$ lades till i din korg");*/
                /*inventory.AddItem(selectedItem.Description, selectedItem.Cost);*/

            }
            else
            {
                Console.WriteLine("Inte tillräckligt med pengar för detta!");
            }
        }
        else
        {
            Console.WriteLine("Föremålet inte tillgängligt");
        }
    }
}