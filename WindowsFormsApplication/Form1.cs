using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        PlayerAnimation player;
        Thread th;
        Thread th1;
        int count;
        Bitmap btm;
        Graphics g;

        public Form1()
        {
            btm = new Bitmap(800, 600);
            count = 0;

            g = this.CreateGraphics();
            this.Height = 600;
            this.Width = 800;
            InitializeComponent();
            player = new PlayerAnimation(this,btm);

            //var task = new Task(Run);
            //task.Start();
            th = new Thread(Run);
            th.Start();
        }

        //PlayerAnimation animate;
        //Graphics g;
        //Graphics scG;
        //Bitmap btm;
        //Timer t;
        
        int fps = 23;
        private void Run()
        {
          //  player.Move(this.Height, this.Width);

            this.Invalidate();

            Thread.Sleep(1000 / fps);
    
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //g = this.CreateGraphics();

            //btm = new Bitmap(110, 200);


            //scG = Graphics.FromImage(btm);

            ////t = new Timer();
            ////t.Interval = 110;
            ////t.Tick += new EventHandler(timer_Tick);


            //animate = new PlayerAnimation(new Bitmap[] { Properties.Resources._1, Properties.Resources._2, Properties.Resources._3, Properties.Resources._4, Properties.Resources._5 });
            ////game = new Game(this);

            ////image = game.LoadBitmap(Properties.Resources.Comp_4_00000);

            ////    if (image == null)
            ////{
            ////    MessageBox.Show("Error Loading");
            ////    Environment.Exit(0);
            ////}
            ////game.Device.DrawImage(image, 0, 0);

            g.DrawImage(Properties.Resources.BackGround_1_800x600, new Point(0, 0));
            
        }

        private void Form1_FormClosed(object sender, EventArgs e)
        {
            

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            count++;
            
            player.t_Tick(sender,e);

            //g.Clear(Color.Black);

            
            //pictureBox1.Image = player.GiveNextImage();

            //if (count % 5 == 0)
            //{
            //    player.playerState = "standing";
            //}
            //else
            //{
            //    player.playerState = "walkingRight";
            //}

           // player.playerState = "standing";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                player.pos.Y -= 20;
            }
            else if (e.KeyCode == Keys.Right)
            {
                player.playerState = "walk";
                player.pos.X += 5;
            }
            else if (e.KeyCode == Keys.Left)
            {
                player.pos.X -= 5;
            }
            else if (e.KeyCode == Keys.Down)
            {
                player.pos.Y += 5;
            }
            else if (e.KeyCode == Keys.Up && e.KeyCode == Keys.Right)
            {
                player.pos.Y -= 5;
                player.pos.X += 5;
            }
            else if (e.KeyCode == Keys.B)
            {
                player.playerState = "block";
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (e.KeyCode == Keys.Right)
                    player.pos.X += 5;

                player.playerState = "combo";
            }
            else
            {
                player.playerState = "walkingRight";
            }

            //player.pos.Y += 20;
        }

    }
}
