namespace Game.Code.Services
{
    public class PlayerFactory : IService
    {
        public PlayersModel Create()
        {
            return new PlayersModel()
            {
                Data = new []
                {
                    new PlayerData()
                    {
                        Name = "Player",
                        LastAnswer = 0,
                        IsLocal = true,
                        NumberOfGuesses = 0
                    },
                    new PlayerData()
                    {
                        Name = "Ai1",
                        LastAnswer = 0,
                        IsLocal = false,
                        NumberOfGuesses = 0
                    }
                }
            };
        }
    }

    public class PlayersModel
    {
        public int Count => Data.Length;
        public PlayerData[] Data;
        public int ActivePlayerIndex;
    }

    public class PlayerData
    {
        public string Name;
        public bool IsLocal;
        public int LastAnswer;
        public int NumberOfGuesses;
    }
}