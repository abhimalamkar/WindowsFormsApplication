using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;


namespace WindowsFormsApplication
{
    public class PlayerAnimation : Form
    {
        Bitmap[] images;

        Bitmap standingRight;

        Bitmap[] block;

        Bitmap[] combo;

        Bitmap[] standing;

        int[] place = new int[10] { 0,0,0,0,0,0,0,0,0,0 };

        //PlayerAnimation animate;
        Graphics g;
        Graphics scG;
        Bitmap btm;
        Timer t;
        public Point pos;
        double x, y, xval, yval;

        public string playerState;

      //  string[] animation = new string[5] { "walingRight", "walingLeft", "stanginRight", "stanfingLeft", "jump" };

        public PlayerAnimation(Form form)
        {
            pos = new Point(0, 0);

            images = new Bitmap[] { Properties.Resources.GokuFightStance, Properties.Resources.GokuKamahaCharge_1_2, Properties.Resources.GokuKamahaCharge_1_1_copy, Properties.Resources.GokuKamahaCharge_1_4, Properties.Resources.GokuKamahaCharge_1_4_1 };

            standingRight = new Bitmap(Properties.Resources.GokuStanceToWalk_1);

            block = new Bitmap[] { Properties.Resources.Goku_Right_BlockStepBack, Properties.Resources.Goku_Right_Block_2,Properties.Resources.Goku_Right_Block};

            combo = new Bitmap[] { Properties.Resources.Goku_Right_Combo_1_1, Properties.Resources.Goku_Right_Combo_1_2, Properties.Resources.Goku_Right_Combo_1_3, Properties.Resources .Goku_Right_Combo_1_4_copy, Properties.Resources .Goku_Right_Combo_1_5, Properties.Resources .Goku_Right_Combo_1_6, Properties.Resources .Goku_Right_Combo_1_7, Properties.Resources .Goku_Right_Combo_1_8, Properties.Resources .Goku_Right_Combo_1_9};

            standing = new Bitmap[] { Properties.Resources.Goku_Right_Standing_1_1, Properties.Resources.Goku_Right_Standing_1_2, Properties.Resources.Goku_Right_Standing_1_3, Properties.Resources.Goku_Right_Standing_1_4 };

            g = form.CreateGraphics();

            btm = new Bitmap(800, 600);

            scG = Graphics.FromImage(btm);



            t = new Timer();
            t.Interval = 500;
            t.Tick += new EventHandler(t_Tick);

        }

        public void Move(int height,int width)
        {

            x += xval;
            y += yval;

            pos.X +=10;
            pos.Y +=10;

            //if (e.KeyCode == Keys.Up)
            //{
            //    pos.Y -= 5;
            //}
            //else if (e.KeyCode == Keys.Right)
            //{
            //    pos.X += 5;
            //}
            //else if (e.KeyCode == Keys.Left)
            //{
            //    pos.X -= 5;
            //}

            //pos.Y += 20;

        }

        public void Draw(Graphics g)
        {

        }

        public Bitmap GiveNextImage()
        {
            Bitmap b = null;


            switch (playerState)
            {
                case "walkingRight":
                    b = standingRight;
                    break;

                case "block":
                    {
                        if (place[1] < block.Length)
                        {
                            b = block[place[1]++];
                        }
                        else
                        {
                            place[1] = 0;
                            b = block[place[1]++];

                        }
                    }
                    break;

                case "standing":
                    {
                        if (place[2] < block.Length)
                        {
                            b = standing[place[2]++];
                        }
                        else
                        {
                            place[2] = 0;
                            b = standing[place[2]++];

                        }
                    }
                    break;

                case "combo":
                    {
                        if (place[3] < combo.Length)
                        {
                            b = combo[place[3]++];
                        }
                        else
                        {
                            place[3] = 0;
                            b = combo[place[3]++];

                        }
                    }
                    break;


                default :

                    {
                        if (place[0] < images.Length)
                        {
                            b = images[place[0]++];
                        }
                        else
                        {
                            place[0] = 0;
                            b = images[place[0]++];

                        }
                    }
                    break;
            }
           
        
            return b;
        }

        public void t_Tick(object sender, EventArgs e)
        {
            //pos.Y += 50;

            scG.Clear(Color.Black);
            scG.DrawImage(GiveNextImage(), pos);
            g.DrawImage(btm, pos);

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PlayerAnimation
            // 
            this.ClientSize = new System.Drawing.Size(this.Height, this.Width);
            this.Name = "PlayerAnimation";
            this.ResumeLayout(false);

        }

        public int playerPhysics()
        {

            return 0;
        }
    }
}
