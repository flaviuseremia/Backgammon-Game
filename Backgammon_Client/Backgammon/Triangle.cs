using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backgammon
{
    class Triangle
    {
        int index;
        int numberOfPieces;
        PictureBox picture;
        PieceColor pieceColor;

        public int _index { get { return index; } set{index= value;} }
        public int _numberOfPieces { get { return numberOfPieces; } set { numberOfPieces = value; } }
        public PictureBox _picture { get { return picture; } set { picture= value; } }

        public PieceColor _pieceColor {get { return pieceColor;} set { pieceColor = value; } }

        public Triangle(int index, int numberOfPieces, PictureBox picture, PieceColor pieceColor)
        {
            this.index = index;
            this.numberOfPieces = numberOfPieces;
            this.picture = picture;
            this.pieceColor = pieceColor;
        }

    }
}
