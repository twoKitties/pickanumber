using Game.Code.Models;

namespace Game.Code.Services
{
    public class DataFactory
    {
        public PlayerModel CreatePlayers()
        {
            return new PlayerModel()
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
}