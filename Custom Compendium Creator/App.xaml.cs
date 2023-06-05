using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Custom_Compendium_Creator.Models;
using Custom_Compendium_Creator.Services;
using Custom_Compendium_Creator.Stores;
using Custom_Compendium_Creator.View_Models;

namespace Custom_Compendium_Creator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Compendium compendium;
        private readonly NavigationStore navigationStore;

        public App()
        {
            compendium = new Compendium();
            navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            navigationStore.CurrentViewModel = CreateHomeViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        // Navigation Methods

        private HomeViewModel CreateHomeViewModel()
        {
            return new HomeViewModel(new NavigationService(navigationStore, CreateCompendiumViewModel));
        }

        private CompendiumViewModel CreateCompendiumViewModel()
        {
            return new CompendiumViewModel(new NavigationService(navigationStore, CreateFeatListViewModel));
        }

        private FeatListViewModel CreateFeatListViewModel()
        {
            return new FeatListViewModel(new NavigationService(navigationStore, CreateFeatViewModel), new NavigationService(navigationStore, CreateCompendiumViewModel), compendium);
        }

        private EditFeatViewModel CreateFeatViewModel()
        {
            return new EditFeatViewModel(new NavigationService(navigationStore, CreateFeatListViewModel), compendium);
        }
    }
}
