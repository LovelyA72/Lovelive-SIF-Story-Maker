using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LL_Story_Maker
{
    public partial class Form1 : Form
    {
        private string bgImage = ".\\data\\bgimage\\background0.png";
        private int gcCounter = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void AutoGC() {
            gcCounter++;
            if (gcCounter > 30) {
                System.GC.Collect();
                gcCounter = 0;
            }
        }

        private string updateBg() {
            bgImage = ".\\data\\bgimage\\background" + comboBox1.SelectedIndex + ".png";
            return bgImage;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateBg();
            pictureBox1.Image = updateSprite();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
            comboBox9.SelectedIndex = 0;
            comboBox10.SelectedIndex = 0;
            pictureBox1.Image = updateSprite();
        }
        private Image updateSprite() {
            Bitmap img = (Bitmap)updateCharactor();
            PointF textLocation = new PointF(50f, 510f);
            PointF speakerNameLocation = new PointF(85f, 461f);
            PointF textBoxLocation = new PointF(0, 496f);
            PointF charBoxLocation = new PointF(40f, 455f);
            String storyText = textBox1.Text;
            String speakerName = textBox2.Text;
            using (Graphics graphics = Graphics.FromImage(img))
            {
                graphics.DrawImage(Image.FromFile(".\\data\\image\\speaker-box.png"), charBoxLocation);
                graphics.DrawImage(Image.FromFile(".\\data\\image\\pink-textbox.png"),textBoxLocation);

               
                using (Font arialFont = new Font("Microsoft YaHei UI", 12))
                {
                    //graphics.DrawString(firstText, arialFont, Brushes.Blue, firstLocation);
                    graphics.DrawString(storyText, arialFont, Brushes.White, textLocation);
                }
                using (Font arialFont = new Font("Microsoft YaHei UI", 10))
                {
                    graphics.DrawString(speakerName, arialFont, Brushes.White, speakerNameLocation);
                }
            }
            return (Image)img;
        }
        private Image updateCharactor() {
            AutoGC();
            Bitmap img = (Bitmap)Image.FromFile(bgImage);
            string char1File = ".\\data\\fgimage\\"+comboBox2.Text+"_" + comboBox5.Text + "_" + comboBox8.Text + ".png";
            string char2File = ".\\data\\fgimage\\" + comboBox3.Text + "_" + comboBox6.Text + "_" + comboBox9.Text + ".png";
            string char3File = ".\\data\\fgimage\\" + comboBox4.Text + "_" + comboBox7.Text + "_" + comboBox10.Text + ".png";
            PointF char1loc = new PointF(-200f, -70f);
            PointF char2loc = new PointF(80f, -70f);
            PointF char3loc = new PointF(350f, -70f);
            using (Graphics graphics = Graphics.FromImage(img))
            {
                try {
                    if ((comboBox2.Text != "(none)") && (comboBox2.Text != ""))
                    {
                        graphics.DrawImage(Image.FromFile(char1File), char1loc);
                    }
                    if ((comboBox3.Text != "(none)") && (comboBox2.Text != ""))
                    {
                        graphics.DrawImage(Image.FromFile(char2File), char2loc);
                    }
                    if ((comboBox4.Text != "(none)") && (comboBox2.Text != ""))
                    {
                        graphics.DrawImage(Image.FromFile(char3File), char3loc);
                    }
                } catch(Exception e){
                    MessageBox.Show("Current image not avilable! Please select an other image.","Render error.");
                }
            }
            return img;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = updateSprite();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = updateSprite();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            System.GC.Collect();
        }
    }
}
