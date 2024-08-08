using System;
using Game.Code.Models;

namespace Game.Code.Services
{
    public class ModelProvider
    {
        public readonly GameStateModel GameStateModel;
        public readonly InputModel InputModel;
        public readonly PlayerModel PlayerModel;
        
        public ModelProvider(Random random, int max)
        {
            GameStateModel = new GameStateModel(random, max);
            InputModel = new InputModel(max);
            PlayerModel = new DataFactory().CreatePlayers();
        }
    }
}