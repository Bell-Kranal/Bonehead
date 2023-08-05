namespace Services.Pool
{
    public interface IInitializable<TParam>
    {
        public void Init(TParam param);
    }
}