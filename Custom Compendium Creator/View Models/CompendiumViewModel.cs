using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Custom_Compendium_Creator.Commands;
using Custom_Compendium_Creator.Services;

namespace Custom_Compendium_Creator.View_Models
{
    public class CompendiumViewModel : ViewModelBase
    {
        private string compendiumName;
        public string CompendiumName
        {
            get
            {
                return compendiumName;
            }
            set
            {
                compendiumName = value;
                OnPropertyChanged(nameof(CompendiumName));
            }
        }

        public ICommand OpenFeatList { get; }

        public CompendiumViewModel(NavigationService featListNavigationService)
        {
            OpenFeatList = new NavigateCommand(featListNavigationService);
        }
    }
}
