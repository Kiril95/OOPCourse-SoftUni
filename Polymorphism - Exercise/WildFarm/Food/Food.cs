namespace WildFarm
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }
        public virtual int Quantity { get; set; }

    }
}