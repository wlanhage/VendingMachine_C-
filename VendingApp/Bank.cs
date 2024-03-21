namespace VendingApp;

public class Bank
{
    private Dictionary<string, int> _balances;

    public Bank()
    {
        _balances = new Dictionary<string, int>();
    }

    public int GetBalance(string name)
    {
        return _balances[name];
    }

    public void Deposit(string name, int amount)
    {
        _balances[name] += amount;
    }

    public void AddUser(string name)
    {
        if (name == "wilson")
        {
            Console.WriteLine("Välkommen tillbaka herr.Wilson");
            _balances[name] = 130;
        }
        else if (name == "kebabkungen")
        {
            Console.WriteLine("Kebabkungen! Ge mig högsta betyg!");
            _balances[name] = 420420;
        }
        else
        {
            _balances[name] = 100;
        }
    }

    public bool DeductBalance(string name, int amount)
    {
        if (_balances[name] >= amount)
        {
            _balances[name] -= amount;
            return true;
        }
        else
        {
            Console.WriteLine("För lågt saldo");
            return false;
        }
    }
}