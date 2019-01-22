using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageMaker
{
    public class ImageMkr
    {
        public static Image updateSprite(string char1, string char2, string char3, string char11, string char21, string char31, string char12, string char22, string char32,string text, string speaker,string bgImage)
        {
            Bitmap img = (Bitmap)updateCharactor(char1, char2, char3, char11, char21, char31, char12, char22, char32, bgImage);
            PointF textLocation = new PointF(50f, 503f);
            PointF speakerNameLocation = new PointF(85f, 455f);
            PointF textBoxLocation = new PointF(0, 488f);
            PointF charBoxLocation = new PointF(40f, 448f);
            String storyText = speaker;
            String speakerName = text;
            using (Graphics graphics = Graphics.FromImage(img))
            {
                graphics.DrawImage(Image.FromFile(".\\data\\image\\speaker-box.png"), charBoxLocation);
                graphics.DrawImage(Image.FromFile(".\\data\\image\\pink-textbox.png"), textBoxLocation);


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
            return img;
        }
        private static Image updateCharactor(string char1, string char2, string char3, string char11, string char21, string char31, string char12, string char22, string char32, string bgImage)
        {
            Bitmap img = (Bitmap)Image.FromFile(bgImage);
            string char1File = ".\\data\\fgimage\\" + char1 + "_" + char11 + "_" + char12 + ".png";
            string char2File = ".\\data\\fgimage\\" + char2 + "_" + char21 + "_" + char22 + ".png";
            string char3File = ".\\data\\fgimage\\" + char3 + "_" + char31 + "_" + char32 + ".png";
            PointF char1loc = new PointF(-200f, -70f);
            PointF char2loc = new PointF(80f, -70f);
            PointF char3loc = new PointF(350f, -70f);
            using (Graphics graphics = Graphics.FromImage(img))
            {
                try
                {
                    if ((char1 != "(none)") && (char1 != ""))
                    {
                        graphics.DrawImage(Image.FromFile(char1File), char1loc);
                    }
                    if ((char2 != "(none)") && (char2 != ""))
                    {
                        graphics.DrawImage(Image.FromFile(char2File), char2loc);
                    }
                    if ((char3 != "(none)") && (char3 != ""))
                    {
                        graphics.DrawImage(Image.FromFile(char3File), char3loc);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Current image not avilable! Please select an other image.", "Render error.");
                }
            }
            return img;
        }
    }
}
