using System;
using System.Collections.Generic;
using System.Text;

namespace Yugioh.Core.Entities
{
    public interface IGameBuilder
    {
        void SetGuid();
        void SetPlayer1();
        void SetPlayer2();
        void SetTurn();
        void SetMessage();
        Game GetGame();
    }
}