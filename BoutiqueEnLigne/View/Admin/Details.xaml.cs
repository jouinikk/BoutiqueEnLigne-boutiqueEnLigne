using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoutiqueEnLigne.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BoutiqueEnLigne.DB;
namespace BoutiqueEnLigne.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Details : ContentPage
    {
        Commande c;
        private readonly DataBaseConnection dataBase = App.DataBase;
        public Details(Commande selected)
        {
            InitializeComponent();
            c = selected;
            LoadData();
            Id.Text = c.Id.ToString();
            ClientName.Text = c.NomClient;
        }

        public async void LoadData()
        {
            try
            {
                var list = await dataBase.ObtenirLignesCommande(c.Id);
                commandLinesListView.ItemsSource = list;
                Console.WriteLine("Items Count: " + list.Count); // Check if the list is not empty
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in LoadData: " + ex.Message);
            }
        }

    }
}