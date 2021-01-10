using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //needed for picture boxes to be recognised
using System.Drawing; //needed for point to be recognised

namespace LaserDefender
{
    public class Enemy
    {
        public PictureBox enemyPicture; //craete a global variable of type pictureBox
        private int xPos, yPos; //determines the x and y position of the enemy
        private int speed;
        private string directionOfEnemy;
        public bool isDisposed = false;


        Random random = new Random();


        public Enemy(Form f)
        {
            //this is a constructor. A aconstructor has the same name as the class

            enemyPicture = new PictureBox(); //create a new instance of a picturebox

            //set the appearence of
            int square = random.Next(30, 60);
            enemyPicture.Width = square;
            enemyPicture.Height = square;



            enemyPicture.Image = LaserDefender.Properties.Resources.enemyShip; //set image to enemy image
            enemyPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            enemyPicture.Visible = false;

            int randomEnemy = random.Next(2);
            if (randomEnemy == 1)
            {
                directionOfEnemy = "down";
                xPos = random.Next(0, f.Width); //random position of enemy on y axis
                yPos = 0;
            } else
            {
                directionOfEnemy = "right";
                yPos = random.Next(0, f.Height); //random position of enemy on y axis
                xPos = 0;
            }



            enemyPicture.Location = new Point(xPos, yPos); //x and y position of enemy for starting
            speed = random.Next(3, 15); //random speed of the enemy
            f.Controls.Add(enemyPicture); //needed to add the control to form

            //end constructor

        }

        public void moveEnemy(Form f)
        {
            enemyPicture.Visible = true; //make enemy visible

            if (directionOfEnemy == "up" || directionOfEnemy =="down")
            {
                moveEnemyUpDown(f);
            }

            if (directionOfEnemy == "right") //check which way the enemy is going
            {
                if (enemyPicture.Right > f.Width) //if far right of screen change its direction
                {
                    directionOfEnemy = "left";
                }

                else
                {
                    xPos = xPos + speed; //move enemy
                    enemyPicture.Location = new Point(xPos, yPos);
                }
            }

            if (directionOfEnemy == "left") //check which way the enemy is going
            {
                if (enemyPicture.Right < 0)
                {
                    directionOfEnemy = "right";
                }

                else
                {
                    xPos = xPos - speed; //move enemy
                    enemyPicture.Location = new Point(xPos, yPos);
                }
            }



        }

        private void moveEnemyUpDown(Form f)
        {
            if (directionOfEnemy=="up")
            {
                if (enemyPicture.Top < 0) //if far right of screen change its direction
                {
                    directionOfEnemy = "down";
                }
                else
                {
                    yPos = yPos - speed; //move enemy
                    enemyPicture.Location = new Point(xPos, yPos);
                }

            }

            if (directionOfEnemy == "down")
            {
                if (enemyPicture.Bottom > f.Height) //if far right of screen change its direction
                {
                    directionOfEnemy = "up";
                }
                else
                {
                    yPos = yPos + speed; //move enemy
                    enemyPicture.Location = new Point(xPos, yPos);
                }

            }
        }

        internal async Task dieAsync()
        {
            enemyPicture.Image = LaserDefender.Properties.Resources.enemyShipDamaged;
            await Task.Delay(300);
            // add animation for enemy dying 
            this.isDisposed = true;
            this.enemyPicture.Dispose();
        }
    }
}
