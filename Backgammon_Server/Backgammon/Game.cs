using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backgammon
{
    class Game
    {
        public Dice[] dices = new Dice[2];
        public Player[] players = new Player[2];
        public Piece[] pieces = new Piece[30];
        public Triangle[] boardTriangles = new Triangle[26]; 



        public Game(PictureBox player1Picture, PictureBox player2Picture, string player1Name, string player2Name)
        {
            players[0] = new Player(player1Name, true, PieceColor.Red, player1Picture);
            players[1] = new Player(player2Name, false, PieceColor.Black, player2Picture);
            dices[0] = new Dice();
            dices[1] = new Dice();

        }

        public void InitializeTriangles( int index, int numberOfPieces, PictureBox picture, PieceColor pieceColor)
        {
            boardTriangles[index] = new Triangle(index,numberOfPieces,picture,pieceColor);
                
        }

        public void DrawInitialPieces(PaintEventArgs e)
        {
            int pieceCounter = 0;
            for (int i = 0; i < boardTriangles.Length; i++)
            {
                if (i < 12)
                {
                    for (int j = 0; j < boardTriangles[i]._numberOfPieces; j++)
                    {
                        pieces[pieceCounter] = new Piece(i, boardTriangles[i]._pieceColor, boardTriangles[i]._picture.Location.X, boardTriangles[i]._picture.Bottom - (j + 1) * 35);
                        pieces[pieceCounter].PieceDraw(e, pieces[pieceCounter]._x, pieces[pieceCounter]._y, pieces[pieceCounter].pieceColor);
                        pieceCounter++;
                    }
                }
                else if(i<24)
                {
                    for (int j = 0; j < boardTriangles[i]._numberOfPieces; j++)
                    {
                        pieces[pieceCounter] = new Piece(i, boardTriangles[i]._pieceColor, boardTriangles[i]._picture.Location.X, boardTriangles[i]._picture.Top + (j) * 35);
                        pieces[pieceCounter].PieceDraw(e, pieces[pieceCounter]._x, pieces[pieceCounter]._y, pieces[pieceCounter].pieceColor);
                        pieceCounter++;
                    }
                }

                else
                {
                    for (int j = 0; j < boardTriangles[i]._numberOfPieces; j++)
                    {
                        pieces[pieceCounter] = new Piece(i, boardTriangles[i]._pieceColor, boardTriangles[i]._picture.Location.X + +(j) * 35, boardTriangles[i]._picture.Top);
                        pieces[pieceCounter].PieceDraw(e, pieces[pieceCounter]._x, pieces[pieceCounter]._y, pieces[pieceCounter].pieceColor);
                        pieceCounter++;
                    }

                }

                

            }
        }

       


    }
}
