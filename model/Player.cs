using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Player
    {
        private List<Card> m_hand = new List<Card>();
        private List<ICardDealtObserver> m_observer = new List<ICardDealtObserver>();

        public void AddToHand(Card a_card)
        {
            m_hand.Add(a_card);

            foreach (ICardDealtObserver o in m_observer) 
            {
				o.CardDealt();
			}
        }

        public void AddSubscribers(ICardDealtObserver o)
        {
            m_observer.Add(o);
        }

        public IEnumerable<Card> GetHand()
        {
            return m_hand.Cast<Card>();
        }

        public void ClearHand()
        {
            m_hand.Clear();
        }

        public void ShowHand()
        {
            foreach (Card c in GetHand())
            {
                c.Show(true);
            }
        }

        public int CalcScore()
        {
            int score = CalcBasicScore();

            if (score > 21)
            {
                foreach (Card c in GetHand())
                {
                    if (c.GetValue() == Card.Value.Ace && score > 21)
                    {
                        score -= 10;
                    }
                }
            }

            return score;
        }

        public int CalcBasicScore()
        {
            int[] cardScores = new int[(int)model.Card.Value.Count]
            {2, 3, 4, 5, 6, 7, 8, 9, 10, 10 ,10 ,10, 11};
            int score = 0;

            foreach(Card c in GetHand()) {
                if (c.GetValue() != Card.Value.Hidden)
                {
                    score += cardScores[(int)c.GetValue()];
                }
            }

            return score;
        }
    }
}
