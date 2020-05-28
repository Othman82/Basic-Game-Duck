using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //needed for picture boxes to be recognised
using System.Drawing; //needed for point to be recognised

namespace Basic_Game_Duck
{
    public class Ducky
    {
        public PictureBox duck; //craete a global variable of type pictureBox
        private int xPos, yPos; //determines the x and y position of the duck
        private int speed;
        private string directionOfDuck = "right";
        public Boolean isDisposed = false;

        public string moveType = "curved";

        Random random = new Random();


        public Ducky(Form f)
        {
            //this is a constructor. A aconstructor has the same name as the class

            duck = new PictureBox(); //create a new instance of a picturebox

            //set the appearence of D
            duck.Width = 30;
            duck.Height = 30;
            duck.Image = Basic_Game_Duck.Properties.Resources.duck; //set image to duck image
            duck.SizeMode = PictureBoxSizeMode.StretchImage;
            duck.Visible = false;

            yPos = random.Next(0, 300); //random position of duck on y axis
            xPos = 0;
            duck.Location = new Point(xPos, yPos); //x and y position of duck for starting
            speed = random.Next(3, 15); //random speed of the duck
            f.Controls.Add(duck); //needed to add the control to form

            //end constructor

        }

        public void moveDucky (Form f)
        {
            duck.Visible = true; //make duck visible
            if (directionOfDuck == "right") //check which way the duck is going
            {
                if (duck.Right > f.Width) //if far right of screen change its direction
                {
                    directionOfDuck = "left";
                }

                else
                {
                    xPos = xPos + speed; //move duck
                    duck.Location = new Point(xPos, yPos);
                }
            }

            if (directionOfDuck == "left") //check which way the duck is going
            {
                if (duck.Right < 0) 
                {
                    directionOfDuck = "right";
                }

                else
                {
                    xPos = xPos - speed; //move duck
                    duck.Location = new Point(xPos, yPos);
                }
            }

         

        }

        internal void die()
        {
            // add animation for duck dying 
               this.isDisposed = true;
            this.duck.Dispose();


        }
    }
}
