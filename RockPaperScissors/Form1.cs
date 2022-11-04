using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

/// <summary>
/// A rock, paper, scissors game that utilizes basic methods
/// for repetitive tasks.
/// </summary>

namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        string playerChoice, cpuChoice;

        int wins = 0;
        int losses = 0;
        int ties = 0;
        int choicePause = 1000;
        int outcomePause = 3000;

        Random randGen = new Random();

        SoundPlayer jabPlayer = new SoundPlayer(Properties.Resources.jabSound);
        SoundPlayer gongPlayer = new SoundPlayer(Properties.Resources.gong);

        Image rockImage = Properties.Resources.rock168x280;
        Image paperImage = Properties.Resources.paper168x280;
        Image scissorImage = Properties.Resources.scissors168x280;
        Image winImage = Properties.Resources.winTrans;
        Image loseImage = Properties.Resources.loseTrans;
        Image tieImage = Properties.Resources.tieTrans;

        public Form1()
        {
            InitializeComponent();
        }

        private void rockButton_Click(object sender, EventArgs e)
        {
            /// TODO Set the playerchoice value, show the appropriate image,
            /// play a sound, wait for a second; repeat for the computer turn 
            playerChoice = "rock";
            playerImage.Image = rockImage;
            ComputerTurn();
            jabPlayer.Play();
            WhoWins();
        }

        private void paperButton_Click(object sender, EventArgs e)
        {
            playerChoice = "paper";
            playerImage.Image = paperImage;
            ComputerTurn();
            jabPlayer.Play();
            WhoWins();
        }

        private void scissorsButton_Click(object sender, EventArgs e)
        {
            playerChoice = "scissor";
            playerImage.Image = scissorImage;
            ComputerTurn();
            jabPlayer.Play();
            WhoWins();
        }

        void ComputerTurn()
        {
            int computerRandom;
            computerRandom = randGen.Next(1, 4);

            switch (computerRandom)
            {
                case 1:
                    cpuChoice = "rock";
                    cpuImage.Image = rockImage;
                    break;
                case 2:
                    cpuChoice = "paper";
                    cpuImage.Image = paperImage;
                    break;
                case 3:
                    cpuChoice = "scissor";
                    cpuImage.Image = scissorImage;
                    break;
            }
        }
        void WhoWins()
        {
            if (playerChoice == cpuChoice)
            {
                resultImage.Image = tieImage;
                ties++;
                tiesLabel.Text = "Ties: " + ties;
            }
            else if (playerChoice == "rock" && cpuChoice == "scissor")
            {
                resultImage.Image = winImage;
                wins++;
                winsLabel.Text = "Wins: " + wins;
            }
            else if (playerChoice == "rock" && cpuChoice == "paper")
            {
                resultImage.Image = loseImage;
                losses++;
                lossesLabel.Text = "Losses: " + losses;
            }
            else if (playerChoice == "paper" && cpuChoice == "rock")
            {
                resultImage.Image = winImage;
                wins++;
                winsLabel.Text = "Wins: " + wins;
            }
            else if (playerChoice == "paper" && cpuChoice == "scissor")
            {
                resultImage.Image = loseImage;
                losses++;
                lossesLabel.Text = "Losses: " + losses;
            }
            else if (playerChoice == "scissor" && cpuChoice == "paper")
            {
                resultImage.Image = winImage;
                wins++;
                winsLabel.Text = "Wins: " + wins;
            }
            else if (playerChoice == "scissor" && cpuChoice == "rock")
            {
                resultImage.Image = loseImage;
                losses++;
                lossesLabel.Text = "Losses: " + losses;
            }
        }
    }
}