using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projet_gestion_de_stock
{
    public partial class Form2 : Form
    {
        private readonly HttpClient _client;
        private bool dataLoaded = false;

        public Form2()
        {
            InitializeComponent();
            _client = new HttpClient();
        }
        
        private async void Form2_Load_1(object sender, EventArgs e)
        {
            if (!dataLoaded)
            {
                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("Nom", "Nom");
                dataGridView1.Columns.Add("Prix", "Prix");
                dataGridView1.Columns.Add("Image", "Image");
                dataGridView1.Columns.Add("Caracteristique", "Caractéristique");

                await ChargerDonneesProduits();
                dataLoaded = true;  // Set the flag to true after loading the data


            }


        }

        private async Task ChargerDonneesProduits()
        {
            if (dataLoaded)
            {
                return;
            }
            else
            {
                MessageBox.Show(dataLoaded.ToString());
                try
                {
                    HttpResponseMessage response = await _client.GetAsync("http://localhost:3001/produits");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        // Désérialisation de la réponse JSON en tant que tableau JSON
                        JArray produitsArray = JArray.Parse(responseBody);

                        MessageBox.Show(responseBody);
                        // Ajouter les produits au DataGridView
                        foreach (JObject produit in produitsArray)
                        {
                            int id = produit.Value<int>("id_produit");
                            string nom = produit.Value<string>("name");
                            decimal prix = produit.Value<decimal>("prix");
                            string image = produit.Value<string>("image");
                            string caracteristique = produit.Value<string>("caracteristique");
                            dataGridView1.Rows.Add(id, nom, prix, image, caracteristique);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la récupération des données : " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur s'est produite : " + ex.Message);
                }
            }
            
        }
    }
}
