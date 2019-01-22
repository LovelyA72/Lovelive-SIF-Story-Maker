using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using ImageMaker;

namespace LL_Story_Maker
{
    public partial class MainUI : Form
    {
        private string bgImage = ".\\data\\bgimage\\background0.png";
        private int gcCounter = 0;
        public MainUI()
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
            AutoGC();
            updateBg();
            pictureBox1.BackgroundImage = ImageMkr.updateSprite(comboBox2.Text, comboBox3.Text, comboBox4.Text, comboBox5.Text, comboBox6.Text, comboBox7.Text, comboBox8.Text, comboBox9.Text, comboBox10.Text, textBox2.Text, textBox1.Text,bgImage);
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
            pictureBox1.BackgroundImage = ImageMkr.updateSprite(comboBox2.Text, comboBox3.Text, comboBox4.Text, comboBox5.Text, comboBox6.Text, comboBox7.Text, comboBox8.Text, comboBox9.Text, comboBox10.Text, textBox2.Text, textBox1.Text,bgImage);
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AutoGC();
            pictureBox1.BackgroundImage = ImageMkr.updateSprite(comboBox2.Text, comboBox3.Text, comboBox4.Text, comboBox5.Text, comboBox6.Text, comboBox7.Text, comboBox8.Text, comboBox9.Text, comboBox10.Text, textBox2.Text, textBox1.Text,bgImage);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            AutoGC();
            pictureBox1.BackgroundImage = ImageMkr.updateSprite(comboBox2.Text, comboBox3.Text, comboBox4.Text, comboBox5.Text, comboBox6.Text, comboBox7.Text, comboBox8.Text, comboBox9.Text,comboBox10.Text, textBox2.Text, textBox1.Text, bgImage);
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

        private void button3_Click(object sender, EventArgs e)
        {
            Regex rxNonDigits = new Regex(@"[^\d]+");
        string time = DateTime.Now.ToShortDateString() + DateTime.Now.TimeOfDay;
            pictureBox1.BackgroundImage.Save(".\\savedata\\IMG_"+ rxNonDigits.Replace(time, "").Substring(0, rxNonDigits.Replace(time, "").Length - 5) + ".jpg", ImageFormat.Jpeg);
            
        }
    }
}
