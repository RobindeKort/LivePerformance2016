namespace LivePerformance2016
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSovon = new System.Windows.Forms.Label();
            this.cbxGebied = new System.Windows.Forms.ComboBox();
            this.cbxProject = new System.Windows.Forms.ComboBox();
            this.lblGebied = new System.Windows.Forms.Label();
            this.lblProject = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::LivePerformance2016.Properties.Resources.logo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(584, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 629);
            this.panel1.TabIndex = 0;
            // 
            // lblSovon
            // 
            this.lblSovon.AutoSize = true;
            this.lblSovon.Font = new System.Drawing.Font("Comic Sans MS", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSovon.Location = new System.Drawing.Point(143, 12);
            this.lblSovon.Name = "lblSovon";
            this.lblSovon.Size = new System.Drawing.Size(267, 111);
            this.lblSovon.TabIndex = 1;
            this.lblSovon.Text = "Sovon";
            this.lblSovon.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbxGebied
            // 
            this.cbxGebied.FormattingEnabled = true;
            this.cbxGebied.Location = new System.Drawing.Point(81, 253);
            this.cbxGebied.Name = "cbxGebied";
            this.cbxGebied.Size = new System.Drawing.Size(382, 24);
            this.cbxGebied.TabIndex = 2;
            this.cbxGebied.SelectedIndexChanged += new System.EventHandler(this.cbxGebied_SelectedIndexChanged);
            // 
            // cbxProject
            // 
            this.cbxProject.Enabled = false;
            this.cbxProject.FormattingEnabled = true;
            this.cbxProject.Location = new System.Drawing.Point(81, 378);
            this.cbxProject.Name = "cbxProject";
            this.cbxProject.Size = new System.Drawing.Size(382, 24);
            this.cbxProject.TabIndex = 3;
            this.cbxProject.SelectedIndexChanged += new System.EventHandler(this.cbxProject_SelectedIndexChanged);
            // 
            // lblGebied
            // 
            this.lblGebied.AutoSize = true;
            this.lblGebied.Location = new System.Drawing.Point(81, 230);
            this.lblGebied.Name = "lblGebied";
            this.lblGebied.Size = new System.Drawing.Size(54, 17);
            this.lblGebied.TabIndex = 4;
            this.lblGebied.Text = "Gebied";
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(81, 355);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(52, 17);
            this.lblProject.TabIndex = 5;
            this.lblProject.Text = "Project";
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(210, 443);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(118, 48);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Go!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 653);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.lblGebied);
            this.Controls.Add(this.cbxProject);
            this.Controls.Add(this.cbxGebied);
            this.Controls.Add(this.lblSovon);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Sovon Live Performance 2016 - Robin de Kort S24";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSovon;
        private System.Windows.Forms.ComboBox cbxGebied;
        private System.Windows.Forms.ComboBox cbxProject;
        private System.Windows.Forms.Label lblGebied;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Button btnStart;
    }
}

