using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Soft17HitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            int score = a_dealer.CalcBasicScore();
            IEnumerable<Card> hand = a_dealer.GetHand();
            if (score == g_hitLimit) 
            {
                foreach(Card card in hand) 
                {
                    if (card.GetValue() == Card.Value.Ace) 
                    {
                        score -= 10;
                    }
                }
            }

            if (a_dealer.CalcScore() < g_hitLimit) { return true; }

            return score < g_hitLimit;
        }
    }
}
