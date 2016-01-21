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

            foreach (Gebied g in admin.Gebieden)
            {
                if (p.GebiedID == g.ID)
                {
                    pnlKaart.BackgroundImage = Image.FromFile(g.KaartPath);
                    pnlKaart.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }

            cbxVogelSoort.DataSource = admin.Diersoorten;
            cbxWaarneming.DataSource = Enum.GetNames(typeof(CSharp.Type));

            int bezoekid = 1;
            foreach (Bezoek b in p.Bezoeken)
            {
                bezoekid++;
            }
            bezoek = new Bezoek(bezoekid, p.ID, DateTime.Now);
            p.AddBezoek(bezoek);
        }

        private void btnStoppen_Click(object sender, EventArgs e)
        {
            this.Close();
            mainform.Show();
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
        }

        private void pnlKaart_MouseMove(object sender, MouseEventArgs e)
        {
            lblXY.Text = "X:" + Convert.ToString(e.X) + " Y:" + Convert.ToString(e.Y);
        }
    }
}
