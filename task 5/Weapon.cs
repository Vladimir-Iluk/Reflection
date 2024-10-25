using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_5
{
    public enum Rarity
    {
        Common = 1,
        Uncommon = 2,
        Rare = 3,
        Epic = 5
    }

    [ClassInfo("Pesho", 3, "Used for C# Advanced Course - Reflection and Atrbites", "Petro", "Stepan")]
    internal class Weapon
    {
        public string Name { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public int Sockets { get; set; }

        private Rarity rarity;
        private Gem[] gems;

        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Vitality { get; set; }

        public Weapon(string name, int minDamage, int maxDamage, int sockets, Rarity rarity)
        {
            Name = name;
            MinDamage = minDamage * (int)rarity;
            MaxDamage = maxDamage * (int)rarity;
            Sockets = sockets;
            gems = new Gem[sockets];
            this.rarity = rarity;
        }


        public void AddGem(int index, Gem gem)
        {
            if (index >= Sockets) throw new ArgumentException("Index is our of range");
            else
            {
                gems[index] = gem;
                this.Strength += gem.Strength;
                this.Agility += gem.Agility;
                this.Vitality += gem.Vitality;

                this.MinDamage += gem.Strength * 2;
                this.MaxDamage += gem.Strength * 3;

                this.MinDamage += gem.Agility * 1;
                this.MaxDamage += gem.Agility * 4;
            }
        }

        public void RemoveGem(int index)
        {
            if (index < 0 || index >= gems.Length) throw new ArgumentException("Index is out of range");
            else
            {
                Gem gem = new Gem();
                gem = gems[index];

                gems[index] = null;

                Strength -= gem.Strength;
                Agility -= gem.Agility;
                Vitality -= gem.Vitality;

                MinDamage -= gem.Strength * 2;
                MaxDamage -= gem.Strength * 3;
                MinDamage -= gem.Agility * 1;
                MaxDamage -= gem.Agility * 4;
            }
        }

        public override string ToString()
        {
            return $"{Name}: {MinDamage}-{MaxDamage} Damage, +{Strength} Strength, +{Agility} Agility, +{Vitality} Vitality";
        }
    }
}
