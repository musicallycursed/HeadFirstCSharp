﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtTheRaces
{
    public class Guy
    {
        public string Name; // The guy's name
        public Bet MyBet; // An instance of Bet that has his bet
        public int Cash; // How much cash he has

        // The last two fields are the guy's GUI controls on the form
        public RadioButton MyRadioButton; // My RadioButton
        public Label MyLabel; // My Label

        public void UpdateLabels()
        {
            // Set my label to my bet's description, and the label on my
            // radio button to show my cash ("Joe has 43 bucks")
            if (MyBet!=null)
            {
                MyLabel.Text = MyBet.GetDescription();
            }
            else
            {
                MyLabel.Text = Name + " hasn't placed a bet.";
            }

            MyRadioButton.Text = Name + " has " + Cash + " bucks";
            
        }

        public void ClearBet() 
        { 
            // Reset my bet so it's zero
            MyBet = null;
            UpdateLabels();
        }

        public bool PlaceBet(int BetAmount, int DogToWin)
        { 
            // Place a new bet and store it in my bet field
            // Return true if the guy had enough money to bet
            if (Cash>=5 && Cash>=BetAmount)
            {
                MyBet = new Bet() { Amount = BetAmount, Dog = DogToWin, Bettor = this };
                UpdateLabels();
                return true;
            }
            else
            {
                return false; 
            }
        }

        public void Collect(int winner)
        { 
            // Ask my bet to pay out, clear my bet, and update my labels
            if (MyBet != null)
            {
                Cash += MyBet.PayOut(winner);
            }
            
            ClearBet();
        }
    }
}
