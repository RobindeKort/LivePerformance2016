using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LivePerformance2016.CSharp;

namespace LivePerformance2016
{
    public partial class BezoekForm : Form
    {
        private MainForm mainform;
        private Administratie admin;
        private Bezoek bezoek;

        public BezoekForm(MainForm m, Administratie a, Project p)
        {
            InitializeComponent();
            mainform = m;
            admin = a;

            // De kaart van het gebied laden
            foreach (Gebied g in admin.Gebieden)
            {
                if (p.GebiedID == g.ID)
                {
                    pnlKaart.BackgroundImage = Image.FromFile(g.KaartPath);
                    pnlKaart.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }

            // Comboboxes vullen
            cbxVogelSoort.DataSource = admin.Diersoorten;
            cbxWaarneming.DataSource = Enum.GetNames(typeof(CSharp.Type));

            // Een nieuw bezoek starten
            int bezoekid = 1;
            if (p.Bezoeken != null)
            {
                foreach (Bezoek b in p.Bezoeken)
                {
                    bezoekid++;
                }
            }
            bezoek = new Bezoek(bezoekid, p.ID, DateTime.Now);
            p.AddBezoek(bezoek);
        }

        private void btnStoppen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BezoekForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bezoek.DatumEind = DateTime.Now;
            admin.SaveBezoek(bezoek);
            mainform.Show();
        }

        private void pnlKaart_MouseClick(object sender, MouseEventArgs e)
        {
            CSharp.Type type = CSharp.Type.VA;
            if (cbxWaarneming.SelectedText == "VA") { type = CSharp.Type.VA; }
            else if (cbxWaarneming.SelectedText == "TI") { type = CSharp.Type.TI; }
            else if (cbxWaarneming.SelectedText == "NI") { type = CSharp.Type.NI; }
            Waarneming waarneming = new Waarneming(0, bezoek.ID, type, e.X, e.Y,
                (Diersoort) cbxVogelSoort.SelectedItem);
            bezoek.AddWaarneming(waarneming);

            pnlKaart.Refresh();
        }

        private void pnlKaart_MouseMove(object sender, MouseEventArgs e)
        {
            lblXY.Text = "X:" + Convert.ToString(e.X) + " Y:" + Convert.ToString(e.Y);
        }

        private void pnlKaart_Paint(object sender, PaintEventArgs e)
        {
            if (bezoek.Waarnemingen != null)
            {
                foreach (Waarneming w in bezoek.Waarnemingen)
                {
                    Label l = new Label();
                    l.AutoSize = true;
                    l.Text = w.Diersoort.Afkorting;
                    l.Font = new Font(base.Font, FontStyle.Bold);
                    l.BackColor = System.Drawing.Color.Transparent;
                    l.MouseClick += new MouseEventHandler(label_Click);
                    pnlKaart.Controls.Add(l);
                    int x = w.LocX - (l.Width / 2);
                    int y = w.LocY - (l.Height / 2);
                    l.Location = new Point(x, y);

                    Graphics g = e.Graphics;
                    if (w.Type == CSharp.Type.VA)
                    {
                        g.DrawLine(Pens.Black, x, y - 5, x + 20, y - 5);
                    }
                    else if (w.Type == CSharp.Type.TI)
                    {
                        // Bij TI wordt er niks speciaals getekend
                    }
                    else if (w.Type == CSharp.Type.NI)
                    {
                        g.DrawEllipse(Pens.Black, x, y - 5, 20, 20);
                    }
                }
            }
        }

        private void label_Click(object sender, MouseEventArgs e)
        {
            Label l = (Label)sender;
            foreach (Waarneming w in bezoek.Waarnemingen)
            {
                if (w.LocX == l.Location.X + (l.Width/2) &&
                    w.LocY == l.Location.Y + (l.Height/2))
                {
                    MessageBox.Show(w.Diersoort.ToString() + " X:" + w.LocX + " Y:" + w.LocY);
                }
            }
        }
    }
}
