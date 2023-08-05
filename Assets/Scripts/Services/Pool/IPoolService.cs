using UI.Coin.FlyingUI;

namespace Services.Pool
{
    public interface IPoolService<TPool> where TPool : IFlyingUI
    {
        public TPool Item { get; set; }
    }
}