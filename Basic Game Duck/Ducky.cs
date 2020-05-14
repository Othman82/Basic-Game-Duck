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
        public PictureBox d; //craete a global variable of type pictureBox
        private int xPos, yPos; //determines the x and y position of the duck
        private int speed;
        private string directionOfDuck = "right";
        public Boolean isDisposed = false;

        Random random = new Random();

        public Ducky(Form f)
        {
            //this is a constructor. A aconstructor has the same name as the class

            d = new PictureBox(); //create a new instance of a picturebox

            //set the appearence of D
            d.Width = 30;
            d.Height = 30;
            d.Image = Basic_Game_Duck.Properties.Resources.duck; //set image to duck image
            d.SizeMode = PictureBoxSizeMode.StretchImage;
            d.Visible = false;

            yPos = random.Next(0, 300); //random position of duck on y axis
            xPos = 0;
            d.Location = new Point(xPos, yPos); //x and y position of duck for starting
            speed = random.Next(3, 15); //random speed of the duck
            f.Controls.Add(d); //needed to add the control to form

            //end constructor

        }

        public void moveDucky (Form f)
        {
            d.Visible = true; //make duck visible
            if (directionOfDuck == "right") //check which way the duck is going
            {
                if (d.Right > f.Width) //if far right of screen change its direction
                {
                    directionOfDuck = "left";
                }

                else
                {
                    xPos = xPos + speed; //move duck
                    d.Location = new Point(xPos, yPos);
                }
            }

            if (directionOfDuck == "left") //check which way the duck is going
            {
                if (d.Right < 0) 
                {
                    directionOfDuck = "right";
                }

                else
                {
                    xPos = xPos - speed; //move duck
                    d.Location = new Point(xPos, yPos);
                }
            }





        }







    }
}
