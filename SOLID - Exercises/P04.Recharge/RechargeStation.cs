namespace P04.Recharge
{
    public class RechargeStation
    {
        public void Recharge(IRechargeable recharge)
        {
            recharge.Recharge();
        }
    }
}