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

namespace LaserDefender
{
    public partial class Form1 : Form
    {
        //make a list capable of storing enemys
        private List<Enemy> enemies = new List<Enemy>();
        private List<Bullet> bullets = new List<Bullet>();
        private GameState gameState;

        int enemyNumber = 0; // used in array to index each enemy
        string arrowDirection = "up";

        public Form1()
        {
            InitializeComponent();
            gameState = new GameState(livesLabel, scoreLabel);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Space))
            {
                bullets.Add(new Bullet(this, picBoxUp, arrowDirection)); //create a new bullet
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.bulletSound);
                player.Play();
            } 
            if (e.KeyCode.Equals(Keys.W)) //moves arrow up if we can
            {
                if (picBoxUp.Top > 0)  //check we are not at the very top of the form
                {
                    picBoxUp.Top = picBoxUp.Top - 30; //reducing top takes us closer to 0 (the absolute top)
                    picBoxUp.Image = Properties.Resources.playerShip; //switch playerShip to favour up direction
                    arrowDirection = "up";
                }
            }
            if (e.KeyCode.Equals(Keys.A)) //moves arrow left if we can
            {              
                if (picBoxUp.Left > 0)  //check we are not at the very left of the form
                {
                    picBoxUp.Left = picBoxUp.Left - 10; //reducing top takes us closer to 0 (the absolute top)
                    picBoxUp.Image = Properties.Resources.playerShipLeft; //switch playerShip to favour left direction
                    arrowDirection = "left";
                }
            }
            if (e.KeyCode.Equals(Keys.D)) //moves playerShip right if we can
            {

                if (picBoxUp.Right < this.Width)  //check we are not at the very right of the form
                {
                    picBoxUp.Left = picBoxUp.Left + 10; //reducing top takes us closer to 0 (the absolute top)
                    picBoxUp.Image = Properties.Resources.playerShipRight; //switch playerShip to favour right direction
                    arrowDirection = "right";
                }
            }
            if (e.KeyCode.Equals(Keys.S)) //moves arrow down if we can
            {
                
                if (picBoxUp.Bottom < this.Height - 10)  //check we are not at the very bottom of the form
                {
                    picBoxUp.Top = picBoxUp.Top + 10; //reducing top takes us closer to 0 (the absolute top)
                    picBoxUp.Image = Properties.Resources.playerShipDown; //switch playerShip to favour down direction
                    arrowDirection = "down";
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (enemyNumber > 9)
            {
                timer1.Enabled = false; //after 10 enemys we stop the timer so we do not get any more enemys or an error
                timer2.Enabled = true; // we enable the other timer which controls the enemys movemnt
            }
            else
            {
                enemies.Add(new Enemy(this));
                enemyNumber++;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            enemies.RemoveAll(enemy => enemy.isDisposed);

            foreach (Enemy enemy in enemies)
            {
                enemy.moveEnemy(this);  //call the moveenemyy method

                if (picBoxUp.Bounds.IntersectsWith(enemy.enemyPicture.Bounds)) //check for collision between arrow and all enemys
                {

                    if (gameState.isGameOver())
                    {
                        timer2.Enabled = false; //stop all enemys from moving

                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.loose);
                        player.Play();

                        playAgainOption();
                        return;
                    }
                    else {
                        // move player to start position
                        picBoxUp.Location = new Point(this.Width/2,this.Height/2);
                        _ = enemy.dieAsync();
                        enemyNumber--;
                    }
                }
            }
            bullets.RemoveAll(bullet => bullet.isDisposed);
            foreach (Bullet bullet in bullets)
            {
                bullet.MoveBullet(this);
                foreach (Enemy enemy in enemies)
                {
                    if (bullet.bullet.Bounds.IntersectsWith(enemy.enemyPicture.Bounds))
                    {
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.boom);
                        player.Play();

                        bullet.isDisposed = true;
                        bullet.bullet.Dispose();
                        gameState.increaseScore();
                        _ = enemy.dieAsync();
                        enemyNumber--;
                    }
                }
            }
        }
        private void playAgainOption()
        {
            string message = "Do you want to play again?";
            string title = "You Loose";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                Program.restart = false;
                this.Close();
            }
        }
    }
}
