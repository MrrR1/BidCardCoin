﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BidCardCoin.Crtl;
using BidCardCoin.ORM;
using BidCardCoin.Views;

namespace BidCardCoin.Vue
{
    public partial class Enchere : UserControl
    {
        public Enchere()
        {
            InitializeComponent();
            loadEncheres();
            loadLieux();
        }
        LieuViewModel myDataObjectLieu; // Objet de liaison avec la vue lors de l'ajout d'une Enchere par exemple.
        ObservableCollection<LieuViewModel> li;
        
        EnchereViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Enchere par exemple.
        ObservableCollection<EnchereViewModel> lp;
        int selectedEnchereId;
        
        void loadEncheres()
        {
            lp = EnchereORM.listeEncheres();
            myDataObject = new EnchereViewModel();
            //LIEN AVEC la VIEW
            listeEncheres.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        }
        
        void loadLieux()
        {
            li = LieuORM.listeLieux();
            myDataObjectLieu = new LieuViewModel();
            //LIEN AVEC la VIEW
            /*listeLieus.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            Ajout_enchere ucObj = new Ajout_enchere();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }

        private void listeEncheres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEncheres.SelectedIndex < lp.Count) && (listeEncheres.SelectedIndex >= 0))
            {
                selectedEnchereId = lp.ElementAt(listeEncheres.SelectedIndex).id;
            }
        }

        private void supprimerEnchere(object sender, RoutedEventArgs e)
        {
            if (listeEncheres.SelectedItem is EnchereViewModel)
            {
                EnchereViewModel toRemove = (EnchereViewModel)listeEncheres.SelectedItem;
                lp.Remove(toRemove);
                listeEncheres.Items.Refresh();
                EnchereORM.supprimerEnchere(selectedEnchereId);
            }
        }
        
    }
}