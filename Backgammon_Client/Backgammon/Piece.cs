using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backgammon 
{
       

    class Piece : Position
    {
        int index;

        public PieceColor pieceColor;

        static int pieceSize=35;

        public int _index { get { return index; } set { index = value; } }


        public Piece(int index,PieceColor pieceColor,int x, int y) : base(x,y)
        {
           this. index = index;
           this.pieceColor = pieceColor;

            
        }

        public void PieceDraw(PaintEventArgs e,int x, int y,PieceColor pieceColor)
        { 
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(x, y, pieceSize, pieceSize);

            PathGradientBrush pthGrBrush = new PathGradientBrush(path);

            pthGrBrush.CenterColor = Color.FromArgb(215, 225, 255, 255);

            if (pieceColor==PieceColor.Red)
            {
                Color[] colors = { Color.FromArgb(255, 255, 255) };
                pthGrBrush.SurroundColors = colors;
                e.Graphics.FillEllipse(pthGrBrush, x, y, pieceSize, pieceSize);
            }
            else
            {
                Color[] colors = { Color.FromArgb(0, 0 , 0) };
                pthGrBrush.SurroundColors = colors;
                e.Graphics.FillEllipse(pthGrBrush, x, y, pieceSize, pieceSize);
            }
        }
    }
}
