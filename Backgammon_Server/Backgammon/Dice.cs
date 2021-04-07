using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backgammon
{
    public class Dice
    {
        Random rand = new Random();
        List<int> numbersList;
        ImageList dicesImages;

        public ImageList _dicesImages { get { return dicesImages; } }

        public Dice()
        {
            numbersList = new List<int>();
            dicesImages = new ImageList();
            InitializateNumbers();
            InitializateDicesImages();
        }

        //Initializare numere zaruri
        public void InitializateNumbers()
        {   

            for (int i = 1; i <=6 ; i++)
            {
                numbersList.Add(i);             
            }
        }

        // initializare poze zaruri

        public void InitializateDicesImages()
        {
            for (int i = 1; i <=6; i++)         
            {
                dicesImages.Images.Add(Image.FromFile(@"D:\C#\Proiect An 2 facultate\Backgammon_Server\Backgammon\Images\Dice" + i + ".PNG"));
            }
        }

        // Da cu zarul
        public int DiceRoll()
        {
            int randomvalue;
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);
                 randomvalue =Math.Abs(BitConverter.ToInt32(rno, 0) % 6);
            }
            return randomvalue;
        }
    }
}
