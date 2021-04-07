namespace Backgammon
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class PlayerDetails : Form
    {
        private fGame windowGame;
        public string imagePath;

        public PlayerDetails()
        {
            InitializeComponent();
        }

        //public PictureBox getPicture1
        //{
        //    get { return pictureBoxPlayer1; }
        //}

        public PictureBox getPicture2
        {
            get { return pictureBoxPlayer2; }
        }

        //public string getPlayer1Name
        //{
        //    get { return textPlayer1Name.Text; }
        //}

        public string getPlayer2Name
        {
            get { return textPlayer2Name.Text; }
        }

        //private void btnUploadImage1_Click(object sender, EventArgs e)
        //{
        //    fileDialogPlayer1.InitialDirectory = "D:\\C#\\Backgammon\\Backgammon\\Images";
        //    fileDialogPlayer1.Filter = "Image Files (*.jpg;*.jpeg;.*.gif; *.PNG)|*.jpg;*.jpeg;.*.gif;*.PNG";
        //    if (fileDialogPlayer1.ShowDialog() == DialogResult.OK)
        //    {
        //        pictureBoxPlayer1.BackgroundImage = new Bitmap(fileDialogPlayer1.FileName);
        //    }
        //}

        private void btnUploadImage2_Click(object sender, EventArgs e)
        {
            fileDialogPlayer2.InitialDirectory = "D:\\C#\\Backgammon\\Backgammon\\Images";
            fileDialogPlayer2.Filter = "Image Files (*.jpg;*.jpeg;.*.gif; *.PNG)|*.jpg;*.jpeg;.*.gif;*.PNG";
            if (fileDialogPlayer2.ShowDialog() == DialogResult.OK)
            {
                pictureBoxPlayer2.BackgroundImage = new Bitmap(fileDialogPlayer2.FileName);
                imagePath = fileDialogPlayer2.FileName;
                
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if ( textPlayer2Name.Text != null && pictureBoxPlayer2.BackgroundImage != null)
            {
                MessageBox.Show("Ai incarcat tot");
                windowGame = new fGame(getPicture2,getPlayer2Name,imagePath);
                windowGame.Show();
                this.DialogResult = DialogResult.Cancel;
                


            }
            else
                MessageBox.Show("Nu ai incarcat tot");
        }
    }
}
