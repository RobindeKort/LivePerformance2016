using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LivePerformance2016.CSharp;
using LivePerformance2016.CSharp.Data;

namespace LivePerformance2016
{
    public partial class BezoekForm : Form
    {
        private MainForm mainform;
        private Administratie admin;
        private Project project;
        private Bezoek bezoek;
        private bool refresh;
        private bool fullkaart;

        public BezoekForm(MainForm m, Administratie a, Project p, bool fullkaart)
        {
            InitializeComponent();
            mainform = m;
            admin = a;
            project = p;
            this.fullkaart = fullkaart;
            refresh = true;

            // De kaart van het gebied laden
            foreach (Gebied g in admin.Gebieden)
            {
                if (project.GebiedID == g.ID)
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

            // Comboboxen disablen wanneer alleen de kaart bekeken wordt
            cbxVogelSoort.Enabled = true;
            cbxWaarneming.Enabled = true;
            if (fullkaart)
            {
                cbxVogelSoort.Enabled = false;
                cbxWaarneming.Enabled = false;
            }
        }

        // Stopt het bezoek
        private void btnStoppen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Slaat het bezoek op als het form wordt gesloten
        private void BezoekForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bezoek.DatumEind = DateTime.Now;
            admin.SaveBezoek(bezoek);
            admin.RefreshGebieden();
            mainform.Show();
        }

        // Maakt een nieuwe waarneming aan onder het huidige bezoek
        // wanneer er op de kaart geklikt wordt
        private void pnlKaart_MouseClick(object sender, MouseEventArgs e)
        {
            if (!fullkaart)
            {
                CSharp.Type type = CSharp.Type.VA;
                if (cbxWaarneming.SelectedText == "VA") { type = CSharp.Type.VA; }
                else if (cbxWaarneming.SelectedText == "TI") { type = CSharp.Type.TI; }
                else if (cbxWaarneming.SelectedText == "NI") { type = CSharp.Type.NI; }
                Waarneming waarneming = new Waarneming(0, bezoek.ID, type, e.X, e.Y,
                    (Diersoort) cbxVogelSoort.SelectedItem);
                bezoek.AddWaarneming(waarneming);
            
                refresh = true;
                pnlKaart.Refresh();
            }
        }

        // Tekent een label met bijbehorend symbool voor elke waarneming
        private void DrawLabel(Graphics g, Waarneming w)
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
                    g.DrawEllipse(Pens.Black, x - 2, y - 7, 26, 26);
                }
        }

        // Laat alle waarnemingen zien wanneer er op de knop kaart (MainForm)
        // is geklikt, en anders alleen de waarnemingen van het huidige bezoek
        private void pnlKaart_Paint(object sender, PaintEventArgs e)
        {
            if (refresh)
            {
                pnlKaart.Controls.Clear();
                if (fullkaart)
                {
                    foreach (Bezoek b in project.Bezoeken)
                    {
                        foreach (Waarneming w in b.Waarnemingen)
                        {
                            DrawLabel(e.Graphics, w);
                        }
                    }
                }
                else
                {
                    foreach (Waarneming w in bezoek.Waarnemingen)
                    {
                        DrawLabel(e.Graphics, w);
                    }
                }
                refresh = false;
            }
        }

        // Laat de coordinaten van de muis zien (op de kaart)
        private void pnlKaart_MouseMove(object sender, MouseEventArgs e)
        {
            lblXY.Text = "X:" + Convert.ToString(e.X) + " Y:" + Convert.ToString(e.Y);
        }

        private void label_Click(object sender, MouseEventArgs e)
        {
            Label l = (Label)sender;
            foreach (Bezoek b in project.Bezoeken)
            {
                foreach (Waarneming w in b.Waarnemingen)
                {
                    if (w.LocX == l.Location.X + (l.Width/2) &&
                        w.LocY == l.Location.Y + (l.Height/2))
                    {
                        MessageBox.Show(w.Diersoort.ToString() + " X:" + w.LocX.ToString() + " Y:" + w.LocY.ToString());
                    }
                }
            }
        }

        private void btnExporteer_Click(object sender, EventArgs e)
        {
            string path = @"Bestanden\Bezoek.xml";
            if (File.Exists(path))
            {
                if (admin.data.GetType() == typeof (Database))
                {
                    Bezoek b = new XML().GetBezoek();
                    admin.SaveBezoek(b);
                    File.Delete(path);
                    MessageBox.Show("Het bezoek is succesvol geexporteerd!");
                }
                else
                {
                    MessageBox.Show("Database is niet bereikbaar. \nGa online om het bezoek te exporteren. ");
                }
            }
            else
            {
                MessageBox.Show("Er is geen lokaal opgeslagen bezoek.");
            }
        }
    }
}
