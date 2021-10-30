﻿namespace Raiding
{
    public abstract class BaseHero
    {
        protected BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }
        public string Name { get; set; }
        public int Power { get; set; }

        public abstract void CastAbility();
    }
}