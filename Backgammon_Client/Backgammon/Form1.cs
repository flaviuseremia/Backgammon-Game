using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backgammon
{
    public partial class fMenu : Form
    {
        

        private PlayerDetails playerDetailsWindow;
        public fMenu()
        {
            InitializeComponent();
            playerDetailsWindow = new PlayerDetails();

        }
        private void btnEnglish_Click(object sender, EventArgs e)
        {
            btnInstruction.Text = "Instruction";
            lLanguage.Text = "Language:";
            btnPlayersImages.Text = "Players pictures";
        }
        private void btnRomana_Click(object sender, EventArgs e)
        {
            btnInstruction.Text = "Instructiuni";
            lLanguage.Text = "Limba:";
            btnPlayersImages.Text = "Imagini jucatori";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            playerDetailsWindow.ShowDialog();
            this.Hide();
        }

        private void btnPlayersImages_Click(object sender, EventArgs e)
        {

        }
    }
}
