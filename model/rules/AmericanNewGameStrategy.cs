using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class AmericanNewGameStrategy : INewGameStrategy
    {
        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            bool a_show = true;

            a_dealer.DealCard(a_player, a_show);
            a_dealer.DealCard(a_dealer, a_show);
            a_dealer.DealCard(a_player, a_show);
            a_dealer.DealCard(a_dealer, !a_show);

            return true;
        }
    }
}
