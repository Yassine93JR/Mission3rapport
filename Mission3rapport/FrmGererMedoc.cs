using Mission3rapport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;

namespace gsbRapports
{
    public partial class FrmGererMedoc : Form
    {
        private gsbrapports2016Entities mesDonnees;

        public FrmGererMedoc(gsbrapports2016Entities mesDonnees)
        {
            InitializeComponent();
            this.mesDonnees = mesDonnees;

            this.bdgGereMedoc.DataSource = mesDonnees.famille.ToList();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifie si les données sont bien initialisées
                if (this.mesDonnees == null)
                {
                    MessageBox.Show("Les données ne sont pas initialisées. Veuillez vérifier la connexion à la base de données.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Création du formulaire d'ajout de médicament
                FrmAjouterMedicament F2 = new FrmAjouterMedicament(this.mesDonnees);

                // Affichage du formulaire en mode modal
                if (F2.ShowDialog() == DialogResult.OK)
                {
                    // Mettre à jour la liste des médicaments après l'ajout
                    MettreAJourMedicaments(this.mesDonnees.medicament.ToList());
                }
            }
            catch (Exception ex)
            {
                // Gestion des erreurs
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MettreAJourMedicaments(List<medicament> medicaments)
        {
            throw new NotImplementedException();
        }

        private void btnAjouter_Click_1(object sender, EventArgs e)
        {

            FrmNouvelleFamille F2 = new FrmNouvelleFamille(this.mesDonnees);
            F2.Show();
        }

        private void FrmGererMedoc_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


}