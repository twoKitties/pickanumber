namespace Game.Code.Models
{
    public class PlayerModel
    {
        public int Count => Data.Length;
        public PlayerData[] Data;
        public int ActivePlayerIndex;
    }
}