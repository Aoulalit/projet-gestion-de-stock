using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace projet_gestion_de_stock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Code à exécuter lors du chargement de Form1
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Vous pouvez ajouter la logique de vérification du login ici
            // Pour l'instant, nous supposons que la vérification réussit
            // Créer une nouvelle instance du formulaire contenant le DataGridView
            Form2 mainForm = new Form2();

            // Cacher ce formulaire de connexion
            this.Hide();

            // Afficher le formulaire contenant le DataGridView
            mainForm.Show();
        }
    }
}
