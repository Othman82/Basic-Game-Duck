using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;  //needed for the picturebox

namespace Basic_Game_Duck
{
    class Bullet
    {
        public PictureBox d; //the bullet will be inside a picture box
        private int xPos, yPos;
        public Boolean isDisposed = false;


        public Bullet(Form f, PictureBox arrow)
        {

            d = new PictureBox();
            //set the bullet's appearance
            d.Width = 3;
            d.Height = 3;
            d.BackColor = Color.Red;
            d.Visible = false;

            //set start position of the bullet

            yPos = arrow.Top + 3;
            xPos = arrow.Left + (arrow.Width / 2);

            d.Location = new Point(xPos, yPos);
            f.Controls.Add(d);
        }

        public void MoveBullet(Form f)
        {
            d.Visible = true;
            yPos = yPos - 9;

            if (yPos <0)
            {
                d.Dispose();
                isDisposed = true;
            }
            d.Location = new Point(xPos, yPos);


        }




    }
}
