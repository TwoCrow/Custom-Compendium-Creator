using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Custom_Compendium_Creator.Commands;
using Custom_Compendium_Creator.Models;
using Custom_Compendium_Creator.Services;
using Microsoft.VisualStudio.PlatformUI;

namespace Custom_Compendium_Creator.View_Models
{
    public class FeatListViewModel : ViewModelBase
    {
        private Compendium compendium;
        private readonly ObservableCollection<FeatViewModel> feats;
        public IEnumerable<FeatViewModel> Feats => feats;

        public ICommand AddFeatCommand { get; }
        public ICommand ReturnCommand { get; } // Takes user to previous view.
        public ICommand EditFeatCommand { get; }
        public ICommand DeleteFeatCommand { get; }

        NavigationService featNavigationService;

        public FeatListViewModel(NavigationService featNavigationService, NavigationService compendiumNavigationService, Compendium compendium)
        {
            this.featNavigationService = featNavigationService;
            this.compendium = compendium;

            AddFeatCommand = new AddFeatCommand(featNavigationService);
            ReturnCommand = new NavigateCommand(compendiumNavigationService);
            EditFeatCommand = new DelegateCommand<FeatViewModel>(EditFeat);
            DeleteFeatCommand = new DelegateCommand<FeatViewModel>(RemoveFeatFromList);

            feats = new ObservableCollection<FeatViewModel>();

            UpdateFeats();
        }

        public void EditFeat(object obj)
        {
            ICommand NavigateAndEditCommand = new EditFeatCommand(featNavigationService, (FeatViewModel)obj);
            NavigateAndEditCommand.Execute(null);
            // Navigate to the Edit Feat VM
            // Pass it the information from the FeatViewModel to populate its fields
        }

        public void RemoveFeatFromList(object obj)
        {
            FeatViewModel featVM = (FeatViewModel)obj;
            feats.Remove(featVM);
            compendium.FeatList.RemoveFeat(featVM.Feat);
        }

        private void UpdateFeats()
        {
            feats.Clear();

            foreach (Feat feat in compendium.FeatList.GetAllFeats())
            {
                feats.Add(new FeatViewModel(feat));
            }
        }
    }
}
