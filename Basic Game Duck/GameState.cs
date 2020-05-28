using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_Game_Duck
{
    public class GameState
    {
        private int lives = 3;
        private int score = 0;
        private Label scoreLabel;
        private Label livesLabel;

        public GameState(Label livesLabel, Label scoreLabel)
        {

            this.scoreLabel = scoreLabel;
            scoreLabel.Text = "Score " + score;

            this.livesLabel = livesLabel;
            livesLabel.Text = "Lives " + lives;

        }

        public void increaseScore()
        {
            score = score + 10;
            scoreLabel.Text = "Score " + score.ToString();
        }



        public bool isGameOver()
        {
            lives = lives - 1;
            livesLabel.Text = "Lives " + lives.ToString();

            if (lives == 0)
            {
                return true;
            }

            return false;
        }

    }
}
