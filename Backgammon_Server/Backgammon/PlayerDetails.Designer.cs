
namespace Backgammon
{
    partial class PlayerDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textPlayer1Name = new System.Windows.Forms.TextBox();
            this.fileDialogPlayer1 = new System.Windows.Forms.OpenFileDialog();
            this.fileDialogPlayer2 = new System.Windows.Forms.OpenFileDialog();
            this.btnUploadImage1 = new System.Windows.Forms.Button();
            this.pictureBoxPlayer1 = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // textPlayer1Name
            // 
            this.textPlayer1Name.Location = new System.Drawing.Point(151, 40);
            this.textPlayer1Name.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textPlayer1Name.Name = "textPlayer1Name";
            this.textPlayer1Name.Size = new System.Drawing.Size(116, 20);
            this.textPlayer1Name.TabIndex = 0;
            // 
            // fileDialogPlayer1
            // 
            this.fileDialogPlayer1.FileName = "openFileDialog1";
            // 
            // fileDialogPlayer2
            // 
            this.fileDialogPlayer2.FileName = "openFileDialog2";
            // 
            // btnUploadImage1
            // 
            this.btnUploadImage1.Location = new System.Drawing.Point(151, 97);
            this.btnUploadImage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUploadImage1.Name = "btnUploadImage1";
            this.btnUploadImage1.Size = new System.Drawing.Size(97, 20);
            this.btnUploadImage1.TabIndex = 2;
            this.btnUploadImage1.Text = "Incarca";
            this.btnUploadImage1.UseVisualStyleBackColor = true;
            this.btnUploadImage1.Click += new System.EventHandler(this.btnUploadImage1_Click);
            // 
            // pictureBoxPlayer1
            // 
            this.pictureBoxPlayer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxPlayer1.Location = new System.Drawing.Point(169, 172);
            this.pictureBoxPlayer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxPlayer1.Name = "pictureBoxPlayer1";
            this.pictureBoxPlayer1.Size = new System.Drawing.Size(79, 77);
            this.pictureBoxPlayer1.TabIndex = 4;
            this.pictureBoxPlayer1.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(162, 302);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(86, 37);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Inainte";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // PlayerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 379);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.pictureBoxPlayer1);
            this.Controls.Add(this.btnUploadImage1);
            this.Controls.Add(this.textPlayer1Name);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PlayerDetails";
            this.Text = "PlayerDetails";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textPlayer1Name;
        private System.Windows.Forms.OpenFileDialog fileDialogPlayer1;
        private System.Windows.Forms.OpenFileDialog fileDialogPlayer2;
        private System.Windows.Forms.Button btnUploadImage1;
        private System.Windows.Forms.PictureBox pictureBoxPlayer1;
        private System.Windows.Forms.Button btnNext;
    }
}