namespace RPG
{
    public class MagicWand : Weapon
    {

        public override void Attack(Player enemy)
        {
            double damage = Strength;
            enemy.Hit(damage);
        }

        public MagicWand()
        {
            Strength = 15.0;
        }

    }
}
