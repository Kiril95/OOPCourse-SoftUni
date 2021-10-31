namespace WildFarm
{
    public class Vegetable : Food
    {
        public Vegetable(int quantity) : base(quantity)
        {
        }
        public override int Quantity { get; set; }
    }
}