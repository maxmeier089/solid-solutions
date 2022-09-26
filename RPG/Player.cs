namespace RPG
{
    public class Player
    {

        public string Name { get; private set; }

        public bool IsAlive { get; internal set; } = true;

        public double Vitality { get; set; } = 100;

        public Weapon? Weapon { get; set; }

        public Shield? Shield { get; set; }


        public void Attack(Player enemy)
        {
            Console.WriteLine(Name + " attacks " + enemy.Name);

            if (Weapon != null)
            {
                Weapon.Attack(enemy);
            }
        }

        public void Hit(double damage)
        {
            Console.WriteLine(damage + " damage for " + Name);

            Vitality = Math.Max(0.0, Vitality - damage);

            if (Vitality == 0.0)
            {
                IsAlive = false;
                Console.WriteLine(Name + " is dead.");
            }
            else
            {
                Console.WriteLine("Vitality left: " + Vitality);
            }
        }

        public void Reset()
        {
            Vitality = 100.0;
            IsAlive = true;
        }

        public Player(string name)
        {
            Name = name;
        }


    }
}
