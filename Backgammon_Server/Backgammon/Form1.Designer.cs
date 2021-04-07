
namespace Backgammon
{
    partial class fMenu
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnInstruction = new System.Windows.Forms.Button();
            this.lLanguage = new System.Windows.Forms.Label();
            this.btnRomana = new System.Windows.Forms.Button();
            this.btnEnglish = new System.Windows.Forms.Button();
            this.btnPlayersImages = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(254, 68);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(131, 74);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnInstruction
            // 
            this.btnInstruction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F);
            this.btnInstruction.Location = new System.Drawing.Point(254, 281);
            this.btnInstruction.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInstruction.Name = "btnInstruction";
            this.btnInstruction.Size = new System.Drawing.Size(136, 72);
            this.btnInstruction.TabIndex = 1;
            this.btnInstruction.Text = "Instructiuni";
            this.btnInstruction.UseVisualStyleBackColor = true;
            // 
            // lLanguage
            // 
            this.lLanguage.AutoSize = true;
            this.lLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lLanguage.Location = new System.Drawing.Point(437, 41);
            this.lLanguage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lLanguage.Name = "lLanguage";
            this.lLanguage.Size = new System.Drawing.Size(38, 13);
            this.lLanguage.TabIndex = 2;
            this.lLanguage.Text = "Limba:";
            // 
            // btnRomana
            // 
            this.btnRomana.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRomana.Location = new System.Drawing.Point(496, 36);
            this.btnRomana.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRomana.Name = "btnRomana";
            this.btnRomana.Size = new System.Drawing.Size(35, 24);
            this.btnRomana.TabIndex = 3;
            this.btnRomana.Text = "Ro";
            this.btnRomana.UseVisualStyleBackColor = true;
            this.btnRomana.Click += new System.EventHandler(this.btnRomana_Click);
            // 
            // btnEnglish
            // 
            this.btnEnglish.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnglish.Location = new System.Drawing.Point(556, 36);
            this.btnEnglish.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.Size = new System.Drawing.Size(37, 24);
            this.btnEnglish.TabIndex = 4;
            this.btnEnglish.Text = "En";
            this.btnEnglish.UseVisualStyleBackColor = true;
            this.btnEnglish.Click += new System.EventHandler(this.btnEnglish_Click);
            // 
            // btnPlayersImages
            // 
            this.btnPlayersImages.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlayersImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btnPlayersImages.Location = new System.Drawing.Point(254, 175);
            this.btnPlayersImages.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPlayersImages.Name = "btnPlayersImages";
            this.btnPlayersImages.Size = new System.Drawing.Size(136, 72);
            this.btnPlayersImages.TabIndex = 5;
            this.btnPlayersImages.Text = "Imagini jucatori";
            this.btnPlayersImages.UseVisualStyleBackColor = true;
            this.btnPlayersImages.Click += new System.EventHandler(this.btnPlayersImages_Click);
            // 
            // fMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Backgammon.Properties.Resources.Menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(657, 427);
            this.Controls.Add(this.btnPlayersImages);
            this.Controls.Add(this.btnEnglish);
            this.Controls.Add(this.btnRomana);
            this.Controls.Add(this.lLanguage);
            this.Controls.Add(this.btnInstruction);
            this.Controls.Add(this.btnStart);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "fMenu";
            this.Text = "Intro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnInstruction;
        private System.Windows.Forms.Label lLanguage;
        private System.Windows.Forms.Button btnRomana;
        private System.Windows.Forms.Button btnEnglish;
        private System.Windows.Forms.Button btnPlayersImages;
    }
}

