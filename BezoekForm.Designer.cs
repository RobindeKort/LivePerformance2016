namespace LivePerformance2016
{
    partial class BezoekForm
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
            this.pnlKaart = new System.Windows.Forms.Panel();
            this.btnStoppen = new System.Windows.Forms.Button();
            this.cbxWaarneming = new System.Windows.Forms.ComboBox();
            this.lblWaarneming = new System.Windows.Forms.Label();
            this.cbxVogelSoort = new System.Windows.Forms.ComboBox();
            this.lblVogelsoort = new System.Windows.Forms.Label();
            this.lblXY = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlKaart
            // 
            this.pnlKaart.Location = new System.Drawing.Point(13, 13);
            this.pnlKaart.Name = "pnlKaart";
            this.pnlKaart.Size = new System.Drawing.Size(980, 628);
            this.pnlKaart.TabIndex = 0;
            this.pnlKaart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlKaart_MouseClick);
            this.pnlKaart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlKaart_MouseMove);
            // 
            // btnStoppen
            // 
            this.btnStoppen.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStoppen.Location = new System.Drawing.Point(1050, 596);
            this.btnStoppen.Name = "btnStoppen";
            this.btnStoppen.Size = new System.Drawing.Size(178, 45);
            this.btnStoppen.TabIndex = 1;
            this.btnStoppen.Text = "Stoppen";
            this.btnStoppen.UseVisualStyleBackColor = true;
            this.btnStoppen.Click += new System.EventHandler(this.btnStoppen_Click);
            // 
            // cbxWaarneming
            // 
            this.cbxWaarneming.FormattingEnabled = true;
            this.cbxWaarneming.Location = new System.Drawing.Point(999, 90);
            this.cbxWaarneming.Name = "cbxWaarneming";
            this.cbxWaarneming.Size = new System.Drawing.Size(271, 24);
            this.cbxWaarneming.TabIndex = 2;
            // 
            // lblWaarneming
            // 
            this.lblWaarneming.AutoSize = true;
            this.lblWaarneming.Location = new System.Drawing.Point(1000, 70);
            this.lblWaarneming.Name = "lblWaarneming";
            this.lblWaarneming.Size = new System.Drawing.Size(88, 17);
            this.lblWaarneming.TabIndex = 3;
            this.lblWaarneming.Text = "Waarneming";
            // 
            // cbxVogelSoort
            // 
            this.cbxVogelSoort.FormattingEnabled = true;
            this.cbxVogelSoort.Location = new System.Drawing.Point(999, 156);
            this.cbxVogelSoort.Name = "cbxVogelSoort";
            this.cbxVogelSoort.Size = new System.Drawing.Size(271, 24);
            this.cbxVogelSoort.TabIndex = 4;
            // 
            // lblVogelsoort
            // 
            this.lblVogelsoort.AutoSize = true;
            this.lblVogelsoort.Location = new System.Drawing.Point(1000, 136);
            this.lblVogelsoort.Name = "lblVogelsoort";
            this.lblVogelsoort.Size = new System.Drawing.Size(76, 17);
            this.lblVogelsoort.TabIndex = 5;
            this.lblVogelsoort.Text = "Vogelsoort";
            // 
            // lblXY
            // 
            this.lblXY.AutoSize = true;
            this.lblXY.Location = new System.Drawing.Point(1000, 13);
            this.lblXY.Name = "lblXY";
            this.lblXY.Size = new System.Drawing.Size(54, 17);
            this.lblXY.TabIndex = 6;
            this.lblXY.Text = "X:? Y:?";
            // 
            // BezoekForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 653);
            this.Controls.Add(this.lblXY);
            this.Controls.Add(this.lblVogelsoort);
            this.Controls.Add(this.cbxVogelSoort);
            this.Controls.Add(this.lblWaarneming);
            this.Controls.Add(this.cbxWaarneming);
            this.Controls.Add(this.btnStoppen);
            this.Controls.Add(this.pnlKaart);
            this.Name = "BezoekForm";
            this.Text = "BezoekForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BezoekForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlKaart;
        private System.Windows.Forms.Button btnStoppen;
        private System.Windows.Forms.ComboBox cbxWaarneming;
        private System.Windows.Forms.Label lblWaarneming;
        private System.Windows.Forms.ComboBox cbxVogelSoort;
        private System.Windows.Forms.Label lblVogelsoort;
        private System.Windows.Forms.Label lblXY;
    }
}