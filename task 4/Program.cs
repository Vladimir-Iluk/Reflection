
class Program
{ 
    static void Main()
    {
        List<Weapon> weapons = new List<Weapon>();
        while (true)
        {
            Console.Write("Enter = ");
            string[] enteredInfromation = Console.ReadLine().Split(';');
            if (enteredInfromation[0] == "end") break;

            if (enteredInfromation[0] == "Create")
            {
                string[] rarityAndtype = enteredInfromation[1].Split();

                if (Enum.TryParse(rarityAndtype[0], out Rarity rarity))
                {
                    string weaponName = rarityAndtype[1];
                    Weapon weapon = null;
                    switch (weaponName)
                    {
                        case "Axe":
                            weapon = new Weapon(enteredInfromation[2], 5, 10, 4, rarity);
                            break;
                        case "Sword":
                            weapon = new Weapon(enteredInfromation[2], 4, 6, 3, rarity);
                            break;
                        case "Knife":
                            weapon = new Weapon(enteredInfromation[2], 3, 4, 2, rarity);
                            break;
                    }

                    if (weapon != null)
                    {
                        weapons.Add(weapon);
                    }
                    else throw new ArgumentException("Invalid type of weapon or rarity!");
                }
            }

            if (enteredInfromation[0] == "Add")
            {
                foreach(Weapon weapon in weapons)
                {
                    if(weapon.Name == enteredInfromation[1])
                    {
                        string[] gemInformation = enteredInfromation[3].Split();
                        int Strength = 0, Agility = 0, Vitality = 0;

                        if (gemInformation[1] == "Ruby")
                        {
                            Strength = 7;
                            Agility = 2;
                            Vitality = 5;
                        }
                        else if (gemInformation[1] == "Emerald")
                        {
                            Strength = 1;
                            Agility = 4;
                            Vitality = 9;
                        }
                        else if (gemInformation[1] == "Amethyst")
                        {
                            Strength = 2;
                            Agility = 8;
                            Vitality = 4;
                        }

                        Gem gem = new Gem(gemInformation[0], Strength, Agility, Vitality);

                        weapon.AddGem(int.Parse(enteredInfromation[2]), gem);
                    }
                }
            }

            if (enteredInfromation[0] == "Remove")
            {
                foreach (Weapon weapon in weapons)
                {
                    if (weapon.Name == enteredInfromation[1]) weapon.RemoveGem(int.Parse(enteredInfromation[2]));
                }
            }

            if (enteredInfromation[0] == "Print")
            {
                foreach (Weapon weapon in weapons)
                {
                    if (weapon.Name == enteredInfromation[1]) Console.WriteLine(weapon);
                }
            }
        }
    }
}