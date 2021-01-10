using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;  //needed for the picturebox

namespace LaserDefender
{
    class Bullet
    {
        public PictureBox bullet; //the bullet will be inside a picture box
        private int xPos, yPos;
        public Boolean isDisposed = false;
        string arrowDirection;

        public Bullet(Form f, PictureBox arrow, string arrowDirection)
        {

            bullet = new PictureBox();
            //set the bullet's appearance
            bullet.Width = 3;
            bullet.Height = 3;
            bullet.BackColor = Color.Red;
            bullet.Visible = false;

            this.arrowDirection = arrowDirection;

            //set start position of the bullet

            yPos = arrow.Top + 3;
            xPos = arrow.Left + (arrow.Width / 2);

            bullet.Location = new Point(xPos, yPos);
            f.Controls.Add(bullet);
        }

        public void MoveBullet(Form f)
        {
            bullet.Visible = true;
            if (arrowDirection=="up")
            {
                yPos = yPos - 9;
            }

            if (arrowDirection=="down")
            {
                yPos = yPos + 9;
            }

            if (arrowDirection=="left")
            {
                xPos = xPos - 9;
            }

            if (arrowDirection=="right")
            {
                xPos = xPos + 9;
            }

            bullet.Location = new Point(xPos, yPos);


        }




    }
}
