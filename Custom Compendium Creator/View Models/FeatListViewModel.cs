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

        public FeatListViewModel(NavigationService featNavigationService, NavigationService compendiumNavigationService, Compendium compendium)
        {
            //AddFeatCommand = new AddFeatCommand();
            //ReturnCommand = new ReturnCommand();
            //EditFeatCommand = new EditFeatCommand();
            //DeleteFeatCommand = new DeleteFeatCommand();

            AddFeatCommand = new NavigateCommand(featNavigationService);
            ReturnCommand = new NavigateCommand(compendiumNavigationService);

            this.compendium = compendium;

            feats = new ObservableCollection<FeatViewModel>();

            //feats.Add(new FeatViewModel(new Feat("Feat", "Summary", "Description")));
            //feats.Add(new FeatViewModel(new Feat("Murder Fucker", "You murder and then fuck", "Description")));
            //feats.Add(new FeatViewModel(new Feat("Kissy Fingers", "Make the boo boos go away", "Description")));
            //feats.Add(new FeatViewModel(new Feat("Pickle Eater", "You eat many, many pickles", "Description")));
            //feats.Add(new FeatViewModel(new Feat("Ticklish", "You're so ticklish! Ha ha ha!", "Description")));

            UpdateFeats();
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
