namespace RPG
{
    public class Sword : Weapon
    {

        public override void Attack(Player enemy)
        {
            double defense = enemy.Shield != null ? enemy.Shield.Strength : 0.0;
            double damage = Math.Max(Strength - defense, 0.0);
            enemy.Hit(damage);
        }

        public Sword()
        {
            Strength = 35.0;
        }

    }
}
