using System;
using System.Collections.Generic;
using System.Text;

namespace Yugioh.Core.Entities
{
    public class GameBuilder
    {
        private IGameBuilder _Builder;
        public GameBuilder(IGameBuilder gameBuilder)
        {
            _Builder = gameBuilder;
        }
        public void CreateGame()
        {
            _Builder.SetGuid();
            _Builder.SetPlayer1();
            _Builder.SetPlayer1();
            _Builder.SetTurn();
            _Builder.SetMessage();
        }
        public Game GetGame()
        {
            return _Builder.GetGame();
        }
    }
}