namespace RPG
{
    public class SmallShield : Shield
    {

        public readonly double Accuracy = 0.7;

        private readonly Random random = new();

        public override double Strength
        {
            get
            {
                if (random.NextDouble() < Accuracy)
                {
                    return 40.0;
                }
                else
                {
                    return 0.0;
                }
            }
        }
    }
}
