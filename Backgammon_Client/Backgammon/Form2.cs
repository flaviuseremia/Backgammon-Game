namespace Backgammon
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Net.Sockets;
    using System.Threading;
    using System.Windows.Forms;

    public partial class fGame : Form
    {
        public TcpClient client;

        public NetworkStream clientStream;

        public bool ascult;

        public fGame clientForm;

        public Thread t;

        public string imagePath;

        internal Game game;

        internal int diceNumber1, diceNumber2, diceMoves = 2, nextDiceToMove;

        internal static int clickContor = 0;

        internal int clickedTriangleSaved;

        internal int clickedTriangle;

        internal int blackPieces = 15, redPieces = 15;

        public fGame(PictureBox player2Picture, string player2Name, string imgPath)
        {
            InitializeComponent();
            picPlayer2.BackgroundImage = player2Picture.BackgroundImage;
            lPlayer2Name.Text = player2Name;
            game = new Game(picPlayer1, player2Picture, lPlayer1Name.Text, player2Name);
            SetTriangles();
            imagePath = imgPath;
            clientForm = this;
        }

        private void Asculta_client()
        {
            int i;

            StreamReader citire = new StreamReader(clientStream);
            Byte[] bytes = new Byte[256];
            string dataRecived = null;
            while (ascult)
            {
                i = clientStream.Read(bytes, 0, bytes.Length);
                dataRecived = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                MethodInvoker m = new MethodInvoker(() => clientForm.textBox1.Text += ("client: " + dataRecived + Environment.NewLine));
                clientForm.textBox1.Invoke(m);
                string[] words = dataRecived.Split('&');
                if (words[0] == "-100")
                {
                    m = new MethodInvoker(() => clientForm.lPlayer1Name.Text = (words[1]));
                    clientForm.lPlayer1Name.Invoke(m);
                    picPlayer1.BackgroundImage = new Bitmap(words[2]);
                }
                if (words[0] == "1")
                {
                    pictureBoxDice1.BackgroundImage = game.dices[0]._dicesImages.Images[Int32.Parse(words[1])];
                    pictureBoxDice2.BackgroundImage = game.dices[1]._dicesImages.Images[Int32.Parse(words[2])];
                }
                if (words[0] == "2")
                {
                    clickedTriangleSaved = Int32.Parse(words[1]);
                    clickedTriangle = Int32.Parse(words[2]);
                    game.boardTriangles[clickedTriangleSaved]._numberOfPieces--;
                    if (game.boardTriangles[clickedTriangle]._numberOfPieces == 0)
                    {
                        game.boardTriangles[clickedTriangle]._pieceColor = game.boardTriangles[clickedTriangleSaved]._pieceColor;
                        game.boardTriangles[clickedTriangle]._numberOfPieces++;
                    }
                    else if (game.boardTriangles[clickedTriangle]._numberOfPieces == 1 && game.boardTriangles[clickedTriangle]._pieceColor != game.boardTriangles[clickedTriangleSaved]._pieceColor)
                    {
                        if (game.boardTriangles[clickedTriangle]._pieceColor == PieceColor.Red)
                            game.boardTriangles[25]._numberOfPieces++;
                        else
                            game.boardTriangles[24]._numberOfPieces++;

                        game.boardTriangles[clickedTriangle]._pieceColor = game.boardTriangles[clickedTriangleSaved]._pieceColor;
                    }
                    else
                        game.boardTriangles[clickedTriangle]._numberOfPieces++;

                    m = new MethodInvoker(() => panelTable.Refresh());
                    clientForm.panelTable.Invoke(m);
                }
                if (words[0] == "3")
                {
                    ChangeTurns();
                }
                if (words[0] == "4")
                {
                    clickedTriangleSaved = Int32.Parse(words[1]);
                    redPieces = Int32.Parse(words[2]);
                    blackPieces = Int32.Parse(words[3]);
                    game.boardTriangles[clickedTriangleSaved]._numberOfPieces--;
                    m = new MethodInvoker(() => panelTable.Refresh());
                    clientForm.panelTable.Invoke(m);
                    if (redPieces == 0)
                    {
                        MessageBox.Show(lPlayer1Name + "a castigat!");
                        this.Close();
                    }
                    if (blackPieces == 0)
                    {
                        MessageBox.Show(lPlayer2Name + " a castigat!");
                        this.Close();
                    }
                }
            }
        }

        private void btnSend_Click_1(object sender, EventArgs e)
        {
            try
            {

                StreamWriter scriere = new StreamWriter(clientStream);
                scriere.AutoFlush = true;
                scriere.WriteLine(tbDate.Text);
                textBox1.Text += "Client: " + tbDate.Text + Environment.NewLine;
                tbDate.Clear();
            }
            finally
            {

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ascult = false;
            t.Abort();
            clientStream.Close();
            client.Close();
        }

        private void tbDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnSend_Click_1(sender, e);
            }
        }

        private void btnConect_Click_1(object sender, EventArgs e)
        {
            if (btnConect.Text == "Connect")
            {
                if (tbAddress.Text.Length > 0)
                {
                    client = new TcpClient(tbAddress.Text, 3000);
                    ascult = true;
                    t = new Thread(new ThreadStart(Asculta_client));
                    t.Start();
                    string message = "-100&" + lPlayer2Name.Text + "&" + imagePath;

                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                    clientStream = client.GetStream();

                    clientStream.Write(data, 0, data.Length);


                    tbDate.Enabled = true;
                    btnSend.Enabled = true;
                    label1.Visible = false;
                    tbAddress.Visible = false;
                    btnConect.Text = "Disconect";

                    StreamWriter scriere = new StreamWriter(clientStream);
                    scriere.AutoFlush = true;
                    scriere.WriteLine("Client conectat");
                    textBox1.Text += "Client: Client conectat" + Environment.NewLine;



                }
                else
                {
                    MessageBox.Show("Specificati adresa de IP");
                }
            }
            else
            {
                ascult = false;
                t.Abort();
                StreamWriter scriere = new StreamWriter(clientStream);
                scriere.AutoFlush = true;
                scriere.WriteLine("#Gata");
            }
        }

        public void SendMessageToClient(string text)
        {
            Byte[] name = System.Text.Encoding.ASCII.GetBytes(text);
            clientStream.Write(name, 0, name.Length);
        }

        private void btnPlayer2Dice_Click(object sender, EventArgs e)
        {
            diceNumber1 = game.dices[0].DiceRoll();
            pictureBoxDice1.BackgroundImage = game.dices[0]._dicesImages.Images[diceNumber1];
            diceNumber2 = game.dices[1].DiceRoll();
            pictureBoxDice2.BackgroundImage = game.dices[1]._dicesImages.Images[diceNumber2];
            string diceRolled = "1&" + diceNumber1.ToString() + "&" + diceNumber2.ToString();
            SendMessageToClient(diceRolled);
            diceNumber1++;
            diceNumber2++;
            if (diceNumber1 == diceNumber2)
                diceMoves = 4;
            btnPlayer2Dice.Visible = false;

            for (int i = 0; i < 30; i++)
                if (game.pieces[i].pieceColor == PieceColor.Black)
                    if (game.pieces[i]._index + diceNumber1 < 24 && game.pieces[i]._index + diceNumber2 < 24)
                        if (game.boardTriangles[game.pieces[i]._index + diceNumber1]._numberOfPieces < 2 || game.boardTriangles[game.pieces[i]._index + diceNumber2]._numberOfPieces < 2)
                        {
                            game.players[1]._turn = true;
                            break;
                        }
            if (game.players[1]._turn != true)
            {
                btnPlayer1Dice.Visible = true;
                game.players[0]._turn = true;
            }
        }

        private void btnPlayer1Dice_Click(object sender, EventArgs e)
        {
            diceNumber1 = game.dices[0].DiceRoll();
            pictureBoxDice1.BackgroundImage = game.dices[0]._dicesImages.Images[diceNumber1];
            diceNumber2 = game.dices[1].DiceRoll();
            pictureBoxDice2.BackgroundImage = game.dices[1]._dicesImages.Images[diceNumber2];
            diceNumber1++;
            diceNumber2++;
            if (diceNumber1 == diceNumber2)
                diceMoves = 4;
            btnPlayer1Dice.Visible = false;

            for (int i = 0; i < 30; i++)
            {
                if (game.pieces[i].pieceColor == PieceColor.Red)
                    if (game.pieces[i]._index - diceNumber1 > 0 && game.pieces[i]._index - diceNumber2 > 0)
                        if (game.boardTriangles[game.pieces[i]._index - diceNumber1]._numberOfPieces < 2 || game.boardTriangles[game.pieces[i]._index - diceNumber2]._numberOfPieces < 2)
                        {
                            game.players[0]._turn = true;
                            break;
                        }
            }
            if (game.players[0]._turn != true)
            {
                btnPlayer2Dice.Visible = true;
                game.players[1]._turn = true;
            }
        }

        private void panelTable_Paint(object sender, PaintEventArgs e)
        {
            game.DrawInitialPieces(e);
        }

        public void SetTriangles()
        {

            for (int i = 0; i < game.boardTriangles.Length; i++)
            {
                PictureBox pictureBoxMatch = this.Controls.Find("pictureBox" + i, true)[0] as PictureBox;

                PieceColor pieceColor = SetColor(i);
                int trianglePieces = SetPieces(i);
                game.InitializeTriangles(i, trianglePieces, pictureBoxMatch, pieceColor);
                game.boardTriangles[i]._picture.Click += new EventHandler(this.TrianglePictureBox_Click);
            }
        }

        private int SetPieces(int i)
        {
            if (i == 0 || i == 23)
                return 2;
            else
                if (i == 5 || i == 18 || i == 11 || i == 12)
                return 5;
            else
                if (i == 7 || i == 16)
                return 3;
            else
                return 0;
        }

        private PieceColor SetColor(int i)
        {
            if (i == 5 || i == 7 || i == 12 || i == 23 || i == 25)
                return PieceColor.Red;
            else
                if (i == 18 || i == 16 || i == 11 || i == 0 || i == 24)
                return PieceColor.Black;
            else
                return PieceColor.None;
        }

        private void TrianglePictureBox_Click(object sender, EventArgs e)
        {
            FirstClick(sender);


            clickedTriangle = FindClickedTriangle((PictureBox)sender);

            SecondClick();
        }

        private void SecondClick()
        {
            if (clickContor > 0 && clickedTriangleSaved != clickedTriangle && clickedTriangle != 24 && clickedTriangle != 25)
            {
                if (game.boardTriangles[clickedTriangleSaved]._pieceColor == PieceColor.Red && clickedTriangleSaved > clickedTriangle)
                {
                    if (RedPieceIsMovedCorect() == true)
                        CheckPiecesOnTriangle();
                }
                else if (game.boardTriangles[clickedTriangleSaved]._pieceColor == PieceColor.Black && clickedTriangleSaved < clickedTriangle)
                {
                    if (BlackPieceIsMovedCorect() == true)
                        CheckPiecesOnTriangle();
                }
                else if (clickedTriangleSaved == 24)
                    if (BlackPieceIsMovedCorect() == true)
                        CheckPiecesOnTriangle();
                panelTable.Refresh();

            }
        }

        private bool BlackPieceIsMovedCorect()
        {
            if (game.boardTriangles[24]._numberOfPieces != 0)
            {
                if (diceNumber1 == clickedTriangle + 1 && diceMoves == 2)
                {
                    nextDiceToMove = diceNumber2;
                    return true;
                }
                else
                if (diceNumber2 == clickedTriangle + 1 && diceMoves == 2)
                {
                    nextDiceToMove = diceNumber1;

                    return true;
                }
                else if (diceMoves == 1 && nextDiceToMove == clickedTriangle + 1)
                {
                    return true;
                }
            }
            else if (diceNumber1 == diceNumber2 && clickedTriangleSaved + diceNumber1 == clickedTriangle)
            {
                return true;
            }


            else if (clickedTriangleSaved + diceNumber1 == clickedTriangle && diceMoves == 2)
            {
                nextDiceToMove = diceNumber2;

                return true;
            }
            else if (clickedTriangleSaved + diceNumber2 == clickedTriangle && diceMoves == 2)
            {
                nextDiceToMove = diceNumber1;

                return true;
            }
            else if (diceMoves == 1 && clickedTriangleSaved + nextDiceToMove == clickedTriangle)
            {
                return true;
            }
            return false;
        }

        private bool RedPieceIsMovedCorect()
        {
            if (game.boardTriangles[25]._numberOfPieces != 0)
            {
                if (24 - diceNumber1 == clickedTriangle && diceMoves == 2)
                {
                    nextDiceToMove = diceNumber2;
                    return true;
                }
                else
                if (24 - diceNumber2 == clickedTriangle && diceMoves == 2)
                {
                    nextDiceToMove = diceNumber1;

                    return true;
                }
                else if (diceMoves == 1 && 24 - nextDiceToMove == clickedTriangle)
                {
                    return true;
                }
            }
            else if (diceNumber1 == diceNumber2 && clickedTriangleSaved - diceNumber1 == clickedTriangle)
            {
                return true;
            }

            else if (clickedTriangleSaved - diceNumber1 == clickedTriangle && diceMoves == 2)
            {
                nextDiceToMove = diceNumber2;
                return true;
            }
            else if (clickedTriangleSaved - diceNumber2 == clickedTriangle && diceMoves == 2)
            {
                nextDiceToMove = diceNumber1;
                return true;
            }
            else if (diceMoves == 1 && clickedTriangleSaved - nextDiceToMove == clickedTriangle)
            {
                return true;
            }
            return false;
        }

        private void CheckPiecesOnTriangle()
        {
            if (game.boardTriangles[clickedTriangle]._numberOfPieces == 0)
            {
                ModifyNumberOfPieces();
                game.boardTriangles[clickedTriangle]._pieceColor = game.boardTriangles[clickedTriangleSaved]._pieceColor;
            }
            else if (game.boardTriangles[clickedTriangle]._numberOfPieces == 1 && game.boardTriangles[clickedTriangle]._pieceColor == game.boardTriangles[clickedTriangleSaved]._pieceColor)
            {
                ModifyNumberOfPieces();

            }
            else if (game.boardTriangles[clickedTriangle]._numberOfPieces == 1 && game.boardTriangles[clickedTriangle]._pieceColor != game.boardTriangles[clickedTriangleSaved]._pieceColor)
            {
                ColorLabelWhite();
                clickContor = 0;
                game.boardTriangles[clickedTriangleSaved]._numberOfPieces--;
                if (game.boardTriangles[clickedTriangle]._pieceColor == PieceColor.Red)
                    game.boardTriangles[25]._numberOfPieces++;
                else
                    game.boardTriangles[24]._numberOfPieces++;
                game.boardTriangles[clickedTriangle]._pieceColor = game.boardTriangles[clickedTriangleSaved]._pieceColor;
                diceMoves--;
                if (diceMoves == 0)
                {
                    diceMoves = 2;
                    ChangeTurns();
                }
                SendMessageToClient("2&" + clickedTriangleSaved.ToString() + "&" + clickedTriangle.ToString());
            }
            else if (game.boardTriangles[clickedTriangle]._pieceColor == game.boardTriangles[clickedTriangleSaved]._pieceColor)
            {
                ModifyNumberOfPieces();
            }
        }

        private void ModifyNumberOfPieces()
        {
            clickContor = 0;
            game.boardTriangles[clickedTriangleSaved]._numberOfPieces--;
            game.boardTriangles[clickedTriangle]._numberOfPieces++;
            SendMessageToClient("2&" + clickedTriangleSaved.ToString() + "&" + clickedTriangle.ToString());
            ColorLabelWhite();
            diceMoves--;
            if (diceMoves == 0)
            {
                diceMoves = 2;
                ChangeTurns();
            }
        }

        private void ChangeTurns()
        {
            if (game.players[0]._turn == true)
            {
                game.players[0]._turn = false;
                game.players[1]._turn = true;
                MethodInvoker m = new MethodInvoker(() => clientForm.btnPlayer2Dice.Visible = true);
                clientForm.btnPlayer2Dice.Invoke(m);

            }
            else
            {
                game.players[0]._turn = true;
                game.players[1]._turn = false;
                MethodInvoker m = new MethodInvoker(() => clientForm.btnPlayer2Dice.Visible = false);
                clientForm.btnPlayer2Dice.Invoke(m);
                SendMessageToClient("3&");
            }
        }

        private void CheckTriangleColor()
        {
            if (game.boardTriangles[clickedTriangle]._pieceColor == PieceColor.None)
                game.boardTriangles[clickedTriangle]._pieceColor = game.boardTriangles[clickedTriangleSaved]._pieceColor;
        }

        private void FirstClick(object sender)
        {
            if (clickContor == 0)
            {
                clickedTriangleSaved = FindClickedTriangle((PictureBox)sender);
                if (game.boardTriangles[clickedTriangleSaved]._numberOfPieces != 0 && MyTurn() == true && clickedTriangleSaved < 24)
                {
                    ColorLabelGreen();
                    clickContor++;
                }
                else if (game.boardTriangles[clickedTriangleSaved]._numberOfPieces != 0 && MyTurn() == true && clickedTriangleSaved > 23)

                    clickContor++;


            }
            if (RedHome() == false)
            {
                BlackHome();
            }
            else if (BlackHome() == false)
                RedHome();
            else RedHome();
        }

        private bool MyTurn()
        {
            if (game.players[0]._turn == true && game.boardTriangles[clickedTriangleSaved]._pieceColor == PieceColor.Red)
                return true;
            else if (game.players[1]._turn == true && game.boardTriangles[clickedTriangleSaved]._pieceColor == PieceColor.Black)
                return true;
            return false;
        }

        private void ColorLabelWhite()
        {
            if (clickedTriangleSaved < 24)
            {
                Label labelMatch = this.Controls.Find("label" + clickedTriangleSaved, true)[0] as Label;
                labelMatch.BackColor = System.Drawing.Color.White;
            }
        }

        private void ColorLabelGreen()
        {
            if (clickedTriangleSaved < 24)
            {
                Label labelMatch = this.Controls.Find("label" + clickedTriangleSaved, true)[0] as Label;
                labelMatch.BackColor = System.Drawing.Color.Lime;
            }
        }

        private bool BlackHome()
        {
            int homeOfBlackPieces = 0;
            for (int i = 18; i < 24; i++)
                if (game.boardTriangles[i]._pieceColor == PieceColor.Black)
                    homeOfBlackPieces += game.boardTriangles[i]._numberOfPieces;
            if (homeOfBlackPieces == blackPieces)
            {
                btnRetrievePiece.Visible = true;
                return true;
            }
            else
            {
                btnRetrievePiece.Visible = false;
                return false;
            }
        }

        private bool RedHome()
        {
            int homeOfRedPieces = 0;
            for (int i = 0; i < 6; i++)
                if (game.boardTriangles[i]._pieceColor == PieceColor.Red)
                    homeOfRedPieces += game.boardTriangles[i]._numberOfPieces;
            if (homeOfRedPieces == redPieces)
            {
                btnRetrievePiece.Visible = true;
                return true;
            }
            else
            {
                btnRetrievePiece.Visible = false;
                return false;
            }
        }

        private void btnRetrievePiece_Click(object sender, EventArgs e)
        {
            if (clickContor == 1 && game.players[0]._turn == true)
            {
                if (CheckOthersTrianglesIfEmpty(clickedTriangleSaved) == true)
                {
                    if (diceNumber1 == diceNumber2 && clickedTriangleSaved + 1 <= diceNumber1)
                        retrieve();
                    else if (clickedTriangleSaved + 1 <= diceNumber1 && diceMoves == 2)
                    {
                        nextDiceToMove = diceNumber2;
                        retrieve();
                    }
                    else if (clickedTriangleSaved + 1 <= diceNumber2 && diceMoves == 2)
                    {
                        nextDiceToMove = diceNumber1;
                        retrieve();
                    }
                    else if (diceMoves == 1 && clickedTriangleSaved + 1 <= nextDiceToMove)
                        retrieve();
                }
                else if (diceNumber1 == diceNumber2 && diceNumber1 == clickedTriangleSaved + 1)
                    retrieve();
                else if (diceNumber1 == clickedTriangleSaved + 1 && diceMoves == 2)
                {
                    nextDiceToMove = diceNumber2;
                    retrieve();
                }
                else if (diceNumber2 == clickedTriangleSaved + 1 && diceMoves == 2)
                {
                    nextDiceToMove = diceNumber1;
                    retrieve();
                }
                else if (diceMoves == 1 && nextDiceToMove == clickedTriangleSaved + 1)
                    retrieve();
            }

            else if (clickContor == 1 && game.players[1]._turn == true)
            {
                if (CheckOthersTrianglesIfEmpty(clickedTriangleSaved) == true)
                {
                    if (diceNumber1 == diceNumber2 && 24 - diceNumber1 <= clickedTriangleSaved)
                        retrieve();
                    else if (24 - diceNumber1 <= clickedTriangleSaved && diceMoves == 2)
                    {
                        nextDiceToMove = diceNumber2;
                        retrieve();
                    }
                    else if (24 - diceNumber2 <= clickedTriangleSaved && diceMoves == 2)
                    {
                        nextDiceToMove = diceNumber1;
                        retrieve();
                    }
                    else if (diceMoves == 1 && 24 - nextDiceToMove <= clickedTriangleSaved)
                        retrieve();
                }
                else if (diceNumber1 == diceNumber2 && 24 - diceNumber1 == clickedTriangleSaved)
                    retrieve();
                else if (24 - diceNumber1 == clickedTriangleSaved && diceMoves == 2)
                {
                    nextDiceToMove = diceNumber2;
                    retrieve();
                }
                else if (24 - diceNumber2 == clickedTriangleSaved && diceMoves == 2)
                {
                    nextDiceToMove = diceNumber1;
                    retrieve();
                }
                else if (diceMoves == 1 && 24 - nextDiceToMove == clickedTriangleSaved)
                    retrieve();

            }

            ColorLabelWhite();
            if (redPieces == 0)
            {
                MessageBox.Show(lPlayer1Name + "a castigat!");
                this.Close();
            }
            if (blackPieces == 0)
            {
                MessageBox.Show(lPlayer2Name + " a castigat!");
                this.Close();
            }
        }

        private void btnChangeTurn_Click(object sender, EventArgs e)
        {

            ChangeTurns();
        }

        private bool CheckOthersTrianglesIfEmpty(int currentTriangle)
        {
            if (game.players[0]._turn == true)
            {
                if (currentTriangle != 5)
                {
                    for (int i = 5; i > currentTriangle; i--)
                        if (game.boardTriangles[i]._numberOfPieces != 0)
                            return false;
                }
                else return false;
            }
            else if (currentTriangle != 18)
                for (int i = 18; i < currentTriangle; i++)
                {
                    if (game.boardTriangles[i]._numberOfPieces != 0)
                        return false;

                }
            else return false;

            return true;
        }

        private void retrieve()
        {
            ColorLabelWhite();
            game.boardTriangles[clickedTriangleSaved]._numberOfPieces--;
            diceMoves--;
            if (game.boardTriangles[clickedTriangleSaved]._pieceColor == PieceColor.Red)
                redPieces--;
            else
                blackPieces--;
            clickContor = 0;
            SendMessageToClient("4&" + clickedTriangleSaved.ToString() + "&" + redPieces.ToString() + "&" + blackPieces.ToString());
            if (diceMoves == 0)
            {
                diceMoves = 2;
                ChangeTurns();
            }
            panelTable.Refresh();
            btnRetrievePiece.Visible = false;
        }

        private void btnDeselectPiece_Click(object sender, EventArgs e)
        {
            clickContor = 0;
            ColorLabelWhite();
        }

        private int FindClickedTriangle(PictureBox clickedPictureBox)
        {
            for (int i = 0; i < game.boardTriangles.Length; i++)
            {
                if ((game.boardTriangles[i]._picture.Left <= clickedPictureBox.Left) && (game.boardTriangles[i]._picture.Top <= clickedPictureBox.Top) && (game.boardTriangles[i]._picture.Bottom >= clickedPictureBox.Bottom) && (game.boardTriangles[i]._picture.Right >= clickedPictureBox.Right))
                    return i;
            }
            return -1;
        }
    }
}
