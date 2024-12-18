using Mission3rapport;
using System;
using System.Windows.Forms;

namespace gsbRapports
{
    public partial class FrmMenu : Form
    {
        private gsbrapports2016Entities mesDonnees;

        public FrmMenu()
        {
            this.InitializeComponent();
            this.mesDonnees = new gsbrapports2016Entities();
            this.IsMdiContainer = true;
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            // Ajouter dynamiquement un bouton au formulaire
            Button btnListeMedicament = new Button
            {
                Text = "Liste des Médicaments",
                Location = new System.Drawing.Point(20, 50), // Position du bouton
                Size = new System.Drawing.Size(150, 40), // Taille du bouton
                BackColor = System.Drawing.Color.LightBlue // Optionnel : style du bouton
            };

            // Ajouter un gestionnaire d'événements pour le clic sur le bouton
            btnListeMedicament.Click += BtnListeMedicament_Click;

            // Ajouter le bouton au formulaire
            this.Controls.Add(btnListeMedicament);
        }

        private void BtnListeMedicament_Click(object sender, EventArgs e)
        {
            try
            {
                // Ouvrir la fenêtre ListeMedicament
                ListeMedicament listeMedicamentForm = new ListeMedicament(this.mesDonnees);
                listeMedicamentForm.MdiParent = this; // Le définir comme enfant MDI
                listeMedicamentForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGererMedoc F3 = new FrmGererMedoc(this.mesDonnees);
            F3.MdiParent = this;
            F3.Show();
        }

        private void offrirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void offertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            medocOffert F3 = new medocOffert(this.mesDonnees);
            F3.MdiParent = this;
            F3.Show();
        }
    }
}
