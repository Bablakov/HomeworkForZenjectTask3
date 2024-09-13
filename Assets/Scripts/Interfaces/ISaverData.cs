using Scripts.Players;

namespace Scripts.Interfaces
{
    public interface ISaverData
    {
        public Player Player { get; }

        public void SetPlayer(Player player);
    }
}