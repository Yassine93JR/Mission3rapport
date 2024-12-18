using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using gsbRapports;

namespace Mission3rapport
{
    public partial class ListeMedicament : Form
    {
        private gsbrapports2016Entities mesDonnees;
        private string familleSelectionnee;

        public ListeMedicament(gsbrapports2016Entities mesDonnees)
        {
            InitializeComponent();
            this.mesDonnees = mesDonnees;
            this.bdgMedicament.DataSource = mesDonnees.medicament.ToList();
            this.bdgMedocOfferts.DataSource = mesDonnees.offrir.ToList();

            this.familleSelectionnee = "";
        }

        public void MettreAJourMedicaments(List<medicament> medicaments)
        {
            this.dListeMedicaments.DataSource = medicaments;
        }

       

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            this.bdgMedicament.EndEdit();
            this.mesDonnees.SaveChanges();
            MessageBox.Show("Enregistrement validé");

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            FrmAjouterMedicament F2 = new FrmAjouterMedicament(this.mesDonnees);
            F2.Show();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            string familleAvantSuppression = familleSelectionnee;

            List<DataGridViewRow> lignesASupprimer = new List<DataGridViewRow>();

            foreach (DataGridViewRow ligne in dListeMedicaments.Rows)
            {
                DataGridViewCheckBoxCell celluleCheckBox = ligne.Cells["Sélectionner"] as DataGridViewCheckBoxCell;

                if (celluleCheckBox != null && Convert.ToBoolean(celluleCheckBox.Value))
                {
                    lignesASupprimer.Add(ligne);
                }
            }

            foreach (DataGridViewRow ligne in lignesASupprimer)
            {
                medicament medicamentASupprimer = ligne.DataBoundItem as medicament;

                if (medicamentASupprimer != null)
                {
                    mesDonnees.medicament.Remove(medicamentASupprimer);
                }
            }

            mesDonnees.SaveChanges();

            dListeMedicaments.Refresh();
            dListeMedicaments.Update();

            MessageBox.Show("Médicaments supprimés avec succès.");
        }

       

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bdgMedicament_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dListeMedicaments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListeMedicament_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {


        }
        private void listBoxMedicaments(object sender, EventArgs e)
        {

        }
    }
}
