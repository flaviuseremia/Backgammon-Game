
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
            this.textPlayer2Name = new System.Windows.Forms.TextBox();
            this.fileDialogPlayer1 = new System.Windows.Forms.OpenFileDialog();
            this.fileDialogPlayer2 = new System.Windows.Forms.OpenFileDialog();
            this.btnUploadImage2 = new System.Windows.Forms.Button();
            this.pictureBoxPlayer2 = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer2)).BeginInit();
            this.SuspendLayout();
            // 
            // textPlayer2Name
            // 
            this.textPlayer2Name.Location = new System.Drawing.Point(133, 42);
            this.textPlayer2Name.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textPlayer2Name.Name = "textPlayer2Name";
            this.textPlayer2Name.Size = new System.Drawing.Size(116, 20);
            this.textPlayer2Name.TabIndex = 1;
            // 
            // fileDialogPlayer1
            // 
            this.fileDialogPlayer1.FileName = "openFileDialog1";
            // 
            // fileDialogPlayer2
            // 
            this.fileDialogPlayer2.FileName = "openFileDialog2";
            // 
            // btnUploadImage2
            // 
            this.btnUploadImage2.Location = new System.Drawing.Point(133, 99);
            this.btnUploadImage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUploadImage2.Name = "btnUploadImage2";
            this.btnUploadImage2.Size = new System.Drawing.Size(97, 20);
            this.btnUploadImage2.TabIndex = 3;
            this.btnUploadImage2.Text = "Incarca";
            this.btnUploadImage2.UseVisualStyleBackColor = true;
            this.btnUploadImage2.Click += new System.EventHandler(this.btnUploadImage2_Click);
            // 
            // pictureBoxPlayer2
            // 
            this.pictureBoxPlayer2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxPlayer2.Location = new System.Drawing.Point(157, 174);
            this.pictureBoxPlayer2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxPlayer2.Name = "pictureBoxPlayer2";
            this.pictureBoxPlayer2.Size = new System.Drawing.Size(73, 77);
            this.pictureBoxPlayer2.TabIndex = 5;
            this.pictureBoxPlayer2.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(144, 295);
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
            this.ClientSize = new System.Drawing.Size(420, 379);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.pictureBoxPlayer2);
            this.Controls.Add(this.btnUploadImage2);
            this.Controls.Add(this.textPlayer2Name);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PlayerDetails";
            this.Text = "PlayerDetails";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textPlayer2Name;
        private System.Windows.Forms.OpenFileDialog fileDialogPlayer1;
        private System.Windows.Forms.OpenFileDialog fileDialogPlayer2;
        private System.Windows.Forms.Button btnUploadImage2;
        private System.Windows.Forms.PictureBox pictureBoxPlayer2;
        private System.Windows.Forms.Button btnNext;
    }
}