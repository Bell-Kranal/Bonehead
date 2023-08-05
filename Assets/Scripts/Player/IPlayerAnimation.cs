namespace Player
{
    public interface IPlayerAnimation
    {
        public Chest Chest { get; set; }
        public bool CurrentAnimationIsBlink { get; }
        public void PlayOpenChestAnimation();
    }
}