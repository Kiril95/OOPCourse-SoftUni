namespace WildFarm
{
    public class Meat : Food
    {
        public Meat(int quantity) : base(quantity)
        {
        }
        public override int Quantity { get; set; }
    }
}