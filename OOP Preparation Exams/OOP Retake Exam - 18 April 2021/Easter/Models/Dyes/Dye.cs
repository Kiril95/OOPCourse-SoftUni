using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get => this.power;

            private set
            {
                if (value < 0)
                {
                    power = 0;
                }
                else
                {
                    this.power = value;
                }
            }
        }

        public void Use()
        {
            this.Power -= 10;
        }

        public bool IsFinished() => this.Power == 0;
    }
}