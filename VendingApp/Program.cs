using VendingApp;

        var machine = new Vendingmachine("Wilson's shop");

        var inventory = new Inventory();

        machine.AddItem(new Items("coca cola", 10));
        machine.AddItem(new Items("fanta", 10));
        machine.AddItem(new Items("snickers", 8));
        machine.AddItem(new Items("kebab", 35));

        Console.WriteLine($"Välkommen till {machine.Name}, vad heter du?");
        var userName = Console.ReadLine();
        var user = new User(userName);

        var bank = new Bank();
        bank.AddUser(user.Name);

        Console.WriteLine($"{userName}, du har nu {bank.GetBalance(user.Name)} kronor");

        Console.WriteLine($"---- {machine.Name} ----");

        while (true)
        {
            Console.WriteLine("Välj ett option");
            Console.WriteLine("Se plånbok - plånbok");
            Console.WriteLine("Se utbud - shop");
            /*Console.WriteLine("See dina köpta föremål - korg");*/
            Console.WriteLine("Köpa något - köp");
            Console.Write("Ange ditt val: ");

            var choice = Console.ReadLine().Trim().ToLower();

            switch (choice)
            {
                case "plånbok":
                    Console.WriteLine("Du valde plånbok");
                    Console.WriteLine($"Plånbok: {bank.GetBalance(user.Name)}");
                    break;
                case "shop":
                    Console.WriteLine("Du valde att se shoppen");
                    machine.ListItems();
                    break;
                /*case "korg":
                    Console.WriteLine("Du valde att se din korg");
                    inventory.GetInventory();
                    break;*/
                case "köp":
                    while (true)
                    {
                        Console.WriteLine($"Vad skulle du vilja köpa?");
                        var selectedItem = Console.ReadLine().ToLower();

                        machine.Purchase(selectedItem, user, bank);
                        Console.WriteLine($"Du har nu {bank.GetBalance(user.Name)} kronor kvar.");

                        Console.WriteLine("Vill du köpa något annat? (ja/nej)");
                        var finalAnswer = Console.ReadLine().ToLower();

                        if (finalAnswer.ToLower() != "ja")
                        {
                            Console.WriteLine("Ha d, välkommen åter");
                            break;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Obenfintligt alternativ");
                    break;
            }
        }