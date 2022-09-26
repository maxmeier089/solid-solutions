namespace RPG
{
    public abstract class Weapon
    {

        public double Strength { get; protected set; }

        public abstract void Attack(Player enemy);


    }
}
