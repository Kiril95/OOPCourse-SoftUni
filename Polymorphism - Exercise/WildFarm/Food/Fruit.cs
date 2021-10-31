namespace WildFarm
{
    public class Fruit : Food
    {
        public Fruit(int quantity) : base(quantity)
        {
        }
        public override int Quantity { get; set; }
    }
}