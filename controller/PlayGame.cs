using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.model;

namespace BlackJack.controller
{
    class PlayGame : ICardDealtObserver
    {
        private model.Game m_game;
        private view.IView m_view;

        public PlayGame(model.Game a_game, view.IView a_view) 
        {
            m_game = a_game;
            m_view = a_view;
            m_game.AddSubscribers(this);
        }

        public void CardDealt() 
        {
            m_view.PauseGame();
            DisplayInfo();
        }
        public bool Play()
        {
            DisplayInfo();

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }

            Event input = m_view.GetInput();

            if (input == Event.Play)
            {
                m_game.NewGame();
            }
            else if (input == Event.Hit)
            {
                m_game.Hit();
            }
            else if (input == Event.Stand)
            {
                m_game.Stand();
            }

            return input != Event.Quit;
        }

        private void DisplayInfo()
        {
            m_view.DisplayWelcomeMessage();
            
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());
        }
    }
}
