using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public class Game
    {
        private Graphics m_device;
        private Bitmap[] m_surface;
        private PictureBox m_pb;
        private Form m_form;

        public Game(Form1 form)
        {
            m_form = form;
            m_form.FormBorderStyle = FormBorderStyle.FixedSingle;

            m_pb = new PictureBox();
            m_pb.Parent = m_form;
            m_pb.Dock = DockStyle.Fill;
            m_pb.BackColor = Color.White;
            m_surface = new Bitmap[100];
            for (int i = 0; i < 100; i++)
            {
                m_surface[i] = new Bitmap(m_form.Width, m_form.Height);
               
            }

            m_pb.Image = m_surface[0];
            m_device = Graphics.FromImage(m_surface[0]);

        }

        ~Game()
        {
            m_device.Dispose();
            for(int i = 0;i<100;i++)
            m_surface[i].Dispose();
            m_pb.Dispose();
        }

        public Bitmap LoadBitmap(Bitmap filename)
        {
            Bitmap bit = null;

            try
            {

                bit = new Bitmap(filename);
            }
            catch (Exception ex) { }
            return bit;
        }

        public Graphics Device
        {
            get { return m_device; }
        }

        public void Update(int i)
        {
            m_pb.Image = m_surface[i];
        }


    }
}
