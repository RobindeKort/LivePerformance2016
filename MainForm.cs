using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LivePerformance2016.CSharp;
using LivePerformance2016.CSharp.Data;
using Oracle.ManagedDataAccess.Client;

namespace LivePerformance2016
{
    public partial class MainForm : Form
    {
        private Administratie admin;

        public MainForm()
        {
            InitializeComponent();
            //Database data = new Database();
            IData data = SetDataSource();

            try
            {
                admin = new Administratie(data);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(0);
            }
            catch (OracleException e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(0);
            }

            cbxGebied.DataSource = admin.Gebieden;
        }

        // Vraagt aan de gebruiker of hij on-/offline is
        private IData SetDataSource()
        {
            DialogResult dialogResult = MessageBox.Show("Heeft u verbinding met het internet?", "VerbindingsTest", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                return new Database();
            }
            else if (dialogResult == DialogResult.No)
            {
                return new XML();
            }
            return null;
        }
        
        private void cbxGebied_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnKaart.Enabled = false;
            cbxProject.Enabled = false;
            if (cbxGebied.SelectedIndex >= 0)
            {
                cbxProject.Enabled = true;
                Gebied g = (Gebied)cbxGebied.SelectedItem;
                cbxProject.DataSource = g.Projecten;
            }
        }

        private void cbxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnKaart.Enabled = false;
            if (cbxProject.SelectedIndex >= 0)
            {
                btnStart.Enabled = true;
                btnKaart.Enabled = true;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Project p = (Project)cbxProject.SelectedItem;
            BezoekForm bf = new BezoekForm(this, admin, p, false);
            this.Hide();
            bf.Show();
        }

        private void btnKaart_Click(object sender, EventArgs e)
        {
            Project p = (Project)cbxProject.SelectedItem;
            BezoekForm bf = new BezoekForm(this, admin, p, true);
            this.Hide();
            bf.Show();
        }
    }
}
