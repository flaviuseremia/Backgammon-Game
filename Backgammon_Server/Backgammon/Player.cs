namespace Backgammon
{
    using System.Windows.Forms;

    public class Player
    {
        private string name;

        private PieceColor color;

        private PictureBox avatarPicture;

        private bool turn;

        public bool _turn
        {
            get { return turn; }
            set { turn = value; }
        }

        public Player()
        {

        }

        public Player(string name, bool turn, PieceColor color, PictureBox avatarPicture)
        {
            this.name = name;
            this.turn = turn;
            this.color = color;
            this.avatarPicture = avatarPicture;
        }
    }
}
