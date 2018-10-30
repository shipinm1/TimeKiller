namespace MwCapture
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.Program1 = new System.Windows.Forms.PictureBox();
            this.showButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.exitButton = new System.Windows.Forms.Button();
            this.Program2 = new System.Windows.Forms.PictureBox();
            this.Program3 = new System.Windows.Forms.PictureBox();
            this.pauseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Program1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Program2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Program3)).BeginInit();
            this.SuspendLayout();
            // 
            // Program1
            // 
            this.Program1.Location = new System.Drawing.Point(17, 12);
            this.Program1.Name = "Program1";
            this.Program1.Size = new System.Drawing.Size(514, 368);
            this.Program1.TabIndex = 0;
            this.Program1.TabStop = false;
            // 
            // showButton
            // 
            this.showButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.showButton.Location = new System.Drawing.Point(1094, 38);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(90, 50);
            this.showButton.TabIndex = 1;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = false;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Red;
            this.exitButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(1109, 488);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 40);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "EXIT";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Program2
            // 
            this.Program2.Location = new System.Drawing.Point(581, 12);
            this.Program2.Name = "Program2";
            this.Program2.Size = new System.Drawing.Size(389, 256);
            this.Program2.TabIndex = 3;
            this.Program2.TabStop = false;
            // 
            // Program3
            // 
            this.Program3.Location = new System.Drawing.Point(581, 308);
            this.Program3.Name = "Program3";
            this.Program3.Size = new System.Drawing.Size(387, 241);
            this.Program3.TabIndex = 4;
            this.Program3.TabStop = false;
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pauseButton.Location = new System.Drawing.Point(1094, 94);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(90, 55);
            this.pauseButton.TabIndex = 5;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = false;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1252, 637);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.Program3);
            this.Controls.Add(this.Program2);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.Program1);
            this.Name = "Main";
            this.Text = "MwCapture";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Program1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Program2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Program3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Program1;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.PictureBox Program2;
        private System.Windows.Forms.PictureBox Program3;
        private System.Windows.Forms.Button pauseButton;
    }
}

