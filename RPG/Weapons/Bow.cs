namespace RPG
{
    public class Bow : Weapon
    {

        public readonly double Accuracy = 0.6;

        private readonly Random random = new();

        public override void Attack(Player enemy)
        {
            if (random.NextDouble() < Accuracy)
            {
                double defense = enemy.Shield != null ? enemy.Shield.Strength : 0.0;
                double damage = Math.Max(Strength - defense, 0.0);
                enemy.Hit(damage);
            }
        }

        public Bow()
        {
            Strength = 50.0;
        }

    }
}
