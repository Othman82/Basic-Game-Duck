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

namespace Basic_Game_Duck
{
    public partial class Form1 : Form
    { 
     //make a list capable of storing ducks
    private List<Ducky> ducks = new List<Ducky>();
    private List<Bullet> bullets = new List<Bullet>();



    int duckNumber = 0; // used in array to index each duck
    string arrowDirection = "up";
    
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode.Equals (Keys.Space))
            {
                bullets.Add(new Bullet(this, picBoxUp)); //create a new bullet
            }

            if (e.KeyCode.Equals(Keys.W))
            {
                //moves arrow up if we can

                if (picBoxUp.Top > 0)  //check we are not at the very top of the form
                {

                    picBoxUp.Top = picBoxUp.Top - 30; //reducing top takes us closer to 0 (the absolute top)
                    picBoxUp.Image = Properties.Resources.upArrow; //switch arrow graphic to favour up direction
                    arrowDirection = "up";
                   
                }

                
            }
           

            if (e.KeyCode.Equals(Keys.A))
            {
                //moves arrow left if we can

                if (picBoxUp.Left > 0)  //check we are not at the very left of the form
                {

                    picBoxUp.Left = picBoxUp.Left - 10; //reducing top takes us closer to 0 (the absolute top)
                    picBoxUp.Image = Properties.Resources.leftArrow; //switch arrow graphic to favour left direction
                    arrowDirection = "left";
                }

                
            }


            if (e.KeyCode.Equals(Keys.D))
            {
                //moves arrow right if we can

                if (picBoxUp.Right < this.Width)  //check we are not at the very right of the form
                {

                    picBoxUp.Left = picBoxUp.Left+ 10; //reducing top takes us closer to 0 (the absolute top)
                    picBoxUp.Image = Properties.Resources.rightArrow; //switch arrow graphic to favour right direction
                    arrowDirection = "right";
                }
            }

            if (e.KeyCode.Equals(Keys.S))
            {
                //moves arrow down if we can

                if (picBoxUp.Bottom < this.Height - 10)  //check we are not at the very bottom of the form
                {

                    picBoxUp.Top = picBoxUp.Top + 10; //reducing top takes us closer to 0 (the absolute top)
                    picBoxUp.Image = Properties.Resources.downArrow; //switch arrow graphic to favour down direction
                    arrowDirection = "down";
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (duckNumber > 9)
            {
                timer1.Enabled = false; //after 10 ducks we stop the timer so we do not get any more ducks or an error
                timer2.Enabled = true; // we enable the other timer which controls the ducks movemnt
            }

            else
            {
                ducks.Add(new Ducky(this));
                duckNumber++;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            ducks.RemoveAll(duck => duck.isDisposed);

            foreach (Ducky duck in ducks)
             {
                duck.moveDucky(this);  //call the moveDucky method

              if ( picBoxUp.Bounds.IntersectsWith(duck.d.Bounds)) //check for collision between arrow and all ducks

                {
                    timer2.Enabled = false; //stop all ducks from moving

                    SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Alarm01.wav"); //add sound when you lose
                    simpleSound.Play();
                    MessageBox.Show("you lose");
                    return;
                }

            }

            bullets.RemoveAll(bullet => bullet.isDisposed);
            foreach (Bullet bullet in bullets)
            {
                bullet.MoveBullet(this);

                foreach (Ducky duck in ducks)
                {
                    if (bullet.d.Bounds.IntersectsWith(duck.d.Bounds))
                    {
                        bullet.isDisposed = true;
                        bullet.d.Dispose();
                        duck.isDisposed = true;
                        duck.d.Dispose();
                    }
                }


            }



        }

    }
}
