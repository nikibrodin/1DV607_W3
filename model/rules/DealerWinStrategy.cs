using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class DealerWinStrategy : IWinStrategy
    {
        private const int g_maxScore = 21;

        public bool IsDealerWinner(model.Dealer a_dealer, model.Player a_player)
        {
            return a_dealer.CalcScore() >= a_player.CalcScore();
        }
    }
}
