﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BidCardCoin.Crtl;
using BidCardCoin.ORM;

namespace BidCardCoin.Views
{
    public partial class Produit : UserControl
    {
        public Produit()
        {
            InitializeComponent();
            
            loadProduits();

        }
        
        
        ProduitViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Produit par exemple.
        ObservableCollection<ProduitViewModel> lp;
        ObservableCollection<ProduitViewModel> lp2;
        
        CategorieProduitViewModel myDataObjectCP; // Objet de liaison avec la vue lors de l'ajout d'une Produit par exemple.
        ObservableCollection<CategorieProduitViewModel> cp;

        LotViewModel myDataObjectLot; // Objet de liaison avec la vue lors de l'ajout d'une Produit par exemple.
        ObservableCollection<LotViewModel> lo;
        int compteur = 0;

        int selectedProduitId;
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            Ajout_produit ucObj = new Ajout_produit();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }

        void BtnAfficherCat(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            //MessageBox.Show(TextboxProduit.Text);
            if (TextboxProduit.Text == "")
=======
            
            cp = CategorieProduitORM.getProduit_Categorie(Convert.ToInt32(ComboBoxProduit.SelectedValue.ToString()));

            if (cp == null)
>>>>>>> R1
            {
                MessageBox.Show("C'est nul");
            }
            else
            {
                cp = CategorieProduitORM.getProduit_Categorie(Convert.ToInt32(TextboxProduit.Text));
                myDataObjectCP = new CategorieProduitViewModel();
       
                listeCP.ItemsSource = cp;
       
                listeCP.DataContext = myDataObjectCP; 
       
                listeCP.Items.Refresh();    
            }
           
            
            
        }

        void loadProduits()
        {
            lp = ProduitORM.listeProduits();
            lp2 = ProduitORM.listeProduits();
            myDataObject = new ProduitViewModel();
            //LIEN AVEC la VIEW
            listeProduits.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
            ComboBoxProduit.ItemsSource = lp2;

        }

        private void listeCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeProduits.SelectedIndex < lp.Count) && (listeProduits.SelectedIndex >= 0))
            {
                selectedProduitId = lp.ElementAt(listeProduits.SelectedIndex).id;
            }
        }

        private void supprimerProduit(object sender, RoutedEventArgs e)
        {
            if (listeProduits.SelectedItem is ProduitViewModel)
            {
                ProduitViewModel toRemove = (ProduitViewModel)listeProduits.SelectedItem;
                lp.Remove(toRemove);
                listeProduits.Items.Refresh();
                ProduitORM.supprimerProduit(selectedProduitId);
            }
        }


        private void btnCatProd(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(myDataObject.id.ToString());
        }
    }
}